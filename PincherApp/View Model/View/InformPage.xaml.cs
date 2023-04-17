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

        private void ListElement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is InformItem item)
            {
                item.IsActivate = !item.IsActivate; // меняем значение свойства IsActivate
                ((ListView)sender).SelectedItem = null; // снимаем выделение
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}