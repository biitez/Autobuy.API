# Autobuy.API
Unofficial asynchronous library written in .NET Framework that interacts with AutoBuy.IO API

This library uses the latest autobuy API (https://api.autobuy.io)
To find your API key, just go to your shop settings!

### Usage:
```csharp
var autobuy = new API("Your API Key");
```

## Available API Endpoints

### Orders:
- Get All Orders:
```csharp
var allOrders = await autobuy.GetOrdersAsync(page: 1);
foreach (var i in allOrders.orders)
{
    Console.WriteLine(i.email);
}
```
- Get specific order:
```csharp
var orderInfo = await autobuy.GetOrderAsync(IDOrder: "Order ID");
Console.WriteLine(orderInfo.isComplete);
Console.WriteLine(orderInfo.email);
Console.WriteLine(orderInfo.gateway);
Console.WriteLine(orderInfo.ipAddress);
(...)
```
### Products:
- Get all products:
```csharp
var pr = await autobuy.GetProductsAsync();
foreach (var i in pr.products)
{
    Console.WriteLine(i.name);
    Console.WriteLine(i.price);
    (...)
}
```
- Get specific products:
```csharp
var infoProduct = await autobuy.GetProductAsync(IDProduct: "ID Product");
Console.WriteLine(infoProduct.name);
Console.WriteLine(infoProduct.price);
(...)
```
- Create product:
```csharp
var productInfo = new ProductInfo()
{
    Name = "Name Product",
    BlockProxy = false,
    Description = "Description Product",
    Price = 9.99,
    ProductType = ProductType.SerialNumber,
    Serials = "test1,test2",
    StockDelimiter = ",",
    PurchaseMax = 10000,
    PurchaseMin = 1,
    Unlisted = false
};

var productCreate = await autobuy.CreateProductAsync(productInfo);
Console.WriteLine(productCreate.id);
```
- Delete product:
```csharp
await autobuy.DeleteProduct(IDProduct: "");
```
### Projects:
- Get all projects:
```csharp
var Init = new Autobuy.License.Projects();
var List = await Init.GetAllProjectsAsync();
foreach (var i in List.projects)
{
    Console.WriteLine(i.name);
    Console.WriteLine(i.version);
    Console.WriteLine(i.licenseCount);
    Console.WriteLine(i.id);
}
```
- Get specific project:
```csharp
var Init = new Autobuy.License.Projects();
var projectInfo = await Init.GetProjectInfoAsync(IDProject: "ID Project");
Console.WriteLine(projectInfo.Id);
Console.WriteLine(projectInfo.IsBan);
Console.WriteLine(projectInfo.ProjectVersion);
(...)
```
### License control:
- Initialize
```csharp
var control = new Licensing(projectID: "Project ID", projectName: "Project Name");
```

- Create licenses
```csharp
var licenseInfo = new LicenseInfo()
{
    Email = "Email@email.com",
    ExpireDate = DateTime.UtcNow
};

var newLice = await control.CreateLicenseAsync(licenseInfo);
Console.WriteLine(newLice.id); // license key
```
- Delete license
```csharp
await control.DeleteLicenseAsync("license key");
```
- Verify HWID:
```csharp
bool sameHWID = await control.verifyHwidAsync("license key")
```
- Login:
```csharp
bool logIn = await control.AuthKeyAsync(licenseKey: licenseKey)
```

Any bug or problem, let me know and I will update.

### Credits:
- https://t.me/biitez
