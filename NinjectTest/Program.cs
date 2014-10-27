using IoCBenchmark;

namespace NinjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Ninject", () => new NinjectAbstraction());
        }
    }
}
