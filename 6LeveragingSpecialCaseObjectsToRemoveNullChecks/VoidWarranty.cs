namespace _6LeveragingSpecialCaseObjectsToRemoveNullChecks
{
    public class VoidWarranty : IWarranty
    {
        [ThreadStatic]
        private static VoidWarranty instanceNull;
        
        //ensure nobody can be able to instantiate this class directly;
        private VoidWarranty()
        {

        }
        public static VoidWarranty Instance { 
            get 
            { 
                if(instanceNull == null) instanceNull = new VoidWarranty();
                return instanceNull; 
            } 
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {
        }
    }
}