using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SimpleVoice.Helpers
{
    public static class AssemblyHelper
    {
        public static List<Assembly> GetAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                assemblies.Add(assembly);

                foreach (AssemblyName referencedAssembly in assembly.GetReferencedAssemblies())
                {
                    try
                    {
                        Assembly loadedAssembly = Assembly.Load(referencedAssembly);
                        
                        if (!assemblies.Contains(loadedAssembly))
                        {
                            assemblies.Add(loadedAssembly);
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine($"Could not load assembly: {referencedAssembly.Name}");
                    }
                    catch (FileLoadException e)
                    { } // The Assembly has already been loaded.
                    catch (BadImageFormatException e)
                    { }
                }
            }
            
            // Scan adjacent assemblies
            foreach (string dll in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories))
            {
                try
                {                    
                    Assembly loadedAssembly = Assembly.LoadFile(dll);
                    if (!assemblies.Contains(loadedAssembly))
                    {
                        assemblies.Add(loadedAssembly);
                    }
                }
                catch (FileLoadException loadEx)
                { } // The Assembly has already been loaded.
                catch (BadImageFormatException imgEx)
                { } // If a BadImageFormatException exception is thrown, the file is not an assembly.
            }

            return assemblies;
        }
    }
}
