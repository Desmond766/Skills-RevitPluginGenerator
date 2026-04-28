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
    class ResolverForCross
    {
        //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 构造函数
        public ResolverForCross(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        //方法
        public void Resolver(Reference r)
        {
            //【一】收集要删除的构件

            List<ElementId> elementDel = new List<ElementId>();
            //收集构件1（拾取的翻弯三通）
            Element crossElem = m_doc.GetElement(r);
            elementDel.Add(crossElem.Id);

            //收集构件0，1，2，3（四根横直管）
            List<Element> horLineGList = Utils.FindConnectedToList(crossElem);
            if (horLineGList.Count != 4)//管道假接的情况跳过
            {
                TaskDialog.Show("提示", "检查管道是否连接。");
                return;
            }

            Element horLineG0 = horLineGList[0];
            Element horLineG1 = horLineGList[1];
            Element horLineG2 = horLineGList[2];
            Element horLineG3 = horLineGList[3];
            elementDel.Add(horLineG0.Id);
            elementDel.Add(horLineG1.Id);
            elementDel.Add(horLineG2.Id);
            elementDel.Add(horLineG3.Id);

            //收集构件01，11，21，31(翻弯的上配件1、上配件2、上配件3、上配件4)
            //01
            Element upPeiJ01 = Utils.GetGoalElement(horLineG0, elementDel);
            elementDel.Add(upPeiJ01.Id);
            //11
            Element upPeiJ11 = Utils.GetGoalElement(horLineG1, elementDel);
            elementDel.Add(upPeiJ11.Id);
            //21
            Element upPeiJ21 = Utils.GetGoalElement(horLineG2, elementDel);
            elementDel.Add(upPeiJ21.Id);
            //31
            Element upPeiJ31 = Utils.GetGoalElement(horLineG3, elementDel);
            elementDel.Add(upPeiJ31.Id);

            //收集构件02，12，22，32(翻弯的斜管1、斜管2、斜管3、斜管4)
            //02
            Element xieLineG02 = Utils.GetGoalElement(upPeiJ01, elementDel);
            elementDel.Add(xieLineG02.Id);
            //12
            Element xieLineG12 = Utils.GetGoalElement(upPeiJ11, elementDel);
            elementDel.Add(xieLineG12.Id);
            //22
            Element xieLineG22 = Utils.GetGoalElement(upPeiJ21, elementDel);
            elementDel.Add(xieLineG22.Id);
            //32
            Element xieLineG32 = Utils.GetGoalElement(upPeiJ31, elementDel);
            elementDel.Add(xieLineG32.Id);

            //收集构件03，13，23，33(翻弯的下配件1、下配件2、下配件3、下配件4)
            //03
            Element downPeiJ03 = Utils.GetGoalElement(xieLineG02, elementDel);
            elementDel.Add(downPeiJ03.Id);
            //13
            Element downPeiJ13 = Utils.GetGoalElement(xieLineG12, elementDel);
            elementDel.Add(downPeiJ13.Id);
            //23
            Element downPeiJ23 = Utils.GetGoalElement(xieLineG22, elementDel);
            elementDel.Add(downPeiJ23.Id);
            //33
            Element downPeiJ33 = Utils.GetGoalElement(xieLineG32, elementDel);
            elementDel.Add(downPeiJ33.Id);

            //______________________________________________________________________________________

            //【二】收集四根短直管信息，确定四通移动位置

            //收集构件04，14，24，34(直短管1、直短管2、直短管3、直短管4)
            Element sHorLineG04 = Utils.GetGoalElement(downPeiJ03, elementDel);
            Element sHorLineG14 = Utils.GetGoalElement(downPeiJ13, elementDel);
            Element sHorLineG24 = Utils.GetGoalElement(downPeiJ23, elementDel);
            Element sHorLineG34 = Utils.GetGoalElement(downPeiJ33, elementDel);
            //收集四根直短管
            MEPCurve g04MEPCurve = sHorLineG04 as MEPCurve;
            MEPCurve g14MEPCurve = sHorLineG14 as MEPCurve;
            MEPCurve g24MEPCurve = sHorLineG24 as MEPCurve;
            MEPCurve g34MEPCurve = sHorLineG34 as MEPCurve;
            
            //四通前后位置
            XYZ oldPlace = new XYZ();
            XYZ newPlace = new XYZ();
            
            LocationPoint crossLocationPt = m_doc.GetElement(r).Location as LocationPoint;
            oldPlace = crossLocationPt.Point;//四通原来位置

            LocationCurve g04LocationCurve = sHorLineG04.Location as LocationCurve;
            Line g04Line = g04LocationCurve.Curve as Line;
            XYZ g04OriPt = g04Line.Origin;//短管高度

            newPlace = new XYZ(oldPlace.X, oldPlace.Y, g04OriPt.Z);//四通要移到的位置

           

            //______________________________________________________________________________________

            //【三】删除收集到的构件 

            elementDel.Remove(crossElem.Id);
            foreach (var item in elementDel)
            {
                m_doc.Delete(item);
            }

            //______________________________________________________________________________________

            //【四】移动四通到直短管标高
            ElementTransformUtils.MoveElement(m_doc, crossElem.Id, newPlace - oldPlace);

            //______________________________________________________________________________________

            //【五】补直管
            //找到要补直管的两点
            
            Utils.GetPtToCreateMEPCurve(m_doc, g04MEPCurve, crossElem);
            Utils.GetPtToCreateMEPCurve(m_doc, g14MEPCurve, crossElem);
            Utils.GetPtToCreateMEPCurve(m_doc, g24MEPCurve, crossElem);
            Utils.GetPtToCreateMEPCurve(m_doc, g34MEPCurve, crossElem);
            
            m_doc.Delete(sHorLineG04.Id);
            m_doc.Delete(sHorLineG14.Id);
            m_doc.Delete(sHorLineG24.Id);
            m_doc.Delete(sHorLineG34.Id);
        }
    }
}
