# Sample Snippet: CreateDimensions

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\CreateDimensions\CreateDimensions`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document = Autodesk.Revit.DB.Document;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CreateDimensions
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        UIDocument uIDoc = null;
        Document doc = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            IList<Reference> references;
            IList<Reference> linkedReference;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new HangerFilter(), "框选要标注的吊架（按空格键完成框选，ESC键取消）");
                listenUtils.startListen();
                linkedReference = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.LinkedElement, new LinkedBeamWallFilter(), "选择梁、墙或柱（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<FamilyInstance> hangers = references.Select(r => doc.GetElement(r) as FamilyInstance).ToList();

            ReferenceArray referenceArray = new ReferenceArray();
            //XYZ p1 = null;
            //XYZ p2 = null;
            //int count = 0;
            //foreach (Reference reference in references)
            //{
            //    string name = null;
            //    if (name == null)
            //    {
            //        name = doc.GetElement(reference).Name;
            //    }
            //    if (doc.GetElement(reference).Name.Equals(name))
            //    {
            //        count++;
            //    }
            //    FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            //    if (p1 == null && count == 1)
            //    {
            //        p1 = (familyInstance.Location as LocationPoint).Point;
            //    }
            //    if (p2 == null && count == 2)
            //    {
            //        p2 = (familyInstance.Location as LocationPoint).Point;
            //    }
            //    if (count > 2)
            //    {
            //        break;
            //    }
            //}
            FamilyInstance firstHanger = doc.GetElement(references.First()) as FamilyInstance;
            XYZ hangerP = (firstHanger.Location as LocationPoint).Point;
            double pZ = (firstHanger.Location as LocationPoint).Point.Z;

            TransactionGroup group = new TransactionGroup(doc, "吊架间创建尺寸标注");
            group.Start();
            using (Transaction t = new Transaction(doc, "创建模型线"))
            {
                t.Start();
                foreach (Reference reference in linkedReference)
                {
                    RevitLinkInstance revitLinkInstance = doc.GetElement(reference.ElementId) as RevitLinkInstance;
                    Transform transform = revitLinkInstance.GetTransform();
                    Document linkDoc = revitLinkInstance.GetLinkDocument();
                    Element wallOrBeam = linkDoc.GetElement(reference.LinkedElementId);
                    ElementType elementType = linkDoc.GetElement(wallOrBeam.GetTypeId()) as ElementType;

                    //double width = elementType.LookupParameter("b")?.AsDouble() ?? elementType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble();
// ... truncated ...
```

## HangerFilter.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDimensions
{
    public class HangerFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_MechanicalEquipment && (elem as FamilyInstance).Symbol.FamilyName.Contains("吊架"))
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}

```

