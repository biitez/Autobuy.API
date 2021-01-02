using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.Orders.Json
{
    public class order
    {
        public string id { get; set; }
        public string productId { get; set; }
        public string email { get; set; }
        public string ipAddress { get; set; }
        public double total { get; set; }
        public string currency { get; set; }
        public string gateway { get; set; }
        public bool isComplete { get; set; }
        public DateTime createdAtUtc { get; set; }
        public List<string> serials { get; set; }
    }

}
