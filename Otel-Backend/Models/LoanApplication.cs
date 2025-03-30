namespace Models
{
    public class LoanApplication (int customerId, int productId, decimal amount, int termMonths)      
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public int CustomerId {get; set;} = customerId;
        public int ProductId {get; set;} = productId;
        public decimal Amount {get; set;} = amount;
        public int TermMonths {get; set;} = termMonths;
        public string Status {get; set;} = "Pending"; //default status
    }
}
