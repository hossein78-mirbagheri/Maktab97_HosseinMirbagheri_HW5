using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Domain
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        //meghdare mahsole
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }


    }
}
