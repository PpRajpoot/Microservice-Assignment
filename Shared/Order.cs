﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Order
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
