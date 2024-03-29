﻿using PincherApp.Core.Classes;
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
        /// Метод для перевода в необходимый тип объекта
        /// </summary>
        /// <param name="baseItems">Список объектов в базовом типе объекта </param>
        /// <returns>Список итемов для вывода на экран</returns>
        private static List<InformItem> ConvertType(List<BaseItem> baseItems)
        {
            //Получаем список объектов и приводим их к нужному типу
            List<InformItem> informItems = new();

            foreach (BaseItem item in baseItems)
            {
                informItems.Add(item as InformItem);
            }
            return informItems;
        }



    }
}
