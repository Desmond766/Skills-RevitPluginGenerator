using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_OffsetOverturner
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
            //收集要镜像的构件
            List<ElementId> elementDel = new List<ElementId>();

            //收集构件1（拾取的翻弯直管）
            ElementId idZhiG = m_doc.GetElement(r).Id;
            elementDel.Add(idZhiG);
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

            //(直短管1)
            List<Element> listZhiDuanG1 = Utils.FindConnectedToList(peiJX1);
            Element zhiDuanG1 = null;
            foreach (var item in listZhiDuanG1)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    zhiDuanG1 = item;
                }
            }
            //(直短管2)
            List<Element> listZhiDuanG2 = Utils.FindConnectedToList(peiJX2);
            Element zhiDuanG2 = null;
            foreach (var item in listZhiDuanG2)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    zhiDuanG2 = item;
                }
            }

            //确定镜像轴管\非镜像轴管
            MEPCurve mepCurveAxisG = null;
            //判断直短管1和2的高度是否一致
            //如果不一致，记住高度
            MEPCurve mepCurveZhiDuanG1 = zhiDuanG1 as MEPCurve;
            MEPCurve mepCurveZhiDuanG2 = zhiDuanG2 as MEPCurve;
            MEPCurve mepCurveZhiG = m_doc.GetElement(r) as MEPCurve;

            if (Math.Abs(mepCurveZhiDuanG1.LevelOffset - mepCurveZhiDuanG2.LevelOffset) < 0.001)
            {
                mepCurveAxisG = mepCurveZhiDuanG1;
            }
            else if (Math.Abs(mepCurveZhiG.LevelOffset - mepCurveZhiDuanG1.LevelOffset) > Math.Abs(mepCurveZhiG.LevelOffset - mepCurveZhiDuanG2.LevelOffset))
            {
                mepCurveAxisG = mepCurveZhiDuanG1;
            }
            else
            {
                mepCurveAxisG = mepCurveZhiDuanG2;
            }


            //确定镜像的平面
            //平面的法向量
            XYZ norm = new XYZ(0, 0, 1);
            //平面上的点。轴管上的点
            Line mepLineRAxis = (mepCurveAxisG.Location as LocationCurve).Curve as Line;
            XYZ origin = mepLineRAxis.GetEndPoint(0);
            Plane plane = new Plane(norm, origin);

            //镜像构件
            if (Math.Abs(mepCurveZhiDuanG1.LevelOffset - mepCurveZhiDuanG2.LevelOffset) < 0.001)
            {
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
            }
            else if (Math.Abs(mepCurveZhiG.LevelOffset - mepCurveZhiDuanG1.LevelOffset) > Math.Abs(mepCurveZhiG.LevelOffset - mepCurveZhiDuanG2.LevelOffset))
            {
                double d = mepCurveZhiDuanG2.LevelOffset;
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
                mepCurveZhiDuanG2.LevelOffset = d;
            }
            else
            {
                double d = mepCurveZhiDuanG1.LevelOffset;
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
                mepCurveZhiDuanG1.LevelOffset = d;
            }

           

            //判断翻转构件是桥架
            if (mepCurveZhiG is CableTray)
            {
                //镜像构件1（拾取的翻弯直管）
                List<ElementId> listZhiG = new List<ElementId>();
                listZhiG.Add(idZhiG);
                //确定镜像的平面
                //平面的法向量
                XYZ norm1 = new XYZ(0, 0, 1);
                //平面上的点。轴管上的点
                Line mepLineZhiG = (mepCurveZhiG.Location as LocationCurve).Curve as Line;
                XYZ origin1 = mepLineZhiG.GetEndPoint(0);
               // 镜像的平面
                Plane plane1 = new Plane(norm1, origin1);
                //镜像
                ElementTransformUtils.MirrorElements(m_doc, listZhiG, plane1,false);


                //镜像构件4(翻弯的短管1)
                //确定镜像的平面
                //平面的法向量
                Options option = new Options();
                option.View = m_doc.ActiveView;
                double a = 0.0;
                GeometryElement geomDuanG1 = duanG1.get_Geometry(option);
                foreach (GeometryObject geomobj in geomDuanG1)
                {
                    Solid geomSolid = geomobj as Solid;
                    if (null == geomSolid)
                    {
                        continue;
                    }
                    foreach (Face geomFace in geomSolid.Faces)
                    {
                        if (geomFace.Area > a)
                        {
                            a = geomFace.Area;
                        }
                    }
                }

                XYZ norm2 = new XYZ();
                foreach (GeometryObject geomobj in geomDuanG1)
                {
                    Solid geomSolid = geomobj as Solid;
                    if (null == geomSolid)
                    {
                        continue;
                    }
                    foreach (Face geomFace in geomSolid.Faces)
                    {
                        if (Math.Abs( geomFace.Area - a)<0.01)
                        {
                            PlanarFace aq=geomFace as PlanarFace;
                            norm2 = aq.FaceNormal;
                        }
                    }
                }
                //平面上的点。轴管上的点
                MEPCurve mepCurveDuanG1 = duanG1 as MEPCurve;
                Line mepLineDuanG1 = (mepCurveDuanG1.Location as LocationCurve).Curve as Line;
                XYZ origin2 = mepLineDuanG1.GetEndPoint(0);
                // 镜像的平面
                Plane plane2 = new Plane(norm2, origin2);
                // 镜像
                List<ElementId> listDuanG1_1 = new List<ElementId>();
                listDuanG1_1.Add(duanG1.Id);
                ElementTransformUtils.MirrorElements(m_doc, listDuanG1_1, plane2, false);


                //镜像构件5(翻弯的短管2)
                //确定镜像的平面
                //平面的法向量
                double b = 0.0;
                GeometryElement geomDuanG2 = duanG2.get_Geometry(option);
                foreach (GeometryObject geomobj in geomDuanG2)
                {
                    Solid geomSolid = geomobj as Solid;
                    if (null == geomSolid)
                    {
                        continue;
                    }
                    foreach (Face geomFace in geomSolid.Faces)
                    {
                        if (geomFace.Area > b)
                        {
                            b = geomFace.Area;
                        }
                    }
                }

                XYZ norm3 = new XYZ();
                foreach (GeometryObject geomobj in geomDuanG2)
                {
                    Solid geomSolid = geomobj as Solid;
                    if (null == geomSolid)
                    {
                        continue;
                    }
                    foreach (Face geomFace in geomSolid.Faces)
                    {
                        if (Math.Abs(geomFace.Area - b) < 0.01)
                        {
                            PlanarFace aq = geomFace as PlanarFace;
                            norm3 = aq.FaceNormal;
                        }
                    }
                }
                //平面上的点。轴管上的点
                MEPCurve mepCurveDuanG2 = duanG2 as MEPCurve;
                Line mepLineDuanG2 = (mepCurveDuanG2.Location as LocationCurve).Curve as Line;
                XYZ origin3 = mepLineDuanG2.GetEndPoint(0);
                // 镜像的平面
                Plane plane3 = new Plane(norm3, origin3);
                // 镜像
                List<ElementId> listDuanG2_2 = new List<ElementId>();
                listDuanG2_2.Add(duanG2.Id);
                ElementTransformUtils.MirrorElements(m_doc, listDuanG2_2, plane3, false);

                //peiJS1弯头位置的点
                XYZ peiJS1Pt = (peiJS1.Location as LocationPoint).Point;
                //peiJS1弯头
                Utils.CreateElbowFitting(m_doc, peiJS1Pt, mepCurveZhiG, mepCurveDuanG1);

                //peiJS2弯头位置的点
                XYZ peiJS2Pt = (peiJS2.Location as LocationPoint).Point;
                //peiJS2弯头
                Utils.CreateElbowFitting(m_doc, peiJS2Pt, mepCurveZhiG, mepCurveDuanG2);

                //peiJX1弯头位置的点
                XYZ peiJX1Pt = (peiJX1.Location as LocationPoint).Point;
                //peiJX1弯头
                Utils.CreateElbowFitting(m_doc, peiJX1Pt, mepCurveZhiDuanG1, mepCurveDuanG1);

                //peiJX2弯头位置的点
                XYZ peiJX2Pt = (peiJX2.Location as LocationPoint).Point;
                //peiJX2弯头
                Utils.CreateElbowFitting(m_doc, peiJX2Pt, mepCurveZhiDuanG2, mepCurveDuanG2);

                m_doc.Delete(peiJS1.Id);
                m_doc.Delete(peiJS2.Id);
                m_doc.Delete(peiJX1.Id);
                m_doc.Delete(peiJX2.Id);

            }
        }


    }
}
