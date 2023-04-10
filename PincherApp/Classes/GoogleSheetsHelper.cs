using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace PincherApp
{
    // Класс для работы с гугл таблиццами 
    public class GoogleSheetsHelper
    {
        public SheetsService Service { get; set; }

        private const string APPLICATION_NAME = "PincherApp";
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
                ApplicationName = APPLICATION_NAME
            });
        }
        /// <summary>
        /// Метод для получения учетных данных из файла
        /// </summary>
        /// <returns>Учетные данные для гугл из "Google.Apis.Auth.OAuth2"</returns>
        private static  GoogleCredential GetCredentialsFromFile()
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
        /// <param name="spreadsheetId">Идентификатор таблиццы</param>
        /// <param name="range"> массив значений из каких ячеек и страниц брать информацию</param>
        /// <returns>Список (аналог таблиццы)</returns>
        public IList<IList<object>> GetSpreadsheetValues(string spreadsheetId, string range)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request =
                Service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;

            return values;
        }

    }
}
