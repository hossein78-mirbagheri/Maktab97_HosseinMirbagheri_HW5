using HW5.Domain;
using HW5.Interfase;
using System.IO;
using System.Reflection;
using System;
using System.Threading.Channels;
using System.Xml.Linq;
using HW5.CreateList;
using static HW5.CreateList.CreateList;

ProductRepository productRepository = new ProductRepository();
StockRepository stockRepository = new StockRepository();
ShowProduct showProduct = new ShowProduct();
Stock stock = new Stock();
Product product = new Product();
CreateList createList = new CreateList();
string option = "";
bool flag;
string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName + "\\FileDataStorage.txt";
var lines = productRepository.GetProductList();
foreach (var line in lines)
{
    Console.WriteLine(line.Name + "" +  line.ProductId);
}
int id = 0;
int Number = 0 ;
int Price = 0;
string name = Console.ReadLine();
product.Name = name;
stock.ProductId = id;
stock.ProductQuantity = Number;
stock.ProductPrice = Price;
stockRepository.BuyProduct(stock);
do
{
    Console.WriteLine("\n 1.AddProduct \n 2.List of Product \n 3.List of Stock \n 4.Exit");
    option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Console.WriteLine("productid?");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name?");
            name = Console.ReadLine();
            Console.WriteLine("Price?");
            Price = Convert.ToInt32(Console.ReadLine());
            var stat = createList.AddProduct(id,name,Price);
                if (stat == true)
                {
                    Console.WriteLine("Add Product Successfully");
                }
                else
                {
                    Console.WriteLine("Add Product Error");
                }
            break;

            Console.Clear();
            var sh = showProduct.showlist(path);
            foreach (var item in sh)
            {
                Console.WriteLine(item);
            }
            break;
        case "3":
            Console.Clear();
            var h = showProduct.showlist(path);
            foreach (var item in h)
            {
                Console.WriteLine(item);
            }
            break;

            break;
        case "4":
            Console.Clear();

            flag = false;
            break;

        default:
            Console.Clear();

            Console.WriteLine("Error: Please give a number between 1 and 4!");
            flag = false;
            break;
    }

} while (option != "4");


Console.WriteLine("GoodBye :)\n");