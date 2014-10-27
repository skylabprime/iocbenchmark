using IoCBenchmark;

namespace SimpleInjectorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("SimpleInjector", () => new SimpleInjectorAbstraction());
        }
    }
}
