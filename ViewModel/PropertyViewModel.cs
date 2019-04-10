using Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModel
{
    public class PropertyViewModel
    {
        public PropertyViewModel() { }

        private string _propertyName;
        private string _propertyTypeName;
        private PropertyData _propertyData;

        // -----PROPERTIES-----
        [XmlIgnore]
        public PropertyData PropertyData
        {
            get { return _propertyData; }
            set { _propertyData = value; }
        }
        [DataMember]
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        [DataMember]
        public string PropertyTypeName
        {
            get { return _propertyTypeName; }
            set { _propertyTypeName = value; }
        }
    }
}
