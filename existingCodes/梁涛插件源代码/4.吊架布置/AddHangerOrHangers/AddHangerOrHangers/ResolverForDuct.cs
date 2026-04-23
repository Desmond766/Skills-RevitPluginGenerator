using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace AddHanger
{
    class ResolverForDuct
    {
        private UIApplication m_uiapp;
        private Document m_doc;
        private  Transform transform2;

        double wide_Duct;
        double height_Duct;
        double height_Hanger;
        double height_Floor;

        // 构造函数
        public ResolverForDuct(ExternalCommandData commandData,Transform transform)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
            this.transform2 = transform;
        }

        //方法
        public void Resolve(View3D view3D, Element hanger, Element mep, XYZ location)
        {
            wide_Duct = mep.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble();
            height_Duct = mep.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble();

            MEPCurve mepCurve = mep as MEPCurve;
            Line mepLine = (mepCurve.Location as LocationCurve).Curve as Line;
            XYZ mepDirection = mepLine.Direction;
            XYZ endpoint0 = mepLine.GetEndPoint(0);
            XYZ endpoint1 = mepLine.GetEndPoint(1);

            //拾取点与风管中线交点
            IntersectionResult iResult = mepLine.Project(location);
            XYZ projectPoint = iResult.XYZPoint;
            projectPoint = transform2.OfPoint(projectPoint);

            //创建吊架
            FamilySymbol sy = (hanger as FamilyInstance).Symbol;
            FamilyInstance new_Hanger = m_doc.Create.NewFamilyInstance(
                        projectPoint, sy, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

            //拾取点到楼板的投影点，修正吊架的插入点
            XYZ point_Hanger = Utils.GetClearHeightPoint(view3D, m_doc, projectPoint);
            (new_Hanger.Location as LocationPoint).Point = point_Hanger;


            //设置吊架
            //c_风管宽  风管高度
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "c_风管宽")
                    para.Set(wide_Duct);
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "风管高度")
                    para.Set(height_Duct);

            //b_底层管道底高
            //double projectHeight = Utils.GetClearHeight(view3D, doc, projectPoint);
            double projectHeight = projectPoint.DistanceTo(point_Hanger);  //拾取点就是风管的中心点，在几何中心位置（风管底部  到地下楼板的距离）
            height_Hanger = projectHeight - height_Duct / 2;

            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "b_底层管道底高")
                    para.Set(height_Hanger);



            //计算楼层高度
            double projectHeightUp = Utils.GetClearHeightUp(view3D, m_doc, projectPoint);//获得管线中心点向上投影的高度


            height_Floor = projectHeightUp + projectHeight;

            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "a_楼板底高")
                    para.Set(height_Floor);
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "a_梁底底高")
                    para.Set(height_Floor - 200 / 304.8);


            //旋转吊架
            //判断管线方向与角度
            if (endpoint0.Z != endpoint1.Z)
            {
                endpoint1 = new XYZ(endpoint1.X, endpoint1.Y, endpoint0.Z);
                mepDirection = endpoint1 - endpoint0;
            }
            double angle = mepDirection.AngleTo(XYZ.BasisX);
            Line axis = Line.CreateBound(projectPoint, new XYZ(projectPoint.X, projectPoint.Y, 0));

            if (angle > 0.5 * Math.PI)
            {
                angle = Math.PI - angle;
            }
            ElementTransformUtils.RotateElement(m_doc, new_Hanger.Id, axis, 0.5 * Math.PI - angle);
            Transform transform = new_Hanger.GetTransform();

            if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(mepDirection) - 0.5 * Math.PI) > 0.001)
            {
                ElementTransformUtils.RotateElement(m_doc, new_Hanger.Id, axis, -2 * (0.5 * Math.PI - angle));
            }
        }


    }
}
