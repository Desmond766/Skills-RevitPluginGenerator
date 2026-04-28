using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PipelineOffset
{
    //管道135度偏移
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            double angle = 4.5 / 18 * Math.PI;
            //获取中断点和管道
            Reference reference = uIDoc.Selection.PickObject(ObjectType.Element, new PipelineFilter(), "选择一根管线");
            //获取偏移方向
            XYZ directPoint = uIDoc.Selection.PickPoint();
            Element element = doc.GetElement(reference);
            XYZ oldPoint = reference.GlobalPoint;
            Line pipeLine = (element.Location as LocationCurve).Curve as Line;
            XYZ point = pipeLine.Project(oldPoint).XYZPoint;
            XYZ p1 = pipeLine.GetEndPoint(0);
            XYZ p2 = pipeLine.GetEndPoint(1);
            Line newLine1 = Line.CreateBound(p1, point);
            Line newLine2 = Line.CreateBound(point, p2);
            TransactionGroup group = new TransactionGroup(doc, "管道135度偏移");
            group.Start();
            Transaction t = new Transaction(doc, "打断管道");
            t.Start();
            //1.打断管道
            //if (element is Duct duct)
            //{
            //    ElementId symbolId = duct.GetTypeId();
            //    MEPSystem mEPSystem = duct.MEPSystem;
            //    ElementId systemId = mEPSystem.GetTypeId();
            //    ElementId levelId = duct.ReferenceLevel.Id;
            //    Duct duct1 = Duct.Create(doc, systemId, symbolId, levelId, p1, point);
            //    Duct duct2 = Duct.Create(doc, systemId, symbolId, levelId, point, p2);
            //    connector1 = GetConnector(duct1, point);
            //    connector2 = GetConnector(duct2, point);

            //}
            //else if (element is Pipe pipe)
            //{
            //    //ElementId symbolId = pipe.GetTypeId();
            //    //MEPSystem mEPSystem = pipe.MEPSystem;
            //    //ElementId systemId = mEPSystem.GetTypeId();
            //    //ElementId levelId = pipe.ReferenceLevel.Id;
            //    //Pipe pipe1 = Pipe.Create(doc, systemId, symbolId, levelId, p1, point);
            //    //Pipe pipe2 = Pipe.Create(doc, systemId, symbolId, levelId, point, p2);
            //    ICollection<ElementId> ids = ElementTransformUtils.CopyElement(doc, element.Id, (p1 + p2) / 2);
            //    ElementId copyId = ids.First();
            //    (pipe.Location as LocationCurve).Curve = newLine1;
            //    Pipe pipe1 = pipe;
            //    Pipe pipe2 = doc.GetElement(copyId) as Pipe;
            //    (pipe2.Location as LocationCurve).Curve= newLine2;
            //    connector1 = GetConnector(pipe1, point);
            //    connector2 = GetConnector(pipe2, point);
            //    Line axis = Line.CreateBound(point, point + XYZ.BasisZ * 2);

            //    //ElementTransformUtils.RotateElement(doc, pipe2.Id, axis, 0.7854);
            //    ElementTransformUtils.RotateElement(doc, pipe2.Id, axis, -angle);
            //}
            //else if (element is CableTray cableTray)
            //{
            //    ElementId symbolId = cableTray.GetTypeId();
            //    ElementId levelId = cableTray.ReferenceLevel.Id;
            //    CableTray cableTray1 = CableTray.Create(doc, symbolId, p1, point, levelId);
            //    CableTray cableTray2 = CableTray.Create(doc, symbolId, point, p2, levelId);
            //    connector1 = GetConnector(cableTray1, point);
            //    connector2 = GetConnector(cableTray2, point);
            //}
            //TaskDialog.Show("22", angle.ToString());
            //PlumbingUtils.BreakCurve(doc, element.Id, point);

            //1.打断管道
            ICollection<ElementId> ids = ElementTransformUtils.CopyElement(doc, element.Id, (p1 + p2) / 2);
            ElementId copyId = ids.First();
            (element.Location as LocationCurve).Curve = newLine1;
            MEPCurve mEPCurve1 = element as MEPCurve;
            MEPCurve mEPCurve2 = doc.GetElement(copyId) as MEPCurve;
            (mEPCurve2.Location as LocationCurve).Curve = newLine2;
            t.Commit();
            Line axis = Line.CreateBound(point, point + XYZ.BasisZ * 2);
            //ElementTransformUtils.RotateElement(doc, pipe2.Id, axis, 0.7854);

            //2.旋转其中一根管道
            //判断需要旋转的管道
            XYZ crossP1 = newLine1.GetEndPoint(1) - newLine1.Direction * 2;
            XYZ crossP2 = newLine2.GetEndPoint(0) + newLine2.Direction * 2;
            if (crossP1.DistanceTo(directPoint) < crossP2.DistanceTo(directPoint))
            {
                Transaction t1 = new Transaction(doc, "判断正确旋转方向");
                t1.Start();
                ElementTransformUtils.RotateElement(doc, mEPCurve1.Id, axis, -angle);
                double dirP1 = ((mEPCurve1.Location as LocationCurve).Curve as Line).GetEndPoint(0).DistanceTo(directPoint);
                ElementTransformUtils.RotateElement(doc, mEPCurve1.Id, axis, 2 * angle);
                double dirP2 = ((mEPCurve1.Location as LocationCurve).Curve as Line).GetEndPoint(0).DistanceTo(directPoint);
                t1.RollBack();
                Transaction t2 = new Transaction(doc, "旋转管道");
                t2.Start();
                if (dirP1 < dirP2)
                {
                    ElementTransformUtils.RotateElement(doc, mEPCurve1.Id, axis, -angle);
                }
                else
                {
                    ElementTransformUtils.RotateElement(doc, mEPCurve1.Id, axis, angle);
                }
                t2.Commit();

            }
            else
            {
                Transaction t1 = new Transaction(doc, "判断正确旋转方向");
                t1.Start();
                ElementTransformUtils.RotateElement(doc, mEPCurve2.Id, axis, -angle);
                double dirP1 = ((mEPCurve2.Location as LocationCurve).Curve as Line).GetEndPoint(1).DistanceTo(directPoint);
                ElementTransformUtils.RotateElement(doc, mEPCurve2.Id, axis, 2 * angle);
                double dirP2 = ((mEPCurve2.Location as LocationCurve).Curve as Line).GetEndPoint(1).DistanceTo(directPoint);
                t1.RollBack();
                Transaction t2 = new Transaction(doc, "旋转管道");
                t2.Start();
                if (dirP1 < dirP2)
                {
                    ElementTransformUtils.RotateElement(doc, mEPCurve2.Id, axis, -angle);
                }
                else
                {
                    ElementTransformUtils.RotateElement(doc, mEPCurve2.Id, axis, angle);
                }
                t2.Commit();
                //ElementTransformUtils.RotateElement(doc, mEPCurve2.Id, axis, -angle);
            }
            //3.在两个连接器之间创建管件
            Connector connector1 = GetConnector(mEPCurve1, point);
            Connector connector2 = GetConnector(mEPCurve2, point);
            Transaction t3 = new Transaction(doc, "创建连接件");
            t3.Start();
            try
            {
                doc.Create.NewElbowFitting(connector1, connector2);
            }
            catch (Exception)
            {
                TaskDialog.Show("错误", "创建连接件失败");
            }
            t3.Commit();
            
            //TaskDialog.Show("lll", CheckPointSide(pipeLine,oldPoint));
            group.Assimilate();
            return Result.Succeeded;
        }
        //获取连接器
        public Connector GetConnector(MEPCurve mEPCurve,XYZ point)
        {
            double min = double.MaxValue;
            Connector connector = null;
            foreach (Connector item in mEPCurve.ConnectorManager.Connectors)
            {
                if ((item.Origin - point).GetLength() < min)
                {
                    min = (item.Origin - point).GetLength();
                    connector = item;
                }
            }
            return connector;
        }
    }
    public class PipelineFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == -2008000 
                ||elem.Category.Id.IntegerValue == -2008044
                || elem.Category.Id.IntegerValue == -2008130)
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
