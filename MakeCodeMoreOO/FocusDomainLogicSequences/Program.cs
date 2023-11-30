namespace FocusDomainLogicSequences
{
    internal class Program
    {
        /// <summary>
        /// find which painter is available and have cheapest price to do
        /// </summary>
        /// <param name="sqMeters"></param>
        /// <param name="painters"></param>
        /// <returns></returns>
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCompensation(sqMeters));
        }
        static void Main(string[] args)
        {
            List<IPainter> list = new List<IPainter>()
            {
                new PainterA(),
                new PainterB(),
                new PainterC(),
            };

            Console.WriteLine("Get cheapest Painter from the list painter");
            var result = FindCheapestPainter(2, list);
            Console.WriteLine($"{nameof(result)} with cheapest price is {result.EstimateCompensation(2)}");
        }
    }

    public static class EnumerableExtentions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion) where T : class
                     where TKey : IComparable<TKey>
        {
            var result = sequence
            .Select(obj => Tuple.Create(obj, criterion(obj)))
            .Aggregate((Tuple<T, TKey>)null,
                (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
            .Item1;

            return result;
        }
            
    }

}