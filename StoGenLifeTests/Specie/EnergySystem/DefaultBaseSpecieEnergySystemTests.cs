using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoGenLife.Enviroment;
using StoGenLife.Injector;
using StoGenLife.Specie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Specie.Tests
{
    [TestClass()]
    public class DefaultBaseSpecieEnergySystemTests
    {
        private IBaseSpecieEnergySystem CreateSystem()
        {
            IBaseSpecieEnergySystem result = DcInjector.GetService(typeof(IBaseSpecieEnergySystem)) as IBaseSpecieEnergySystem;
            return result;
        }

        [TestMethod()]
        public void MainTest()
        {
            IBaseSpecieEnergySystem system = CreateSystem();
            system.InitDefault();
            system.TryFeed(300);

            DateTime startT = World.GameTime;
            int i = 0;
            while (!system.IsEmpty())
            {
                i++;
                system.TryGet(5);
                World.GameTime =  World.GameTime.AddHours(1);
            }

            DateTime startE = World.GameTime;
            Assert.IsTrue(i == 60);
        }

    }
}