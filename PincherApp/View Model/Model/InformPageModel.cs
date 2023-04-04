using PincherApp.Classes;

namespace PincherApp.View_Model.Model
{
    internal class InformPageModel
    {
        internal List<InformItem> InformItems { get; } = GetInformItemsFromSpreadsheet("1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg", "Лист1!A1:C");

        public static List<InformItem> MapFromRangeData(IList<IList<object>> values)
        {
            List<InformItem> items = new();
            foreach (IList<object> value in values)
            {
                InformItem item = new(
                    value[2].ToString(),
                    value[0].ToString(),
                    value[1].ToString());

                items.Add(item);
            }
            return items;
        }

        public static List<InformItem> GetInformItemsFromSpreadsheet(string spreadsheetId, string range)
        {
            GoogleSheetsHelper sheetsHelper = new();
            try
            {
                IList<IList<object>> values = sheetsHelper.GetSpreadsheetValues(spreadsheetId, range);
                List<InformItem> items = MapFromRangeData(values);
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
