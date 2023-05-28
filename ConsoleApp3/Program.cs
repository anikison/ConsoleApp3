using ConsoleApp3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hotel = new Hotel { 
                Id = 1, Name = "HotelFull", 
                Chains = new List<Chain>() { new Chain { Chainid = 1, ChainName = "Robost" } }, 
                error = new Error { ErrorId = 1, Description = "fullError" } 
            };

            string xml = SerializationHelper.SerializeXml(hotel);

            var hotel2 = new Hotel
            {
                Id = 3,
                Name = "HotelMinimal",
                Chains = new List<Chain>() { new Chain { Chainid = 1, ChainName = "Robost" } }
            };

            string xml2 = SerializationHelper.SerializeXml(hotel2);

            var hotel3 = new Hotel
            {
                Id = 5,
                Name = "HotelNoChain",
                Chains = new List<Chain>(),
                error = new Error { ErrorId = 5},
                MasterChain = "ChainMaster",
                MasterSecret = "SecretCode"
            };

            string xml3 = SerializationHelper.SerializeXml(hotel3);

            var myObjectType = typeof(Hotel);
            //bool hasBaseClass1 = typeof(DerivedClass).IsSubclassOf(typeof(BaseClass));
            //Console.WriteLine("A classe possui uma classe base direta? " + hasBaseClass1);

            // Exemplo 2: Verificar se a classe é uma subclasse, considerando heranças em cadeia
            bool hasInheritance = HasInheritance(typeof(Hotel));
            Console.WriteLine("A classe possui alguma classe base? " + hasInheritance);
            bool hasInheritance2 = HasInheritance(typeof(Chain));
            Console.WriteLine("A classe possui alguma classe base? " + hasInheritance2);
            var props = myObjectType.GetProperties();

            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attributes = new XmlAttributes();

            foreach (var prop in props)
            {
                var x = prop.PropertyType.Namespace.StartsWith("System");

                //if (prop.PropertyType.IsClass)
                //    AddAttributesFromClass(prop, overrides, attributes);

                attributes.XmlIgnore = prop.IsDefined(typeof(ApiLightAttribute), inherit: true);
                overrides.Add(myObjectType, prop.Name, attributes);
            }

            string xml4 = SerializationHelper.SerializeXml(hotel3, overrides);

            Console.ReadKey();
        }
        private static void AddAttributesFromClass(object fullclass, XmlAttributeOverrides overrides, XmlAttributes attributes)
        {
            var objType = fullclass.GetType();
            var fullProps = objType.GetProperties();
            foreach (var prop in fullProps) {
                attributes.XmlIgnore = prop.IsDefined(typeof(ApiLightAttribute), inherit: true);
                overrides.Add(objType, prop.Name, attributes);
            }
        }
        private static bool HasInheritance(Type derivedType) =>
            derivedType.BaseType != null && derivedType.BaseType != typeof(object);
    }
}
