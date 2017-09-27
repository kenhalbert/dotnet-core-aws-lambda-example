using System.Threading.Tasks;

namespace DotnetCoreLambdaExample
{
    // example interface used to illustrate DI in C# Lambda functions
    public interface IExampleService
    {
        Task<string> GetMessageToReturn();
    }
}