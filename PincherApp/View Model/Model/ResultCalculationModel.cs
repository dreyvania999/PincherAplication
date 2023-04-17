using PincherApp.Core.Classes;
using System.ComponentModel;

namespace PincherApp
{
    internal class ResultCalculationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ResultCalculationModel(SalesInformation sales, double growth)
        {
            _Resultsales = new ResultCalculate(sales, growth);
            _sales = sales;
        }

        private readonly ResultCalculate _Resultsales;

        private readonly SalesInformation _sales;
        public int Count => _sales.Count;

        public double Conversion => _sales.Conversion;


        public double MopMonthlyRevenue => _sales.MopMonthlyRevenue;

        public double MOPRevenue => _sales.MopRevenueYear;

        public double YearRevenue => _sales.RevenueYear;

        public double NewConversion => _Resultsales.Conversion;


        public double NewMopMonthlyRevenue => _Resultsales.MopMonthlyRevenue;

        public double NewMOPRevenue => _Resultsales.MopRevenueYear;

        public double NewYearRevenue => _Resultsales.RevenueYear;
    }
}
