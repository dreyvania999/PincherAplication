using PincherApp.Core.Classes;

namespace PincherApp
{

    public partial class InformPage : ContentPage
    {
        private readonly InformPageModel informPageModelmodel;
        public InformPage()
        {
            informPageModelmodel = new InformPageModel();
            InitializeComponent();
            BindingContext = informPageModelmodel; // установить контекст данных страницы
            ListElement.ItemsSource = informPageModelmodel.InformItems;
        }

        private async void ListElement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is InformItem item)
            {

                Uri websiteUri = new(item.sitePath);
                bool success = await Launcher.TryOpenAsync(websiteUri);

                if (!success)
                {
                    await DisplayAlert("Alert", "Проблема с открытием сайта компании", "OK");
                }
                ((ListView)sender).SelectedItem = null; // снимаем выделение
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}