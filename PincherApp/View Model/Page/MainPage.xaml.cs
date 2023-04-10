namespace PincherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel _model;

        public MainPage()
        {
            InitializeComponent();
            _model = new MainPageModel();
            BindingContext = _model;
        }

        [Obsolete]
        private void LowerManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.UpdaneWindowSize(LowerManagers.Window.Height, LowerManagers.Window.Width);
            _model.CountLowerManagers = (int)Math.Round(e.NewValue);
            SetPhoto(LowerManagers, _model.LowerManager);
        }

        [Obsolete]
        private void UpperManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.UpdaneWindowSize(UpperManagers.Window.Height, UpperManagers.Window.Width);
            _model.CountUpperManagers = (int)Math.Round(e.NewValue);
            SetPhoto(UpperManagers, _model.UpperManager);
        }

        [Obsolete]
        private void SetPhoto(StackLayout managerLayout, ManagerInorm manager)
        {
            managerLayout.Children.Clear();

            for (int i = 0; i < manager.Count; i++)
            {
                Image img = new()
                {
                    Source = ImageSource.FromResource(manager.PathToPhoto),
                    WidthRequest = manager.CurrentWidth,
                    HeightRequest = manager.CurrentHeight,
                    Margin = 5,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                managerLayout.Children.Add(img);
            }
        }

        private void AgreeButton_Clicked(object sender, EventArgs e)
        {

            NextButton.IsVisible = true;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InformPage());
        }
    }
}
