using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CommunityToolkit.Maui;

using PincherApp.Core.Classes;

namespace PincherApp;

public partial class CostCalculationPage : ContentPage
{
    private readonly CostCalculationModel costCalculationModel;

    private double growth = 0;
    public CostCalculationPage()
    {
        costCalculationModel = new CostCalculationModel();
        InitializeComponent();
        BindingContext = costCalculationModel; // установить контекст данных страницы

        BusinessFocus.ItemsSource = costCalculationModel.BysinesType;

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

    private async void Calculate_Clicked(object sender, EventArgs e)
    {
        if (!IsNormalInformation())
        {
            await DisplayAlert("Alert", "Заполните все поля пожалуйста!", "OK");
        }
        else
        {
            _ = Navigation.PushAsync(new ResultCalculation(costCalculationModel.GetSales, growth));
        }
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
            Color с = new(255, 0, 0);
            entry.TextColor = с;
            ToolTipProperties.SetText(entry, "Повторите ввод количества менеджеров");
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
            Entry entry = sender as Entry;
            Color с = new(255, 255, 255);
            entry.TextColor = с;
        }
        else
        {
            Entry entry = sender as Entry;
            Color с = new(255, 0, 0);
            entry.TextColor = с;
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
            Color с = new(255, 0, 0);
            entry.TextColor = с;
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
            Color с = new(255, 0, 0);
            entry.TextColor = с;
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
            Color с = new(255, 0, 0);
            entry.TextColor = с;
            ToolTipProperties.SetText(entry, "Повторите ввод операционной прибыли");
        }
    }

    private bool IsNormalInformation()
    {
        IEnumerable<Entry> allEntries = ParentElenent.Children.OfType<Entry>();

        foreach (Entry entry in allEntries)
        {
            // Обработка каждого элемента Entry
            if (entry.Text == null)
            {
                return false;
            }
        }
        return growth != 0;
    }

    private async void OnLabelTapped(object sender, EventArgs e)
    {
        var popup = new Popup();

        var label1 = new Label
        {
            Text = "Введите количество людей, приходящих в компанию со всех источников рекламы:",
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };
        var entry1 = new Entry
        {
            Keyboard = Keyboard.Numeric,
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };

        var label2 = new Label
        {
            Text = "Введите количество людей, совершающих покупку:",
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };
        var entry2 = new Entry
        {
            Keyboard = Keyboard.Numeric,
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };

        var button = new Button
        {
            Text = "Сохранить",
            FontSize = 18
        };
        button.Clicked += (s, args) =>
        {
            // Сохраняем введенные значения
            var peopleCount = int.Parse(entry1.Text);
            var purchaseCount = int.Parse(entry2.Text);

            // Закрываем всплывающее окно
            popup.Close();
        };

        var stackLayout = new StackLayout
        {
            Padding = new Thickness(20),
            Children = { label1, entry1, label2, entry2, button }
        };

        popup.Content = stackLayout;

        await PopupExtensions.ShowPopupAsync<Popup>(this, popup);
    }


}