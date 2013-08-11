using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public interface IEdge<T>
    {
        T Parent { get; }

        T Child { get; }
    }
}
