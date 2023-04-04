using System.ComponentModel;

namespace PincherApp.Classes
{
    internal class InformItem : INotifyPropertyChanged
    {
        private bool _isActivate;
        public InformItem(string PhotoPath, string Title, string Description)
        {
            this.Description = Description;
            this.PhotoPath = PhotoPath;
            this.Title = Title;
        }

        public string Description { get; set; }
        public string Title { get; set  ; }
        public string PhotoPath { get; set; }
        public bool IsActivate  
        { 
            get 
            { 
                return this._isActivate;
            }
            set {
            this._isActivate = value;
                OnPropertyChanged(nameof(IsActivate));
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
