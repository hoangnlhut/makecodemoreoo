namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }

    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHour { get; set; }
        public bool IsAvailable => true;

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);
        }

        public double EstimateCompensation(double sqMeters)
        {
            return (EstimateTimeToPaint(sqMeters)).TotalHours * DollarsPerHour;
        }
    }
}