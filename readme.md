# dotnet-core-aws-lambda-example
A simple AWS Lambda function written in C#, with a unit test project.  This was written to demonstrate some patterns I've found to be useful in C# Lambda functions, and to serve as a starting point for developers who are new to developing C# Lambda functions and want to know how to solve problems like bootstrapping, dependency injection, and configuration in a serverless C# application.

Here are the most important patterns demonstrated here:
1. Using the default constructor of the Function class to bootstrap any services the function depends on.  I like to do things this way because it lets me use an overloaded constructor to inject mocks in unit tests.
2. Using the .NET Core configuration API (Microsoft.Extensions.Configuration) to read from both a local config file and Lambda environment variables to build the function's configuration object.

## Setup
### Prerequisites
Make sure you've installed a version of the .NET Core SDK that supports `netstandard2.1` for the Lambda function project and the unit test project).

### Building and deploying the Lambda function
1. Navigate to the directory the Lambda function's .csproj file is in (./DotnetCoreLambdaExample) and run `dotnet restore`
2. In the same directory, run `dotnet publish -o lambda`
3. Navigate to ./DotnetCoreLambdaExample/lambda and zip all the contents of the directory.  Keep the zip file somewhere safe for the next step...
4. Create a new Lambda function in the AWS Lambda console
    - When prompted to provide a zip file containing your Lambda's code, upload the zip file from step 3
    - Specify the handler as `DotnetCoreLambdaExample::DotnetCoreLambdaExample.Function::Handler`
    - Optionally provide a value for the `MessageToReturn` environment variable the code uses.  The value you set here will be included in the result of the Lambda invocation

## Running the Lambda function in AWS
After following the steps above to build & deploy the Lambda function, invoke it in the AWS Lambda Console using this event JSON:
`{ "myProperty": "Hello world!" } `

## Running the unit tests
1. Navigate to the directory the test project's .csproj file is in (./DotnetCoreLambdaExample.Tests) and run `dotnet restore`
2. In the same directory, run `dotnet test`
