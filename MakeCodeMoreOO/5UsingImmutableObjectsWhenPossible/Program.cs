namespace _5UsingImmutableObjectsWhenPossible
{
    internal class Program
    {
        static bool IsHappyHour { get; set; }
        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            MoneyAmount moneyAmount = cost;
            if (IsHappyHour)
            {
                factor = .5M;
            }
            Console.WriteLine($"\n Reserving an item that costs reduced to {cost}");
            return moneyAmount.Scale(factor);
        }

        
        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        { 
            bool enoughMoney = wallet.Amount >= cost.Amount;

            var newMoneyAmount = Reserve(cost);

            bool realEnoughMoney = wallet.Amount >= newMoneyAmount.Amount;

            if(realEnoughMoney)
            {
                Console.WriteLine($"You will pay {newMoneyAmount} with your wallet {wallet}");
            }
            else
            {
                Console.WriteLine($"You cannot pay {newMoneyAmount} with your {wallet}");
            }
        }
        static void Main(string[] args)
        {
            //Buy(new MoneyAmount(12, "USD"),
            //    new MoneyAmount(10, "USD"));

            //IsHappyHour = true;

            //Buy(new MoneyAmount(7, "USD"),
            //    new MoneyAmount(10, "USD"));

            //MoneyAmount x = new MoneyAmount(12, "USD");
            //MoneyAmount y = new MoneyAmount(12, "USD");

            //HashSet<MoneyAmount> set = new HashSet<MoneyAmount>();

            //set.Add(x);

            //if(set.Contains(y))
            //{
            //    Console.WriteLine("Cannot add repeated value");
            //}
            //else
            //{
            //    set.Add(y);
            //}

            //Console.WriteLine($"Count: {set.Count}");


            MoneyAmount x = new MoneyAmount(12, "USD");
            MoneyAmount y = new MoneyAmount(12, "USD");

            if(x == y)
            {
                Console.WriteLine("Values are equals");
            }
            else
            {
                Console.WriteLine("Values are not equal");
            }
        }
    }
}