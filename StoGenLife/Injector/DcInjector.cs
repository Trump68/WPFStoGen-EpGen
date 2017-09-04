using Ninject;
using StoGenLife.Specie;
using StoGenLife.Specie.EnergySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Injector
{
    public static class DcInjector
    {
        private static IKernel Kernel;

        static DcInjector()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }
        public static object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public static IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        private static void AddBindings()
        {
            Kernel.Bind<IBaseSpecieEnergyStorage>().To<DefaultBaseSpecieEnergyStorage>();
            Kernel.Bind<IBaseSpecieEnergySystem>().To<DefaultBaseSpecieEnergySystem>();
            Kernel.Bind<IBaseFoodDigestionSystem>().To<DefaultBaseFoodDigestionSystem>();
            
        }
    }
}
