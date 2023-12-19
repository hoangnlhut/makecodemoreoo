namespace _10Refactoring
{
    public static class ControlDigitAlgorithms
    {

        public static ControlDigitAlgorithm ForAccountingDepartment =>
            new ControlDigitAlgorithm(x => x.DigitsFromHighest(), MultiplyingFactor, 7);

        public static ControlDigitAlgorithm ForSalesDepartment =>
           new ControlDigitAlgorithm(x => x.DigitsFromLowest(), MultiplyingFactor, 9);

        public static IEnumerable<int> MultiplyingFactor
        {
            get
            {
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }
    }
}