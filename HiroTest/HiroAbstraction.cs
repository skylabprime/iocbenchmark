using Hiro;
using Hiro.Containers;
using IoCBenchmark;

namespace HiroTest
{
    public class HiroAbstraction : IContainerAbstraction
    {
        private readonly DependencyMap _map = new DependencyMap();
        private IMicroContainer _container;

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            if (singleton)
            {
                _map.AddSingletonService<I, T>();
            }
            else
            {
                _map.AddService<I, T>();
            }
        }

        public void Compile()
        {
            _container = _map.CreateContainer();
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}
