﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Type Type{ get; set; }
        public decimal Price { get; set; }
        public Count Count { get; set; }
    }
}
