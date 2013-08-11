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
        private ConcurrentBag<Vertex<T>> _graph;
        private ConcurrentBag<T> _nodes;

        public Graph()
        {
            _nodes = new ConcurrentBag<T>();
            _graph = new ConcurrentBag<Vertex<T>>();
        }

        public void AddVertices(T parent, IEnumerable<T> children)
        {
            AddNodeIfNew(parent);
            foreach (var child in children)
            {
                AddNodeIfNew(child);
                _graph.Add(new Vertex<T>(parent, child));
            }
        }

        private void AddNodeIfNew(T node)
        {
            if (!_nodes.Contains(node))
                _nodes.Add(node);
        }

        public IEnumerable<T> Nodes
        {
            get { return  _nodes; }
        }

        public IEnumerable<IVertex<T>> Vertices
        {
            get { return _graph; }
        }
    }
}
