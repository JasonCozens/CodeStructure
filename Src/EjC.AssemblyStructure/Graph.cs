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

        public Graph()
        {
            _graph = new ConcurrentBag<Vertex<T>>();
        }

        public void AddVertices(T parent, IEnumerable<T> children)
        {
            _graph.Add(new Vertex<T>(parent, parent));
            foreach(var child in children)
                _graph.Add(new Vertex<T>(parent, child));
        }

        public IEnumerable<T> Nodes
        {
            get { return  _graph.Select(v => v.Parent).Union(_graph.Select(v => v.Child)); }
        }

        public IEnumerable<IVertex<T>> Vertices
        {
            get { return _graph.Where(v => !(v.Parent.Equals(v.Child))); }
        }
    }
}
