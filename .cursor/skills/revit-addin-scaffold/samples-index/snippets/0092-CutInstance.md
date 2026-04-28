# Sample Snippet: CutInstance

Source project: `existingCodes\梁涛插件源代码\1.土建\CutInstance\CutInstance`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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


// ... truncated ...
```

## DelFailuresPreProcess.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutInstance
{
    public class DelFailuresPreProcess : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            var failureMessages = failuresAccessor.GetFailureMessages();
            foreach (var failure in failureMessages)
            {
                if (failure.GetSeverity() == FailureSeverity.Error)
                {
                    //if (failuresAccessor.IsElementsDeletionPermitted(failure.GetFailingElementIds().ToList()))
                    //{
                    //    failuresAccessor.DeleteElements(new ElementId[] { failure.GetFailingElementIds().OrderByDescending(x => x.IntegerValue).First() });
                    //    TaskDialog.Show("revit", failure.GetFailingElementIds().Count.ToString());
                    //}
                    failuresAccessor.RollBackPendingTransaction();
                    failuresAccessor.ResolveFailure(failure);
                }
            }
            return FailureProcessingResult.Continue;
        }

        [Description("这个方法用在事务开始前，在FailureHandler初始化后调用")]
        /// <summary>
        /// 这个方法用在事务开始前，在FailureHandler初始化后调用
        /// </summary>
        public static void SetFailedHandlerBeforeTransaction(IFailuresPreprocessor failureHandler, Transaction transaction)
        {
            FailureHandlingOptions failureHandlingOptions = transaction.GetFailureHandlingOptions();
            failureHandlingOptions.SetFailuresPreprocessor(failureHandler);
            // 这句话是关键  
            transaction.SetFailureHandlingOptions(failureHandlingOptions);
        }
    }
}

```

