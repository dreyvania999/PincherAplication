namespace PincherApp
{
    public class BaseItem
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }//Путь к изображению 
        public BaseItem(string PhotoPath, string Title, string Description)
        {
            this.Description = Description;
            this.PhotoPath = PhotoPath;
            this.Title = Title;
        }
    }
}
