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
                item.IsActivate = !item.IsActivate; // ������ �������� �������� IsActivate
                ((ListView)sender).SelectedItem = null; // ������� ���������
            }
        }

    }
}