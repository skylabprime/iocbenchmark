using IoCBenchmark;

namespace HiroTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Hiro", () => new HiroAbstraction());
        }
    }
}
