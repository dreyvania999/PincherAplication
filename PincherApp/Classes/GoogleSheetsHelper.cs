using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace PincherApp.Classes
{
    public class GoogleSheetsHelper
    {
        public SheetsService Service { get; set; }

        private const string APPLICATION_NAME = "PincherApp";
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        public GoogleSheetsHelper()
        {
            InitializeService();
        }

        private void InitializeService()
        {
            GoogleCredential credential = GetCredentialsFromFile();
            Service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPLICATION_NAME
            });
        }

        private GoogleCredential GetCredentialsFromFile()
        {
            GoogleCredential credential;

            using (Stream stream =  FileSystem.OpenAppPackageFileAsync("pinchertestproject.json").Result)
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            return credential;
        }


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
