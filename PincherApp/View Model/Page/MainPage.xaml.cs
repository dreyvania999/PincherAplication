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

        private void LowerManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.CountLowerManagers = (int)Math.Round(e.NewValue);
            _model.SizeLowerManagers = LowerManagers.WidthRequest / _model.CountLowerManagers;
            SetPhoto();
        }

        private void UpperManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.CountUpperManagers = (int)Math.Round(e.NewValue);
            _model.SizeUpperManagers = UpperManagers.WidthRequest / _model.CountUpperManagers;
            SetPhoto();
        }

        private void SetPhoto()
        {
            UpperManagers.Children.Clear();
            LowerManagers.Children.Clear();

            for (int i = 0; i < _model.CountLowerManagers; i++)
            {
                Image img = new()
                {
                    Source = ImageSource.FromResource(_model.PathToLowerManagersPhoto),
                    WidthRequest = _model.SizeLowerManagers,
                    HeightRequest = _model.SizeLowerManagers
                };

                LowerManagers.Children.Add(img);
            }

            for (int i = 0; i < _model.CountUpperManagers; i++)
            {
                Image img = new()
                {
                    Source = ImageSource.FromResource(_model.PathToUpperManagersPhoto),
                    WidthRequest = _model.SizeUpperManagers,
                    HeightRequest = _model.SizeUpperManagers
                };

                UpperManagers.Children.Add(img);
            }
        }

        private void AgreeButton_Clicked(object sender, EventArgs e)
        {

            NextButton.IsVisible = true;
        }
    }
}
