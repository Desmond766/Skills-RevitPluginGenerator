using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    public enum CheckingItem
    {
        //Interfere Checking
        PanelInterfere,
        RebarStrandInterfere,
        EmbedLifterInterfere,
        //Rebar Checking
        RebarList,
        BentBarLength,
        BentBarSketch,
        //Embed Checking
        EmbedList,
        EmbedDrawing,
        //Lifter Checking
        LifterCapacity,
        LifterLocation,
        //Model Checking
        Workset
    }


    public class TicketChecker
    {
        public List<CheckingItem> CheckingItems { get; set; }
        public AssemblyInstance HostAssemblyInst { get; set; }
        public List<FamilyInstance> SFramingList { get; set; }
        public List<FamilyInstance> SEquipmentList { get; set; }
        public List<Element> OtherMemembers { get; set; }
        public FamilyInstance Panel { get; set; }
        public List<FamilyInstance> StrRebarList { get; set; }
        public List<FamilyInstance> BentRebarList { get; set; }
        public List<FamilyInstance> StrandList { get; set; }
        public List<FamilyInstance> PcEmbedList { get; set; }
        public List<FamilyInstance> YardMaterialList { get; set; }
        public List<FamilyInstance> LifterList { get; set; }
        public List<View> Views { get; set; }
        public List<View> Schedules { get; set; }
        public Document Document { get; set; }
        public TicketChecker(AssemblyInstance assemblyInst)
        {
            HostAssemblyInst = assemblyInst;
            Document = assemblyInst.Document;
            Init();
        }
        private void Init()
        {
            SFramingList = new List<FamilyInstance>();
            SEquipmentList = new List<FamilyInstance>();
            OtherMemembers = new List<Element> { };
            foreach (ElementId id in HostAssemblyInst.GetMemberIds())
            {
                Element elem = Document.GetElement(id);
                if (elem is FamilyInstance)
                {
                    FamilyInstance fi = (FamilyInstance) elem;
                    if (fi.Category.Id.IntegerValue 
                        == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        SFramingList.Add(fi);
                    }
                    else if (fi.Category.Id.IntegerValue 
                        == (int)BuiltInCategory.OST_SpecialityEquipment)
                    {
                        SEquipmentList.Add(fi);
                    }
                    else
                    {
                        OtherMemembers.Add(fi);
                    }
                }
                else
                {
                    OtherMemembers.Add(elem);
                }
            }
            foreach (var item in SEquipmentList)
            {

            }
        }
    }
}
