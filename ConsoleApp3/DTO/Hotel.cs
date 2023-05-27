using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.DTO
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chain> Chains { get; set; }
        public Error error { get; set; }

    }
}
