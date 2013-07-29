using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public class AssemblyDependencies : IAssemblyDependencies
    {
        public void Analyse(System.Reflection.Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
        }

        public IEnumerable<string> DirectDependencies
        {
            get { return new List<string>(); }
        }
    }
}
