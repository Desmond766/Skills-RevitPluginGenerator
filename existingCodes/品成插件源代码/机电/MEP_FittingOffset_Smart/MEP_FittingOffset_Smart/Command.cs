using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

using System.IO;

namespace MEP_FittingOffset_Smart
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选择桥架三通
            //多选
            IList<Reference> allRef = sel.PickObjects(ObjectType.Element, new CTTeeSelectionFilter(),"框选要排列的桥架三通");
            List<Element> list = new List<Element>();
            foreach (Reference item in allRef)
            {
                list.Add(doc.GetElement(item));
            }

            //选择基准三通
            Reference firstPick = sel.PickObject(ObjectType.Element, new CTTeeSelectionFilter(), "选择基准三通");
            Element firstEle = doc.GetElement(firstPick);


            //排序要爬升的三通
            list = list.OrderBy(u => (u.Location as LocationPoint).Point.DistanceTo((firstEle.Location as LocationPoint).Point)).ToList();
            if (list[0].Id == firstEle.Id)
            {
                list.RemoveAt(0);//将基准三通移出要移动的list
            }

            

            Resolver resolver = new Resolver(commandData);
            int index = 0;
            double _distance = 200;

            using (Transaction t = new Transaction(doc, "机电管线避让"))
            {
                t.Start();
                //while (true)
                //{
                //    try
                //    {
                //        Reference r1 = sel.PickObject(ObjectType.Element, "选择桥架三通");
                //        index++;
                //        _distance = 200 * index;
                //        resolver.Resolve(r1, _distance);
                //    }
                //    catch (Exception ex)
                //    {

                //        if (ex.Message == "The user aborted the pick operation.")
                //        {
                //            break;
                //        }
                //    }
                //}

                foreach (Element ele in list)
                {
                    index++;
                    _distance = 200 * index;
                    resolver.Resolve(ele, _distance);
                }

                t.Commit();
            }


            return Result.Succeeded;
        }
    }
}
