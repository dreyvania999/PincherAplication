using PincherApp.Core.Interfase;

namespace PincherApp.Core.Classes
{
    //Класс для размеров экрана(для возможности расширения при )
    internal class SizeInform : ISizable
    {

        public double CurrentWidth { get; set; }
        public double CurrentHeight { get; set; }

        public void UpdateSize(double Width, double Height)
        {
            CurrentWidth = Width;
            CurrentHeight = Height;
        }


    }
}
