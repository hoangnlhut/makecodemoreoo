namespace MakeCodeMoreOO.StatePattern
{
    public class Active : IAccountState
    {
        private Action OnUnfreeze { get; }
        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }
        public IAccountState Freeze()
        {
            return new Frozen(OnUnfreeze);
        }

        public IAccountState WithDraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}