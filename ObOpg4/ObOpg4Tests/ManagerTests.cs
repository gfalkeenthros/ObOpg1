using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObOpg4;
using ObOpg4.Managers;
using System.Collections.Generic;
using ObOpg1;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;

namespace ObOpg4Tests
{
    [TestClass]
    public class ManagerTests
    {
        private BeerManager _manager;
        private IReadOnlyCollection<Beer> _testList = new ReadOnlyCollection<Beer>(new List<Beer>()

        {
            new Beer(1,"Carlsberg", 15,5),
            new Beer(1,"Tuborg", 13.5,5),
            new Beer(1,"Corona", 20,8),
            new Beer(1,"Bud Light", 20,3)
        });

        [TestInitialize]
        public void Init()
        {
            _manager = new BeerManager(new List<Beer>(_testList));
        }

        [TestMethod]
        public void GetAll_ShouldReturnTestList()
        {
            var data = _manager.GetAll();
            CollectionAssert.AreEquivalent((ICollection)data, (ICollection)_testList);
        }

        [TestMethod]
        public void GetById_IdEquals1_ShouldReturnFirstElement()
        {
            
        }
    }
}
