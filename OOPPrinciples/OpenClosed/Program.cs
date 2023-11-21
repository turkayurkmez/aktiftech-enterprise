// See https://aka.ms/new-console-template for more information
using OpenClosed;

Console.WriteLine("Hello, World!");
//...Gelişime.. Açık ....Değişime.... Kapalı olmalıdır


Customer customer = new Customer() { Campaign = new ThreeForOnePriceCampaign() };
OrderManager orderManager = new OrderManager { Customer = customer };
var price = orderManager.GetDiscountedPrice(1500);
Console.WriteLine(price);