namespace PincherApp
{
    public class InformItem
    {
        private bool _isActivate = false;
        private PropertyChanger _propertyChanger = new PropertyChanger();

        public InformItem(string PhotoPath, string Title, string Description)
        {
            this.Description = Description;
            this.PhotoPath = PhotoPath;
            this.Title = Title;
        }

        public string Description { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActivate
        {
            get => _isActivate;
            set
            {
                _isActivate = value;
                _propertyChanger.OnPropertyChanged(nameof(IsActivate));
            }
        }


    }
}
