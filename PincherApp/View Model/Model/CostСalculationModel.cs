using PincherApp.Core.Classes;
using PincherApp.Core.StaticClasses;
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

        public List<BaseItem> BiznessType = GoogleSheetsHelper.GetInformItemsFromSpreadsheet(BaseProgrammInform.TableID, BaseProgrammInform.TableBysinessTypeRange);

        public SalesInformation GetSales { get; } = new();
        public int Count
        {
            get => GetSales.Count;
            set
            {
                GetSales.Count = value;
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(RevenueYear));
            }
        }

        public double Conversion
        {
            get => GetSales.Conversion;
            set
            {
                GetSales.Conversion = value;
                OnPropertyChanged(nameof(Conversion));
            }
        }


        public double MopMonthlyRevenue
        {
            get => GetSales.MopMonthlyRevenue;
            set
            {
                GetSales.MopMonthlyRevenue = value;
                OnPropertyChanged(nameof(MopMonthlyRevenue));
                OnPropertyChanged(nameof(MopRevenueYear));
                OnPropertyChanged(nameof(RevenueYear));
            }
        }

        public double MopRevenueYear => GetSales.MopRevenueYear;

        public double RevenueYear => GetSales.RevenueYear;

        public double OperatingProfit
        {
            set => GetSales.OperatingProfit = value;
        }
    }
}
