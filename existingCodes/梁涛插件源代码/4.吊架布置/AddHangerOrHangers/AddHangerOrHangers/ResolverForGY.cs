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

    class ResolverForGY
    {
        private UIApplication m_uiapp;
        private Document m_doc;
        private Transform transform2;
        private Transform transform3;

        double wide_GY;
        double height_Hanger;
        double height_Floor;

        // 构造函数
        public ResolverForGY(ExternalCommandData commandData,Transform transform,Transform transform1)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
            transform2 = transform;
            transform3 = transform1;
        }

        //方法
        public void Resolve(View3D view3D, Element hanger, Element mep1, Element mep2, XYZ location)
        {
            MEPCurve mepCurve1 = mep1 as MEPCurve;
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            XYZ mepDirection = mepLine1.Direction;
            XYZ endpoint0 = mepLine1.GetEndPoint(0);
            XYZ endpoint1 = mepLine1.GetEndPoint(1);

            MEPCurve mepCurve2 = mep2 as MEPCurve;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;

            //拾取点与MEP1中线交点
            IntersectionResult iResult1 = mepLine1.Project(location);
            XYZ projectPoint1 = iResult1.XYZPoint;
            //projectPoint1 = transform2.OfPoint(projectPoint1);
            //拾取点与MEP2中线交点
            IntersectionResult iResult2 = mepLine2.Project(location);
            XYZ projectPoint2 = iResult2.XYZPoint;
            //projectPoint2 = transform3.OfPoint(projectPoint2);
            //修正两点的Z值
            projectPoint2 = new XYZ(projectPoint2.X, projectPoint2.Y, projectPoint1.Z);
            //共用管线的宽度
            double a = projectPoint1.DistanceTo(projectPoint2);
            double b = Utils.GetHalfWide(mep1);
            double c = Utils.GetHalfWide(mep2);
            wide_GY = a + b + c;
            //共用管线的中点
            double i = b - (b + c) / 2;
            location = (projectPoint1 + projectPoint2) / 2;

            if (b > c)
            {
                location = location + ((projectPoint1 - projectPoint2).Normalize() * i);
            }
            else if (b < c)
            {
                location = location + ((projectPoint2 - projectPoint1).Normalize() * (-1 * i));
            }
            else
            {
                location = (projectPoint1 + projectPoint2) / 2;
            }

            XYZ projectPoint = location;

            //创建吊架
            FamilySymbol sy = (hanger as FamilyInstance).Symbol;
            FamilyInstance new_Hanger = m_doc.Create.NewFamilyInstance(
                        location, sy, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
            //共用管线中点到楼板的投影点，修正吊架的插入点
            XYZ point_Hanger = Utils.GetClearHeightPoint(view3D, m_doc, location);
            (new_Hanger.Location as LocationPoint).Point = point_Hanger;

            //设置吊架-----------------------------------------------------------------------------------------------------------------------------------------------------------
            //吊架长度
            foreach (Parameter para in new_Hanger.Parameters)
                if (para.Definition.Name == "c_风管宽")
                    para.Set(wide_GY);

            //桥架底标高
            //double projectHeight = Utils.GetClearHeight(view3D, doc, projectPoint);
            double projectHeight = projectPoint.DistanceTo(point_Hanger);
            height_Hanger = projectHeight - Utils.GetHalfHeight(mep1);

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
