namespace _5UsingImmutableObjectsWhenPossible
{
    sealed class MoneyAmount : IEquatable<MoneyAmount>
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor)
        => new MoneyAmount(Amount * factor, CurrencySymbol);

        //do not overload operator -> make code quite hard readable
        //public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);

        public override bool Equals(object? obj)
        => Equals(obj as MoneyAmount);

        //when you override Equals then you should override GetHashCode
        public bool Equals(MoneyAmount other)
            => other != null && Amount == other.Amount && CurrencySymbol == other.CurrencySymbol;

        public override int GetHashCode()
            => Amount.GetHashCode() ^ CurrencySymbol.GetHashCode();

        public static bool operator ==(MoneyAmount a, MoneyAmount b)
            => (ReferenceEquals(a, null) && ReferenceEquals(b, null)) || (ReferenceEquals(a, null) & a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b)
           =>  !( a == b);

        public override string ToString()
        => $"{Amount} {CurrencySymbol}";

       
    }
}