﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjC.AssemblyStructure
{
    public class Edge<T> : IEdge<T>
    {
        public Edge(T parent, T child)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            if (child == null) throw new ArgumentNullException("child");
            Parent = parent;
            Child = child;
        }

        public T Parent { get; private set; }

        public T Child { get; private set; }
    }
}
