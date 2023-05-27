using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    public static class SerializationHelper
    {
        public static T DeserializeXml<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public static string SerializeXml<T>(this T toSerialize, XmlAttributeOverrides overrrides = null)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), overrrides);
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static T DeserializeJson<T>(this string toDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(toDeserialize);
        }

        public static string SerializeJson<T>(this T toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }
    }
}
