namespace PincherApp.Core.Classes
{
    internal class ResultCalculate : BaseSaler
    {
        public ResultCalculate(SalesInformation sales, double growth)
        {
            Count = sales.Count;
            MopMonthlyRevenue = (sales.MopMonthlyRevenue / 100 * growth) + sales.MopMonthlyRevenue;
            Conversion = (sales.Conversion / 100 * growth) + sales.Conversion;
        }

    }
}
