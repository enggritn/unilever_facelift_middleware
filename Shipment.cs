using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceliftMW
{
    class Shipment
    {
        public string TransactionId { get; set; }
        public List<string> items { get; set; }
    }
}
