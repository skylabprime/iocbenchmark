using IoCBenchmark;

namespace AutofacTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Autofac", () => new AutofacAbstraction());
        }
    }
}
