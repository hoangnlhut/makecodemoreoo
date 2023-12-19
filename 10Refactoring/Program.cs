using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _10Refactoring
{
    public static class ControlDigit
    {
        #region origin logic
        public static int GetControlDigit(long number)
        {
            int sum = 0;
            bool isOddPos = true;

            // separate digit
            // loop through digits
            // multiply every other  digit by three
            // Calculate pondered sum of digits
            //take modulo 7 of the sum

            while (number > 0)                 // infrastructure
            {
                int digit = (int)(number % 10); //infrastructure
                if(isOddPos)               // domain
                {
                    sum += 3 * digit;      //3 = parameter
                }
                else                       // += and *= infrastructure
                {
                    sum += digit;
                }
                number /= 10; //infrastructure
                isOddPos = !isOddPos;     // domain
            }
            
            int modulo = sum % 7;        //7 = parameter
            return modulo;               // % = domain
        }

        #endregion
        #region refactory from original
        //public static int GetControlDigitRefactor(long number, Func<long, IEnumerable<int>> getDigitsOf, IEnumerable<int> multiplyingFactor, int modulo)
        //{

        //    //first approach : use for each
        //    //int sum = 0
        //    // IEnumerator<int> factor = MultiplyingFactor.GetEnumerator();

        //    //foreach (var digit in GetDigitsOf(number))
        //    //{
        //    //    factor.MoveNext();
        //    //    sum += digit * factor.Current;
        //    //}
        //    //int modulo = sum % 7;
        //    //return modulo;

        //    //  second approach: use zip of Linq: zip 2 sequences into a single sequence
        //    return
        //        getDigitsOf(number)
        //        .Zip(multiplyingFactor, (a, b) => a * b).Sum() % modulo;

        //}

        //private static IEnumerable<int>  GetDigitsOf(long number)
        //{
        //    IList<int> digits = new List<int>();

        //    //this loop no domain logic, no algorithms around
        //    while (number > 0)
        //    {
        //        digits.Add((int)(number % 10));
        //        number /= 10;
        //    }

        //    return digits;
        //}

        public static IEnumerable<int> MultiplyingFactor
        {
            get
            {
                //return new int[] { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1 };
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var getResult = ControlDigit.GetControlDigitRefactor(12345);
            //var getResult = ControlDigit.GetControlDigitRefactor(12345, x => x.DigitsFromLowest(), ControlDigit.MultiplyingFactor, 7);

            //var getResult = new ControlDigitAlgorithm( x => x.DigitsFromLowest(), ControlDigit.MultiplyingFactor, 7).GetControlDigitRefactor(12345);
            var getResult = ControlDigitAlgorithms.ForSalesDepartment.GetControlDigitRefactor  (12345);

            Console.WriteLine($"{getResult}");
        }
    }
}