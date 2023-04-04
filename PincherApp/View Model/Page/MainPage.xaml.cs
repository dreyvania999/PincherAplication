using PincherApp.Classes;
using PincherApp.View_Model.Model;

namespace PincherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel _model;
        private readonly double screenWidth;
        private readonly double screenHeight;

        //Только для теста
        private readonly List<InformItem> informItems;
        public MainPage()
        {
            InitializeComponent();
            _model = new MainPageModel();
            BindingContext = _model;
            DisplayInfo displayInfo = DeviceDisplay.MainDisplayInfo;
            screenWidth = displayInfo.Width;
            screenHeight = displayInfo.Height;
            LowerManagers.WidthRequest = screenWidth;
            UpperManagers.WidthRequest = screenWidth;

            LowerManagers.MaximumHeightRequest = screenHeight / 6;
            UpperManagers.MaximumHeightRequest = screenHeight / 6;
            //Только для теста
            informItems=InformPageModel.GetInformItemsFromSpreadsheet("1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg", "Лист1!A1:C");
            screenWidth = displayInfo.Width;
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
                    HeightRequest = _model.SizeLowerManagers,
                    Aspect = Aspect.AspectFill,
                    Margin = new Thickness(5)
                };

                LowerManagers.Children.Add(img);
            }

            for (int i = 0; i < _model.CountUpperManagers; i++)
            {
                Image img = new()
                {
                    Source = ImageSource.FromResource(_model.PathToUpperManagersPhoto),
                    WidthRequest = _model.SizeUpperManagers,
                    HeightRequest = _model.SizeUpperManagers,
                    Aspect = Aspect.AspectFill,
                    Margin = new Thickness(5)
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
