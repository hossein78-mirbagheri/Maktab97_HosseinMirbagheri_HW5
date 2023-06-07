using HW5.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.CreateList
{
    public class CreateList
    {
        public bool AddProduct(int ProductId, string Name, int Barcode)
        {
            Product product = new Product();
            product.ProductId = ProductId;
            product.Name = Name;
            product.Barcode = Barcode;
            var jsonfile = JsonConvert.SerializeObject(product);
            return true;
        }

        public class ShowProduct
        {
            public string[] showlist(string path)
            {
                int i = 0;
                var d = File.ReadAllLines(path);
                string[] lines = new string[d.Length];
                foreach (string line in d)
                {
                    lines[i] = line;
                    i++;
                }
                if (d.Length == 0)
                {
                    return null;
                }
                return lines;
            }
        }
    }
   
}
