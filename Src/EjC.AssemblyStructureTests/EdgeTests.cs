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
        private const string NoExceptionThrownMessage = "No exception thrown.";

        [TestMethod]
        public void Newedge_ParentIsNull_ThrowsArgumentNullException()
        {
            try
            {
                new Edge<string>(null, "child");
                Assert.Fail(NoExceptionThrownMessage);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("parent", ex.ParamName);
            }
        }

        [TestMethod]
        public void Newedge_ChildIsNull_ThrowsArgumentNullException()
        {
            try
            {
                new Edge<string>("parent", null);
                Assert.Fail(NoExceptionThrownMessage);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("child", ex.ParamName);
            }
        }

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
