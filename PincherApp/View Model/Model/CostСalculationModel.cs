namespace PincherApp
{
    internal class CostСalculationModel
    {
        private readonly SalesInformation sales = new();

        public int Count
        {
            get => sales.Count;
            set => sales.Count = value;
        }

        public double Conversion
        {
            get => sales.Conversion;
            set => sales.Conversion = value;
        }


        public double MopMonthlyRevenue
        {
            get => sales.MopMonthlyRevenue;
            set => sales.MopMonthlyRevenue = value;
        }

        public double MopRevenueYear => sales.MopRevenueYear;

        public double RevenueYear => sales.RevenueYear;

        public double OperatingProfit
        {
            get => sales.OperatingProfit;
            set => sales.OperatingProfit = value;
        }
    }
}
