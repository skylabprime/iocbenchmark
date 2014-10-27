using IoCBenchmark;

namespace StructureMapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("StructureMap", () => new StructureMapAbstraction());
        }
    }
}
