using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using LINQtoCSV;

namespace Sklep
{
    public class Methots
    {
        public static void START()
        {
            string csvPath = @"C:\Users\Bartosz J 4I2\source\repos\sklepik\Sklep\Products.csv";
            var allProducts = Methots.LoadProducts(csvPath);
        }
        private static IEnumerable<Product> allProducts;

        #region Operations
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

        public static void SelectAndView(List<Product> products)
        {

            int selected = 0;
            int products_lenght = products.Count;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < products_lenght; i++)
                {
                    if (i == selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(products[i]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(products_lenght - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine($"Your choice is = {products[selected]}");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Bad switch");
                        break;
                }

            }


        }

        public static string[] methods = { "Add product", "Display All", "Select and view" };
        public static void ShowMenu()
        {
            Console.Clear();
            Console.ResetColor();

            int selected = 0;
            int methots_lenght = methods.Length;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < methots_lenght; i++)
                {
                    if (i == selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(methods[i]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(methots_lenght - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        goto switch_methots;
                    default:
                        Console.WriteLine("Bad switch");
                        break;
                }
                switch_methots:
                switch (methods[selected]) 
                {
                    case ("Add product"):
                    AddProduct();
                    ShowMenu();
                        break;
                    case ("Display All"):
                        Display(allProducts);
                        
                        break;
                    case ("SelectAndView"):
                        break;
                        
                }

            }
            
            

              static void Display(IEnumerable<Product> allProducts)
            {
                foreach (var product in allProducts)
                {
                    Console.WriteLine(product);
                }
            }



        }
        #endregion

        #region CSV_Reader

       

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
