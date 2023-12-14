namespace _8IncreasingFlexibilitybyAvoidingSwitchStatements
{
    public class LifeTimeWaranty : IWarranty
    {
        private DateTime IssuingDate { get; }
        public LifeTimeWaranty(DateTime issuingDate)
        {
            IssuingDate = issuingDate;
        }
        private bool IsValidOn(DateTime date)
         => date.Date >= IssuingDate;

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate)) return;
            onValidClaim();
        }
    }
}