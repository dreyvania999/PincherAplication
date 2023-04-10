using System.ComponentModel;

namespace PincherApp
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
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
        private readonly SizeInform windowSize;
        internal ManagerInorm LowerManager;
        internal ManagerInorm UpperManager;

        public MainPageModel()
        {
            windowSize = new SizeInform();
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
                    if (windowSize.CurrentHeight <= windowSize.CurrentWidth / value)
                    {
                        LowerManager.UpdateSize(windowSize.CurrentHeight, windowSize.CurrentHeight);
                    }
                    else
                    {
                        LowerManager.UpdateSize(windowSize.CurrentWidth / value, windowSize.CurrentHeight);//переписать размер(скорее всего не подойдет)
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
                    if (windowSize.CurrentHeight <= windowSize.CurrentWidth / value)
                    {
                        UpperManager.UpdateSize(windowSize.CurrentHeight, windowSize.CurrentHeight);
                    }
                    else
                    {
                        UpperManager.UpdateSize(windowSize.CurrentWidth / value, windowSize.CurrentHeight);//переписать размер(скорее всего не подойдет)
                    }

                    OnPropertyChanged(nameof(CountUpperManagers));
                    UpdateOptimization();
                }
            }
        }


        public void UpdaneWindowSize(double height, double width)
        {
            windowSize.UpdateSize(width, height);
        }

    }
}
