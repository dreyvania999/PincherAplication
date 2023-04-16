namespace PincherApp
{

    internal interface ISizable
    {
        public double CurrentWidth { get; set; }
        public double CurrentHeight { get; set; }

        public void UpdateSize(double Width, double Height);
    }
}
