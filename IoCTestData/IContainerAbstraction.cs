namespace IoCBenchmark
{
    public interface IContainerAbstraction
    {
        void Register<I, T>(bool singleton)
            where I : class
            where T : class, I;

        void Compile();

        T Resolve<T>()
            where T : class;
    }
}
