using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces;

namespace Reflection
{
    public class Reflector
    {
        public AssemblyData _AssemblyModel { get; private set; }

        public void Reflect(string assemblyFile, ILogger log)
        {
            log.Log("Reading assembly file...");
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            _AssemblyModel = new AssemblyData(assembly, log);
        }

        public void Reflect(Assembly assembly, ILogger log)
        {
            log.Log("Getting information from assembly object...");
            _AssemblyModel = new AssemblyData(assembly, log);
        }
        /*
        public string AssemblyToString()
        {
            string result = null;

            result += String.Format("-->{0}{1}", _AssemblyModel.Name, Environment.NewLine);

            foreach (NamespaceData nd in _AssemblyModel.Namespaces)
            {
                result += String.Format("---->{0}{1}", nd.Name, Environment.NewLine);

                foreach (TypeData td in nd.Types)
                {
                    result += String.Format("------>{0}{1}", td.Name, Environment.NewLine);

                    foreach (MethodData constructorData in td.Constructors)
                    {
                        result += String.Format("-------->{0}{1}", constructorData.Name, Environment.NewLine);
                    }

                    foreach (MethodData methodData in td.Methods)
                    {

                        result += String.Format("-------->{0} - {1}{2}", methodData.Name, methodData.ReturnType.Name, Environment.NewLine);

                    }

                    foreach (PropertyData propertyData in td.Properties)
                    {
                        result += String.Format("-------->{0}{1}", propertyData.Name, Environment.NewLine);
                    }
                }
            }
            return result;
        }*/
    }
}
