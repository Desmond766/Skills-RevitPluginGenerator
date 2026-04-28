using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlippingFloor
{
    public class CreateFloorTypeCommand : IExternalEventHandler
    {
        public string Front { get; set; }
        public HashSet<string> After { get; set; }
        public FloorType FloorType { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            List<string> floorTypeNames = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(FloorType)).Cast<FloorType>().ToList().Select(x => x.Name).ToList();
            int count = After.Count;
            try
            {
                using (Transaction t = new Transaction(doc, "创建楼板类型"))
                {
                    t.Start();
                    foreach (var item in After)
                    {
                        if (floorTypeNames.Contains(Front + item))
                        {
                            count--;
                            continue;
                        }
                        FloorType newFloorType = FloorType.Duplicate(Front + item) as FloorType;
                        int thickness = Convert.ToInt32(item.Replace("m", ""));
                        if (thickness <= 0)
                        {
                            count--;
                            continue;
                        }
                        CompoundStructure structure = newFloorType.GetCompoundStructure();
                        IList<CompoundStructureLayer> layers = structure.GetLayers();
                        if (layers.Count > 0)
                        {
                            CompoundStructureLayer layer = layers[0];
                            layer.Width = thickness / 304.8;
                            structure.SetLayers(layers);
                            newFloorType.SetCompoundStructure(structure);
                        }
                    }
                    t.Commit();
                }
            }
            catch (Exception e)
            {
                GlobalResources.MainWindow1.Hide();
                TaskDialog.Show("错误", e.Message);
                GlobalResources.MainWindow1.Show();
                return;
            }
            
            GlobalResources.MainWindow1.Hide();
            if (count == 0)
            {
                TaskDialog.Show("创建楼板类型", "已存在这些名称的楼板类型，无需再次创建");
            }
            else
            {
                TaskDialog.Show("创建楼板类型", "创建成功！" + "\n" + "生成楼板类型数量:" + count);
            }            
            GlobalResources.MainWindow1.Show();


        }

        public string GetName()
        {
            return "CreateFloorTypeCommand";
        }
    }
}
