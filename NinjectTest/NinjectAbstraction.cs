using System;
using System.Collections.Generic;
using IoCBenchmark;
using Ninject;
using Ninject.Modules;

namespace NinjectTest
{
    public class NinjectAbstraction : IContainerAbstraction
    {
        private readonly NinjectTestModule _module = new NinjectTestModule();
        private readonly StandardKernel _kernel = new StandardKernel();

        public void Register<I, T>(bool singleton)
            where I : class
            where T : class, I
        {
            _module.Maps.Add(new Tuple<Type, Type, bool>(typeof (I), typeof (T), singleton));
        }

        public void Compile()
        {
            _kernel.Load(_module);
        }

        public T Resolve<T>()
            where T : class
        {
            return _kernel.Get<T>();
        }


        private class NinjectTestModule : NinjectModule
        {
            public readonly List<Tuple<Type, Type, bool>> Maps = new List<Tuple<Type, Type, bool>>();

            public override void Load()
            {
                foreach (var tuple in Maps)
                {
                    var binding = Bind(tuple.Item1).To(tuple.Item2);
                    if (tuple.Item3)
                    {
                        binding.InSingletonScope();
                    }
                    else
                    {
                        binding.InTransientScope();
                    }
                }
            }
        }
    }
}
