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
    public class Methots
        {
        public static void AddProduct()
        {
            Console.WriteLine("Input the name:");
            var name = Console.ReadLine();

            Console.WriteLine("Input the quantity:");
            var quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose the type:");
            foreach (var i in Enum.GetValues(typeof(Type)))
                Console.WriteLine(i);
            Type type = (Type)Enum.Parse(typeof(Type), Console.ReadLine());

            Console.WriteLine("Input the price:");
            string pricee = (Console.ReadLine());
            pricee = pricee.Replace(",", ".");
            decimal price = decimal.Parse(pricee);


            Console.WriteLine("Input the count:");
            foreach (var j in Enum.GetValues(typeof(Count)))
                Console.WriteLine(j);
            Count count = (Count)Enum.Parse(typeof(Count), Console.ReadLine());

            StreamWriter sw = new StreamWriter(@"C:\Users\Bartosz\source\repos\Sklep\Sklep\Products.csv", true);
            Product product = new Product();
            product.Name = name;
            product.Quantity = quantity;
            product.Type = type;
            product.Price = price;
            product.Count = count;

            sw.WriteLine(product.Name + "," + product.Quantity + "," + product.Type + "," + product.Price + "," + product.Count);
            sw.Close();
            Console.WriteLine("DONE");
        }
    }
}
