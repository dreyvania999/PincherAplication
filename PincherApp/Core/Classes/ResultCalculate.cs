
namespace PincherApp
{
    internal class ResultCalculate : IManagers
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
                }
            }
        }


    }
}
