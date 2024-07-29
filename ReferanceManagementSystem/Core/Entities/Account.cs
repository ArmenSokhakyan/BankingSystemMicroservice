using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReferanceManagementSystem.Core.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountHolder { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountCurrency { get; set; }

        [Required]
        public DateTime creationDate { get; set; } = DateTime.UtcNow;
    }
}
