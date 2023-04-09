namespace PincherApp
{
    internal class ManagerInorm
    {
        private int _count;
        private double _widthPhoto;
        private double _heightPhoto;
        public readonly string PathToPhoto;

        public ManagerInorm(string pathToPhoto)
        {
            PathToPhoto = pathToPhoto;
        }

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
        public double Width
        {
            get => _widthPhoto;
            set
            {
                if (_widthPhoto != value)
                {
                    _widthPhoto = value;
                }
            }
        }

        public double Height
        {
            get => _heightPhoto;
            set
            {
                if (_heightPhoto != value)
                {
                    _heightPhoto = value;
                }
            }
        }


    }
}
