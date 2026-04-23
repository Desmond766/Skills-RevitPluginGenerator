using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    
    public class Insulation
    {
        string controlMarkParam = "CONTROL_MARK";
        string lengthParam = "DIM_LENGTH";
        string widthParam = "DIM_WIDTH";
        public Element Host { get; set; }
        public string IDescription { get; set; }
        public string ControlMark { get; set; }
        public string LENGTH { get; set; }
        public string WIDTH { get; set; }
        public string IdentityInfo { get; set; }
        public Insulation(Element elem)
        {
            Host = elem;
            Init();
        }
        public Insulation(string mark, string symbol, string id)
        {
            ControlMark = mark;
            IDescription = symbol;
            IdentityInfo = id;
        }

        private void Init()
        {
            IDescription = (Host as FamilyInstance).Symbol.FamilyName;
            ControlMark = Utils.GetParameterByName(Host, controlMarkParam);
            LENGTH = Utils.GetParameterByName(Host, lengthParam);
            WIDTH = Utils.GetParameterByName(Host, widthParam);
            List<string> paramList = new List<string>();
            foreach (Parameter p in Host.Parameters)
            {
                //if (p.Definition.ParameterGroup == BuiltInParameterGroup.PG_GEOMETRY)//Revit API 2024
                if (p.Definition.ParameterGroup == BuiltInParameterGroup.PG_GEOMETRY)
                {
                    if (p.Id.IntegerValue != (int)BuiltInParameter.HOST_VOLUME_COMPUTED
                        && p.Id.IntegerValue != (int)BuiltInParameter.HOST_AREA_COMPUTED)
                    {
                        paramList.Add(p.Definition.Name + ":" + p.AsValueString());
                    }
                }
            }
            paramList.Sort();
            IdentityInfo = string.Join(",", paramList);
        }

        public bool IsSameAs(Insulation insulation2)
        {
            if (IDescription == insulation2.IDescription)
            {
                if (IdentityInfo == insulation2.IdentityInfo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
