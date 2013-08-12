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
    /// Tests for the AssemblyDependencies class.
    /// </summary>
    [TestClass]
    public class AssemblyDependenciesTests
    {
        [TestMethod]
        public void Analyse_NullArgument_ThrowsException()
        {
            // Arrange
            IAssemblyDependencies assemblyDepencies = new AssemblyDependencies();
            // Act
            try
            {
                assemblyDepencies.Analyse(null);
                Assert.Fail("No exception thrown.");
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Analyse_AssemblyWithNoReferencies_HasNoDirectDependencies()
        {
            // Arrange
            Assembly assembly = new StubAssembly()
            {
                GetReferencedAssemblies01 = () => new AssemblyName[] { }
            };
            IAssemblyDependencies assemblyDepencies = new AssemblyDependencies();
            // Act
            assemblyDepencies.Analyse(assembly);
            var dependencies = assemblyDepencies.DirectDependencies.ToArray();
            // Assert
            Assert.AreEqual(0, dependencies.Count());
        }

        [TestMethod]
        public void Analyse_AssemblyWithOneReference_HasOneDirectDependency()
        {
            // Arrange
            var name = "EjC.Tests.Assembly01";
            var refencedassembly = new AssemblyName(name + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            Assembly assembly = new StubAssembly()
            {
                GetReferencedAssemblies01 = () => new AssemblyName[] { refencedassembly }
            };
            IAssemblyDependencies assemblyDepencies = new AssemblyDependencies();
            // Act
            assemblyDepencies.Analyse(assembly);
            var dependencies = assemblyDepencies.DirectDependencies.ToArray();
            // Assert
            Assert.AreEqual(1, dependencies.Count());
            Assert.AreEqual(name, dependencies[0]);
        }

        [TestMethod]
        public void Analyse_AssemblyWithMultipleReferences_HasOneDirectDependency()
        {
            // Arrange
            var name01 = "EjC.Tests.Assembly01";
            var name02 = "EjC.Tests.Assembly02";
            var name03 = "EjC.Tests.Assembly03";
            var refencedassembly01 = new AssemblyName(name01 + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            var refencedassembly02 = new AssemblyName(name02 + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            var refencedassembly03 = new AssemblyName(name03 + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            Assembly assembly = new StubAssembly()
            {
                GetReferencedAssemblies01 = () => new AssemblyName[] {
                    refencedassembly01,
                    refencedassembly02,
                    refencedassembly03}
            };
            IAssemblyDependencies assemblyDepencies = new AssemblyDependencies();
            // Act
            assemblyDepencies.Analyse(assembly);
            var dependencies = assemblyDepencies.DirectDependencies.ToArray();
            // Assert
            Assert.AreEqual(3, dependencies.Count());
            Assert.IsTrue(dependencies.Contains(name01));
            Assert.IsTrue(dependencies.Contains(name02));
            Assert.IsTrue(dependencies.Contains(name03));
        }
    }
}
