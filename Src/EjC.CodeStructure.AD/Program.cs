using EjC.AssemblyStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjC.CodeStructure.AD
{
    /// <summary>
    /// Simple console app to display an assembly's dependencies.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyName = args[0];
            var assemblyLoader = new AssemblyLoader();
            var assemblyDependencies = new AssemblyDependencies();
            IGraph<string> graph = new Graph<string>();
            AddAllDependencies(assemblyLoader, assemblyDependencies, graph, assemblyName);
            Console.WriteLine("digraph g {");
            foreach (var v in graph.Edges)
                Console.WriteLine("\"" + v.Parent + "\" -> \"" + v.Child + "\" ;");
            Console.WriteLine("}");
            Console.ReadLine();
        }

        private static void AddAllDependencies(AssemblyLoader assemblyLoader, AssemblyDependencies assemblyDependencies, IGraph<string> graph, string assemblyName)
        {
            if (graph.Edges.Select(v => v.Parent).Contains(assemblyName))
                return;
            assemblyLoader.RefeflectionOnly(assemblyName);
            if (assemblyLoader.AssemblyLoaded)
            {
                assemblyDependencies.Analyse(assemblyLoader.Assembly);
                graph.AddEdges(assemblyLoader.Name, assemblyDependencies.DirectDependencies);
                foreach (var dependency in assemblyDependencies.DirectDependencies)
                {
                    AddAllDependencies(assemblyLoader, assemblyDependencies, graph, dependency);
                }
            }
            else
            {
                graph.AddEdges(assemblyName, new List<string>());
                //Console.WriteLine("    Assembly failed to load: {0}", assemblyName);
            }
        }
    }
}
