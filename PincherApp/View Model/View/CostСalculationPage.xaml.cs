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
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Uri websiteUri = new("https://pinschersales.ru/");
        bool success = await Launcher.TryOpenAsync(websiteUri);

        if (!success)
        {
            // Если не удалось открыть сайт, выполните необходимые действия
        }
    }

    private void MOPCount_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (int.TryParse(e.NewValue.ToString(), out int count))
        {
            costСalculationModel.Count = count;
        }
        else
        {
            _ = DisplayAlert("Alert", "Повторите ввод колличества менеджеров", "OK");
        }
    }

    private void MOPCountEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(e.NewTextValue, out int count))
        {
            costСalculationModel.Count = count;
        }
        else
        {
            _ = DisplayAlert("Alert", "Повторите ввод колличества менеджеров", "OK");
        }
    }

    private void Konversion_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double conversion))
        {
            costСalculationModel.Conversion = conversion;
        }
        else
        {
            _ = DisplayAlert("Alert", "Повторите ввод конверсии", "OK");
        }

    }

    private void MOPRevenue_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double mopMonthlyRevenue))
        {
            costСalculationModel.MopMonthlyRevenue = mopMonthlyRevenue;
        }
        else
        {
            _ = DisplayAlert("Alert", "Повторите ввод выручки на одного MOПa", "OK");
        }

    }
}