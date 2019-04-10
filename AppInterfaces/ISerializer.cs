using System.IO;
using System.Reflection;

namespace AppInterfaces
{
    public interface ISerializer
    {
        void Serialize<Type>(Type type, string name, ILogger log);
        Type Deserialize<Type>(string name, ILogger log);
    }
}