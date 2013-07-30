using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public interface IGraph<T>
    {
        void AddVertices(T parent, IEnumerable<T> children);

        IEnumerable<T> Nodes { get; }

        IEnumerable<IVertex<T>> Vertices { get; }
    }
}
