namespace MakeCodeMoreOO.StatePattern
{
    public class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; set; }
        public Frozen(Action actionOnUnfreeze)
        {
            OnUnfreeze = actionOnUnfreeze;
        }
        public IAccountState Freeze()
        {
            OnUnfreeze();
            return new Active(OnUnfreeze);
        }

        public IAccountState Deposit(Action addToBalance)
        {
            OnUnfreeze();
            addToBalance();
            return new Active(OnUnfreeze);
        }

        public IAccountState WithDraw(Action subtractFromBalance)
        {
           OnUnfreeze() ;
            subtractFromBalance();
            return new Active(OnUnfreeze);
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}