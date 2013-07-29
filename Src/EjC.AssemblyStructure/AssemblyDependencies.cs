using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public class AssemblyDependencies : IAssemblyDependencies
    {
        Assembly _assembly;

        public void Analyse(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            _assembly = assembly;
        }

        public IEnumerable<string> DirectDependencies
        {
            get { return _assembly.GetReferencedAssemblies().Select(an => an.Name); }
        }
    }
}
