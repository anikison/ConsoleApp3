using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3.DTO
{
    public class MasterHotel
    {
        [ApiLight]
        [XmlIgnore]
        public string MasterChain { get; set; }
        public string MasterSecret { get; set; }
    }
}
