using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class NamespaceData
    {
        public NamespaceData() {}
        public NamespaceData(string name, IEnumerable<Type> types)
        {
            _NamespaceName = name;
            _Types = from type in types
                     orderby type.Name
                     select new TypeData(type);
        }

        private string _NamespaceName;
        private IEnumerable<TypeData> _Types;

        // -----PROPERTIES-----
        public string Name
        {
            get { return _NamespaceName; }
            set { _NamespaceName = value; }
        }

        public IEnumerable<TypeData> Types
        {
            get { return _Types; }
            set { _Types = value; }
        }
    }
}
