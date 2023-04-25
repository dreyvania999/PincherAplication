using PincherApp.Core.Classes;

namespace PincherApp;

public partial class ResultCalculation : ContentPage
{
    private readonly ResultCalculationModel resultCalculationModel;
    public ResultCalculation(SalesInformation sales, double growth)
    {
        InitializeComponent();
        resultCalculationModel = new ResultCalculationModel(sales, growth);
        BindingContext = resultCalculationModel;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

        Uri websiteUri = new("https://pinschersales.ru/");
        bool success = await Launcher.TryOpenAsync(websiteUri);

        if (!success)
        {
            await DisplayAlert("Alert", "Проблема с открытием сайта компании", "OK");
        }
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }
}