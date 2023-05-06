using PincherApp.Core.Classes;

namespace PincherApp;

public partial class CostСalculationPage : ContentPage
{
    private readonly CostСalculationModel costCalculationModel;

    private double growth;
    public CostСalculationPage()
    {
        costCalculationModel = new CostСalculationModel();
        InitializeComponent();
        BindingContext = costCalculationModel; // установить контекст данных страницы

        BusinessFocus.ItemsSource = costCalculationModel.BiznessType;

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
        _ = Navigation.PushAsync(new ResultCalculation(costCalculationModel.GetSales, growth));
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
                _ = DisplayAlert("Alert", "Вы уверены в том что ваше количество менеджеров меньше нуля?", "OK");
                return;
            }
            costCalculationModel.Count = count;
        }
        else
        {
           Entry entry = sender as Entry;
            entry.TextColor= Entry.TextColor.Red;
            ToolTipProperties.SetText(entry, "Повторите ввод количества менеджеров");
            //ToolTipProperties.TextProperty.(textField, true);
        }
    }

    private void MOPCountEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(e.NewTextValue, out int count))
        {
            if (count < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверены в том что ваше количество менеджеров меньше нуля?", "OK");
                return;
            }
            costCalculationModel.Count = count;
        }
        else
        {
            Entry entry = sender as Entry;
            ToolTipProperties.SetText(entry, "Повторите ввод количества менеджеров");
        }
    }

    private void Konversion_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double conversion))
        {
            if (conversion < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверены в том что конверсия меньше нуля?", "OK");
                return;
            }
            costCalculationModel.Conversion = conversion;
        }
        else
        {
            Entry entry = sender as Entry;
            ToolTipProperties.SetText(entry, "Повторите ввод конверсии");
        }

    }

    private void MOPRevenue_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double mopMonthlyRevenue))
        {
            if (mopMonthlyRevenue < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверены в том что прибыль от одного менеджера меньше нуля?", "OK");
                return;
            }
            costCalculationModel.MopMonthlyRevenue = mopMonthlyRevenue;
        }
        else
        {
            Entry entry = sender as Entry;
            ToolTipProperties.SetText(entry, "Повторите ввод выручки на одного MOПa");
        }

    }

    private void OperatingProfit_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double operatingProfit))
        {
            if (operatingProfit < 0)
            {
                _ = DisplayAlert("Alert", "Вы уверены в том что операционная прибыль меньше нуля?", "OK");
                return;
            }
            costCalculationModel.OperatingProfit = operatingProfit;
        }
        else
        {
            Entry entry = sender as Entry;
            ToolTipProperties.SetText(entry, "Повторите ввод операционной прибыли");
        }
    }
}