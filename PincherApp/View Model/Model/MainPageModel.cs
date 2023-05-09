using PincherApp.Core.Classes;
using PincherApp.Core.StaticClasses;
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

        public string LostedTime
        {
            get
            {
                return LostedTime;
            }
            set
            {
                LostedTime = value;
                OnPropertyChanged(nameof(LostedTime));
            }
        }
        private void UpdateTimeOptimization()
        {
            Optimization = UpperManager.Count != 0 && (LowerManager.Count / UpperManager.Count) > 5;

            int lostTime;
            
            if (!_optimization)
            {
                lostTime = LowerManager.Count * 25; //количество времени на прослушку если у РОПов нет перегрузки 
            }
            else
            {
                lostTime= (LowerManager.Count*25)/100*(100+ ((LowerManager.Count / UpperManager.Count) *5)); //если роп перегружен то времени на каждого МОПа потребуется больше времени
            }
            if (Assessor.Visibility)
            {
                lostTime -= 2 * lostTime / 3;
            }
            lostTime += 50;//время на аналитику при настроенных программах для этого
            lostTime += 20;//Время на планерку утром
            LostedTime = "Каждый день вашим руководителям отдела продаж придется тратить " + lostTime + " минут для поддержания качества работы в вашем отделе продаж";

        }
        private readonly SizeInform _windowSize;
        internal ManagerInorm LowerManager;
        internal ManagerInorm UpperManager;
        internal ManagerInorm Assessor;

        public MainPageModel()
        {
            _windowSize = new SizeInform();
            LowerManager = new ManagerInorm(BaseProgrammInform.LoverManagerImagePath);
            UpperManager = new ManagerInorm(BaseProgrammInform.UpperManagerImagePath);
            Assessor = new ManagerInorm(BaseProgrammInform.LoverManagerImagePath);
            LostedTime = "Здесь будет рассчитано количество времени на улучшение качества работы своими силами";
        }

        public int CountLowerManagers
        {
            get => LowerManager.Count;
            set
            {
                if (LowerManager.Count != value)
                {
                    LowerManager.Count = value;
                    if (_windowSize.CurrentHeight <= _windowSize.CurrentWidth / value)
                    {
                        LowerManager.UpdateSize(_windowSize.CurrentHeight, _windowSize.CurrentHeight);
                    }
                    else
                    {
                        LowerManager.UpdateSize(_windowSize.CurrentWidth / value, _windowSize.CurrentHeight);//переписать размер(скорее всего не подойдет)
                    }

                    OnPropertyChanged(nameof(CountLowerManagers));
                    UpdateTimeOptimization();
                }
            }
        }

        public int CountAssessor
        {
            get => Assessor.Count;
            set
            {
                if (Assessor.Count != value)
                {
                    Assessor.Count = value;
                    if (_windowSize.CurrentHeight <= _windowSize.CurrentWidth / value)
                    {
                        Assessor.UpdateSize(_windowSize.CurrentHeight, _windowSize.CurrentHeight);
                    }
                    else
                    {
                        Assessor.UpdateSize(_windowSize.CurrentWidth / value, _windowSize.CurrentHeight);//переписать размер(скорее всего не подойдет)
                    }

                    OnPropertyChanged(nameof(Assessor));
                    UpdateTimeOptimization();
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
                    if (_windowSize.CurrentHeight <= _windowSize.CurrentWidth / value)
                    {
                        UpperManager.UpdateSize(_windowSize.CurrentHeight, _windowSize.CurrentHeight);
                    }
                    else
                    {
                        UpperManager.UpdateSize(_windowSize.CurrentWidth / value, _windowSize.CurrentHeight);//переписать размер(скорее всего не подойдет)
                    }

                    OnPropertyChanged(nameof(CountUpperManagers));
                    UpdateTimeOptimization();
                }
            }
        }

        public bool AssesorVisibility
        {
            get => Assessor.Visibility;
            set
            {
                Assessor.Visibility = value;
                OnPropertyChanged(nameof(AssesorVisibility));
            }
        }
        public bool LowerManagersVisibility
        {
            get => LowerManager.Visibility;
            set
            {
                LowerManager.Visibility = value;
                OnPropertyChanged(nameof(LowerManagersVisibility));
            }
        }
        public bool UpperManagersVisibility
        {
            get => UpperManager.Visibility;
            set
            {
                UpperManager.Visibility = value;
                OnPropertyChanged(nameof(UpperManagersVisibility));
            }
        }

        public void UpdaneWindowSize(double height, double width)
        {
            _windowSize.UpdateSize(width - 10, height / 2);
        }

    }
}
