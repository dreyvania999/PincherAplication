using System.ComponentModel;

namespace PincherApp.Core.Classes
{
    // Класс для отображения одного итема полученного из гугл таблицы
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

            string[] s = Description.ToLower().Split("конверсия");
            base.Description = s[0];
            if (s.Length > 1)
            {
                Conversion = "Конверсия " + s[1];
            }

        }
        public InformItem(BaseItem basic)
            : base(basic.PhotoPath, basic.Title, basic.Description)
        {
            PhotoPath = basic.PhotoPath;
            Title = basic.Title;
            Description = basic.Description;
        }

        public string sitePath { get; set; }
        public string Conversion { get; set; }

    }
}
