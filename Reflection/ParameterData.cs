using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class ParameterData
    {
        public ParameterData() {}

        public ParameterData(string name, TypeData typeData)
        {
            _Name = name;
            _TypeData = typeData;
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
    }
}
