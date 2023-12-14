using _8IncreasingFlexibilitybyAvoidingSwitchStatements.Common;
using System.Buffers;

namespace _8IncreasingFlexibilitybyAvoidingSwitchStatements
{
    public partial class SoldArticle 
    {
        // Money back if looks like new
        public IWarranty MoneyBackGuarantee { get; private set; }
        // Only if article doesn't work
        private IWarranty NotOperationalWarranty { get; }
        // If replaceable part malfunctions
        private IWarranty CircuitryWarranty { get; set; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();
        public DeviceStatus OperationalStatus { get; set; }
        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; } 


        public SoldArticle(IWarranty moneyBack, IWarranty express, IWarrantyMapFactory rulesFactory)
        {
            if (moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));

            if (express == null)
                throw new ArgumentNullException(nameof(express));

            MoneyBackGuarantee = moneyBack;
            NotOperationalWarranty = express;
            CircuitryWarranty = VoidWarranty.Instance;

            //new apply with new way

            OperationalStatus = DeviceStatus.AllFine();
            WarrantyMap = rulesFactory.Create(ClaimMoneyBack, ClaimNotOperationalWarranty, ClaimCircuitryWarranty);
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            CircuitryWarranty = extendedWarranty;
            //OperationalStatus &= ~DeviceStatus.CircuitryFailed;
            OperationalStatus = OperationalStatus.CircuitryFailed();
        }

        /// <summary>
        /// Failure detected in electrical part
        /// </summary>
        /// <param name="detectedOn"></param>
        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry
                .WhenSome()
                .Do(c =>
                {
                    c.MarkDefective(detectedOn);
                    //OperationalStatus |= DeviceStatus.CircuitryFailed;
                    OperationalStatus = OperationalStatus.CircuitryFailed();
                })
                .Execute();
        }

        /// <summary>
        // Rule out(eliminate) money back guarantee
        /// </summary>
        public void VisibleDamage()
        {
            //OperationalStatus |= DeviceStatus.VisiblyDamaged;
            OperationalStatus = OperationalStatus.WithVisibleDamage();
        }

        /// <summary>
        /// Activates or deactivates express warranty
        /// </summary>
        public void NotOperational()
        {
            //OperationalStatus |= DeviceStatus.NotOperational;
            OperationalStatus = OperationalStatus.NotOperational();
        }

        /// <summary>
        /// Activates or deactivates express warranty
        /// </summary>
        public void Repaired()
        {
            //OperationalStatus &= DeviceStatus.NotOperational;
            OperationalStatus = OperationalStatus.NotOperational();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            //traditional way with swich case
            //switch (OperationalStatus)
            //{
            //    case DeviceStatus.AllFine:
            //        MoneyBackGuarantee.Claim(DateTime.Now, onValidClaim);
            //        break;
            //    case DeviceStatus.VisiblyDamaged:
            //        break;
            //    case DeviceStatus.NotOperational:
            //    case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged:
            //    case DeviceStatus.NotOperational | DeviceStatus.CircuitryFailed:
            //    case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
            //        NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
            //        break;
            //    case DeviceStatus.CircuitryFailed:
            //        Circuitry
            //            .WhenSome()
            //            .Do(c => CircuitryWarranty.Claim(c.DefectDetectedOn, onValidClaim))
            //            .Execute();
            //        break;
            //}

            //new way with three dispatch dynamic
            WarrantyMap[OperationalStatus].Invoke(onValidClaim);
        }

    }
}