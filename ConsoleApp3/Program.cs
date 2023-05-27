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
                Chains = new List<Chain>()
            };

            string xml3 = SerializationHelper.SerializeXml(hotel3);

            var myObjectType = typeof(Hotel);
            var props = myObjectType.GetProperties();

            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            foreach (var item in props)
            {
                XmlAttributes attributes = new XmlAttributes();
                // Adicionar o atributo XmlIgnore
                attributes.XmlIgnore = true;

                // Criar o XmlAttributeOverrides e adicionar o XmlAttributes
                overrides.Add(myObjectType, item.Name, attributes);
            }

            string xml4 = SerializationHelper.SerializeXml(hotel3, overrides);

            Console.ReadKey();
        }
    }
}
