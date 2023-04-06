using PincherApp.Classes;

namespace PincherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel _model;
        private readonly double screenWidth;
        private readonly double screenHeight;


        public MainPage()
        {
            InitializeComponent();
            
            DisplayInfo displayInfo = DeviceDisplay.MainDisplayInfo;
            screenWidth = displayInfo.Width;
            screenHeight = displayInfo.Height;
            
            LowerManagers.MaximumWidthRequest = screenWidth;
            UpperManagers.MaximumWidthRequest = screenWidth;
            LowerManagers.WidthRequest = screenWidth-1;
            UpperManagers.WidthRequest = screenWidth-1;

            LowerManagers.HeightRequest = screenHeight / 6;
            UpperManagers.HeightRequest = screenHeight / 6;
            LowerManagers.MaximumHeightRequest = screenHeight / 6;
            UpperManagers.MaximumHeightRequest = screenHeight / 6;

            _model = new MainPageModel(screenHeight, screenWidth);
            BindingContext = _model;
        }

        private void LowerManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.CountLowerManagers = (int)Math.Round(e.NewValue);
            SetPhoto(LowerManagers, _model.LowerManager);
        }

        private void UpperManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.CountUpperManagers = (int)Math.Round(e.NewValue);          
            SetPhoto(UpperManagers,_model.UpperManager);
        }

        private void SetPhoto(StackLayout managerLayout, ManagerInorm manager)
        {
            managerLayout.Children.Clear();
            double imageSize = (screenWidth - (manager.Count * 5)) / manager.Count; // вычисляем размер изображения в соотношении с количеством изображений и шириной экрана
            for (int i = 0; i < manager.Count; i++)
            {
                Image img = new()
                {
                    Source = ImageSource.FromResource(manager.PathToPhoto),
                    WidthRequest = imageSize,
                    HeightRequest = managerLayout.HeightRequest - 10, // устанавливаем высоту изображения, учитывая Margin
                    Margin = new Thickness(5, 0, 0, 0) // устанавливаем Margin, чтобы изображения не налезали друг на друга
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
            _ = Navigation.PushAsync(new InformPage());
        }
    }
}
