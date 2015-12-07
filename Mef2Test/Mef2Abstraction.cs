using IoCBenchmark;
using System.Composition.Convention;
using System.Composition.Hosting;

namespace Mef2Test
{
    public class Mef2Abstraction : IContainerAbstraction
    {
        private CompositionHost container;
        private ConventionBuilder conventionBuilder = new ConventionBuilder();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            if (singleton)
            {
                conventionBuilder.ForType<T>().Export<I>().Shared();
            }
            else
            {
                conventionBuilder.ForType<T>().Export<I>();
            }
        }

        public void Compile()
        {
            var configuration = new ContainerConfiguration().WithAssembly(typeof(TestRunner).Assembly, conventionBuilder);
            container = configuration.CreateContainer();
        }

        public T Resolve<T>()
            where T : class
        {
            var export = container.GetExport<T>();
            return export;
        }
    }
}
