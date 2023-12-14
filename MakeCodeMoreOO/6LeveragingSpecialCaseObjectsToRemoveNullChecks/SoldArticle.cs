using _8IncreasingFlexibilitybyAvoidingSwitchStatements.Common;

namespace _8IncreasingFlexibilitybyAvoidingSwitchStatements
{
    public class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        private IWarranty NotOperationalWarranty { get; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();
        private IWarranty FailedCircuitryWarranty { get; set; }
        private IWarranty CircuitryWarranty { get; set; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            if (moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));

            if (express == null)
                throw new ArgumentNullException(nameof(express));

            MoneyBackGuarantee = moneyBack;
            ExpressWarranty = VoidWarranty.Instance;
            NotOperationalWarranty = express;
            CircuitryWarranty = VoidWarranty.Instance;
        }

        public void VisibleDamage()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
            ExpressWarranty = NotOperationalWarranty;
        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry.Do(circuitrySingle =>
            {
                circuitrySingle.MarkDefective(detectedOn);
                CircuitryWarranty = FailedCircuitryWarranty;
            });
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            FailedCircuitryWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            Circuitry.Do(circuitrySingle => CircuitryWarranty.Claim(circuitrySingle.DefectDetectedOn, onValidClaim));
        }
    }
}