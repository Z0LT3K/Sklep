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
using Sklep;

namespace Sklep
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\Bartosz\source\repos\Sklep\Sklep\Products.csv";
            var allProducts = LoadProducts(csvPath);


            Methots.AddProduct();
           

            Console.WriteLine("Naciśnij strzałkę w górę lub w dół, aby poruszać się po liście. Naciśnij Enter, aby wyjść.");

            Console.ReadKey();
            Display(allProducts);

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
                Console.WriteLine(product);
            }
        }

        #endregion

        #region CsvReader 
        public static List<Product> LoadProducts(string csvPath)
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
