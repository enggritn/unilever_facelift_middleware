using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceliftMW
{
    class RfidTag
    {
        public string TagId { get; set; }
        public string Antenna { get; set; }
        public DateTime ReadAt { get; set; }
        public string Location { get; set; }
    }
}
