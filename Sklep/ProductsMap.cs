using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;


namespace Sklep
{
    public sealed class ProductsMap : ClassMap<Product>
    {
        public ProductsMap()
        {
            Map(p => p.Name).Name(nameof(Product.Name));
            Map(p => p.Quantity).Name(nameof(Product.Quantity));
            Map(p => p.Type).Name(nameof(Product.Type));
            Map(p => p.Price).Name(nameof(Product.Price));
            Map(p => p.Count).Name(nameof(Product.Count));
            


        }

        
    }

}
