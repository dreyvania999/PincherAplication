
namespace PincherApp
{
    internal class ResultCalculate : BaseSaler
    {
       public ResultCalculate(SalesInformation sales, double growth)
        {
            this.Count = sales.Count;
            this.MopMonthlyRevenue = (sales.MopMonthlyRevenue/100)* growth+ sales.MopMonthlyRevenue;
            this.Conversion = (sales.Conversion / 100) * growth + sales.Conversion;
        }

    }
}
