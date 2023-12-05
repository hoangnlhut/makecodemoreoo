namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    public partial class CombiningPainter4<TPainter> : CompositePainter<TPainter> where TPainter : IPainter
    {
        //strategy
        private IPaintingScheduler4<TPainter> Scheduler { get; }
        public CombiningPainter4(IEnumerable<TPainter> painters, IPaintingScheduler4<TPainter> scheduleWork) : base(painters)
        {
            Reduce = Combine;
            Scheduler = scheduleWork;
        }

        //template
        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            IEnumerable<TPainter> availablePainters = painters.Where(painter => painter.IsAvailable);

            IEnumerable<PaintingTask4<TPainter>> schedule = this.Scheduler.Schedule(sqMeters, availablePainters);

            TimeSpan time = schedule.Max(task => task.Painter.EstimateTimeToPaint(task.SquareMeters));

            double cost = schedule.Max(task => task.Painter.EstimateCompensation(task.SquareMeters));

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}