namespace MakeCodeMoreOO.StatePattern
{
    /// <summary>
    /// Apply State Pattern 
    /// </summary>
    public interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState WithDraw(Action subtractFromBalance);
        IAccountState Freeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}