using HW5.Domain;
using HW5.Interfase.Exception;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace HW5.Interfase
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            FileStream JsonProductfile = File.Open(@"..\DataBase\Product.json", FileMode.OpenOrCreate);
            _products = JsonSerializer.Deserialize<List<Product>>(JsonProductfile);
        }
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
            }
            catch (System.Exception exception)
            {
                return (exception.Message);
            }
            return "True";
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
            string JsonSeralize = JsonSerializer.Serialize(_products);
            File.WriteAllText(@"..\DataBase\Product.json", JsonSeralize);
        }
    }
}
