using System.ComponentModel.DataAnnotations;

namespace NotificationServiceSystem.Presentation.API.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        [Required]
        public string Receiver { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
