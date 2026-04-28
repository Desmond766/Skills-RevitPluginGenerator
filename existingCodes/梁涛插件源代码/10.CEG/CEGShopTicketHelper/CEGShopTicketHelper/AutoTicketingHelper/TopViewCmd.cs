using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    [Transaction(TransactionMode.Manual)]
    public class TopViewCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            if(!doc.ActiveView.IsAssemblyView || !(doc.ActiveView is ViewSection))
            {
                message = "support assembly view only!";
                return Result.Cancelled;
            }

            AssemblyInstance currentAssembly 
                = doc.GetElement(doc.ActiveView.AssociatedAssemblyInstanceId) 
                as AssemblyInstance;

            ViewAnnotatingHelper2 helper2 = new ViewAnnotatingHelper2(currentAssembly, doc.ActiveView);

            TopViewFrm frm = new TopViewFrm();
            DialogResult dialogResult = frm.ShowDialog();
            string pickItem = frm._pickItem;
            while (DialogResult.OK != dialogResult) 
            {
                if (DialogResult.Cancel == dialogResult)
                {
                    return Result.Cancelled;
                }
                if (pickItem == "pickEdge")
                {
                    helper2.SideARef = sel.PickObject(ObjectType.Edge);
                    helper2.SideBRef = sel.PickObject(ObjectType.Edge);
                    helper2.End1Ref = sel.PickObject(ObjectType.Edge);
                    helper2.End2Ref = sel.PickObject(ObjectType.Edge);
                }
                if (pickItem == "pickGeom")//2pick
                {
                    List<Reference> references = new List<Reference>();
                    references.Add(sel.PickObject(ObjectType.Edge));
                    references.Add(sel.PickObject(ObjectType.Edge));
                    helper2.GeomRefGroups.Add(references);
                }
                if (pickItem == "pickGeom2")//4pick
                {
                    List<Reference> references = new List<Reference>();
                    references.Add(sel.PickObject(ObjectType.Edge));
                    references.Add(sel.PickObject(ObjectType.Edge));
                    references.Add(sel.PickObject(ObjectType.Edge));
                    references.Add(sel.PickObject(ObjectType.Edge));
                    helper2.GeomRefGroups.Add(references);
                }
                if (pickItem == "pickSideA")
                {
                    List<FamilyInstance> sideAEmbedList = sel.PickObjects(ObjectType.Element,
                        new EmbedFilter())
                        .Select(u => doc.GetElement(u) as FamilyInstance).ToList();
                    if (sideAEmbedList.Count != 0)
                    {
                        string cegCategory = Utils.GetParameterByName(sideAEmbedList[0].Symbol, "MANUFACTURE_COMPONENT");
                        if (null != cegCategory && cegCategory.Contains("LIFTING"))
                        {
                            helper2.SideALifterGroups.Add(sideAEmbedList);
                        }
                        else
                        {
                            helper2.SideAEmbedGroups.Add(sideAEmbedList);
                        }
                    }
                }
                if (pickItem == "pickSideB")
                {
                    List<FamilyInstance> sideBEmbedList = sel.PickObjects(ObjectType.Element,
                        new EmbedFilter())
                        .Select(u => doc.GetElement(u) as FamilyInstance).ToList();
                    if (sideBEmbedList.Count != 0)
                    {
                        string cegCategory = Utils.GetParameterByName(sideBEmbedList[0].Symbol, "MANUFACTURE_COMPONENT");
                        if (null != cegCategory && cegCategory.Contains("LIFTING"))
                        {
                            helper2.SideBLifterGroups.Add(sideBEmbedList);
                        }
                        else
                        {
                            helper2.SideBEmbedGroups.Add(sideBEmbedList);
                        }
                    }
                }
                if (pickItem == "pickEnd1")
                {
                    List<FamilyInstance> end1EmbedList = sel.PickObjects(ObjectType.Element,
                        new EmbedFilter())
                        .Select(u => doc.GetElement(u) as FamilyInstance).ToList();
                    if (end1EmbedList.Count != 0)
                    {
                        string cegCategory = Utils.GetParameterByName(end1EmbedList[0].Symbol, "MANUFACTURE_COMPONENT");
                        if (null != cegCategory && cegCategory.Contains("LIFTING"))
                        {
                            helper2.End1LifterGroups.Add(end1EmbedList);
                        }
                        else
                        {
                            helper2.End1EmbedGroups.Add(end1EmbedList);
                        }
                    }
                }
                if (pickItem == "pickEnd2")
                {
                    List<FamilyInstance> end2EmbedList = sel.PickObjects(ObjectType.Element,
                        new EmbedFilter())
                        .Select(u => doc.GetElement(u) as FamilyInstance).ToList();
                    if (end2EmbedList.Count != 0)
                    {
                        helper2.End2EmbedGroups.Add(end2EmbedList);
                    }
                }
                if (pickItem == "pickTop")
                {
                    List<FamilyInstance> topEmbedList = sel.PickObjects(ObjectType.Element,
                        new EmbedFilter())
                        .Select(u => doc.GetElement(u) as FamilyInstance).ToList();
                    if (topEmbedList.Count != 0)
                    {
                        string cegCategory = Utils.GetParameterByName(topEmbedList[0].Symbol, "MANUFACTURE_COMPONENT");
                        if (null != cegCategory && cegCategory.Contains("LIFTING"))
                        {
                            helper2.TopLifterGroups.Add(topEmbedList);
                        }
                        else
                        {
                            helper2.TopEmbedGroups.Add(topEmbedList);
                        }
                    }
                }
                if (pickItem == "pickSoffit")
                {
                    List<FamilyInstance> soffitEmbedList = sel.PickObjects(ObjectType.Element, 
                        new EmbedFilter())
                        .Select(u => doc.GetElement(u) as FamilyInstance).ToList();
                    if (soffitEmbedList.Count != 0)
                    {
                        helper2.SoffitEmbedGroups.Add(soffitEmbedList);
                    }
                }
                dialogResult = frm.ShowDialog();
                pickItem = frm._pickItem;
            }
            //自动判断
            if (frm._autoIdentify)
            {
                helper2.InitEmbedGroups();
            }

            using (Transaction trans = new Transaction(doc, "TopViewInFrom"))
            {
                trans.Start();
                helper2.AddSideEndText();
                helper2.GeomDim();
                helper2.FaceEmbedDim();
                helper2.SideEmbedDim();
                helper2.EndEmbedDim();
                helper2.FaceLifterDim();
                helper2.SideLifterDim();
                helper2.EndLifterDim();
                helper2.OverallSideDim();
                helper2.OverallEndDim();
                trans.Commit();
            }

            return Result.Succeeded;
        }

    }
}
