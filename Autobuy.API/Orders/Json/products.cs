using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.Orders.Json
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int stockCount { get; set; }
        public double price { get; set; }
        public string productType { get; set; }
        public bool unlisted { get; set; }
        public int purchaseMax { get; set; }
        public int purchaseMin { get; set; }
        public object webhookUrl { get; set; }
        public string stockDelimiter { get; set; }
        public string imageUrl { get; set; }
        public List<string> serials { get; set; }
    }

    public class ProductsManager
    {
        public List<Product> products { get; set; }
    }


}
