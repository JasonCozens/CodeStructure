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
        public void RefeflectionOnly(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            try
            {
                Assembly.ReflectionOnlyLoad(name);
            }
            catch (FileNotFoundException)
            {
                AssemblyLoaded = false;
            }
        }

        public System.Reflection.Assembly Assembly
        {
            get { 
                if (AssemblyLoaded) return null;
                throw new InvalidOperationException("No assembly loaded");
            }
        }

        public bool AssemblyLoaded { get; private set; }
    }
}
