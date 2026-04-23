using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RevitUtils
{
    [Transaction(TransactionMode.Manual)]
    public class Template1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;


            //ViewUtils.SelectView3D(doc);

            //List<People> peoples = new List<People>();
            //peoples.Add(new Men());
            //peoples.Add(new Women());
            //foreach (var item in peoples)
            //{
            //    item.Run();
            //}
            //return Result.Succeeded;

            //var view3d = ViewUtils.SelectView3D(doc);
            //ViewUtils.OpenView
            //TaskDialog.Show("er", view3d.Name);

            var floors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Floors).ToList();
            ProgressBarView pbv = new ProgressBarView(commandData);
            pbv.pb.Minimum = 0;
            pbv.pb.Maximum = floors.Count;
            pbv.lbl_totalCount.Content = "0/2";
            pbv.Show();
            

            Transaction t = new Transaction(doc, "修改板厚");
            pbv.lbl_tranName.Content = "修改板厚中...";
            pbv.lbl_totalCount.Content = "- 1/2";
            t.Start();
            for (int i = 0; i < floors.Count(); i++)
            {
                if(pbv.Cancel == true)
                {
                    if (t.HasStarted()) t.RollBack();
                    return Result.Failed;
                }
                Thread.Sleep(100);
                if (floors[i].get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).IsReadOnly == false)
                {
                    floors[i].get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).Set(floors[i].get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble() + 2000 / 304.8);
                }
                pbv.pb.Value = i;
                pbv.lbl_percent.Content = Math.Round((((double)i / floors.Count) * 100)) + "%";
                System.Windows.Forms.Application.DoEvents();
            }
            t.Commit();

            var walls = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Walls).ToList();
            pbv.pb.Maximum = walls.Count;
            pbv.lbl_tranName.Content = "修改墙底部偏移中...";
            pbv.lbl_totalCount.Content = "- 2/2";
            Transaction t2 = new Transaction(doc, "修改墙底部偏移");
            t2.Start();
            for (int i = 0; i < walls.Count; i++)
            {
                if (pbv.Cancel == true)
                {
                    if(t2.HasStarted()) t2.RollBack();
                    return Result.Failed;
                }
                Thread.Sleep(100);
                walls[i].get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(walls[i].get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - 1000 / 304.8);

                pbv.pb.Value = i;
                pbv.lbl_percent.Content = Math.Round((((double)i / walls.Count) * 100)) + "%";
                System.Windows.Forms.Application.DoEvents();
            }

            t2.Commit();


            pbv.Close();

            return Result.Succeeded;
        }
    }
    public class People
    {
        public virtual void Run()
        {
            TaskDialog.Show("revt", "people run");
        }
    }
    public class Women : People
    {
        public override void Run()
        {
            TaskDialog.Show("revit", "women run");
        }
    }
    public class Men : People
    {
        public override void Run()
        {
            TaskDialog.Show("revit", "men run");
        }
    }
}
