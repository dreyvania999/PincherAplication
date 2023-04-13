namespace PincherApp;

public partial class ResultCalculation : ContentPage
{
    public ResultCalculation()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Uri websiteUri = new("https://pinschersales.ru/");
        bool success = Launcher.TryOpenAsync(websiteUri).Result;

        if (!success)
        {
            // Если не удалось открыть сайт, выполните необходимые действия
        }
    }
}