using System.Threading.Tasks;

namespace DotnetCoreLambdaExample
{
    // example service implementation used to illustrate DI and configuration in C# Lambda functions
    public class ExampleService : IExampleService
    {
        private readonly string messageToReturn;

        public ExampleService(string messageToReturn)
        {
            this.messageToReturn = messageToReturn;
        }

        // Just returns the message the service was configured with.
        public async Task<string> GetMessageToReturn()
            => this.messageToReturn;
    }
}