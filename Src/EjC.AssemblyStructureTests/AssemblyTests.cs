using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EjC.AssemblyStructureTests
{
    [TestClass]
    public class AssemblyTests
    {
        /// <summary>
        /// Can the referenced assemblies be retreived fron a ReflectionOnlyLoad?
        /// </summary>
        [TestMethod]
        public void ReflectionOnlyLoad()
        {
            var assembly = Assembly.ReflectionOnlyLoad(Assembly.GetExecutingAssembly().FullName);
            Assert.IsNotNull(assembly.GetReferencedAssemblies());
        }
    }
}
