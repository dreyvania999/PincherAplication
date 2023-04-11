using PincherApp.Core.Classes;

namespace PincherApp
{
    internal class InformPageModel
    {

        public InformPageModel()
        {
            //Получаем список обьектов и приводим их к нужному типу
            List<InformItem> informItems = new();

            foreach (BaseItem item in GoogleSheetsHelper.GetInformItemsFromSpreadsheet("1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg", "Лист1!A2:C"))
            {
                informItems.Add(item as InformItem);
            }

            InformItems = informItems;
        }
        internal readonly List<InformItem> InformItems;



    }
}
