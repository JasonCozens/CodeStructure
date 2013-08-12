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
        public void ReflectionLoad_EmptyString_ThrowsNullArgumentException()
        {
            // Arrange
            IAssemblyLoader assemblyLoader = new AssemblyLoader();
            // Act
            try
            {
                assemblyLoader.RefeflectionOnly("");
                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void ReflectionLoad_FileNotFound_AssemblyLoadedIsFalse()
        {
            // Arrange
            IAssemblyLoader assemblyLoader = new AssemblyLoader();
            // Act
            assemblyLoader.RefeflectionOnly("XXX");
            // Assert
            Assert.AreEqual("XXX", assemblyLoader.Name);
            Assert.AreEqual(false, assemblyLoader.AssemblyLoaded);
            try
            {
                var assembly = assemblyLoader.Assembly;
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        /// <summary>
        /// It is necessary to use a real assembly here as it is not posssible
        /// to Shim Assembly and call the static method ReflectionOnlyLoad.
        /// </summary>
        [TestMethod]
        public void ReflectiionLoad_AssemblyLoaded()
        {
            // Arrange.
            IAssemblyLoader assemblyLoader = new AssemblyLoader();
            var name = Assembly.GetExecutingAssembly().GetName().Name;
            // Act
            assemblyLoader.RefeflectionOnly(name);
            // Assert
            Assert.AreEqual(name, assemblyLoader.Name);
            Assert.AreEqual(true, assemblyLoader.AssemblyLoaded);
            Assert.IsNotNull(assemblyLoader.Assembly);
        }
    }
}
