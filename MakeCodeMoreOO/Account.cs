using MakeCodeMoreOO.StatePattern;

namespace MakeCodeMoreOO
{
    public class Account
    {
        public decimal Balance { get; set; }
        private IAccountState State { get; set; }

        public Account(Action onUnfreeze)
        {
            State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            State = State.Deposit(() => Balance += amount);
        }

        public void WithDraw(decimal amount)
        {
            State = State.WithDraw(() => Balance -= amount);
        }

        public void Freeze()
        {
            State = State.Freeze();
        }

        public void HolderVerified()
        { 
            State = State.HolderVerified(); 
        }

        public void Close()
        { 
            State = State.Close();
        }    
    }
}