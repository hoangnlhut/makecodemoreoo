namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new List<ProportionalPainter>()
            {
                new ProportionalPainter(){TimePerSqMeter = new TimeSpan(1,0,0), DollarsPerHour = 1},
                new ProportionalPainter(){TimePerSqMeter = new TimeSpan(2,0,0), DollarsPerHour = 2},
                new ProportionalPainter(){TimePerSqMeter = new TimeSpan(3,0,0), DollarsPerHour = 3},
            };

            //IPainter result = CompositePainterFactories.CreateGroup(painters);

            IPainter result = CompositePainterFactories34.CombineProportional(painters);
            var isAvailable = result.IsAvailable;
            var estimateTime = result.EstimateTimeToPaint(10);
            var estimateCompensation = result.EstimateCompensation(10);

            //IPainter resultCheapeast = CompositePainterFactories.CreateCheapestSelector(painters);

            //var isAvailable1 = resultCheapeast.IsAvailable;
            //var estimateTime1 = resultCheapeast.EstimateTimeToPaint(10);
            //var estimateCompensation1 = resultCheapeast.EstimateCompensation(10);

            //IPainter resultFastest = CompositePainterFactories.CreateFastestSelector(painters);

            //var isAvailable2 = resultCheapeast.IsAvailable;
            //var estimateTime2 = resultCheapeast.EstimateTimeToPaint(10);
            //var estimateCompensation2 = resultCheapeast.EstimateCompensation(10);
        }
    }
}