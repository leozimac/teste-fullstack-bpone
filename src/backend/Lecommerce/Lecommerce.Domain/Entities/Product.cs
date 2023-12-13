using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lecommerce.Domain.Entities
{
    [Table("products")]
    public class Product
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("code")]
        public int Code { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Required]
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }

        [Column("deletion_date")]
        public DateTime? DeletionDate { get; set; }

        public Product()
        {
            
        }

        public Product(string name, int code, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
            Price = price;
            Active = true;
            CreationDate = DateTime.UtcNow;
        }

        public void UpdateProperties(string name, int code, decimal price)
        {
            Name = name;
            Code = code;
            Price = price;
            UpdateDate = DateTime.UtcNow;
        }

        public void SetDeleted()
        {
            Active = false;
            DeletionDate = DateTime.UtcNow;
        }
    }
}
