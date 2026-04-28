using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    internal class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            Dimension dimension = reference.GetElement(doc) as Dimension;
            ReferenceArray referenceArray = dimension.References;
            foreach (Reference item in referenceArray)
            {
                Element element = doc.GetElement(item);
                if (element is FamilyInstance familyInstance && element.Category.Id.IntegerValue == -2002000)
                {
                    bool find = false;
                    FamilyInstanceReferenceType type = familyInstance.GetReferenceType(item);
                    if (type != FamilyInstanceReferenceType.NotAReference)
                    {
                        IList<Reference> references = familyInstance.GetReferences(type);
                        foreach (Reference item2 in references)
                        {
                            if (item2.ConvertToStableRepresentation(doc) == item.ConvertToStableRepresentation(doc))
                            {
                                find = true;
                                TaskDialog.Show("ab", "find:" + item2.ConvertToStableRepresentation(doc) + type);
                            }
                        }
                        if (!find)
                        {
                            TaskDialog.Show("ab", "NOfind:" + references.Count() + type);
                        }
                    }
                    Options options = new Options();
                    options.View = doc.ActiveView;
                    options.ComputeReferences = true;
                    int count = 0;
                    bool find1 = false;
                    GeometryElement geometryElement = element.get_Geometry(options);
                    foreach (GeometryObject geometry in geometryElement)
                    {
                        if (geometry is GeometryInstance geometryInstance)
                        {

                            GeometryElement geo = geometryInstance.GetSymbolGeometry();
                            foreach (GeometryObject item2 in geo)
                            {
                                if (item2 is Line line)
                                {
                                    count++;
                                    if (item.ConvertToStableRepresentation(doc) == line.Reference.ConvertToStableRepresentation(doc))
                                    {
                                        find1 = true;
                                        TaskDialog.Show("yes", "find111");
                                    }
                                }
                            }
                        }
                    }
                    TaskDialog.Show("ds", "" + count);
                }
            }

            //FamilyInstance familyInstance = reference.GetElement(doc) as FamilyInstance;
            //Options opt = new Options();
            //opt.View = doc.ActiveView;
            //opt.ComputeReferences = true;
            //GeometryElement geometryElement = familyInstance.get_Geometry(opt);
            //foreach (GeometryObject geometryObject in geometryElement)
            //{
            //    if (geometryObject is GeometryInstance geometryInstance)
            //    {
            //        foreach (var item in geometryInstance.GetSymbolGeometry())
            //        {
            //            if (item is Line line)
            //            {
            //                TaskDialog.Show("sd", line.Reference.ConvertToStableRepresentation(doc));
            //            }
            //        }
            //    }
            //}

            //IList<Reference> references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element);
            //XYZ p =((doc.GetElement(references.First()).Location as LocationCurve).Curve as Line).Origin;
            //Line line = Line.CreateBound(p, p + XYZ.BasisY * 2);
            //ReferenceArray referenceArray = new ReferenceArray();
            //foreach (var item in references)
            //{
            //    referenceArray.Append(item);
            //}
            //using (Transaction t = new Transaction(doc,"ds"))
            //{
            //    t.Start();
            //    doc.Create.NewDimension(doc.ActiveView, line, referenceArray,doc.GetElement(new ElementId(334690)) as DimensionType);
            //    t.Commit();
            //}

            return Result.Succeeded;
        }
    }
}
