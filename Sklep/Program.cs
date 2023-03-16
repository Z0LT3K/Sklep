using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Sklep
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\Bartosz\source\repos\Sklep\Sklep\Pruducts.csv";

            var allProducts = LoadProducts(csvPath);

            ShowAll(allProducts);
        }


        static void Display(Product product)
        {
            Console.WriteLine(product);
        }

        static void ShowAll(IEnumerable<Product> products)
        {
            foreach(var product in products)
            {
                Console.WriteLine(product);
            }
        }
        static List<Product> LoadProducts(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                
                csv.Context.RegisterClassMap<ProductsMap>();
                var records = csv.GetRecords<Product>().ToList();
                
                return records;
            }

        }

    }
}
