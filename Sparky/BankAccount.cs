namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogBook _logBook;
        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            Balance = 0;
        }
        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit method invoked"); 
            Balance+=amount;
            return true;
        }
        public bool Withdraw(int amount)
        {
            if(Balance>=amount)
            {
                _logBook.LogToDb("Withdrawal Amount: " + amount.ToString());
                Balance-=amount;
                return _logBook.LogBalanceAfterWithdrawal(Balance);
            }
            return _logBook.LogBalanceAfterWithdrawal(Balance-amount);
        }
        public int GetBalance()
        {
            return Balance;
        }
    }
}