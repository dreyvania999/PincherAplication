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