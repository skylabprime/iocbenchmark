using IoCBenchmark;

namespace UnityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestRunner().Run("Unity", () => new UnityAbstraction());
        }
    }
}
