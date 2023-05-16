using PincherApp;
using PincherApp.Core.Classes;
using PincherApp.Core.Interfase;

namespace UnitTestProject
{
    public class UnitTest1
    {

        [Fact]
        public void InitializeInformItem()
        {
            Assert.NotNull(new InformItem("3", "2", "1"));
        }

        [Fact]
        public void TimeCalculator()
        {
            Assert.Equal(70, MainPageModel.UpdateTime(1, 0, 1, true));
        }
        [Fact]
        public void TimeCalculatorNotEqual()
        {
            Assert.NotEqual(70, MainPageModel.UpdateTime(11, 11, 1, false));
        }
        [Fact]
        public void RoiCalculator()
        {
            ResultCalculationModel resultModel = new();
            Assert.Equal(1000, resultModel.CalculateROI(100000, 10000));
        }
        [Fact]
        public void RoiCalculatorNotEqual()
        {
            ResultCalculationModel resultModel = new();
            Assert.NotEqual(100, resultModel.CalculateROI(1000000, 10000));
        }

        [Fact]
        public void InterfasesWorckCorrectly()
        {
            List<IManagers> lis = new()
            {
                new ManagerInorm("123"),
                new SalesInformation()
            };

            Assert.NotNull(lis);
        }

        [Fact]
        public void TestFileExists()
        {
            //получаю путь к текущей директории и разбиваю его 
            string[] strings = Directory.GetCurrentDirectory().Split('\\');
            string filePath = "";
            //Составляю путь к файлу
            for (int i = 0; i < strings.Length - 5; i++)
            {
                filePath += strings[i] + "\\";
            }
            filePath += "PincherApp\\PincherApp\\Resources\\Raw\\pinchertestproject.json";
            //Проверка на наличие файлла по адресу
            bool fileExists = File.Exists(filePath);
            Assert.True(fileExists);
        }

        [Fact]
        public void ConverterBaseItemToInformItem()
        {
            Assert.NotNull(new InformItem(new BaseItem("3", "2", "1")));
        }
        [Fact]
        public void Baseus()
        {
            BaseItem BM = new("3", "2", "1");
            InformItem? IM = BM as InformItem;
            Assert.False(IM is not null);
        }
    }
}