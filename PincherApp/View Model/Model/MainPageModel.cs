using PincherApp.Classes;
using System.ComponentModel;

namespace PincherApp
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //Проверка оптимизации
        private bool _optimization = false;
        public bool Optimization
        {
            get => _optimization;
            set
            {
                if (_optimization != value)
                {
                    _optimization = value;
                    OnPropertyChanged(nameof(Optimization));
                }
            }
        }
        private void UpdateOptimization()
        {
            Optimization = UpperManager.Count != 0 && (LowerManager.Count / UpperManager.Count) > 5;
        }
        private readonly double screenWidth;
        private readonly double screenHeight;
        internal ManagerInorm LowerManager;
        internal ManagerInorm UpperManager;

        public MainPageModel(double screenHeight, double screenWidth)
        {
            this.screenHeight = screenHeight/6;
            this.screenWidth = screenWidth;
            LowerManager = new ManagerInorm("PincherApp.Resources.Images.screenshot_1.png");
            UpperManager = new ManagerInorm("PincherApp.Resources.Images.screenshot_2.png");
        }

        public int CountLowerManagers
        {
            get => LowerManager.Count;
            set
            {
                if (LowerManager.Count != value)
                {
                    LowerManager.Count = value;
                    if (screenHeight <= screenWidth / value)
                    {
                        LowerManager.Width = screenHeight;
                        LowerManager.Height = screenHeight;
                    }
                    else
                    {
                        LowerManager.Width = screenWidth / value;
                        LowerManager.Height = screenHeight;//переписать размер(скорее всего не подойдет)
                    }
                   
                    OnPropertyChanged(nameof(CountLowerManagers));
                    UpdateOptimization();
                }
            }
        }

        public int CountUpperManagers
        {
            get => UpperManager.Count;
            set
            {
                if (UpperManager.Count != value)
                {
                    UpperManager.Count = value;
                    if (screenHeight <= screenWidth / value)
                    {
                        UpperManager.Width = screenHeight;
                        UpperManager.Height = screenHeight;
                    }
                    else
                    {
                        UpperManager.Width = screenWidth / value;
                        UpperManager.Height = screenHeight;//переписать размер(скорее всего не подойдет)
                    }

                    OnPropertyChanged(nameof(CountUpperManagers));
                    UpdateOptimization();
                }
            }
        }

        


    }
}
