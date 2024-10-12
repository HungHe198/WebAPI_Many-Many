using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Models
{
    public class Laptop_People
    {
        
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }

        
    }   
}
