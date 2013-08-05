using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EjC.AssemblyStructureTests
{
    [TestClass]
    public class ConcurrentBagTests
    {
        /// <summary>
        /// This is a Bag not a Set.
        /// </summary>
        [TestMethod]
        public void AddItemTwice()
        {
            var bag = new ConcurrentBag<string>();
            bag.Add("TEST");
            bag.Add("TEST");
            Assert.AreEqual(2, bag.Count);
        }
    }
}
