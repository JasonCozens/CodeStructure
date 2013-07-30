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
    public class VertexTests
    {
        [TestMethod]
        public void NewVertex_ParentChildAreCorrect()
        {
            // Act
            var vertex = new Vertex<string>("Parent", "Child");
            // Assert
            Assert.AreEqual("Parent", vertex.Parent);
            Assert.AreEqual("Child", vertex.Child);
        }
    }
}
