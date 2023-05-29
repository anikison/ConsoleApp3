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
            List<Type> classesToCheck = new List<Type> { typeof(Hotel), typeof(Chain), typeof(Error), typeof(MasterHotel) };
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
            bool hasInheritance = HasInheritance(myObjectType);

            var props = myObjectType.GetProperties();

            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attributes = new XmlAttributes();
            IPropertyChecker propertyChecker = new PropertyCheckerStrategy();
            var x = 1;
            foreach (var prop in props)
            {
                //PropertyCheckerStrategy.PropertyExists(classesToCheck, propertyName);
                var tipo = prop.GetType();
                var x1 = tipo == typeof(Chain);
                var x2 = tipo == typeof(List<Chain>);
                foreach (var item in tipo.GetFields())
                {
                    var tipofield = item.FieldType;
                }

                //if (propertyChecker.PropertyExists(classesToCheck, prop.GetType()))
                //    x = 2;
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

        //verifica se a classe é uma herança
        private static bool HasInheritance(Type derivedType) =>
            derivedType.BaseType != null && derivedType.BaseType != typeof(object);
    }
}
