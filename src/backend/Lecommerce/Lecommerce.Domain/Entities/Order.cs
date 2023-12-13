using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lecommerce.Domain.Entities
{
    [Table("orders")]
    public class Order
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("code")]
        public int Code { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column("client_id")]
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public Order()
        {
            CreationDate = DateTime.UtcNow;
            Items = new List<OrderItem>();
            Id = Guid.NewGuid();
        }

        public Order(Guid clientId) : this()
        {
            ClientId = clientId;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
