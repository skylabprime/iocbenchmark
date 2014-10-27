using Autofac;
using IoCBenchmark;

namespace AutofacTest
{
    public class AutofacAbstraction : IContainerAbstraction
    {
        private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();
        private IContainer _container;

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            var registration = _containerBuilder.RegisterType<T>().As<I>();
            if (singleton)
            {
                registration.SingleInstance();
            }
        }

        public void Compile()
        {
            _container = _containerBuilder.Build();
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
