namespace DotnetCoreLambdaExample
{
    public static class ExampleServiceBootstrapper
    {
        // Creates an ExampleService instance with configuration fetched from an environment variable.
        // Static bootstrapping methods like these are useful if you need more than one line of code to 
        // instantiate a dependency.
        public static IExampleService CreateInstance()
        {
            var messageToReturn = LambdaConfiguration.Instance["MessageToReturn"];

            return new ExampleService(messageToReturn);
        }
    }
}