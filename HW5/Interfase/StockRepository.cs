using HW5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW5.Interfase
{
    public class StockRepository : IStockRepository
    {
        ProductRepository product = new ProductRepository();
        private List<Stock> _stocks;

        public StockRepository()
        {
            FileStream JsonProductfile = File.Open(@"..\..\..\DataBase\Stock.json",FileMode.OpenOrCreate);
            _stocks = JsonSerializer.Deserialize<List<Stock>>(JsonProductfile);
        }
        public void BuyProduct(Stock productInStock)
        {
           bool ChosenProduct = _stocks.Any(a => a.ProductId == productInStock.ProductId);
            if(!ChosenProduct)
            {
                _stocks.Add(productInStock);
            }
            else
            {
                _stocks.Where(a => a.ProductId == productInStock.ProductId).SingleOrDefault().ProductQuantity = productInStock.ProductQuantity;
            }
                   }

        public List<Stock> GetSalesProductList()
        {
            return _stocks;
        }

        public string SaleProduct(int productId, int cnt)
        {
            FileStream JsonProductfile = File.Open(@"..\DataBase\Stock.json", FileMode.OpenOrCreate);
            _stocks = JsonSerializer.Deserialize<List<Stock>>(JsonProductfile);
            var oldquantity = GetProductQuantity(productId);
           if(oldquantity<cnt)
            {
                return "not enough product";
            }
            else
            {
              foreach(var line in _stocks)
                {
                    if(line.ProductId == productId)
                    {
                        var newquantity = line.ProductQuantity;
                        newquantity = oldquantity - cnt;
                        var newprice = (newquantity * line.ProductPrice) + (oldquantity * line.ProductPrice) / oldquantity;
                        line.ProductQuantity = newquantity;
                        line.ProductPrice = newprice;
                    }
                }
                return product.GetProductById(productId);
            }
           
        }
        public int GetProductQuantity(int productId)
        {
            FileStream JsonProductfile = File.Open(@"..\DataBase\Stock.json", FileMode.OpenOrCreate);
            _stocks = JsonSerializer.Deserialize<List<Stock>>(JsonProductfile);
            var stk = from st in _stocks
                      where st.ProductId == productId
                      select st.ProductQuantity;
            return stk.Sum();
        }
    }
}
