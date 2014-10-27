using System;
using System.Diagnostics;

namespace IoCBenchmark
{
    public class TestRunner
    {
        public void Run(string name, Func<IContainerAbstraction> containerFactory)
        {
            var totalStopwatch = new Stopwatch();
            var buildStopwatch = new Stopwatch();
            var resolveStopwatch = new Stopwatch();

            Console.WriteLine("Testing: " + name);

            totalStopwatch.Start();

            buildStopwatch.Start();
            var container = containerFactory();
            ContainerRegistrations.Register(container);
            container.Compile();
            buildStopwatch.Stop();

            Console.WriteLine("Build time: " + buildStopwatch.Elapsed);

            resolveStopwatch.Start();
            Resolver.ResolveAll(container);
            resolveStopwatch.Stop();

            totalStopwatch.Stop();

            Console.WriteLine("Resolve time: " + resolveStopwatch.Elapsed);
            Console.WriteLine("Total time: " + totalStopwatch.Elapsed);
        }
    }
}
