using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using System.Reflection.Fakes;
using System.Reflection;
using EjC.AssemblyStructure;

namespace EjC.AssemblyStructureTests
{
    /// <summary>
    /// Summary description for AssemblyDepenciesTests
    /// </summary>
    [TestClass]
    public class AssemblyDependenciesTests
    {
        [TestMethod]
        public void Analyse_AssemblyWithNoReferencies_HasNoDirectDependencies()
        {
            // Arrange
            Assembly assembly = new StubAssembly();
            IAssemblyDependencies assemblyDepencies = new AssemblyDependencies();
            // Act
            assemblyDepencies.Analyse(assembly);
            // Assert
            Assert.AreEqual(0, assemblyDepencies.DirectDependencies.ToArray().Count());
        }
    }
}
