using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lecommerce.Domain.Entities
{
    [Table("clients")]
    public class Client
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        public string? Cpf { get; set; }

        [Column("cnpj")]
        public string? Cnpj { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }

        [Column("deletion_date")]
        public DateTime? DeletionDate { get; set; }

        public Client()
        {
        }

        public Client(string name, string document, bool isCpf)
        {
            if (isCpf)
                Cpf = document;
            else
                Cnpj = document;

            Id = Guid.NewGuid();
            Name = name;
            Active = true;

            CreationDate = DateTime.UtcNow;
        }

        public void Deletion()
        {
            Active = false;
            DeletionDate = DateTime.UtcNow;
        }

        public void Update(string name, string document, bool isCpf)
        {
            if (isCpf)
            {
                Cpf = document;
                Cnpj = null;
            }
            else
            {
                Cnpj = document;
                Cpf = null;
            }

            Name = name;

            UpdateDate = DateTime.UtcNow;
        }
    }
}
