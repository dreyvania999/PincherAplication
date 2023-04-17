using PincherApp.Core.Interfase;

namespace PincherApp.Core.Classes
{
    public abstract class BaseSaler : IManagers
    {

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    RevenueYear = MopRevenueYear * _count;
                }
            }
        }

        public double Conversion { get; set; }

        private double _mopMonthlyRevenue;
        public double MopMonthlyRevenue
        {
            get => _mopMonthlyRevenue;
            set
            {
                _mopMonthlyRevenue = value;
                MopRevenueYear = _mopMonthlyRevenue * 12;
                RevenueYear = MopRevenueYear * _count;
            }
        }

        public double MopRevenueYear { get; private set; }
        public double RevenueYear { get; private set; }
        public double OperatingProfit { get; set; }
    }
}
