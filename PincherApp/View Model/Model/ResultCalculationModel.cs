using PincherApp.Core.Classes;
using PincherApp.Core.StaticClasses;
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
        public double Prirost { get; set; }
        public ResultCalculationModel(SalesInformation sales, double growth)
        {     

            _Resultsales = new ResultCalculate(sales, growth);
            Prirost = growth;
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

        public double OneMinuteCost
        {
            get
            {
                List<object> l = BaseProgrammInform.sheetsHelper.GetSpreadsheetValues(BaseProgrammInform.TableID, BaseProgrammInform.CostTableRange)[0].ToList();
                return Convert.ToDouble(l[0]);
            }
        }

        private double _minuteCount=25;
        public double MinuteCount
        {
            get => _minuteCount;
            set
            {
                _minuteCount = value;
                OnPropertyChanged(nameof(MinuteCount));
                OnPropertyChanged(nameof(MOPMonthCost));
                OnPropertyChanged(nameof(MonthPartCost));
                OnPropertyChanged(nameof(PartCost));
                OnPropertyChanged(nameof(ROI));
                OnPropertyChanged(nameof(TotalProfit));
            }
        }
        private double _dayCount=22;
        public double DayCount
        {
            get => _dayCount;
            set
            {
                _dayCount = value;
                OnPropertyChanged(nameof(DayCount));
                OnPropertyChanged(nameof(MOPMonthCost));
                OnPropertyChanged(nameof(MonthPartCost));
                OnPropertyChanged(nameof(PartCost));
                OnPropertyChanged(nameof(ROI));
                OnPropertyChanged(nameof(TotalProfit));
            }
        }
        public double MOPMonthCost => MinuteCount * OneMinuteCost * DayCount;
        public double MonthPartCost => MinuteCount * OneMinuteCost * Count * DayCount;
        public double PartCost => MinuteCount * OneMinuteCost * Count * DayCount * 3;
        public double MoreYearProfit => _Resultsales.RevenueYear - _sales.RevenueYear;
        public double YearProfit => ((_Resultsales.RevenueYear - _sales.RevenueYear) / 100) * _sales.OperatingProfit;
        public double TotalProfit => YearProfit - PartCost;
        public double ROI => (YearProfit - PartCost) / YearProfit * 100;
    }
}
