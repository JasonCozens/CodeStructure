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
            var assembly = Assembly.ReflectionOnlyLoad(assemblyName);
            var assemblyDependencies = new EjC.AssemblyStructure.AssemblyDependencies();
            assemblyDependencies.Analyse(assembly);
            Console.WriteLine(assembly.FullName);
            foreach (var dependency in assemblyDependencies.DirectDependencies)
            {
                Console.WriteLine(dependency);
            }
        }
    }
}
