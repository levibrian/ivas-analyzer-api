terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 3.48.0"
    }
    random = {
      source  = "hashicorp/random"
      version = "~> 3.1.0"
    }
    archive = {
      source  = "hashicorp/archive"
      version = "~> 2.2.0"
    }
  }

  required_version = ">= 1.0"
}

resource "random_pet" "analyzer_bucket_name" {
  prefix = "analyzer-lambda-bucket"
  length = 4
}

resource "aws_s3_bucket" "analyzer_bucket" {
  bucket = random_pet.analyzer_bucket_name.id

  acl           = "private"
  force_destroy = true
}

resource "aws_s3_bucket_object" "analyzer_bucket_object" {
  bucket = aws_s3_bucket.analyzer_bucket.id

  key    = "ivas-analyzer.zip"
  source = data.archive_file.lambda_ivas_analyzer_zip.output_path

  etag = filemd5(data.archive_file.lambda_ivas_analyzer_zip.output_path)
}

resource "aws_lambda_function" "analyzer-lambda" {

  function_name = "ivas-analyzer"
  
  s3_bucket = aws_s3_bucket.analyzer_bucket.id
  s3_key    = aws_s3_bucket_object.analyzer_bucket_object.key

  runtime = "dotnetcore3.1"
  handler = "Ivas.Analyzer.Api::Ivas.Analyzer.Api.LambdaEntryPoint::FunctionHandlerAsync"

  source_code_hash = data.archive_file.lambda_ivas_analyzer_zip.output_base64sha256
  
  role = aws_iam_role.analyzer_lambda_execution_role.arn
}

resource "aws_cloudwatch_log_group" "analyzer_lambda_log_group" {
  name = "/aws/lambda/${aws_lambda_function.analyzer-lambda.function_name}"

  retention_in_days = 7
}

resource "aws_iam_role" "analyzer_lambda_execution_role" {
  name = "serverless_lambda"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [{
      Action = "sts:AssumeRole"
      Effect = "Allow"
      Sid    = ""
      Principal = {
        Service = "lambda.amazonaws.com"
      }
    }]
  })
}

resource "aws_iam_role_policy_attachment" "analyzer_lambda_policy" {
  role       = aws_iam_role.analyzer_lambda_execution_role.name
  policy_arn = "arn:aws:iam::aws:policy/service-role/AWSLambdaBasicExecutionRole"
}

resource "aws_apigatewayv2_api" "analyzer_api" {
  name          = "analyzer_serverless_api"
  protocol_type = "HTTP"
}

resource "aws_apigatewayv2_stage" "analyzer_api_stage" {
  api_id = aws_apigatewayv2_api.analyzer_api.id

  name        = "serverless_lambda_stage"
  auto_deploy = true

  access_log_settings {
    destination_arn = aws_cloudwatch_log_group.analyzer_api_log_group.arn

    format = jsonencode({
      requestId               = "$context.requestId"
      sourceIp                = "$context.identity.sourceIp"
      requestTime             = "$context.requestTime"
      protocol                = "$context.protocol"
      httpMethod              = "$context.httpMethod"
      resourcePath            = "$context.resourcePath"
      routeKey                = "$context.routeKey"
      status                  = "$context.status"
      responseLength          = "$context.responseLength"
      integrationErrorMessage = "$context.integrationErrorMessage"
    })
  }
}

resource "aws_apigatewayv2_integration" "analyzer_api_integration" {
  api_id = aws_apigatewayv2_api.analyzer_api.id

  integration_uri    = aws_lambda_function.analyzer-lambda.invoke_arn
  integration_type   = "AWS_PROXY"
  integration_method = "POST"
}

resource "aws_cloudwatch_log_group" "analyzer_api_log_group" {
  name = "/aws/api_gw/${aws_apigatewayv2_api.analyzer_api.name}"

  retention_in_days = 7
}

resource "aws_lambda_permission" "analyzer_api_principal" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = aws_lambda_function.analyzer-lambda.function_name
  principal     = "apigateway.amazonaws.com"

  source_arn = "${aws_apigatewayv2_api.analyzer_api.execution_arn}/*/*"
}