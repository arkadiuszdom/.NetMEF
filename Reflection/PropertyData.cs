using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class PropertyData
    {
        public PropertyData() {}

        public PropertyData(string propertyName, TypeData propertyType)
        {
            _Name = propertyName;
            _TypeData = propertyType;
        }

        private string _Name;
        private TypeData _TypeData;

        // -----PROPERTIES-----
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public TypeData TypeData
        {
            get { return _TypeData; }
            set { _TypeData = value; }
        }
        // ---STATIC METHODS---
        public static IEnumerable<PropertyData> EmitProperties(IEnumerable<PropertyInfo> properties)
        {
            return from p in properties
                   where p.GetGetMethod().GetVisible() || p.GetSetMethod().GetVisible()
                   select new PropertyData(p.Name, TypeData.EmitReference(p.PropertyType));
        }
    }
}
