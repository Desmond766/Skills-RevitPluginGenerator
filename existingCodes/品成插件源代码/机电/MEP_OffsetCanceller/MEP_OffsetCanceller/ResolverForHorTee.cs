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
    class ResolverForHorTee
    {
        //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 构造函数
        public ResolverForHorTee(ExternalCommandData commandData)
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
            Element TeeElem = m_doc.GetElement(r);
            elementDel.Add(TeeElem.Id);

            //收集构件0，1，2（三根横直管）
            List<Element> horLineGList = Utils.FindConnectedToList(m_doc.GetElement(r));
            if (horLineGList.Count != 3)//管道假接的情况跳过
            {
                TaskDialog.Show("提示", "检查管道是否连接。");
                return;
            }

            Element horLineGList0 = horLineGList[0];
            Element horLineGList1 = horLineGList[1];
            Element horLineGList2 = horLineGList[2];
            elementDel.Add(horLineGList0.Id);
            elementDel.Add(horLineGList1.Id);
            elementDel.Add(horLineGList2.Id);



            //收集构件01，11，21(翻弯的上配件1、上配件2、上配件3)
            //01
            List<Element> upPeiJList0 = Utils.FindConnectedToList(horLineGList0);
            Element upPeiJ01 = null;
            foreach (var item in upPeiJList0)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    upPeiJ01 = item;
                }
            }
            elementDel.Add(upPeiJ01.Id);
            //11
            List<Element> upPeiJList1 = Utils.FindConnectedToList(horLineGList1);
            Element upPeiJ11 = null;
            foreach (var item in upPeiJList1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    upPeiJ11 = item;
                }
            }
            elementDel.Add(upPeiJ11.Id);
            //21
            List<Element> upPeiJList2 = Utils.FindConnectedToList(horLineGList2);
            Element upPeiJ21 = null;
            foreach (var item in upPeiJList2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    upPeiJ21 = item;
                }
            }
            elementDel.Add(upPeiJ21.Id);


            //收集构件02，12，22(翻弯的斜管1、斜管2、斜管3)
            //02
            List<Element> xieLineGList0 = Utils.FindConnectedToList(upPeiJ01);
            Element xieLineG02 = null;
            foreach (var item in xieLineGList0)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    xieLineG02 = item;
                }
            }
            elementDel.Add(xieLineG02.Id);

            //12
            List<Element> xieLineGList1 = Utils.FindConnectedToList(upPeiJ11);
            Element xieLineG12 = null;
            foreach (var item in xieLineGList1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    xieLineG12 = item;
                }
            }
            elementDel.Add(xieLineG12.Id);

            //22
            List<Element> xieLineGList2 = Utils.FindConnectedToList(upPeiJ21);
            Element xieLineG22 = null;
            foreach (var item in xieLineGList2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    xieLineG22 = item;
                }
            }
            elementDel.Add(xieLineG22.Id);


            //收集构件03，13，23(翻弯的下配件1、下配件2、下配件3)
            //03
            List<Element> downPeiJList0 = Utils.FindConnectedToList(xieLineG02);
            Element downPeiJ03 = null;
            foreach (var item in downPeiJList0)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    downPeiJ03 = item;
                }
            }
            elementDel.Add(downPeiJ03.Id);
            //13
            List<Element> downPeiJList1 = Utils.FindConnectedToList(xieLineG12);
            Element downPeiJ13 = null;
            foreach (var item in downPeiJList1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    downPeiJ13 = item;
                }
            }
            elementDel.Add(downPeiJ13.Id);
            //23
            List<Element> downPeiJList2 = Utils.FindConnectedToList(xieLineG22);
            Element downPeiJ23 = null;
            foreach (var item in downPeiJList2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    downPeiJ23 = item;
                }
            }
            elementDel.Add(downPeiJ23.Id);

            //______________________________________________________________________________________

            //【二】收集三根短直管信息，确定三通移动位置

            //收集构件04(直短管1)
            List<Element> sHorLineGList0 = Utils.FindConnectedToList(downPeiJ03);
            Element sHorLineG04 = null;
            foreach (var item in sHorLineGList0)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    sHorLineG04 = item;
                }
            }
            //收集构件14(直短管2)
            List<Element> sHorLineGList1 = Utils.FindConnectedToList(downPeiJ13);
            Element sHorLineG14 = null;
            foreach (var item in sHorLineGList1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    sHorLineG14 = item;
                }
            }
            //收集构件24(直短管3)
            List<Element> sHorLineGList2 = Utils.FindConnectedToList(downPeiJ23);
            Element sHorLineG24 = null;
            foreach (var item in sHorLineGList2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    sHorLineG24 = item;
                }
            }

            //收集三根直短管
            MEPCurve g04MEPCurve = sHorLineG04 as MEPCurve;
            MEPCurve g14MEPCurve = sHorLineG14 as MEPCurve;
            MEPCurve g24MEPCurve = sHorLineG24 as MEPCurve;
           
            //三通位置
            XYZ oldPlace = new XYZ();
            XYZ newPlace = new XYZ();

            LocationPoint threeTLocationPt = m_doc.GetElement(r).Location as LocationPoint;
            oldPlace = threeTLocationPt.Point;//三通原来位置

            LocationCurve g04LocationCurve = sHorLineG04.Location as LocationCurve;
            Line g04Line = g04LocationCurve.Curve as Line;
            XYZ g04OriPt = g04Line.Origin;//短管高度

            newPlace = new XYZ(oldPlace.X, oldPlace.Y, g04OriPt.Z);//三通要移到的位置


            //______________________________________________________________________________________

            //【三】删除收集到的构件 

            elementDel.Remove(TeeElem.Id);
            foreach (var item in elementDel)
            {
                m_doc.Delete(item);
            }

            //______________________________________________________________________________________

            //【四】移动三通到直短管标高
            ElementTransformUtils.MoveElement(m_doc, TeeElem.Id, newPlace - oldPlace);
           //Utils.DrawModelCurve(m_doc, newPlace, oldPlace);

            //______________________________________________________________________________________
            
            //【五】补直管

            Utils.GetPtToCreateMEPCurve(m_doc, g04MEPCurve, TeeElem);
            Utils.GetPtToCreateMEPCurve(m_doc, g14MEPCurve, TeeElem);
            Utils.GetPtToCreateMEPCurve(m_doc, g24MEPCurve, TeeElem);

            m_doc.Delete(sHorLineG04.Id);
            m_doc.Delete(sHorLineG14.Id);
            m_doc.Delete(sHorLineG24.Id);


        }

    }
}
