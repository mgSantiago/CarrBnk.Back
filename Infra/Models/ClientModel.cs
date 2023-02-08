using System.ComponentModel.DataAnnotations;

namespace Infra.Models
{
    public record ClientModel
    {
        [Key]
        public Guid Code { get; set; }
        public string BusinessName { get; set; }
        public int RegistrationNumber { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
