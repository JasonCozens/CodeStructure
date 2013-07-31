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
            _assembly = null;
            try
            {
                _assembly = Assembly.ReflectionOnlyLoad(name);
            }
            catch (FileNotFoundException) { }
        }

        public System.Reflection.Assembly Assembly
        {
            get { 
                if (AssemblyLoaded) return _assembly;
                throw new InvalidOperationException("No assembly loaded");
            }
        }

        public bool AssemblyLoaded {
            get { return _assembly != null; }
       } 
    }
}
