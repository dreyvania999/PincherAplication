using PincherApp.Core.Classes;

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
            //Добавление команды для набора телефона 
            Call.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open("+79535599079");
                    else
                        DisplayAlert("Alert", "You have been alerted", "OK");
                })
            });
        }
       



        [Obsolete]
        private void LowerManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.UpdaneWindowSize(LowerManagers.Window.Height, LowerManagers.Window.Width);//Нужно переписать на делегат срабоатывающий после майн пейдж
            _model.CountLowerManagers = (int)Math.Round(e.NewValue);
            SetPhoto(LowerManagers, _model.LowerManager);
        }

        [Obsolete]
        private void UpperManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.UpdaneWindowSize(UpperManagers.Window.Height, UpperManagers.Window.Width);//Нужно переписать на делегат срабоатывающий после майн пейдж
            _model.CountUpperManagers = (int)Math.Round(e.NewValue);
            SetPhoto(UpperManagers, _model.UpperManager);
        }
        /// <summary>
        /// Метод который добавляет картинки в обьект 
        /// </summary>
        /// <param name="managerLayout">Обьект в который будет добавляться фото</param>
        /// <param name="manager">Менеджеры которых добавлять будем</param>
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
                };

                managerLayout.Children.Add(img);
            }
        }

        private void SeeMoreButton_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new InformPage());
        }

        private void ConsultationButton_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new CostСalculationPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Uri websiteUri = new("https://pinschersales.ru/");
            bool success = Launcher.TryOpenAsync(websiteUri).Result;

            if (!success)
            {
                // Если не удалось открыть сайт, выполните необходимые действия
            }
        }
    }
}
