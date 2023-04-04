namespace PincherApp.Classes
{
    internal class InformItem
    {
        public InformItem(string PhotoPath, string Title, string Description)
        {
            this.Description = Description;
            this.PhotoPath = PhotoPath;
            this.Title = Title;
        }

        public string Description { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActivate { get; set; }
    }
}
