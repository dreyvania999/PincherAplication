using PincherApp.Core.Classes;
using System.Diagnostics.Metrics;

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
        _ = Navigation.PushAsync(new ResultCalculation(costСalculationModel.GetSales, growth));
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Uri websiteUri = new("https://pinschersales.ru/");
        bool success = await Launcher.TryOpenAsync(websiteUri);

        if (!success) // проверка работы сайта
        {
            await DisplayAlert("Alert", "Проблема с открытием сайта компании", "OK");
        }
    }

    private void MOPCount_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (int.TryParse(e.NewValue.ToString(), out int count))
        {

            if (count < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверины в том что ваше колличество менеджеров меньше нуля?", "OK");
                return;
            }
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
            if (count < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверины в том что ваше колличество менеджеров меньше нуля?", "OK");
                return;
            }
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
            if (conversion < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверины в том что конверсия меньше нуля?", "OK");
                return;
            }
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
            if (mopMonthlyRevenue < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверины в том что прибыль от одного менеджера меньше нуля?", "OK");
                return;
            }
            costСalculationModel.MopMonthlyRevenue = mopMonthlyRevenue;
        }
        else
        {
            _ = DisplayAlert("Alert", "Повторите ввод выручки на одного MOПa", "OK");
        }

    }

    private void OperatingProfit_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double operatingProfit))
        {
            if (operatingProfit < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверины в том что операционная прибыль меньше нуля?", "OK");
                return;
            }
            costСalculationModel.OperatingProfit = operatingProfit;
        }
        else
        {
            _ = DisplayAlert("Alert", "Повторите ввод операционной прибыли", "OK");
        }
    }
}