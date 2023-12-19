namespace _10Refactoring
{
    public class ControlDigitAlgorithm
    {
        private Func<long, IEnumerable<int>> GetDigitsOf { get; }
        private IEnumerable<int> MultiplyingFactor { get; }
        private int Modulo { get; }
        public ControlDigitAlgorithm(Func<long, IEnumerable<int>> getDigitsOf, IEnumerable<int> multiplyingFactor, int modulo)
        {
            GetDigitsOf = getDigitsOf;
            MultiplyingFactor = multiplyingFactor;
            Modulo = modulo;
        }

        public  int GetControlDigitRefactor(long number)
        {
            return
                GetDigitsOf(number)
                .Zip(MultiplyingFactor, (a, b) => a * b)
                .Sum() % Modulo;

        }
    }
}