using PincherApp.Core.Classes;
using PincherApp.Core.StaticClasses;

namespace PincherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel _model;

        public MainPage()
        {
            InitializeComponent();
            if (IsInternetConnected())
            {
                _model = new MainPageModel();
                BindingContext = _model;
            }
            else
            {
                CallAlert();
            }
            
            
            //Добавление команды для набора телефона 
            Call.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    //проверка возможности ввода номера телефона на разных устройствах
#if WINDOWS || MACCATALYST
                    DisplayAlert("Alert", "К сожалению нет возможности получить доступ к телефону, но он скопирован в ваш буфер обмена", "OK");
                    Clipboard.SetTextAsync(BaseProgrammInform.CompanyPhone);
#endif
                    if (PhoneDialer.Default.IsSupported)
                    {
                        PhoneDialer.Default.Open(BaseProgrammInform.CompanyPhone);
                    }
                    else
                    {
                        DisplayAlert("Alert", "К сожалению нет возможности получить доступ к телефону", "OK");
                    }
                })
            });

        }

        private async void CallAlert()
        {
           await ShowErrorMessageAndQuit();
        }

        public async Task ShowErrorMessageAndQuit()
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету. Пожалуйста, попробуйте подключиться к интернету и войдите снова.", "Ок");
            App.Current.Quit();
        }
        public bool IsInternetConnected()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.Internet;
        }
        private void LowerManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.UpdateWindowSize(LowerManagers.Window.Height/2, LowerManagers.Window.Width);//Нужно переписать на делегат срабатывающий после майн пейдж
            _model.CountLowerManagers = (int)Math.Round(e.NewValue);
            SetPhoto(LowerManagers, _model.LowerManager);
        }

        private void UpperManagerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.UpdateWindowSize(UpperManagers.Window.Height/2, UpperManagers.Window.Width);//Нужно переписать на делегат срабатывающий после майн пейдж
            _model.CountUpperManagers = (int)Math.Round(e.NewValue);
            SetPhoto(UpperManagers, _model.UpperManager);
        }
        /// <summary>
        /// Метод который добавляет картинки в объект 
        /// </summary>
        /// <param name="managerLayout">объект в который будет добавляться фото</param>
        /// <param name="manager">Менеджеры которых добавлять будем</param>
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

        private async void SeeMoreButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InformPage());
        }

        private async void ConsultationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CostCalculationPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Uri websiteUri = new("https://pinschersales.ru/");
            bool success = await Launcher.TryOpenAsync(websiteUri);

            if (!success)
            {
                await DisplayAlert("Alert", "Проблема с открытием сайта компании", "OK");
            }
        }

        private void AssesorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _model.CountAssessor = (int)Math.Round(e.NewValue);
            SetPhoto(Assesor, _model.Assessor);
        }


    }
}
