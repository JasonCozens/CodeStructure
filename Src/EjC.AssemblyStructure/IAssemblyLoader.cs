using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public interface IAssemblyLoader
    {
        void RefeflectionOnly(string name);

        string Name { get; }

        bool AssemblyLoaded { get; }

        Assembly Assembly { get; }
    }
}
