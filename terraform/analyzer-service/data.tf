data "archive_file" "lambda_ivas_analyzer_zip" {
  type = "zip"

  //  source_dir  = "${path.module}/ivas-analyzer"
  source_dir = "../bin/Release/net5.0/linux-x64/publish"
  output_path = "${path.module}/ivas-analyzer.zip"
}