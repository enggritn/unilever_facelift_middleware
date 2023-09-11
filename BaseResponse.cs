using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceliftMW
{
    class BaseResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string TransactionId { get; set; }
        public int TotalPallet { get; set; }
        public string ShipmentType { get; set; }
        public int QtyPalletShipmnet { get; set; }
    }
}
