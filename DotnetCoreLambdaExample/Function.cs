using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace DotnetCoreLambdaExample
{
    public class Function
    {
        private readonly IExampleService exampleService;
        private readonly string anotherMessageToReturn;
        
        // Use this ctor to bootstrap the Lambda's dependencies and fetch any configuration it needs.
        // If you have a service that can't (or shouldn't) be created/configured in one line of code, create a static
        // bootstrapper method like the one for ExampleService below.
        public Function()
            : this (ExampleServiceBootstrapper.CreateInstance(),
                LambdaConfiguration.Instance["AnotherMessage"]) {}

        // Use this ctor to inject mocks in unit tests.
        public Function(IExampleService exampleService, string anotherMessageToReturn)
        {
            this.exampleService = exampleService;
            this.anotherMessageToReturn = anotherMessageToReturn;
        }

        // This attribute tells the Lambda runtime how to serialize & deserialize event and result types.
        // It can go anywhere in the assembly; this is just a natural place to put it.
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public async Task<ExampleResult> Handler(ExampleEvent lambdaEvent)  // Notice that Lambda handler methods can be marked as async 
        {
            var message = await this.exampleService.GetMessageToReturn();

            return new ExampleResult 
            { 
                MyProperty = lambdaEvent.MyProperty, 
                Message = message, 
                AnotherMessage = this.anotherMessageToReturn
            };
        }
    }
}
