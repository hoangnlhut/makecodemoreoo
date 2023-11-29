namespace MakeCodeMoreOO.StatePattern
{
    public class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; set; }
        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }
        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(OnUnfreeze);

        public IAccountState WithDraw(Action subtractFromBalance) => this;
    }
}