using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public interface IAssemblyDependencies
    {
        void Analyse(Assembly assembly);

        IEnumerable<string> DirectDependencies { get; }
    }
}
