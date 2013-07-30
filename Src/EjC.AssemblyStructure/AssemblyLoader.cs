using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public class AssemblyLoader : IAssemblyLoader
    {
        public void RefeflectionOnly(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
        }

        public System.Reflection.Assembly Assembly
        {
            get { 
                if (AssemblyLoaded) return null;
                throw new InvalidOperationException("No assembly loaded");
            }
        }

        public bool AssemblyLoaded
        {
            get { return false; }
        }
    }
}
