using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoGenLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Tests
{
    [TestClass()]
    public class BaseSpecieTests
    {
        [TestMethod()]
        public void LiveDieTest()
        {
            BaseSpecie specie = new BaseSpecie();
            Assert.IsTrue(specie.Live);
            specie.Kill();
            Assert.IsFalse(specie.Live);
        }
        [TestMethod()]
        public void DieWithoutEnergyFeed()
        {
            BaseSpecie specie = new BaseSpecie();
            specie.EnergyStored = 1000;
            specie.EnergyConsumption = 10;
            specie.Exists(10);
            Assert.IsTrue(specie.Live);
            specie.Exists(100);
            Assert.IsFalse(specie.Live);
        }
    }
}