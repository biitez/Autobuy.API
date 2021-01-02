using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.Products.Json
{
    public class UpdateProduct
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int stockCount { get; set; }
        public double price { get; set; }
        public string productType { get; set; }
        public bool unlisted { get; set; }
        public bool blockProxy { get; set; }
        public int purchaseMax { get; set; }
        public int purchaseMin { get; set; }
        public string webhookUrl { get; set; }
        public string stockDelimiter { get; set; }
        public List<string> serials { get; set; }
    }
}
