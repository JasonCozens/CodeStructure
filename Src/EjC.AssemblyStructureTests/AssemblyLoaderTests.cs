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
        public void New_AssemblyLoadedIsFalse_GetAssembkyThrowsException()
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
    }
}
