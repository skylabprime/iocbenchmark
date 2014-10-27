using IoCBenchmark;

namespace CastleWindsorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Castle Windsor", () => new CastleWindsorAbstraction());
        }
    }
}
