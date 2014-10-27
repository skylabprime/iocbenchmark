using Dynamo.Ioc;
using IoCBenchmark;

namespace DynamoTest
{
    public class DynamoAbstraction : IContainerAbstraction
    {
        private readonly IocContainer _container = new IocContainer();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            ILifetime lifetime = null;
            if (singleton)
            {
                lifetime = new ContainerLifetime();
            }
            _container.Register<I, T>(lifetime);
        }

        public void Compile()
        {
            _container.Compile();
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
