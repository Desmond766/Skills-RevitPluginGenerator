using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public class TicketingSetting
    {
        public GeneralSetting GeneralSetting { get; set; }
        public DoubleTeeSetting DoubleTeeSetting { get; set; }
        public SpandrelSetting SpandrelSetting { get; set; }
        public TicketingSetting(string settingFilePath)
        {
            if (File.Exists(settingFilePath))
            {
                List<string> strList = File.ReadAllLines(settingFilePath).ToList();
            }
        }
    }

    public class GeneralSetting
    {
        public string TitleBlockName { get; set; }
        public string View3DTemplateName { get; set; }
        public string ViewPortTypeName { get; set; }

        public string embedTagFamilyName { get; set; }
        public string embedTagTypeName { get; set; }
        public string embedTagLargeFamilyName { get; set; }
        public string embedTagLargeTypeName { get; set; }
        public string bentBarTagFamilyName { get; set; }
        public string bentBarTagTypeName { get; set; }
        public string strBarTagFamilyName { get; set; }
        public string strBarTagTypeName { get; set; }
        public string textNodeTypeName { get; set; }
    }

    public class DoubleTeeSetting
    {
        public string topViewName { get; set; }
        public string topViewTemplateName { get; set; }
        public string topViewLocation { get; set; }
        public string elevationViewName { get; set; }
        public string elevationViewTemplateName { get; set; }
        public string elevationViewLocation { get; set; }
    }

    public class SpandrelSetting
    {
        public string topViewName { get; set; }
        public string topViewTemplateName { get; set; }
        public string topViewLocation { get; set; }
        public string reinforcingViewName { get; set; }
        public string reinforcingViewTemplateName { get; set; }
        public string reinforcingViewLocation { get; set; }
    }
}
