using AppInterfaces;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;

namespace XMLSerializerProject
{
    [Export(typeof(ISerializer))]
    public class XMLSerializer : ISerializer
    {
        public void Serialize<Type>(Type type, string name, ILogger log)
        {
            log.Log("Serialize to Xml...");
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Type));
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n"
            };

            using (FileStream fileStream = File.Open(name, FileMode.Create))
            using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
            {
                dataContractSerializer.WriteObject(xmlWriter, type);
            }
        }

        public type Deserialize<type>(string name, ILogger log)
        {
            log.Log("Deserialize from Xml...");
            type collection = default(type);

            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(type));

            using (FileStream fileStream = File.Open(name, FileMode.Open))
            {
                // XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
                // collection = (type)dataContractSerializer.ReadObject(xmlDictionaryReader, true);
                collection = (type)dataContractSerializer.ReadObject(fileStream);
                // xmlDictionaryReader.Close();
            }

            return collection;
        }

        public void Serialize(Assembly assembly, string name, ILogger log)
        {
            this.Serialize<Assembly>(assembly, name, log);
        }
    }
}
