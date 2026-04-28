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
    class Resolver
    {
        //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 构造函数
        public Resolver(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        //方法
        public void Resolve(Reference r)
        {
            //【一】收集要删除的构件
           
            List<ElementId> elementDel = new List<ElementId>();

            //收集构件1（拾取的翻弯直管）
            ElementId idZhiG1 = m_doc.GetElement(r).Id;
            elementDel.Add(idZhiG1);
            //收集构件23(翻弯的上配件1、上配件2)
            List<Element> listPeiJS = Utils.FindConnectedToList(m_doc.GetElement(r));
            Element peiJS1 = listPeiJS[0];
            Element peiJS2 = listPeiJS[1];
            elementDel.Add(peiJS1.Id);
            elementDel.Add(peiJS2.Id);
            //收集构件4(翻弯的短管1)
            List<Element> listDuanG1 = Utils.FindConnectedToList(peiJS1);
            Element duanG1 = null;
            foreach (var item in listDuanG1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    duanG1 = item;
                }
            }
            elementDel.Add(duanG1.Id);
            //收集构件5(翻弯的短管2)
            List<Element> listDuanG2 = Utils.FindConnectedToList(peiJS2);
            Element duanG2 = null;
            foreach (var item in listDuanG2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    duanG2 = item;
                }
            }
            elementDel.Add(duanG2.Id);
            //收集构件6(翻弯的下配件1）
            List<Element> listPeiJX1 = Utils.FindConnectedToList(duanG1);
            Element peiJX1 = null;
            foreach (var item in listPeiJX1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    peiJX1 = item;
                }
            }
            elementDel.Add(peiJX1.Id);
            //收集构件7(翻弯的下配件2）
            List<Element> listPeiJX2 = Utils.FindConnectedToList(duanG2);
            Element peiJX2 = null;
            foreach (var item in listPeiJX2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    peiJX2 = item;
                }
            }
            elementDel.Add(peiJX2.Id);
            //收集构件8(直短管1)
            List<Element> listZhiDuanG1 = Utils.FindConnectedToList(peiJX1);
            Element zhiDuanG1 = null;
            foreach (var item in listZhiDuanG1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    zhiDuanG1 = item;
                }
            }
            //elementDel.Add(zhiDuanG1.Id);
            //收集构件9(直短管2)
            List<Element> listZhiDuanG2 = Utils.FindConnectedToList(peiJX2);
            Element zhiDuanG2 = null;
            foreach (var item in listZhiDuanG2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    zhiDuanG2 = item;
                }
            }
            //elementDel.Add(zhiDuanG2.Id);

            //【二】找到要补直管的两个点
            //直短管1上距离配件下1远的点
            //直短管1上的点
            MEPCurve mepCurveZhiDuanG1 = zhiDuanG1 as MEPCurve;
            Line mepLineZhiDuanG1 = (mepCurveZhiDuanG1.Location as LocationCurve).Curve as Line;
            XYZ startPoint = mepLineZhiDuanG1.GetEndPoint(0);
            XYZ endPoint = mepLineZhiDuanG1.GetEndPoint(1);
            LocationPoint locationPointPeiJX1 = peiJX1.Location as LocationPoint;
            XYZ pointPeiJX1 = locationPointPeiJX1.Point;

            //直短管1上距离配件下1较远的点
            XYZ PFarZhiDuanG1 = new XYZ();
            if (startPoint.DistanceTo(pointPeiJX1) > endPoint.DistanceTo(pointPeiJX1))
            {
                PFarZhiDuanG1 = startPoint;
            }
            else
            {
                PFarZhiDuanG1 = endPoint;
            }

            //直短管2上距离配件下2远的点
            //直短管2上的点
            MEPCurve mepCurveZhiDuanG2 = zhiDuanG2 as MEPCurve;
            Line mepLineZhiDuanG2 = (mepCurveZhiDuanG2.Location as LocationCurve).Curve as Line;
            XYZ startPoint2 = mepLineZhiDuanG2.GetEndPoint(0);
            XYZ endPoint2 = mepLineZhiDuanG2.GetEndPoint(1);
            LocationPoint locationPointPeiJX2 = peiJX2.Location as LocationPoint;
            XYZ pointPeiJX2 = locationPointPeiJX2.Point;

            //直短管2上距离配件下2较远的点
            XYZ PFarZhiDuanG2 = new XYZ();
            if (startPoint2.DistanceTo(pointPeiJX2) > endPoint2.DistanceTo(pointPeiJX2))
            {
                PFarZhiDuanG2 = startPoint2;
            }
            else
            {
                PFarZhiDuanG2 = endPoint2;
            }

            //【三】找到要补直管的两个连接件或点
            //直短管1上较远点位置的连接件
            Connector startConn = Utils.FindConnector(mepCurveZhiDuanG1, PFarZhiDuanG1);
            //XYZ startPt = null;
            //判断连接件是否有连接对象
            if (startConn.IsConnected == true)//有连接
            {
                startConn = Utils.FindConnectedTo(mepCurveZhiDuanG1, PFarZhiDuanG1);
            }
            
            //直短管2上较远点位置的连接件
            Connector endConn = Utils.FindConnector(mepCurveZhiDuanG2, PFarZhiDuanG2);
            //XYZ endPt = null;
            //判断连接件是否有连接对象
            if (endConn.IsConnected == true)//有连接
            {
                endConn = Utils.FindConnectedTo(mepCurveZhiDuanG2, PFarZhiDuanG2);
            }
           
            //判断直短管1和2的标高是否一致
            //TaskDialog.Show("a", PFarZhiDuanG1.Z.ToString() +"\n"+ PFarZhiDuanG2.Z.ToString());
            if (!(Math.Abs(PFarZhiDuanG1.Z - PFarZhiDuanG2.Z) < 0.001))
            {
                TaskDialog.Show("提示", "翻弯两侧高度不一致，无法自动连接管道。");
            }
            else
            {
                //【四】补直管
                MEPHelper.Create(m_doc, mepCurveZhiDuanG1, startConn, endConn);
                m_doc.Delete(zhiDuanG1.Id);
                m_doc.Delete(zhiDuanG2.Id);
            }

            //【五】删除收集到的构件
            foreach (var item in elementDel)
            {
                m_doc.Delete(item);
            }

        }


    }
}
