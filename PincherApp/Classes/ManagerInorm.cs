using PincherApp.Core;

namespace PincherApp
{
    internal class ManagerInorm: ISizable
    {
        private int _count;
       
        public readonly string PathToPhoto ;

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
        public double CurrentWidth { get; set; }
        public double CurrentHeight { get; set; }

        public void UpdateSize(double Width, double Height)
        {
            CurrentWidth = Width;
            CurrentHeight = Height;
        }


    }
}
