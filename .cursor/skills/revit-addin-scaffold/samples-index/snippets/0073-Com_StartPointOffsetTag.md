# Sample Snippet: Com_StartPointOffsetTag

Source project: `existingCodes\品成插件源代码\通用\Com_StartPointOffsetTag\Com_StartPointOffsetTag`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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

namespace Com_StartPointOffsetTag
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            View view = doc.ActiveView;

            //标签
            TagMode tagMode = TagMode.TM_ADDBY_CATEGORY;
            TagOrientation tagOrientation = TagOrientation.Horizontal;//标记的朝向

            //要标注的管线
            IList<Reference> list = sel.PickObjects(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择管线");
            //List<Element> listToTag = new List<Element>();
            using (Transaction trans = new Transaction(doc, "Creat IndependentTag"))
            {
                trans.Start();
                foreach (Reference reference in list)
                {
                    MEPCurve mepCurve = doc.GetElement(reference) as MEPCurve;
                    Line mepLine = (mepCurve.Location as LocationCurve).Curve as Line;
                    XYZ startPoint = mepLine.GetEndPoint(0);
                    XYZ endPoint = mepLine.GetEndPoint(1);

                    if (Math.Abs((doc.GetElement(reference).get_Parameter(BuiltInParameter.RBS_START_OFFSET_PARAM).AsDouble())
                        - (doc.GetElement(reference).get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())) > 0.0001)
                    {
                        IndependentTag tag = doc.Create.NewTag(view, doc.GetElement(reference), true, tagMode, tagOrientation, startPoint);
                        if (null == tag)
                        {
                            throw new Exception("Create IndependentTag Failed.");
                        }

                        tag.LeaderEndCondition = LeaderEndCondition.Attached;
                        tag.HasLeader = false;//不要箭头
                        //XYZ elbowPnt = mid + new XYZ(2.0, 2.0, 0.0);
                        //tag.LeaderElbow = elbowPnt;//有箭头的话，箭头拐点
                        XYZ headerPnt = startPoint + new XYZ(1.0, 1.0, 0.0);
                        tag.TagHeadPosition = headerPnt;//标记的位置
                    }



                }
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}

```

## MEPCurveSelectionFilter.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com_StartPointOffsetTag
{
    public class MEPCurveSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element is MEPCurve)
            {
                if ((element.Location as LocationCurve).Curve is Line)
                {
                    return true;
                }
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}

```

