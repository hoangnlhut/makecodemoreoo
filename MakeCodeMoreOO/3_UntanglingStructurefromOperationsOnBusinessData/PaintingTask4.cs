namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    /// <summary>
    /// derived from tuple first to collect type and amount of data then collect it and then 
    /// transfer it to class
    /// </summary>
    /// <typeparam name="TPainter"></typeparam>
    public class PaintingTask4<TPainter> where TPainter : IPainter
    {
        public TPainter Painter { get; }
        public double SquareMeters { get; }

        public PaintingTask4(TPainter painter, double squareMeters)
        {
            Painter = painter;
            SquareMeters = squareMeters;
        }
    }
}