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

            assemblyLoader.RefeflectionOnly(assemblyName);
            assemblyDependencies.Analyse(assemblyLoader.Assembly);
            graph.AddVertices(assemblyLoader.Name, assemblyDependencies.DirectDependencies);
            foreach (var dependency in assemblyDependencies.DirectDependencies)
            {
                assemblyLoader.RefeflectionOnly(dependency);
                if (assemblyLoader.AssemblyLoaded)
                {
                    assemblyDependencies.Analyse(assemblyLoader.Assembly);
                    graph.AddVertices(assemblyLoader.Name, assemblyDependencies.DirectDependencies);
                }
                else
                {
                    Console.WriteLine("    Assembly failed to load");
                }
            }
            foreach (var v in graph.Vertices)
                Console.WriteLine("\"" + v.Parent + "\" -> \"" + v.Child + "\" ;");
            Console.ReadLine();
        }

        private static void PrintDependencies(AssemblyDependencies assemblyDependencies)
        {
            foreach (var dependency in assemblyDependencies.DirectDependencies)
            {
                Console.WriteLine("    {0}", dependency);
            }
        }
    }
}
