using IoCBenchmark;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;

namespace Mef2Test
{
    public class MefAbstraction : IContainerAbstraction
    {
        private RegistrationBuilder registrationBuilder = new RegistrationBuilder();
        private CompositionContainer container;

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            if (singleton)
            {
                registrationBuilder.ForType<T>().Export<I>().SetCreationPolicy(CreationPolicy.Shared);
            }
            else
            {
                registrationBuilder.ForType<T>().Export<I>().SetCreationPolicy(CreationPolicy.NonShared);
            }
        }

        public void Compile()
        {
            var catalog = new AssemblyCatalog(typeof(TestRunner).Assembly, registrationBuilder);
            container = new CompositionContainer(catalog);
        }

        public T Resolve<T>()
            where T : class
        {
            return container.GetExportedValue<T>();
        }
    }
}
