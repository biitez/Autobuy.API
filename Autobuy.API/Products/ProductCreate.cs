using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.Products
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
        public bool Unlisted { get; set; } = false;
        public bool BlockProxy { get; set; } = false;
        public int PurchaseMax { get; set; } = 100000;
        public int PurchaseMin { get; set; } = 1;
        public string WebhookUrl { get; set; }
        public string StockDelimiter { get; set; }
        public string Serials { get; set; }
    }
}
