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
    /// Simple console app to display an assemblies dependencies.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyName = args[0];
            var assemblyLoader = new AssemblyLoader();
            var assemblyDependencies = new AssemblyDependencies();


            assemblyLoader.RefeflectionOnly(assemblyName);
            assemblyDependencies.Analyse(assemblyLoader.Assembly);
            Console.WriteLine(assemblyName);
            PrintDependencies(assemblyDependencies);
            foreach (var dependency in assemblyDependencies.DirectDependencies)
            {
                assemblyLoader.RefeflectionOnly(dependency);
                Console.WriteLine(assemblyLoader.Name);
                if (assemblyLoader.AssemblyLoaded)
                {
                    //assembly = assemblyLoader.Assembly;
                    assemblyDependencies.Analyse(assemblyLoader.Assembly);
                    PrintDependencies(assemblyDependencies);
                }
                else
                {
                    Console.WriteLine("    Assembly failed to load");
                }
            }
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
