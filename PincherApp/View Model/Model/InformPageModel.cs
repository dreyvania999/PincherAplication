using PincherApp.Core.Classes;

namespace PincherApp
{
    internal class InformPageModel
    {
        internal readonly List<InformItem> InformItems;
        public InformPageModel()
        {
            InformItems = ConvertType(GoogleSheetsHelper.GetInformItemsFromSpreadsheet("1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg", "Лист1!A2:C"));
        }
        /// <summary>
        /// Метод для перевода в необходимый тип итема
        /// </summary>
        /// <param name="baseItems">Список обьектов в базовом типе итема </param>
        /// <returns>Список итемов для вывода на экран</returns>
        private static List<InformItem> ConvertType(List<BaseItem> baseItems)
        {
            //Получаем список обьектов и приводим их к нужному типу
            List<InformItem> informItems = new();

            foreach (BaseItem item in baseItems)
            {
                informItems.Add(new InformItem(item));
            }
            return informItems;
        }



    }
}
