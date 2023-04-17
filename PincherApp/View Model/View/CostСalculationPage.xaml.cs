using PincherApp.Core.Classes;

namespace PincherApp;

public partial class CostСalculationPage : ContentPage
{
    private readonly CostСalculationModel costСalculationModel;

    private double growth;
    public CostСalculationPage()
    {
        costСalculationModel = new CostСalculationModel();
        InitializeComponent();
        BindingContext = costСalculationModel; // установить контекст данных страницы

        BusinessFocus.ItemsSource = costСalculationModel.BiznessType;

        BusinessFocus.ItemDisplayBinding = new Binding("Title");

    }

    private void BusinessFocus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;
        if (picker.SelectedItem is BaseItem selected)
        {
            string description = selected.Description;
            growth = Convert.ToDouble(description);
        }
    }

    private void Calculate_Clicked(object sender, EventArgs e)
    {
        _ = Navigation.PushAsync(new ResultCalculation(costСalculationModel.getSales, growth));
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

    private void MOPCount_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        costСalculationModel.Count = (int)e.NewValue;
    }

    private void MOPCountEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        costСalculationModel.Count = Convert.ToInt32(e.NewTextValue);
    }

    private void Konversion_TextChanged(object sender, TextChangedEventArgs e)
    {
        costСalculationModel.Conversion = Convert.ToDouble(e.NewTextValue);
    }

    private void MOPRevenue_TextChanged(object sender, TextChangedEventArgs e)
    {
        costСalculationModel.MopMonthlyRevenue = Convert.ToDouble(e.NewTextValue);
    }
}