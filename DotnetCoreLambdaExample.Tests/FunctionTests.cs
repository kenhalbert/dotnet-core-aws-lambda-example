using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DotnetCoreLambdaExample;

namespace DotnetCoreLambdaExample.Tests
{
    public class FunctionTests
    {
        [Fact]
        public async Task Handle_Returns_Message_From_Example_Service()
        {
            var testMessage = "Hello, world!  Testing...";

            var exampleServiceMock = new Mock<IExampleService>();

            exampleServiceMock
                .Setup(m => m.GetMessageToReturn())
                .Returns(Task.FromResult(testMessage));

            // here we use the overloaded ctor to inject mocks
            var function = new Function(exampleServiceMock.Object, String.Empty);

            var result = await function.Handler(new ExampleEvent());

            // assert that the message we told the service mock to return is equal to the one
            // the function returns in the result.
            Assert.Equal(testMessage, result.Message);
        }
    }
}
