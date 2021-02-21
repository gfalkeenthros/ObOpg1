using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObOpg1;
using System;

namespace ObOpg1Test
{
    [TestClass]
    public class UnitTest1
    {
        private Beer _beer;

        [TestInitialize]
        public void Init()
        {
            _beer = new Beer(1,"Carlsberg", 18, 5);
        }

        [TestMethod]
        public void Name_TooShortName_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() => _beer.Name = "C");
        }

        [TestMethod]
        public void Name_EmptyName_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() => _beer.Name = "");
        }

        [TestMethod]
        public void Name_ValidName_ShouldBeSet()
        {
            _beer.Name = "Tuborg";
            Assert.AreEqual(_beer.Name, "Tuborg");
        }

        [TestMethod]
        public void Price_LessThanZero_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() => _beer.Price = -1);
        }

        [TestMethod]
        public void Price_EqualsZero_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() => _beer.Price = 0);
        }

        [TestMethod]
        public void Price_ValidPrice_ShouldBeSet()
        {
            _beer.Price = 15;
            Assert.AreEqual(_beer.Price, 15);
        }

        [TestMethod]
        public void ABC_LessThanZero_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _beer.ABV = -1);
        }

        [TestMethod]
        public void ABV_GreaterThan100_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _beer.ABV= 101);
        }

        [TestMethod]
        public void ABV_ValidABV_ShouldBeSet()
        {
            _beer.ABV = 9;
            Assert.AreEqual(_beer.ABV, 9);
        }
    }
}
