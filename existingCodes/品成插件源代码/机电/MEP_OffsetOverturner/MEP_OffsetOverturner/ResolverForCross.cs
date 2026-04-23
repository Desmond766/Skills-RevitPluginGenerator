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
            //【一】收集要镜像的构件
            List<ElementId> elementDel = new List<ElementId>();
            //收集构件（拾取的水平三通）
            Element horTeeElem = m_doc.GetElement(r);
            elementDel.Add(horTeeElem.Id);

            //收集构件0，1，2，3（四根横直管）
            List<Element> horLineGList = Utils.FindConnectedToList(horTeeElem);
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

            //--------------------------------------------------------------------------------------

            //【二】收集四根短直管信息

            //收集构件04，14，24，34(直短管1、直短管2、直短管3、直短管4)
            Element sHorLineG04 = Utils.GetGoalElement(downPeiJ03, elementDel);
            Element sHorLineG14 = Utils.GetGoalElement(downPeiJ13, elementDel);
            Element sHorLineG24 = Utils.GetGoalElement(downPeiJ23, elementDel);
            Element sHorLineG34 = Utils.GetGoalElement(downPeiJ33, elementDel);

            MEPCurve g04MEPCurve = sHorLineG04 as MEPCurve;
            MEPCurve g14MEPCurve = sHorLineG14 as MEPCurve;
            MEPCurve g24MEPCurve = sHorLineG24 as MEPCurve;
            MEPCurve g34MEPCurve = sHorLineG34 as MEPCurve;


            

            double d00 = g04MEPCurve.LevelOffset;
            double d11 = g14MEPCurve.LevelOffset;
            double d22 = g24MEPCurve.LevelOffset;
            double d33 = g34MEPCurve.LevelOffset;

            //--------------------------------------------------------------------------------------

            //【三】确定镜像轴管\非镜像轴管

            //判断直短管1和2，3，4的高度,高差最大的为镜像轴管
            MEPCurve horLineG0MEPCurve = horLineG0 as MEPCurve;

            List<MEPCurve> mepList = new List<MEPCurve>(){
                g04MEPCurve,g14MEPCurve,g24MEPCurve,g34MEPCurve
            };
            
            //根据对象的属性对对象进行排序
            mepList = mepList.OrderBy(u => Math.Abs(u.LevelOffset - horLineG0MEPCurve.LevelOffset)).ToList();

            MEPCurve mepCurveAxisG = mepList[3];

            //确定镜像的平面
            //平面的法向量
            XYZ norm = new XYZ(0, 0, 1);
            //平面上的点。轴管上的点
            Line mepLineRAxis = (mepCurveAxisG.Location as LocationCurve).Curve as Line;
            XYZ origin = mepLineRAxis.GetEndPoint(0);
            Plane plane = new Plane(norm, origin);

            ////--------------------------------------------------------------------------------------

            //【四】镜像构件

            if (mepCurveAxisG == g04MEPCurve)
            {
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
                g14MEPCurve.LevelOffset = d11;
                g24MEPCurve.LevelOffset = d22;
                g34MEPCurve.LevelOffset = d33;
            }
            if (mepCurveAxisG == g14MEPCurve)
            {
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
                g04MEPCurve.LevelOffset = d00;
                g24MEPCurve.LevelOffset = d22;
                g34MEPCurve.LevelOffset = d33;
            }
            if (mepCurveAxisG == g24MEPCurve)
            {
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
                g04MEPCurve.LevelOffset = d00;
                g14MEPCurve.LevelOffset = d11;
                g34MEPCurve.LevelOffset = d33;
            }
            if (mepCurveAxisG == g34MEPCurve)
            {
                ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);
                g04MEPCurve.LevelOffset = d00;
                g14MEPCurve.LevelOffset = d11;
                g24MEPCurve.LevelOffset = d22;
            }

            //--------------------------------------------------------------------------------------

            //判断翻转构件是桥架
            if (horLineG0MEPCurve is CableTray)
            {
                //镜像构件（拾取的水平四通）,构件0，1，2，3（四根横直管）,
                List<ElementId> listToMirror1 = new List<ElementId>();
                listToMirror1.Add(horTeeElem.Id);
                listToMirror1.Add(horLineG0.Id);
                listToMirror1.Add(horLineG1.Id);
                listToMirror1.Add(horLineG2.Id);
                listToMirror1.Add(horLineG3.Id);
                //确定镜像的平面
                //平面的法向量
                XYZ norm1 = new XYZ(0, 0, 1);
                //平面上的点。轴管上的点
                Line mepLineHorLineG0 = (horLineG0.Location as LocationCurve).Curve as Line;
                XYZ origin1 = mepLineHorLineG0.GetEndPoint(0);
                // 镜像的平面
                Plane plane1 = new Plane(norm1, origin1);
                //镜像
                ElementTransformUtils.MirrorElements(m_doc, listToMirror1, plane1, false);


                //镜像构件02，12，22，32(翻弯的斜管1、斜管2、斜管3、斜管4)
                Utils.MirrorMEPCurveSelf(m_doc, xieLineG02);
                Utils.MirrorMEPCurveSelf(m_doc, xieLineG12);
                Utils.MirrorMEPCurveSelf(m_doc, xieLineG22);
                Utils.MirrorMEPCurveSelf(m_doc, xieLineG32);

                //收集MEPCurve
                MEPCurve horLineG1MEPCurve = horLineG1 as MEPCurve;
                MEPCurve horLineG2MEPCurve = horLineG2 as MEPCurve;
                MEPCurve horLineG3MEPCurve = horLineG3 as MEPCurve;

                MEPCurve xieLineG02MEPCurve = xieLineG02 as MEPCurve;
                MEPCurve xieLineG12MEPCurve = xieLineG12 as MEPCurve;
                MEPCurve xieLineG22MEPCurve = xieLineG22 as MEPCurve;
                MEPCurve xieLineG32MEPCurve = xieLineG32 as MEPCurve;
                
                //重新生成构件01，11，21(翻弯的上配件1、上配件2、上配件3)
                //peiJS1弯头位置的点//peiJS1弯头
                XYZ upPeiJ01Pt = (upPeiJ01.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, upPeiJ01Pt, horLineG0MEPCurve, xieLineG02MEPCurve);

                XYZ upPeiJ11Pt = (upPeiJ11.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, upPeiJ11Pt, horLineG1MEPCurve, xieLineG12MEPCurve);

                XYZ upPeiJ21Pt = (upPeiJ21.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, upPeiJ21Pt, horLineG2MEPCurve, xieLineG22MEPCurve);

                XYZ upPeiJ31Pt = (upPeiJ31.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, upPeiJ31Pt, horLineG3MEPCurve, xieLineG32MEPCurve);

                XYZ downPeiJ03Pt = (downPeiJ03.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, downPeiJ03Pt, g04MEPCurve, xieLineG02MEPCurve);

                XYZ downPeiJ13Pt = (downPeiJ13.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, downPeiJ13Pt, g14MEPCurve, xieLineG12MEPCurve);

                XYZ downPeiJ23Pt = (downPeiJ23.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, downPeiJ23Pt, g24MEPCurve, xieLineG22MEPCurve);

                XYZ downPeiJ33Pt = (downPeiJ33.Location as LocationPoint).Point;
                Utils.CreateElbowFitting(m_doc, downPeiJ33Pt, g34MEPCurve, xieLineG32MEPCurve);

                m_doc.Delete(upPeiJ01.Id);
                m_doc.Delete(upPeiJ11.Id);
                m_doc.Delete(upPeiJ21.Id);
                m_doc.Delete(upPeiJ31.Id);

                m_doc.Delete(downPeiJ03.Id);
                m_doc.Delete(downPeiJ13.Id);
                m_doc.Delete(downPeiJ23.Id);
                m_doc.Delete(downPeiJ33.Id);
            }
        }
    }
}
