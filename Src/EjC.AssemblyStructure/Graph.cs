using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjC.AssemblyStructure
{
    public class Graph<T> : IGraph<T>
    {
        ConcurrentDictionary<T, T> _graph;

        public Graph()
        {
            _graph = new ConcurrentDictionary<T, T>();
        }

        public void AddVertices(T parent, IEnumerable<T> children)
        {
            _graph.AddOrUpdate(parent, parent, (k, v) => parent);
        }

        public IEnumerable<T> Nodes
        {
            get { return _graph.Keys; }
        }

        public IEnumerable<IVertex<T>> Vertices
        {
            get { return _graph.
                Where(v => !v.Key.Equals(v.Value)).
                Select(v => new Vertex<T>(v.Key, v.Value)); }
        }
    }
}
