using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Sheets.v4.Data;
using PincherApp;
using System;

namespace UnitTestProject
{
    public class UnitTest1
    {

        [Fact]
        public void InitializeInformItem()
        {

            Assert.NotNull(new InformItem("3","2","1"));
        }


        [Fact]
        public void TestFileExists()
        {
            //получаю путь к текущей дирректории и разбиваю его 
            string[] strings = Directory.GetCurrentDirectory().Split('\\');
            string filePath="";
            //Составляю путь к файлу
            for (int i = 0; i < strings.Length-5; i++)
            {
                filePath += strings[i] + "\\";
            }
            filePath += "PincherApp\\PincherApp\\Resources\\Raw\\pinchertestproject.json";
            //Проверка на наличие файлла по адресу
            bool fileExists = File.Exists(filePath);
            Assert.True(fileExists);
        }

        [Fact]
        public void Test4()
        {

        }
    }
}