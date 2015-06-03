namespace SCGBank.Models
{
    public class TransferReceipt
    {
        public int DepositAccount { get; set; }
        public decimal DepositBalance { get; set; }
        public int WithdrawAccount { get; set; }
        public decimal WithdrawBalance { get; set; }
    }
}