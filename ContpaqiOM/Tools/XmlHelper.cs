using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections;

namespace ContpaqiOM.Tools
{
    public class XmlHelper
    {
        public static T DeserializeStringToXml<T>(string xml,out List<string> Errors) where T : class
        {
            byte[] data = Convert.FromBase64String(xml);
            string xmlDecoded = System.Text.Encoding.UTF8.GetString(data);
             ValidateXml(xmlDecoded, out Errors);
            if (Errors.Count>0)
            {
                return null;
            }
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlDecoded))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
        private static void ValidateXml(string xml, out List<string> Errors)
        {
            var errors = new List<string>();
            var schemaSet = new XmlSchemaSet();
            string xsdPath = @"XMLConfig\comprobante.xsd";
            schemaSet.Add(null, xsdPath);
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemaSet
            };
            settings.ValidationEventHandler += (sender, args) =>
            {
                errors.Add(args.Message);
            };
            using (var reader = XmlReader.Create(new StringReader(xml), settings))
            {
                try
                {
                    while (reader.Read()) { }
                }
                catch (XmlException ex)
                {
                    errors.Add( $"XML Exception: {ex.Message}");
                }
            }
            Errors = errors;
        }
    }
}

