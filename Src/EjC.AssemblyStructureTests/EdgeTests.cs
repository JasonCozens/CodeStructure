using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjC.AssemblyStructure;

namespace EjC.AssemblyStructureTests
{
    [TestClass]
    public class EdgeTests
    {
        [TestMethod]
        public void NewEdge_ParentChildAreCorrect()
        {
            // Act
            var edge = new Edge<string>("Parent", "Child");
            // Assert
            Assert.AreEqual("Parent", edge.Parent);
            Assert.AreEqual("Child", edge.Child);
        }
    }
}
