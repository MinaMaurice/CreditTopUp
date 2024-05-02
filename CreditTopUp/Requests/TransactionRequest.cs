namespace CreditTopUp.Requests
{
    public class TransactionRequest
    {
        public int UserId { get; set; }
        public int BeneficiaryId { get; set; }
        public decimal Amount { get; set; }
    }
}
