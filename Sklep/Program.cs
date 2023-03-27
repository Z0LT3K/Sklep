using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using LINQtoCSV;

namespace Sklep
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\Bartosz\source\repos\Sklep\Sklep\Products.csv";

            var allProducts = LoadProducts(csvPath);

            Console.WriteLine("Input the name:");
            var name = Console.ReadLine();
            Console.WriteLine("Input the quantity:");
            var quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the type:");
            foreach (var i in Enum.GetValues(typeof(Type)))
                Console.WriteLine(i);
            
            Type type = Console.ReadLine();
            Console.WriteLine("Input the price:");
            var price = Console.ReadLine();
            Console.WriteLine("Input the count:");
            foreach (var j in Enum.GetValues(typeof(Count)))
                Console.WriteLine(j);
            var count = Console.ReadLine();

            StreamWriter sw = new StreamWriter(@"C:\Users\Bartosz\source\repos\Sklep\Sklep\Products.csv", true);
            Product product = new Product();
            product.Name = name;
            product.Quantity = quantity;
            product.Type = type;

            sw.WriteLine(product.Name + "," + product.Quantity + "," + product.Type + "," + product.Price + "," + product.Count);



        }

        public static void GetTypes()
        {
            foreach (int i in Enum.GetValues(typeof(Type)))
                Console.WriteLine(i);

        }
        #region Display
        static void GetData(IEnumerable<Product> allProducts)
        {
            var BreadProduct = allProducts.Where(a => a.Type == Type.Bread);
            Display(BreadProduct);
        }

        static void Display(IEnumerable<Product> allProducts)
        {
            foreach (var product in allProducts)
            {
                Console.WriteLine(product.Name + ", " + product.Quantity + ", " + product.Type + ", " + product.Price + ", " + product.Count);
            }
        }

        #endregion

        #region CsvReader 
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

        
        #endregion

    }

}
