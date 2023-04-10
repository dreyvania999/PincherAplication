using System.ComponentModel;

namespace PincherApp
{
    // Класс для отображения одного итема полученного из гугл таблиццы
    public class InformItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public InformItem(string PhotoPath, string Title, string Description)
        {
            this.Description = Description;
            this.PhotoPath = PhotoPath;
            this.Title = Title;
        }
        private bool _isActivate = false;//поле для отображаения и скрытия дополнительного описания
        public string Description { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }
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
