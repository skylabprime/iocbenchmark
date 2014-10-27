using IoCBenchmark;
using StructureMap;

namespace StructureMapTest
{
    public class StructureMapAbstraction : IContainerAbstraction
    {
        private readonly Container _container = new Container();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            _container.Configure(x =>
                                 {
                                     var registration = x.For<I>();
                                     if (singleton)
                                     {
                                         registration = registration.Singleton();
                                     }
                                     registration.Use<T>();
                                 });
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
