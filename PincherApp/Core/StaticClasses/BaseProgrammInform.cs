using PincherApp.Core.Classes;

namespace PincherApp.Core.StaticClasses
{
    public static class BaseProgrammInform
    {
        public static GoogleSheetsHelper sheetsHelper = new();

        public static readonly string ProjectName = "PincherApp";

        public static readonly string TableID = "1BUby1LX8fTHxIpul70Tuo7l85lXYFS9IGHNccIXmaSg";

        public static readonly string TableInformItemRange = "Лист1!A2:C";

        public static readonly string TableBysinessTypeRange = "Лист2!A2:C";

        public static readonly string CostTableRange = "Лист2!A2:C";

        public static readonly string UpperManagerImagePath = "PincherApp.Resources.Images.uppermanager.png";

        public static readonly string LoverManagerImagePath = "PincherApp.Resources.Images.lowermanager.png";
    }
}
