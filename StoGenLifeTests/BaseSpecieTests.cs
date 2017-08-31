using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoGenLife;
using StoGenLife.Specie;
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
            BaseSpecieBody specie = new BaseSpecieBody();
            Assert.IsTrue(specie.Live);
            specie.Kill();
            Assert.IsFalse(specie.Live);
        }      
    }
}