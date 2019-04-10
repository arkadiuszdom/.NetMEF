using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class MethodData
    {
        public MethodData() {}

        private MethodData(MethodBase method)
        {
            _Name = method.Name;
            _ReturnType = EmitReturnType(method);
            _Parameters = EmitParameters(method.GetParameters());
        }

        private string _Name;
        private TypeData _ReturnType;
        private IEnumerable<ParameterData> _Parameters;

        // -----PROPERTIES-----
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public TypeData ReturnType
        {
            get { return _ReturnType; }
            set { _ReturnType = value; }
        }
        public IEnumerable<ParameterData> Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; }
        }

        // ---STATIC METHODS---
        public static IEnumerable<MethodData> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase _currentMethod in methods
                   where _currentMethod.GetVisible()
                   select new MethodData(_currentMethod);
        }

        private static TypeData EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null)
                return null;
            return TypeData.EmitReference(methodInfo.ReturnType);
        }

        private static IEnumerable<ParameterData> EmitParameters(IEnumerable<ParameterInfo> parms)
        {
            return from parm in parms
                   select new ParameterData(parm.Name, TypeData.EmitReference(parm.ParameterType));
        }
    }
}
