using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            Methots.START();
            



            
            Methots.ShowMenu();
            //Methots.SelectAndView(allProducts);
            Console.ReadKey();

         

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
            //Display(BreadProduct);
        }


        #endregion

        #region CsvReader 
       

        
        #endregion

    }

}
