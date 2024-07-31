using System.ComponentModel.DataAnnotations;

namespace IntegrationTest.Models
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        public string Receiver { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
