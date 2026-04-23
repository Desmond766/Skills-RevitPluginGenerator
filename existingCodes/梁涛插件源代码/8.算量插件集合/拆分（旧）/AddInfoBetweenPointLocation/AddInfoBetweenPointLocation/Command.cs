using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInfoBetweenPointLocation
{
    [Transaction(TransactionMode.Manual)]
    // 读取excel表格，将两点位（配电箱到点位或配电箱到配电箱）与其之间的线管回路赋值
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            Element elem = doc.GetElement(sel.PickObject(ObjectType.Element));
            var ids = new List<ElementId>();
            GetAllConnect(elem, ref ids);
            using (Transaction t = new Transaction(doc, "赋值"))
            {
                t.Start();
                foreach (var id in ids)
                {
                    Element element = doc.GetElement(id);
                    var para = element.LookupParameter("电气-线管管材");
                    if (para != null)
                    {
                        para.Set("SC25");
                    }
                    var para2 = element.LookupParameter("路由");
                    if (para2 != null)
                    {
                        para2.Set("WP4");
                    }
                }


                t.Commit();
            }


            return Result.Succeeded;
        }

        /// <summary>
        /// 获取管道/管件通路上所有元素ID
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private List<ElementId> GetAllConnect(Element element, ref List<ElementId> ids)
        {
            List<ElementId> result = new List<ElementId>();
            if (element is FamilyInstance familyInstance)
            {
                if (element.Category.Id.IntegerValue == -2001040)
                {
                    return ids;
                }
                if (!ids.Contains(familyInstance.Id)) ids.Add(familyInstance.Id);
                foreach (Connector item in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (!ids.Contains(conRef.Owner.Id))
                            {
                                ids.Add(conRef.Owner.Id);
                                //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                GetAllConnect(conRef.Owner, ref ids);
                            }
                        }
                    }
                }
            }
            else if (element is Conduit conduit)
            {
                if (!ids.Contains(conduit.Id)) ids.Add(conduit.Id);
                foreach (Connector item in conduit.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (conRef.Owner.Id != item.Owner.Id)
                            {
                                if (!ids.Contains(conRef.Owner.Id))
                                {
                                    ids.Add(conRef.Owner.Id);
                                    //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                    GetAllConnect(conRef.Owner, ref ids);
                                }
                            }
                        }
                    }
                }
            }


            return ids;
        }
    }
}
