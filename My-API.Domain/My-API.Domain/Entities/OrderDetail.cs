using System;
using System.Collections.Generic;
using System.Text;

namespace My_API.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float quantity { get; set; }
    }
}
