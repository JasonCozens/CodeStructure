using EjC.AssemblyStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructureTests
{
    [TestClass]
    public class AssemblyLoaderTests
    {
        [TestMethod]
        public void New_AssemblyLoadedIsFalse_GetAssemblyThrowsException()
        {
            // Act
            IAssemblyLoader assemblyLoader = new AssemblyLoader();
            // Assert
            Assert.AreEqual(false, assemblyLoader.AssemblyLoaded);
            try
            {
                var assembly = assemblyLoader.Assembly;
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void ReflectionLoad_FileNotFound_AssemblyLoadedIsFalse()
        {
            // Arrange.
            IAssemblyLoader assemblyLoader = new AssemblyLoader();
            // Act
            assemblyLoader.RefeflectionOnly("XXX");
            // Assert
            Assert.AreEqual(false, assemblyLoader.AssemblyLoaded);
            try
            {
                var assembly = assemblyLoader.Assembly;
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }
    }
}
