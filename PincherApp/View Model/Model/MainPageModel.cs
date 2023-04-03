using System.ComponentModel;

namespace PincherApp
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private int _countUpperManagers;
        private double _sizeUpperManagers;
        public string PathToUpperManagersPhoto { get; } = "PincherApp.Resources.Images.screenshot_1.png";

        public int CountUpperManagers
        {
            get => _countUpperManagers;
            set
            {
                if (_countUpperManagers != value)
                {
                    _countUpperManagers = value;
                    OnPropertyChanged(nameof(CountUpperManagers));
                    UpdateOptimization();
                }
            }
        }
        public double SizeUpperManagers
        {
            get => _sizeUpperManagers;
            set
            {
                if (_sizeUpperManagers != value)
                {
                    _sizeUpperManagers = value;
                    OnPropertyChanged(nameof(SizeUpperManagers));
                }
            }
        }

        private int _countLowerManagers;
        private double _sizeLowerManagers;

        public string PathToLowerManagersPhoto { get; } = "PincherApp.Resources.Images.screenshot_2.png";
        public int CountLowerManagers
        {
            get => _countLowerManagers;
            set
            {
                if (_countLowerManagers != value)
                {
                    _countLowerManagers = value;
                    OnPropertyChanged(nameof(CountLowerManagers));
                    UpdateOptimization();
                }
            }
        }
        public double SizeLowerManagers
        {
            get => _sizeLowerManagers;
            set
            {
                if (_sizeLowerManagers != value)
                {
                    _sizeLowerManagers = value;
                    OnPropertyChanged(nameof(SizeLowerManagers));
                }
            }
        }

        private void UpdateOptimization()
        {
            if (_countUpperManagers != 0)
            {
                bool isOptimized = (_countLowerManagers / _countUpperManagers) > 5;
                Optimization = isOptimized;
            }
            else
            {
                Optimization = false;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
