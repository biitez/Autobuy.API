using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autobuy.Orders.Json;
using Autobuy.Products.Json;
using Autobuy.Products;
using Microsoft.Win32;
using Autobuy.License;

namespace Autobuy
{
    public class API
    {
        public static requestController Req = new requestController();

        public API(string APIKey)
        {
            Req.APIKey = APIKey;
        }

        public async Task<OrderList> GetOrdersAsync(int page)
        {
            return JsonSerializer.Deserialize<OrderList>(await Req.RequestAsync(
                httpMethod: HttpMethod.Get,
                LinkParam: $"Orders?page={page}"));
        }

        public async Task<order> GetOrderAsync(string IDOrder)
        {
            return JsonSerializer.Deserialize<order>(await Req.RequestAsync(
                httpMethod: HttpMethod.Get,
                LinkParam: $"Order/{IDOrder}"));
        }

        public async Task<ProductsManager> GetProductsAsync()
        {
            return JsonSerializer.Deserialize<ProductsManager>(await Req.RequestAsync(
                httpMethod: HttpMethod.Get,
                LinkParam: "Products"));
        }

        public async Task<ProductManager> GetProductAsync(string IDProduct)
        {
            var idBody = new Dictionary<string, string>()
            {
                { "id", IDProduct }
            };

            return JsonSerializer.Deserialize<ProductManager>(await Req.RequestAsync(
                httpMethod: HttpMethod.Get,
                LinkParam: "Product",
                BodyUrlEncode: idBody));
        }

        public async Task<UpdateProduct> CreateProductAsync(ProductInfo infoProduct)
        {
            Dictionary<string, string> Params = new Dictionary<string, string>()
            {
                { "Name", infoProduct.Name },
                { "Description", infoProduct.Description },
                { "Price", infoProduct.Price.ToString() },
                { "ProductType", infoProduct.ProductType.ToString() },
                { "Unlisted", infoProduct.Unlisted.ToString() },
                { "BlockProxy", infoProduct.BlockProxy.ToString() },
                { "PurchaseMax", infoProduct.PurchaseMax.ToString() },
                { "PurchaseMin", infoProduct.PurchaseMin.ToString() },
                { "WebhookUrl", infoProduct.WebhookUrl },
                { "StockDelimiter", infoProduct.StockDelimiter },
                { "Serials", infoProduct.Serials }
            };  

            return JsonSerializer.Deserialize<UpdateProduct>(await Req.RequestAsync(
                httpMethod: HttpMethod.Post, 
                LinkParam: "Product",
                BodyUrlEncode: Params));
        }

        public async Task<UpdateProduct> UpdateProductAsync(string IDProduct, ProductInfo infoProduct)
        {
            if (string.IsNullOrEmpty(IDProduct))
                throw new Exception("You must specify the product ID!");

            Dictionary<string, string> Params = new Dictionary<string, string>()
            {
                { "Id", IDProduct },
                { "Name", infoProduct.Name },
                { "Description", infoProduct.Description },
                { "Price", infoProduct.Price.ToString() },
                { "ProductType", infoProduct.ProductType.ToString() },
                { "Unlisted", infoProduct.Unlisted.ToString() },
                { "BlockProxy", infoProduct.BlockProxy.ToString() },
                { "PurchaseMax", infoProduct.PurchaseMax.ToString() },
                { "PurchaseMin", infoProduct.PurchaseMin.ToString() },
                { "WebhookUrl", infoProduct.WebhookUrl },
                { "StockDelimiter", infoProduct.StockDelimiter },
                { "Serials", infoProduct.Serials }            };

            return JsonSerializer.Deserialize<UpdateProduct>(await Req.RequestAsync(
                httpMethod: HttpMethod.Put, 
                LinkParam: "Product", 
                BodyUrlEncode: Params));
        }

        public async Task<string> DeleteProduct(string IDProduct)
        {
            Dictionary<string, string> IDBody = new Dictionary<string, string>()
            {
                {"id", IDProduct }
            };

            return await Req.RequestAsync(
                httpMethod: HttpMethod.Delete,
                LinkParam: "Product",
                BodyUrlEncode: IDBody);
        }
    }
}
