using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IoCBenchmark;

namespace CastleWindsorTest
{
    public class CastleWindsorAbstraction : IContainerAbstraction
    {
        private readonly WindsorContainer _container = new WindsorContainer();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            var registration = Component.For<I>().ImplementedBy<T>();
            if (singleton)
            {
                registration = registration.LifestyleSingleton();
            }
            else
            {
                registration = registration.LifestyleTransient();
            }
            _container.Register(registration);
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
