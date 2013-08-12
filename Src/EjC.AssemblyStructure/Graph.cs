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
        private ConcurrentBag<Edge<T>> _edges;
        private ConcurrentBag<T> _vertices;

        public Graph()
        {
            _vertices = new ConcurrentBag<T>();
            _edges = new ConcurrentBag<Edge<T>>();
        }

        public void AddEdges(T parent, IEnumerable<T> children)
        {
            AddNodeIfNew(parent);
            foreach (var child in children)
            {
                AddNodeIfNew(child);
                _edges.Add(new Edge<T>(parent, child));
            }
        }

        private void AddNodeIfNew(T node)
        {
            if (!_vertices.Contains(node))
                _vertices.Add(node);
        }

        public IEnumerable<T> Vertices
        {
            get { return  _vertices; }
        }

        public IEnumerable<IEdge<T>> Edges
        {
            get { return _edges; }
        }
    }
}
