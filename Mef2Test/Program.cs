using IoCBenchmark;

namespace Mef2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Mef2", () => new Mef2Abstraction());
        }
    }
}
