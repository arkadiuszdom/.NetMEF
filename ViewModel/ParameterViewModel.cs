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
    public class ParameterViewModel
    {
        public ParameterViewModel() {}

        private string _parameterName;
        private string _parameterTypeName;
        private ParameterData _parameterData;

        // -----PROPERTIES-----
        [XmlIgnore]
        public ParameterData ParameterData
        {
            get { return _parameterData; }
            set { _parameterData = value; }
        }
        [DataMember]
        public string ParameterName
        {
            get { return _parameterName; }
            set { _parameterName = value; }
        }
        [DataMember]
        public string ParameterTypeName
        {
            get { return _parameterTypeName; }
            set { _parameterTypeName = value; }
        }
    }
}
