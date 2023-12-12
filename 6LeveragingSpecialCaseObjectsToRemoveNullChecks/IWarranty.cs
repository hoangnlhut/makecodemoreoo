namespace _6LeveragingSpecialCaseObjectsToRemoveNullChecks
{
    public interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim);
    }
}