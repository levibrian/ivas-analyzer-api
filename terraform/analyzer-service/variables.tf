variable "aws_region" {
  description = "AWS region for all resources."

  type    = string
  default = "eu-west-1"
}

variable "aws_profile" {
  description = "AWS profile for all resources."
  
  type = string
  default = "default"
}