using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class TypeData
    {
        public TypeData() {}
        public TypeData(Type type)
        {
            _typeName = type.Name;
            _BaseType = GetTypeKind(type);
            _Constructors = MethodData.EmitMethods(type.GetConstructors());
            _Methods = MethodData.EmitMethods(type.GetMethods());
            _Properties = PropertyData.EmitProperties(type.GetProperties());
            _GenericArguments = !type.IsGenericTypeDefinition ? null : TypeData.EmitGenericArguments(type.GetGenericArguments());
        }

        private TypeData(string typeName, string namespaceName)
        {
            _typeName = typeName;
            _NamespaceName = namespaceName;
        }

        private TypeData(string typeName, string namespaceName, IEnumerable<TypeData> genericArguments) : this(typeName, namespaceName)
        {
            _GenericArguments = genericArguments;
        }

        private string _typeName;
        private string _NamespaceName;
        private TypeBase _BaseType;
        private IEnumerable<MethodData> _Methods;
        private IEnumerable<MethodData> _Constructors;
        private IEnumerable<PropertyData> _Properties;
        private IEnumerable<TypeData> _GenericArguments;

        public string Name
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        public TypeBase BaseType
        {
            get { return _BaseType; }
            set { _BaseType = value; }
        }

        public IEnumerable<MethodData> Methods
        {
            get { return _Methods; }
            set { _Methods = value; }
        }

        public IEnumerable<MethodData> Constructors
        {
            get { return _Constructors; }
            set { _Constructors = value; }
        }

        public IEnumerable<PropertyData> Properties
        {
            get { return _Properties; }
            set { _Properties = value; }
        }

        public IEnumerable<TypeData> GenericArguments
        {
            get { return _GenericArguments; }
            set { _GenericArguments = value; }
        }

        public enum TypeBase
        {
            Enum, Struct, Interface, Class
        }

        internal static TypeData EmitReference(Type type)
        {
            if (!type.IsGenericType)
                return new TypeData(type.Name, type.GetNamespace());
            else
                return new TypeData(type.Name, type.GetNamespace(), EmitGenericArguments(type.GetGenericArguments()));
        }
        internal static IEnumerable<TypeData> EmitGenericArguments(IEnumerable<Type> arguments)
        {
            return from Type _argument in arguments select EmitReference(_argument);
        }

        private static TypeBase GetTypeKind(Type type)
        {
            return type.IsEnum ? TypeBase.Enum :
                   type.IsValueType ? TypeBase.Struct :
                   type.IsInterface ? TypeBase.Interface :
                   TypeBase.Class;
        }
    }
}
