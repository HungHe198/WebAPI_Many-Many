using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Models
{
    public class Car_People
    {
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int PeopleId { get; set; }
        public People? People { get; set; }

    }
}
