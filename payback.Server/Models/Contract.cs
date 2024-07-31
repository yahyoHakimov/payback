namespace payback.Server.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
    }
}
