using PincherApp.Core.Interfase;

namespace PincherApp.Core.Classes
{
    //Класс для выводв изображений 
    public class ManagerInorm : ISizable, IManagers
    {


        public readonly string PathToPhoto;

        public ManagerInorm(string pathToPhoto)
        {
            PathToPhoto = pathToPhoto;
        }

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
        public double CurrentWidth { get; set; }
        public double CurrentHeight { get; set; }

        public void UpdateSize(double Width, double Height)
        {
            CurrentWidth = Width;
            CurrentHeight = Height;
        }

        public bool Visibility { get; set; }

    }
}
