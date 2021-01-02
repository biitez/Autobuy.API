using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.Orders.Json
{
    public class Order
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
    }

    public class OrderList
    {
        public int page { get; set; }
        public int pageCount { get; set; }
        public int orderCount { get; set; }
        public List<Order> orders { get; set; }
    }
}
