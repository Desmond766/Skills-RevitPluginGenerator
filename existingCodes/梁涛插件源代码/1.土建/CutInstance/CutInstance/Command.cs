using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CutInstance
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Element elem1 = doc.GetElement(sel.PickObject(ObjectType.Element));
            //Element elem2 = doc.GetElement(sel.PickObject(ObjectType.Element));
            //TaskDialog.Show("ee", InstanceVoidCutUtils.CanBeCutWithVoid(elem1).ToString() + "\n" + InstanceVoidCutUtils.InstanceVoidCutExists(elem1, elem2));
            //return Result.Succeeded;

            ListenUtils listenUtils = new ListenUtils();

            List<Element> CasingPipes;
            try
            {
                listenUtils.startListen();
                CasingPipes = sel.PickObjects(ObjectType.Element, new CasingPipeFilter(), "框选套管（按空格键完成框选，ESC键取消）").Select(x => doc.GetElement(x)).ToList();
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Succeeded;
            }


            List<ElementFilter> elementFilters = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming),
                new ElementCategoryFilter(BuiltInCategory.OST_Walls),
                new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns)
            };
            LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);

            using (Transaction t = new Transaction(doc, "剪切"))
            {
                //var failure = new DelFailuresPreProcess();
                //DelFailuresPreProcess.SetFailedHandlerBeforeTransaction(failure, t);
                t.Start();
                foreach (var casingPipe in CasingPipes)
                {
                    using (var col = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).WhereElementIsNotElementType())
                    {
                        BoundingBoxXYZ bounding = casingPipe.get_BoundingBox(doc.ActiveView);
                        Outline outline = new Outline(bounding.Min, bounding.Max);
                        var elems = col.WherePasses(new BoundingBoxIntersectsFilter(outline)).WherePasses(new ElementIntersectsElementFilter(casingPipe));
                        if (elems.Count() == 1)
                        {
                            Element beCutInstance = elems.First();
                            if (InstanceVoidCutUtils.CanBeCutWithVoid(beCutInstance) && !InstanceVoidCutUtils.InstanceVoidCutExists(beCutInstance, casingPipe))
                            {
                                if (beCutInstance.GroupId.IntegerValue == -1)
                                {
                                    try
                                    {
                                        InstanceVoidCutUtils.AddInstanceVoidCut(doc, beCutInstance, casingPipe);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                                
                            }
                        }
                    }
                }
                t.Commit();
            }



            return Result.Succeeded;
        }
    }

    public class CasingPipeFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == -2008049 && elem.Name.Contains("套管"))
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
