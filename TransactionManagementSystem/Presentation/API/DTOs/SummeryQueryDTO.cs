namespace TransactionManagementSystem.Presentation.API.DTOs
{
    public class SummeryQueryDTO
    {
        public int AccountID { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
    }
}
