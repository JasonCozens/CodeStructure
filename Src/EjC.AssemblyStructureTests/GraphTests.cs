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
            Assert.AreEqual("Parent", graph.Nodes.First());
            Assert.AreEqual(0, graph.Vertices.Count());
        }

        [TestMethod]
        public void AddVertices_AddParentTwice_OnlyOneNode()
        {
            IGraph<string> graph = new Graph<string>();
            // Act
            graph.AddVertices("Parent", new List<string>());
            graph.AddVertices("Parent", new List<string>());
            // Assert
            Assert.AreEqual(1, graph.Nodes.Count());
            Assert.AreEqual("Parent", graph.Nodes.First());
            Assert.AreEqual(0, graph.Vertices.Count());
        }

        [TestMethod]
        public void AddVertices_AddChildTwice_OnlyOneNode()
        {
            IGraph<string> graph = new Graph<string>();
            // Act
            graph.AddVertices("ParentX", new List<string>() { "Child" });
            graph.AddVertices("ParentY", new List<string>() { "Child" });
            // Assert
            Assert.AreEqual(3, graph.Nodes.Count());
            Assert.AreEqual(2, graph.Vertices.Count());
            Assert.IsTrue(graph.Nodes.Contains("ParentX"));
            Assert.IsTrue(graph.Nodes.Contains("ParentY"));
            Assert.IsTrue(graph.Nodes.Contains("Child"));
        }

        [TestMethod]
        public void AddVertices_OneChild_NodesAndVerticesAreCorrect()
        {
            IGraph<string> graph = new Graph<string>();
            // Act
            graph.AddVertices("Parent", new List<string>() { "Child" } );
            // Assert
            Assert.AreEqual(2, graph.Nodes.Count());
            Assert.IsTrue(graph.Nodes.Contains("Parent"));
            Assert.IsTrue(graph.Nodes.Contains("Child"));
            var vertex = graph.Vertices.First();
            Assert.AreEqual(1, graph.Vertices.Count());
            Assert.AreEqual("Parent", vertex.Parent);
            Assert.AreEqual("Child", vertex.Child);
        }
    }
}
