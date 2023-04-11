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
            ListElement.ItemsSource = informPageModelmodel.InformItems;
        }

        private void ListElement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is InformItem item)
            {
                item.IsActivate = !item.IsActivate; // мен€ем значение свойства IsActivate
                ((ListView)sender).SelectedItem = null; // снимаем выделение
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}