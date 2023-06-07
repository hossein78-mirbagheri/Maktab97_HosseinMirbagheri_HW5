using HW5.Domain;
using HW5.Interfase.Exception;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace HW5.Interfase
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        //public ProductRepository()
        //{
        //    var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\Product.json";
        //    var fileToJson = JsonConvert.DeserializeObject<Product>(path);
        //}
        public void CheckProductName(string productName)
        {
            Regex rex = new Regex(@"^[A-X][a-x]{2}[1-9]{3}_$");
            if (!rex.IsMatch(productName))
            {
                throw new CheckNameException();
            }
        }

        string IProductRepository.AddProduct(Product product)
        {
            try
            {
                CheckProductName(product.Name);
                product.ProductId = GiveProductId();
            }
            catch (System.Exception exception)
            {
                return (exception.Message);
            }
            return "True";
            
        }
        public static int GiveProductId()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\Product.json";
            int id = 1;
            var lines = File.ReadAllLines(path);
            foreach(var line in lines)
            {
                var fileTOJson = JsonConvert.DeserializeObject<Product>(line);
                if(fileTOJson.ProductId == id)
                {
                    id++;
                }
                else
                {
                  continue;
                }
            }
            return id;
        }

        public List<Product> GetProductList()
        {
            return _products;
        }

        public string GetProductById(int Id)
        {
            Product product = _products.Single(s => s.ProductId == Id);
            return product.Name;
        }
        private void SavaChanges()
        {
            string Jsonconvert = JsonConvert.SerializeObject(_products);
            File.WriteAllText(@"..\DataBase\Product.json", Jsonconvert);
        }
    }
}
