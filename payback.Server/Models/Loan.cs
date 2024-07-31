namespace payback.Server.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string? Borrower { get; set; }
        public string? Lender { get; set; }
        public bool IsRepaid { get; set; }

    }
}
