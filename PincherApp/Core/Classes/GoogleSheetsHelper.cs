using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using PincherApp.Core.StaticClasses;

namespace PincherApp.Core.Classes
{
    // Класс для работы с гугл таблицами 
    public class GoogleSheetsHelper
    {
        public SheetsService Service { get; set; }

        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets }; //Область применения 

        public GoogleSheetsHelper()
        {
            InitializeService();
        }

        /// <summary>
        /// Метод инициализации сервиса
        /// </summary>
        private void InitializeService()
        {
            GoogleCredential credential = GetCredentialsFromFile();
            Service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = BaseProgrammInform.ProjectName
            });
        }
        /// <summary>
        /// Метод для получения учетных данных из файла
        /// </summary>
        /// <returns>Учетные данные для гугл из "Google.Apis.Auth.OAuth2"</returns>
        private static GoogleCredential GetCredentialsFromFile()
        {
            GoogleCredential credential;

            using (Stream stream = FileSystem.OpenAppPackageFileAsync("pinchertestproject.json").Result)
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            return credential;
        }

        /// <summary>
        /// Получение информации  из таблицы
        /// </summary>
        /// <param name="spreadsheetId">Идентификатор таблицы</param>
        /// <param name="range"> массив значений из каких ячеек и страниц брать информацию</param>
        /// <returns>Список (аналог таблицы)</returns>
        public IList<IList<object>> GetSpreadsheetValues(string spreadsheetId, string range)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request =
                Service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;

            return values;
        }

        /// <summary>
        /// Метод для преобразования объектов в наш тип данных
        /// </summary>
        /// <param name="values">Список объектов из гугл таблицы </param>
        /// <returns>Базовый объект который можно привести к необходимому виду</returns>
        public static List<BaseItem> MapFromRangeData(IList<IList<object>> values)
        {
            List<BaseItem> items = new();
            foreach (IList<object> value in values)
            {
                InformItem item = new(
                    value[2].ToString(),
                    value[0].ToString(),
                    value[1].ToString());
                if (values[0].Count==4)
                {
                    item.sitePath = value[3].ToString();
                }
                items.Add(item);
            }
            return items;
        }

        /// <summary>
        /// Метод для получения данных из таблицы в нужном нам виде
        /// </summary>
        /// <param name="spreadsheetId">Идентификатор таблицы</param>
        /// <param name="range"> массив значений из каких ячеек и страниц брать информацию</param>
        /// <returns>Базовый объект который можно привести к необходимому виду</returns>
        public static List<BaseItem> GetInformItemsFromSpreadsheet(string spreadsheetId, string range)
        {

            try
            {
                IList<IList<object>> values = BaseProgrammInform.sheetsHelper.GetSpreadsheetValues(spreadsheetId, range);
                List<BaseItem> items = MapFromRangeData(values);
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
