using HW5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Interfase
{
    public interface IStockRepository
    {
        string SaleProduct(int productId, int cnt);
        void BuyProduct(Stock productInStock);
        List<Stock> GetSalesProductList();
    }
}
