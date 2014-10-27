using IoCBenchmark;
using SimpleInjector;

namespace SimpleInjectorTest
{
    public class SimpleInjectorAbstraction : IContainerAbstraction
    {
        private readonly Container _container = new Container();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            if (singleton)
            {
                _container.RegisterSingle<I, T>();
            }
            else
            {
                _container.Register<I, T>();
            }
        }

        public void Compile()
        {
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}
