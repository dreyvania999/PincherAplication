using System.Reflection;

namespace PincherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ManagersSlider.Value = 0;
            SalesDeptManagersSlider.Value = 1;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            UpdateUI();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            int numManagers = (int)ManagersSlider.Value;
            int numSalesDeptManagers = (int)SalesDeptManagersSlider.Value;

            ManagersLabel.Text = $"Number of Managers: {numManagers}";
            SalesDeptManagersLabel.Text = $"Number of Sales Department Managers: {numSalesDeptManagers}";

            DisplayImages(numManagers, numSalesDeptManagers);

            if (numManagers > 5 * numSalesDeptManagers)
            {
                OptimizationLabel.IsVisible = true;
            }
            else
            {
                OptimizationLabel.IsVisible = false;
            }
        }

        private void DisplayImages(int numManagers, int numSalesDeptManagers)
        {
            ImagesArea.Children.Clear();

            double imageSize = ImagesArea.Width / (numManagers + numSalesDeptManagers);

            for (int i = 0; i < numSalesDeptManagers; i++)
            {
                var img = new Image();
                img.Source = ImageSource.FromResource("PincherApp.Resources.Images.screenshot_1.png");
                img.WidthRequest = imageSize;
                img.HeightRequest = imageSize;

                ImagesArea.Children.Add(img);
            }

            for (int i = 0; i < numManagers; i++)
            {
                var img = new Image();
                img.Source = ImageSource.FromResource("PincherApp.Resources.Images.screenshot_1.png");

                img.WidthRequest = imageSize;
                img.HeightRequest = imageSize;

                ImagesArea.Children.Add(img);
            }
        }

    }
}
