using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_OffsetCanceller
{
    class ResolverForVerTee
    {
         //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 构造函数
        public ResolverForVerTee(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        //方法
        public void Resolver(Reference r)
        {
            //收集要删除的构件
            List<ElementId> elementDel = new List<ElementId>();

            //收集构件1（拾取的垂直三通）
            Element verTeeElem = m_doc.GetElement(r);
            elementDel.Add(verTeeElem.Id);
            //收集构件2(立管)//旋转轴上的点//旋转轴//垂直方向上的点
            XYZ origin = new XYZ();
            Line axis = null;
            XYZ verEndPt = new XYZ();

            List<Connector> verTeeConnList = Utils.GetConList(Utils.GetConSet(verTeeElem));
            Element verLineG = null;
            if (Math.Abs(verTeeConnList[0].Origin.Z - verTeeConnList[1].Origin.Z) < 0.001)
            {
                verLineG = Utils.FindConnectorToElem(verTeeElem, verTeeConnList[2].Origin);
                origin = verTeeConnList[0].Origin;
                axis = Line.CreateBound(verTeeConnList[0].Origin, verTeeConnList[1].Origin);
                verEndPt = verTeeConnList[2].Origin;
            }
            else if (Math.Abs(verTeeConnList[0].Origin.Z - verTeeConnList[2].Origin.Z) < 0.001)
            {
                verLineG = Utils.FindConnectorToElem(verTeeElem, verTeeConnList[1].Origin);
                origin = verTeeConnList[0].Origin;
                axis = Line.CreateBound(verTeeConnList[0].Origin, verTeeConnList[2].Origin);
                verEndPt = verTeeConnList[1].Origin;
            }
            else
            {
                verLineG = Utils.FindConnectorToElem(verTeeElem, verTeeConnList[0].Origin);
                origin = verTeeConnList[1].Origin;
                axis = Line.CreateBound(verTeeConnList[1].Origin, verTeeConnList[2].Origin);
                verEndPt = verTeeConnList[0].Origin;
            }
            if (verLineG!=null)
            {
                elementDel.Add(verLineG.Id);
            }
            else
            {
                TaskDialog.Show("提示", "检查管道是否连接。");
            }



            //收集构件3（弯头）
            Element elbow = Utils.GetGoalElement(verLineG, elementDel);
            elementDel.Add(elbow.Id);

            //______________________________________________________________________________________

            //【二】收集短直管信息，确定移动位置

            //收集构件4（水平管）
            Element horLineG = Utils.GetGoalElement(elbow, elementDel);
            MEPCurve horLineGCurve = horLineG as MEPCurve;
            XYZ horLineGPt1 = Utils.GetClosedPt(horLineGCurve, verTeeElem);
            XYZ horLineGPt2 = Utils.GetFarPt(horLineGCurve, verTeeElem);
            horLineG.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).Set(origin.Z);


            //______________________________________________________________________________________

            //【三】删除收集到的构件 

            elementDel.Remove(verTeeElem.Id);
            foreach (var item in elementDel)
            {
                m_doc.Delete(item);
            }

            //______________________________________________________________________________________

            //【四】旋转构件1 （垂直三通）
            //旋转角度
            double angle = 0.00;

            LocationPoint verTeeLocationPt = verTeeElem.Location as LocationPoint;
            XYZ verTeePt = verTeeLocationPt.Point;//配件位置
            XYZ a = verEndPt - verTeePt;
            XYZ b = horLineGPt2 - horLineGPt1;
            angle = a.AngleTo(b);

            //预旋转
            Transform tran = Transform.CreateRotation(axis.Direction, angle);
            XYZ preRotate = tran.OfVector(a);
            
            //试旋转判断
            if (preRotate.Normalize().IsAlmostEqualTo(b.Normalize()))
            {
                ElementTransformUtils.RotateElement(m_doc, verTeeElem.Id, axis, angle);
            }
            else
            {
                ElementTransformUtils.RotateElement(m_doc, verTeeElem.Id, axis, -1 * angle);
            }

            //______________________________________________________________________________________

            //【五】补直管

            Utils.GetPtToCreateMEPCurve(m_doc, horLineGCurve, verTeeElem);

            m_doc.Delete(horLineGCurve.Id);
        }
    }
}
