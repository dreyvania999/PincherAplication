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
        public void TestFileExists()
        {
            //получаю путь к текущей дирректории и разбиваю его 
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
            Assert.True(IM as BaseItem is not null);
        }
    }
}