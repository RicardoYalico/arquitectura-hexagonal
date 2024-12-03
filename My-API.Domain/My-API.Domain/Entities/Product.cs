using System;
using System.Collections.Generic;
using System.Text;

namespace My_API.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int OrderDetailID { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
