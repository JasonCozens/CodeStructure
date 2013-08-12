using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public interface IGraph<T>
    {
        void AddEdges(T parent, IEnumerable<T> children);

        IEnumerable<T> Vertices { get; }

        IEnumerable<IEdge<T>> Edges { get; }
    }
}
