using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep
{
    class Magazine
    {
        public List<Product> Products { get; set; } = new List<Product>();
        
       public void AddProduct(Product product)
            {
            Products.Add(product);
            }
        
    }
}
