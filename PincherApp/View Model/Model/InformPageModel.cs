using PincherApp.Core.Classes;
using PincherApp.Core.StaticClasses;

namespace PincherApp
{
    internal class InformPageModel
    {
        internal readonly List<InformItem> InformItems;
        public InformPageModel()
        {
            InformItems = ConvertType(GoogleSheetsHelper.GetInformItemsFromSpreadsheet(BaseProgrammInform.TableID, BaseProgrammInform.TableInformItemRange));
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
