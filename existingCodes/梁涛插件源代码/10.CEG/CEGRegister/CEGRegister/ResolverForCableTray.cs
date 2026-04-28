using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    class ResolverForCableTray
    {
        private UIApplication m_uiapp;
        private Document m_doc;

        double wide_CableTray;
        double height_CableTray;
        double height_Hanger;
        double height_Floor;

        // 构造函数
        public ResolverForCableTray(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        //方法
        public void Resolve(View3D view3D, Element hanger, Element mep, XYZ location)
        {
            wide_CableTray = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
            height_CableTray = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble();
            MEPCurve mepCurve = mep as MEPCurve;
            Line mepLine = (mepCurve.Location as LocationCurve).Curve as Line;
            XYZ mepDirection = mepLine.Direction;
            XYZ endpoint0 = mepLine.GetEndPoint(0);
            XYZ endpoint1 = mepLine.GetEndPoint(1);

            //拾取点与风管中线交点
            IntersectionResult iResult = mepLine.Project(location);
            XYZ projectPoint = iResult.XYZPoint;

            //创建吊架
            FamilySymbol sy = (hanger as FamilyInstance).Symbol;
            FamilyInstance new_Hanger = m_doc.Create.NewFamilyInstance(
                        projectPoint, sy, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

            //拾取点到楼板的投影点，修正吊架的插入点
            XYZ point_Hanger = Utils.GetClearHeightPoint(view3D, m_doc, projectPoint);
            (new_Hanger.Location as LocationPoint).Point = point_Hanger;


            //设置吊架
            //吊架套筒长度
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "吊架套筒长度")
                    para.Set(wide_CableTray);
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "c_桥架宽")
                    para.Set(wide_CableTray);

            //桥架底标高
            //double projectHeight = Utils.GetClearHeight(view3D, doc, projectPoint);
            double projectHeight = projectPoint.DistanceTo(point_Hanger);
            height_Hanger = projectHeight - height_CableTray / 2;

            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "桥架底标高")
                    para.Set(height_Hanger);
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "b_底层管道底高")
                    para.Set(height_Hanger);


            //楼层高度(a_楼板底高)
            double projectHeightUp = Utils.GetClearHeightUp(view3D, m_doc, projectPoint);
            height_Floor = projectHeightUp + projectHeight;

            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "a_楼板底高")
                    para.Set(height_Floor);



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
