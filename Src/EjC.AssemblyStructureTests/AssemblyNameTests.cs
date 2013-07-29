using System;
using System.Configuration.Assemblies;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace EjC.AssemblyStructureTests
{
    /// <summary>
    /// It is not possible for Fakes to create a Stub or Shim for
    /// <see cref="System.Reflection.AssemblyName"/>.
    /// These tests show how a concrete version of <see cref="System.Reflection.AssemblyName"/>
    /// can be used in tests.
    /// </summary>
    [TestClass]
    public class AssemblyNameTests
    {
        /// <summary>
        /// Property values for AssemblyName using the default constructor.
        /// </summary>
        [TestMethod]
        public void NewAssemblyName_InitialPropertyValues()
        {
            var assemblyName = new AssemblyName();
            // Assert
            Assert.AreEqual(null, assemblyName.CodeBase);
            Assert.AreEqual(AssemblyContentType.Default, assemblyName.ContentType);
            Assert.AreEqual(null, assemblyName.CultureInfo);
            Assert.AreEqual(null, assemblyName.CultureName);
            Assert.AreEqual(null, assemblyName.EscapedCodeBase);
            Assert.AreEqual(AssemblyNameFlags.None, assemblyName.Flags);
            Assert.AreEqual(string.Empty, assemblyName.FullName);
            Assert.AreEqual(AssemblyHashAlgorithm.None, assemblyName.HashAlgorithm);
            Assert.AreEqual(null, assemblyName.KeyPair);
            Assert.AreEqual(null, assemblyName.Name);
            Assert.AreEqual(ProcessorArchitecture.None, assemblyName.ProcessorArchitecture);
            Assert.AreEqual(null, assemblyName.Version);
            Assert.AreEqual(AssemblyVersionCompatibility.SameMachine, assemblyName.VersionCompatibility);
        }

        /// <summary>
        /// Property values for AssemblyName when an assembly string is used.
        /// </summary>
        [TestMethod]
        public void NewAssemblyName_WithDsiplayName_InitialPropertyValues()
        {
            // Arrange
            var name = "EjC.AssemblyStructureTests";
            var versionString = "1.0.0.0";
            var version = new Version(versionString);
            var fullName = string.Format("{0}, Version={1}, Culture=neutral, PublicKeyToken=null", name, versionString);
            // Act
            var assemblyName = new AssemblyName(fullName);
            // Assert
            Assert.AreEqual(null, assemblyName.CodeBase);
            Assert.AreEqual(AssemblyContentType.Default, assemblyName.ContentType);
            Assert.AreEqual(CultureInfo.InvariantCulture, assemblyName.CultureInfo);
            Assert.AreEqual(string.Empty, assemblyName.CultureName);
            Assert.AreEqual(null, assemblyName.EscapedCodeBase);
            Assert.AreEqual(AssemblyNameFlags.None, assemblyName.Flags);
            Assert.AreEqual(fullName, assemblyName.FullName);
            Assert.AreEqual(AssemblyHashAlgorithm.None, assemblyName.HashAlgorithm);
            Assert.AreEqual(null, assemblyName.KeyPair);
            Assert.AreEqual(name, assemblyName.Name);
            Assert.AreEqual(ProcessorArchitecture.None, assemblyName.ProcessorArchitecture);
            Assert.AreEqual(version, assemblyName.Version);
            Assert.AreEqual(AssemblyVersionCompatibility.SameMachine, assemblyName.VersionCompatibility);
        }
    }
}
