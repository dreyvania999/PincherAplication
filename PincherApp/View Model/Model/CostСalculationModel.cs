using PincherApp.Core.Classes;
using System.ComponentModel;

namespace PincherApp
{
    internal class CostСalculationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private SalesInformation sales = new();

        public List<BaseItem> BiznessType = GoogleSheetsHelper.GetInformItemsFromSpreadsheet("1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg", "Лист1!F2:H");

        public int Count
        {
            get => sales.Count;
            set
            {
                sales.Count = value;
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(RevenueYear));
            }
        }

        public double Conversion
        {
            get => sales.Conversion;
            set
            {
                sales.Conversion = value;
                OnPropertyChanged(nameof(Conversion));
            }
        }


        public double MopMonthlyRevenue
        {
            get => sales.MopMonthlyRevenue;
            set
            {
                sales.MopMonthlyRevenue = value;
                OnPropertyChanged(nameof(MopMonthlyRevenue));
                OnPropertyChanged(nameof(MopRevenueYear));
                OnPropertyChanged(nameof(RevenueYear));
            }
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
