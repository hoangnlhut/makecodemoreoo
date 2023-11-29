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

        // #1 (interaction): Deposit was invoked on the state
        // #2 (behavior): Result of State.Deposit is new State
        // #5 (behavior): Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            State = State.Deposit(() => Balance += amount);
        }

        // #3 (interaction): WithDraw was invoked on the state
        // #4 (behavior): Result of State.WithDraw is new State
        // #6 (behavior): Deposit 1, Verify, Withdraw 1 - Balance ==9
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