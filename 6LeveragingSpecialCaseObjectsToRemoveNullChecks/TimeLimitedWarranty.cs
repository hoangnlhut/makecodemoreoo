namespace _6LeveragingSpecialCaseObjectsToRemoveNullChecks
{
    public class TimeLimitedWarranty : IWarranty
    {
        private DateTime DateIssued { get; }
        private TimeSpan Duration { get; }
        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            DateIssued = dateIssued;
            Duration = duration;
        }

        private bool IsValidOn(DateTime date)
            => date.Date >= DateIssued && date.Date < this.DateIssued + this.Duration;

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate)) return;
            onValidClaim();
        }
    }
}