using HW5.Domain;
using HW5.Interfase;

ProductRepository productRepository = new ProductRepository();
StockRepository stockRepository = new StockRepository();
Stock stock = new Stock();
var lines = productRepository.GetProductList();
foreach (var line in lines)
{
    Console.WriteLine(line.Name + "" +  line.ProductId);
}
Console.WriteLine("productid?");
int id = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Number?");
int Number= Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Price?");
int Price = Convert.ToInt32(Console.ReadLine());
stock.ProductId = id;
stock.ProductQuantity = Number;
stock.ProductPrice = Price;
stockRepository.BuyProduct(stock);