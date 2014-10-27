using IoCBenchmark;

namespace DynamoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Dynamo", () => new DynamoAbstraction());
        }
    }
}
