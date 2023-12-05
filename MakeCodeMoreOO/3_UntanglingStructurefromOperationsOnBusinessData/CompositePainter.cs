namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    public class CompositePainter<TPainter> : IPainter where TPainter : IPainter
    {
        public bool IsAvailable => painters.Any(painter => painter.IsAvailable);
        private IEnumerable<TPainter> painters { get; }
        protected Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; set; }
        public CompositePainter(IEnumerable<TPainter> painterslist, Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            painters = painterslist;
            Reduce = reduce;
        }

        public double EstimateCompensation(double sqMeters)
        => Reduce(sqMeters, painters).EstimateCompensation(sqMeters);

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        => Reduce(sqMeters, painters).EstimateTimeToPaint(sqMeters);
    }
}