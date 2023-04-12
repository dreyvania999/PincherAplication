namespace PincherApp;

public partial class CostСalculationPage : ContentPage
{
    public CostСalculationPage()
    {
        InitializeComponent();
    }

    private void BusinessFocus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Calculate_Clicked(object sender, EventArgs e)
    {

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