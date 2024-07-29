using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TransactionManagementSystem.Presentation.API.DTOs
{
    public class InTransactionDTO
    {
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string Note { get; set; }
    }
}
