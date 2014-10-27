using IoCBenchmark;
using Microsoft.Practices.Unity;

namespace UnityTest
{
    public class UnityAbstraction : IContainerAbstraction
    {
        private readonly UnityContainer _container = new UnityContainer();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            if (singleton)
            {
                _container.RegisterType<I, T>(new ContainerControlledLifetimeManager());
            }
            else
            {
                _container.RegisterType<I, T>();
            }
        }

        public void Compile()
        {
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
