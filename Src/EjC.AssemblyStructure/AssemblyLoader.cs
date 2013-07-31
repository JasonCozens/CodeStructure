using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public class AssemblyLoader : IAssemblyLoader
    {
        private Assembly _assembly;

        public void RefeflectionOnly(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            try
            {
                _assembly = Assembly.ReflectionOnlyLoad(name);
                AssemblyLoaded = true;
            }
            catch (FileNotFoundException)
            {
                AssemblyLoaded = false;
            }
        }

        public System.Reflection.Assembly Assembly
        {
            get { 
                if (AssemblyLoaded) return _assembly;
                throw new InvalidOperationException("No assembly loaded");
            }
        }

        public bool AssemblyLoaded { get; private set; }
    }
}
