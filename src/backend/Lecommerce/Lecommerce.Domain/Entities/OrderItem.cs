using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lecommerce.Domain.Entities
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    [Table("order_items")]
    public class OrderItem
    {
        [Required]
        [Column("order_id")]
        public Guid OrderId { get; set; }

        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("total")]
        public decimal Total { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


        public OrderItem(Guid orderId, Guid productId, int quantity, decimal total)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Total = total;
        }
    }
}
