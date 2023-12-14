namespace _8IncreasingFlexibilitybyAvoidingSwitchStatements
{
    public class Program
    {
        public static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;

            article.MoneyBackGuarantee.Claim(now, () => Console.WriteLine("Offer Money Back"));
            article.ExpressWarranty.Claim(now, () => Console.WriteLine("Offer repair"));
        }


        public static void Main(string[] args)
        {
            //DateTime sellingDate = new DateTime(2023, 11, 11);
            //TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            //TimeSpan warrantySpan = TimeSpan.FromDays(360);

            //IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            ////IWarranty warranty = new TimeLimitedWarranty(sellingDate, warrantySpan);
            //IWarranty warranty = new LifeTimeWaranty(sellingDate);

            //SoldArticle article = new SoldArticle(moneyBack, warranty);
            //ClaimWarranty(article);


            //SoldArticle noWarrantiedarticle = new SoldArticle(VoidWarranty.Instance, VoidWarranty.Instance);
            //ClaimWarranty(noWarrantiedarticle);





        }
    }
}