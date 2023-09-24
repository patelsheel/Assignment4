using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer? Customer { get; set; } = null;

        public virtual ICollection<OrderLineItem>
            OrderItems
        { get; set; } = new List<OrderLineItem>();
    }
}

