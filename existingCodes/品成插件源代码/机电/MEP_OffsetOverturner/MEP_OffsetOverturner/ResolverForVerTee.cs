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
            //收集要镜像的构件
            List<ElementId> elementDel = new List<ElementId>();

            //收集构件1（拾取的垂直三通）
            Element verTeeElem = m_doc.GetElement(r);
            elementDel.Add(verTeeElem.Id);
            //收集构件2(立管)与镜像平面上的点
            XYZ origin = new XYZ();
            List<Connector> verTeeConnList = Utils.GetConList(Utils.GetConSet(verTeeElem));
            Element verLineG = null;
            if (Math.Abs(verTeeConnList[0].Origin.Z - verTeeConnList[1].Origin.Z) < 0.001)
            {
                verLineG = Utils.FindConnectorToElem(verTeeElem, verTeeConnList[2].Origin);
                origin = verTeeConnList[0].Origin;
            }
            else if (Math.Abs(verTeeConnList[0].Origin.Z - verTeeConnList[2].Origin.Z) < 0.001)
            {
                verLineG = Utils.FindConnectorToElem(verTeeElem, verTeeConnList[1].Origin);
                origin = verTeeConnList[0].Origin;
            }
            else
            {
                verLineG = Utils.FindConnectorToElem(verTeeElem, verTeeConnList[0].Origin);
                origin = verTeeConnList[1].Origin;
            }
            elementDel.Add(verLineG.Id);
            

            //收集构件3（弯头）
            List<Element> elbowList = Utils.FindConnectedToList(verLineG);
            Element elbow = null;
            foreach (var item in elbowList)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    elbow = item;
                }
            }
            elementDel.Add(elbow.Id);

            //收集构件4（水平管）
            List<Element> horLineGList = Utils.FindConnectedToList(elbow);
            Element horLineG = null;
            foreach (var item in horLineGList)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    horLineG = item;
                }
            }
            elementDel.Add(horLineG.Id);

            //确定镜像的平面
            //平面的法向量
            XYZ norm = new XYZ(0, 0, 1);
            //平面上的点。轴上的点
            Plane plane = new Plane(norm, origin);

            ElementTransformUtils.MirrorElements(m_doc, elementDel, plane, false);

            
            //TaskDialog.Show("a", elementDel.Count.ToString());
            ////【三】删除收集到的构件 
            //foreach (var item in elementDel)
            //{
            //    m_doc.Delete(item);
            //}

        }
    }
}
