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
            //������� ���� � ������� ����������� � �������� ��� 
            string[] strings = Directory.GetCurrentDirectory().Split('\\');
            string filePath = "";
            //��������� ���� � �����
            for (int i = 0; i < strings.Length - 5; i++)
            {
                filePath += strings[i] + "\\";
            }
            filePath += "PincherApp\\PincherApp\\Resources\\Raw\\pinchertestproject.json";
            //�������� �� ������� ������ �� ������
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