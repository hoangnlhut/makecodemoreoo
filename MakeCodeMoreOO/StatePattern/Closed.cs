namespace MakeCodeMoreOO.StatePattern
{
    public class Closed : IAccountState
    {
        public IAccountState Close() => this;
        public IAccountState Deposit() => this;
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
        public IAccountState WithDraw() => this;
       
    }
}