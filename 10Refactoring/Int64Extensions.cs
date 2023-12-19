namespace _10Refactoring
{
    static class Int64Extensions
    {
        // read read number from right to left
        public static IEnumerable<int> DigitsFromLowest(this long number)
        {
            do {
                yield return (int)number % 10;
                number /= 10;

            } while (number > 0);
        }

        // add new requirement to read number from left to right
        public static IEnumerable<int> DigitsFromHighest(this long number) => number.DigitsFromLowest().Reverse();


    }
}