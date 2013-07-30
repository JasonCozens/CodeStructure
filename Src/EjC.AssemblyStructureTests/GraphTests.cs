using EjC.AssemblyStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructureTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void NewGraph_IsEmpty()
        {
            // Act
            IGraph<string> graph = new Graph<string>();
            // Assert
            Assert.AreEqual(0, graph.Nodes.Count());
            Assert.AreEqual(0, graph.Vertices.Count());
        }

        [TestMethod]
        public void AddVertices_NoChildren_ParentIsAddedAsNode()
        {
            IGraph<string> graph = new Graph<string>();
            // Act
            graph.AddVertices("Parent", new List<string>());
            // Assert
            Assert.AreEqual(1, graph.Nodes.Count());
            Assert.AreEqual(0, graph.Vertices.Count());
        }
    }
}
