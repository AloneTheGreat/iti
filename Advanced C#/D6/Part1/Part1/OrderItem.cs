﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"{Item.Name}, {Quantity}";
        }
    }
}
