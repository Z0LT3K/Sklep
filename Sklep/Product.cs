using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Type Type { get; set; }
        public decimal Price { get; set; }
        public Count Count { get; set; }
        public override string ToString()
        {
            return $"{Name, -10} {Quantity, -5} {Type, -10} {Price, -6} {Count, -7}";

        }

    }
}
