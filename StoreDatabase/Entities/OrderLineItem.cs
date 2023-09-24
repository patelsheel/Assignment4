using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities
{
    [Table("OrderLineItem")]
    public class OrderLineItem
    {
        public int OrderLineItemID { get; set; }
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public virtual Product? Product { get; set; } = null;

        
    }
}

