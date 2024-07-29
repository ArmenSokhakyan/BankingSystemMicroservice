using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Presentation.API.DTOs.Referances
{
    public class AccountDTO
    {
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
    }
}
