using CommunityToolkit.Maui.Views;

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
            if (conversion >=99)
            {
                _ = DisplayAlert("Alert", "Вы уверены в том что конверсия больше 99?", "OK");
                return;
            }
            Entry entry = sender as Entry;
            Color с = new(255, 255, 255);
            entry.TextColor = с;
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
            Entry entry = sender as Entry;
            Color с = new(255, 255, 255);
            entry.TextColor = с;
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
            Entry entry = sender as Entry;
            Color с = new(255, 255, 255);
            entry.TextColor = с;
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
            if (entry.Text == null&& double.TryParse(entry.Text,out  double tryer))
            {
                _ = DisplayAlert("Alert", "Ошибка при вводе значений проверьте корректность введенных данных", "OK");
                return false;
            }
        }
        return growth != 0;
    }

    private async void OnLabelTapped(object sender, EventArgs e)
    {
        Popup popup = new Popup();

        Label label1 = new()
        {
            Text = "Введите количество людей, приходящих в компанию со всех источников рекламы:",
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };
        Entry entry1 = new()
        {
            Keyboard = Keyboard.Numeric,
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };

        Label label2 = new()
        {
            Text = "Введите количество людей, совершающих покупку:",
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };
        Entry entry2 = new()
        {
            Keyboard = Keyboard.Numeric,
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };

        Button button = new()
        {
            Text = "Сохранить",
            FontSize = 18
        };
        button.Clicked += (s, args) =>
        {
            // Сохраняем введенные значения
            int peopleCount = int.Parse(entry1.Text);
            int purchaseCount = int.Parse(entry2.Text);
            string inform = peopleCount +","+purchaseCount;
            // Закрываем всплывающее окно
            popup.Close(result: inform);
        };

        StackLayout stackLayout = new()
        {
            Background = Color.FromRgba(0, 0, 0, 0),
            Padding = new Thickness(20),
            Children = { label1, entry1, label2, entry2, button }
        };
        popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Center;
        popup.Size = new Size(Window.Width*6/7, Window.Height/2); 
        popup.Content = stackLayout;

        await this.ShowPopupAsync<Popup>(popup);
        if (popup.Result.Result!=null&& popup.Result.Result.ToString() != "")
        {
            string[] str = popup.Result.Result.ToString().Split(",");
            costCalculationModel.Conversion = (Convert.ToDouble(str[0]) / Convert.ToDouble(str[1]))*100;
        }
        
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Popup popup = new Popup();

        Label label1 = new()
        {
            Text = "На сколько вырастет конверсия по вашим ощущениям при внедрении отдела контроля качества?",
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };
        Entry entry1 = new()
        {
            Keyboard = Keyboard.Numeric,
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 10)
        };

      
        Button button = new()
        {
            Text = "Сохранить",
            FontSize = 18
        };
        button.Clicked += (s, args) =>
        {
            // Сохраняем введенные значения
            int peopleCount = int.Parse(entry1.Text);
            // Закрываем всплывающее окно
            popup.Close(result: peopleCount);
        };

        StackLayout stackLayout = new()
        {
            Background = Color.FromRgba(0, 0, 0, 0),
            Padding = new Thickness(20),
            Children = { label1, entry1, button }
        };
        popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Center;
        popup.Size = new Size(Window.Width * 6 / 7, Window.Height / 2);
        popup.Content = stackLayout;

        await this.ShowPopupAsync<Popup>(popup);

        if (popup.Result.Result != null && popup.Result.Result.ToString() != "")
        {
            growth = Convert.ToInt32(popup.Result.Result.ToString()) ;
        }
    }
}