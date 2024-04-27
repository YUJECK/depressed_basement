namespace PlayerStuff
{
    public sealed class PlayerWallet 
    {
        public int Balance { get; private set; }

        public PlayerWallet(int startingBalance)
        {
            Balance = startingBalance;
        }

        public bool CanBuy(int cost)
        {
            return cost <= Balance;
        }
        
        public void TopUp(int money)
        {
            Balance += money;
        }

        public void CashOut(int money)
        {
            Balance -= money;
        }
    }
}