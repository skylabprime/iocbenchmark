using System;
using System.Diagnostics;
using System.IO;

namespace TestAll
{
    class Program
    {
        static void Main(string[] args)
        {
            const string build = "Release";

            RunProcess("NinjectTest", build);
            RunProcess("StructureMapTest", build);
            RunProcess("AutofacTest", build);
            RunProcess("CastleWindsorTest", build);
            RunProcess("UnityTest", build);
          //     RunProcess("HiroTest", build);
            //    RunProcess("DynamoTest", build);
            RunProcess("SimpleInjectorTest", build);
            RunProcess("MefTest", build);
            RunProcess("Mef2Test", build);

            Console.Read();
        }

        static void RunProcess(string name, string build)
        {
            var path = String.Format(@"..\..\..\{0}\Bin\{1}\{0}.exe", name, build);
            var fullPath = Path.Combine(Environment.CurrentDirectory, path);
            var stopwatch = Stopwatch.StartNew();
            var p = Process.Start(fullPath);
            p.WaitForExit();
            stopwatch.Stop();
            Console.WriteLine(name + ": " + stopwatch.Elapsed);
        }
    }
}
