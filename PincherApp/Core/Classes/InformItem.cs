using System.ComponentModel;

namespace PincherApp.Core.Classes
{
    // Класс для отображения одного итема полученного из гугл таблиццы
    public class InformItem : BaseItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public InformItem(string PhotoPath, string Title, string Description)
         : base(PhotoPath, Title, Description)
        {

        }
        public InformItem(BaseItem basic)
            : base(basic.PhotoPath, basic.Title, basic.Description)
        {
            PhotoPath = basic.PhotoPath;
            Title = basic.Title;
            Description = basic.Description;

        }

        private bool _isActivate = false;//поле для отображаения и скрытия дополнительного описания

        public bool IsActivate
        {
            get => _isActivate;
            set
            {
                _isActivate = value;
                OnPropertyChanged(nameof(IsActivate));
            }
        }

    }
}
