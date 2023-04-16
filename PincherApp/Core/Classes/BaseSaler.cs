namespace PincherApp
{
    abstract class BaseSaler : IManagers
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
                    _revenueYear = _mopRevenueYear * _count;
                }
            }
        }

        private double _currentCconversion;
        public double Conversion
        {
            get => _currentCconversion;
            set
            {
                _currentCconversion = value;
            }
        }

        private double _mopMonthlyRevenue;
        public double MopMonthlyRevenue
        {
            get => _mopMonthlyRevenue;
            set
            {
                _mopMonthlyRevenue = value;
                _mopRevenueYear = _mopMonthlyRevenue * 12;
                _revenueYear = _mopRevenueYear * _count;
            }
        }

        private double _mopRevenueYear;
        public double MopRevenueYear
        {
            get => _mopRevenueYear;
        }

        private double _revenueYear;
        public double RevenueYear
        {
            get => _revenueYear;
        }

        private double _operatingProfit;
        public double OperatingProfit
        {
            get => _operatingProfit;
            set
            {
                _operatingProfit = value;
            }
        }
    }
}
