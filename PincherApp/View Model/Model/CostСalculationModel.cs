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

        public List<BaseItem> BiznessType = GoogleSheetsHelper.GetInformItemsFromSpreadsheet("1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg", "Лист1!F2:H");

        public SalesInformation getSales { get; } = new();
        public int Count
        {
            get => getSales.Count;
            set
            {
                getSales.Count = value;
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(RevenueYear));
            }
        }

        public double Conversion
        {
            get => getSales.Conversion;
            set
            {
                getSales.Conversion = value;
                OnPropertyChanged(nameof(Conversion));
            }
        }


        public double MopMonthlyRevenue
        {
            get => getSales.MopMonthlyRevenue;
            set
            {
                getSales.MopMonthlyRevenue = value;
                OnPropertyChanged(nameof(MopMonthlyRevenue));
                OnPropertyChanged(nameof(MopRevenueYear));
                OnPropertyChanged(nameof(RevenueYear));
            }
        }

        public double MopRevenueYear => getSales.MopRevenueYear;

        public double RevenueYear => getSales.RevenueYear;

        public double OperatingProfit
        {
            get => getSales.OperatingProfit;
            set => getSales.OperatingProfit = value;
        }
    }
}
