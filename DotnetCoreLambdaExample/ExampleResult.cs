namespace DotnetCoreLambdaExample
{
    public class ExampleResult
    {
        // the input that was passed in the request object
        public string MyProperty { get; set; }

        // a configured message that the Lambda will return
        public string Message { get; set; }

        // another configured message that the Lambda will return, quite possibly fetched from
        // a different configuration source
        public string AnotherMessage { get; set; }
    }
}