using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using System.Windows;
using Autodesk.Revit.DB.Architecture;
using System.IO;
using System.Threading;


namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Class20 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;//拿到当前项目文档
            Document doc = uiDoc.Document;
            Selection sel = uiDoc.Selection;
            Element Elem1 = null;
            Autodesk.Revit.DB.View activeView = doc.ActiveView;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Func<View3D, bool> isNotTemplate = v3 => !(v3.IsTemplate);
            View3D view3D = collector.OfClass(typeof(View3D)).Cast<View3D>().First<View3D>(isNotTemplate);


            // 检查当前视图是否为 3D 视图
            if (activeView is View3D)
            {
                view3D = activeView as View3D;
                // 在这里可以对当前的 3D 视图进行操作
            }
            else
            {
                TaskDialog.Show("tip", "Please run in 3D view");
                return Result.Failed;
            }

            //Elem1 = sel.PickObject(ObjectType.Element, "select start elem").GetElement(doc);
            List<Collision> colist = new List<Collision>();
            FilteredElementCollector element = new FilteredElementCollector(doc, activeView.Id);
            //element.Where(x => x.Name.Contains("L6"));


            //MessageBox.Show(element.Count().ToString());
            //return Result.Succeeded;
            foreach (Element all_elem in element)
            {


                // Element all_elem = doc.GetElement(new ElementId(33023499)) as Element; //207991  3262458
                if (all_elem.Category is null)
                {
                    continue;
                }
                BuiltInCategory category = (BuiltInCategory)all_elem.Category.Id.IntegerValue;

                if (category == (BuiltInCategory)(-2000240) || category == (BuiltInCategory)(-2000220))
                {
                    continue;
                }
                FilteredElementCollector elements2 = new FilteredElementCollector(doc, activeView.Id).OfCategory(category);

                GeometryElement item_geoment = all_elem.get_Geometry(new Options());//获得几何
                if (item_geoment is null)
                {
                    continue;
                }
                Solid room_solid = null;
                foreach (GeometryObject geometryObject in item_geoment)//获得solid
                {
                    Solid solid_romm = geometryObject as Solid;
                    if (solid_romm != null && solid_romm.Volume > 0)
                    {
                        room_solid = solid_romm;
                        break;
                    }
                }
                if (room_solid == null)
                {
                    FamilyInstance familyInstance = all_elem as FamilyInstance;

                    // 获取实体对象的几何信息
                    Options options = new Options();
                    options.ComputeReferences = true;
                    if (familyInstance is null)
                    {
                        continue;
                    }
                    GeometryElement geomElem = familyInstance.get_Geometry(options);

                    // 遍历几何信息，找到实体并进行处理
                    foreach (GeometryObject geomObject in geomElem)
                    {
                        GeometryInstance gi = geomObject as GeometryInstance;
                        if (gi is null)
                        {
                            continue;
                        }
                        GeometryElement so = gi.GetInstanceGeometry();
                        foreach (GeometryObject geometryObject2 in so)
                        {
                            Solid solid_romm2 = geometryObject2 as Solid;
                            room_solid = solid_romm2;
                        }
                    }
                }
                List<Element> pipes = new List<Element>();
                //碰撞快速过滤器

                if (room_solid is null)
                {
                    continue;
                }
                //var transform = room_solid.GetBoundingBox().Transform;
                //var minSolid = room_solid.GetBoundingBox().Min;
                //var maxSolid = room_solid.GetBoundingBox().Max;
                //var acturalMin = transform.OfPoint(minSolid);
                //var acturalMax = transform.OfPoint(maxSolid);
                //var outline = new Outline(acturalMin, acturalMax);
                //var boxFilter = new BoundingBoxIntersectsFilter(outline);

                ElementIntersectsElementFilter solidFilter = new ElementIntersectsElementFilter(all_elem);

                FilteredElementCollector collector2 = new FilteredElementCollector(doc).OfCategory(category);
                collector2.Where(x => x.Name == all_elem.Name);
                collector2.WherePasses(solidFilter);

                pipes = collector2.ToList();
                // MessageBox.Show(pipes.Count.ToString());
                if (pipes.Count() > 0)
                {

                    foreach (var item in pipes)
                    {
                        //MessageBox.Show(item.Id.ToString());
                        if (item.Id == all_elem.Id)
                        {
                            continue;
                        }
                        if (item.Name == all_elem.Name)
                        {
                            Collision c = new Collision() { eid = all_elem.Id, ename = all_elem.Name };
                            colist.Add(c);
                        }
                        else
                        {
                            continue;
                        }

                    }

                }
                colist.OrderBy(x => x.ename);

            }



            if (colist.Count == 0)
            {
                MessageBox.Show("No collision components found");
                return Result.Cancelled;
            }
            ExecuteEventHandler executeEventHandler = new ExecuteEventHandler("Creat Model Line");
            ExternalEvent externalEvent = ExternalEvent.Create(executeEventHandler);
            UserControl4 modelessView = new UserControl4(colist, executeEventHandler, externalEvent);

            System.Windows.Interop.WindowInteropHelper mainUI = new System.Windows.Interop.WindowInteropHelper(modelessView);
            mainUI.Owner = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            modelessView.Show();






            return Result.Succeeded;
        }
    }
    public class Collision
    {
        public ElementId eid { set; get; }
        public string ename { set; get; }

    }
}
