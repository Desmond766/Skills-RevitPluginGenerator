using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using Document = Autodesk.Revit.DB.Document;

namespace FlippingBeam
{
    [Transaction(TransactionMode.Manual)]
    internal class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Assembly.UnsafeLoadFrom(@"C:\ProgramData\Autodesk\Revit\Addins\2020\Teigha_Net64\TD_Mgd.dll");
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement);
            Element element = doc.GetElement(reference);
            CADLinkType cADLinkType = doc.GetElement(element.GetTypeId()) as CADLinkType;
            Class2 class2 = new Class2();
            List<CADTextModel> cADTextModels1 = class2.GetCADTextInfo(Class2.GetCADPath(cADLinkType.Id, doc));
            List<CADTextModel> cADTextModels = new List<CADTextModel>();
            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            Transform transform = dwg.GetTransform();
            foreach (var item in cADTextModels1)
            {
                if (item.Layer == Command.GetLayerName(doc,reference))
                {
                    cADTextModels.Add(item);
                }
            }
            TaskDialog.Show("sd", cADTextModels.Count.ToString());
            using (Transaction t = new Transaction(doc,"1111"))
            {
                t.Start();
                foreach (var item in cADTextModels)
                {
                    XYZ p = transform.OfPoint(item.Location);
                    //XYZ p = item.Location;
                    //TextNote textNote = TextNote.Create(doc, doc.ActiveView.Id, item.Location, item.Text, new ElementId(118235));
                    TextNote textNote = TextNote.Create(doc, doc.ActiveView.Id, p, item.Text, new ElementId(118235));
                    ElementTransformUtils.RotateElement(doc, textNote.Id, Line.CreateBound(p, new XYZ(p.X, p.Y, p.Z + 1)), item.Angel);
                }
                

                t.Commit();
            }

            return Result.Succeeded;
            //point = new XYZ(point.X, point.Y, 0);
            //ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            //Transform transform = dwg.GetTransform();
            //var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            //ElementId graphicsStyleId = geoObj.GraphicsStyleId;
            //GraphicsStyle gs = doc.GetElement(geoObj.GraphicsStyleId) as GraphicsStyle;
            //string name = gs.GraphicsStyleCategory.Name;
            //TaskDialog.Show("CAD Text Information", geoObj.GetType().ToString() + "\n" + name);
            //Class2 class2 = new Class2();
            //Element element = doc.GetElement(reference);
            //CADLinkType cADLinkType = doc.GetElement(element.GetTypeId()) as CADLinkType;
            //TaskDialog.Show("sd", Class2.GetCADPath(cADLinkType.Id, doc));
            //List<CADTextModel> cADTextModels = class2.GetCADTextInfo(Class2.GetCADPath(cADLinkType.Id, doc));
            //foreach (var item in cADTextModels)
            //{
            //    XYZ p2 = transform.OfPoint(item.Location);
            //    if (p2.DistanceTo(point) < 400 / 304.8)
            //    {
            //        TaskDialog.Show("test", item.Text + p2 + item.Layer + item.Angel);
            //        break;
            //    }
            //}
            //return Result.Succeeded;
        }
    }
}
