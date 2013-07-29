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
    /// </summary>
    [TestClass]
    public class AssemblyNameTests
    {
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
    }
}
