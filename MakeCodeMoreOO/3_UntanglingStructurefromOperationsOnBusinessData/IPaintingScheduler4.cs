namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    public interface IPaintingScheduler4<TPainter> where TPainter : IPainter
    {
        IEnumerable<PaintingTask4<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }


    /// <summary>
    /// concreate class of strategy
    /// </summary>
    /// <typeparam name="TPainter"></typeparam>
    public class PropotionalPaitingSchedul4 : IPaintingScheduler4<ProportionalPainter>
    {
        public IEnumerable<PaintingTask4<ProportionalPainter>> Schedule(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            IEnumerable<Tuple<ProportionalPainter, double>> velocities =
                painters.
                    Select(painter => Tuple.Create(painter, sqMeters/ painter.EstimateTimeToPaint(sqMeters).TotalHours)).ToList();

            double totalVelocity = velocities.Sum(tuple => tuple.Item2);

            IEnumerable<PaintingTask4<ProportionalPainter>> schedule =
                velocities.
                   Select(tuple => new PaintingTask4<ProportionalPainter>(tuple.Item1, sqMeters * tuple.Item2/totalVelocity)).ToList();

            return schedule;
        }
    }
}