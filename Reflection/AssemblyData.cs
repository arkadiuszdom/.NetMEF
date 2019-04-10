using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces;

namespace Reflection
{
    public class AssemblyData : Assembly
    {
        public AssemblyData(Assembly assembly, ILogger log)
        {
            log.Log("Getting types from assembly");

            _Name = assembly.ManifestModule.Name;

            _Namespaces = from Type _type in assembly.GetTypes()
                           where _type.GetVisible()
                           group _type by _type.GetNamespace() into _group
                           orderby _group.Key
                           select new NamespaceData(_group.Key, _group);
        }

        private string _Name;
        private IEnumerable<NamespaceData> _Namespaces;

        // -----PROPERTIES-----
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public IEnumerable<NamespaceData> Namespaces
        {
            get { return _Namespaces; }
            set { _Namespaces = value; }
        }
    }
}
