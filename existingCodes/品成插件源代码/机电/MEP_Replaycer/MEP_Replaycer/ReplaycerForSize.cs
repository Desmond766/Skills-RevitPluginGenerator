using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI.Selection;

namespace MEP_Replaycer
{
    class ReplaycerForSize
    {
        //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 构造函数
        public ReplaycerForSize(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        //方法
        public void Replaycer(Reference reference)
        {
            Element element = m_doc.GetElement(reference);
            MEPCurve mepCurveEle = element as MEPCurve;

            Selection sel = m_uiapp.ActiveUIDocument.Selection;

            //水管
            if (mepCurveEle is Pipe)
            {
                //参照管径
                Parameter diameterEle = element.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
                //选择目标管线
                IList<Reference> listEle = sel.PickObjects(ObjectType.Element, new PipeSystemSelectionFilter(), "请选择管线");//多选方式
                //替换目标管线管径
                foreach (var item in listEle)
                {
                    Element targetElem = m_doc.GetElement(item);
                    if (targetElem is Pipe)//直管
                    {
                        targetElem.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameterEle.AsDouble());
                    }
                    if (targetElem.Category.Name == "管件")
                    {
                        FamilyInstance familyInsElem = targetElem as FamilyInstance;
                        MechanicalFitting fittingElem = familyInsElem.MEPModel as MechanicalFitting;
                        if (fittingElem != null)
                        {
                            if (fittingElem.PartType == PartType.Elbow)//弯头
                            {
                                targetElem.LookupParameter("公称半径").Set(diameterEle.AsDouble() * 0.5);
                            }
                            if (fittingElem.PartType == PartType.Tee)//三通
                            {
                                targetElem.LookupParameter("主干管半径").Set(diameterEle.AsDouble() * 0.5);
                            }
                        }
                        //变径、阀件会自动跟着变化，四通暂不考虑（参数名不固定）
                    }

                }
            }
            //风管
            else if (mepCurveEle is Duct)
            {
                //参照宽、高
                Parameter widthEle = element.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM);
                Parameter heightEle = element.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM);
                //选择目标管线
                IList<Reference> listEle = sel.PickObjects(ObjectType.Element, new DuctSystemSelectionFilter(), "请选择管线");//多选方式
                //替换目标管线宽、高
                foreach (var item in listEle)
                {
                    Element targetElem = m_doc.GetElement(item);
                    if (targetElem is Duct)//直管
                    {
                        targetElem.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).Set(widthEle.AsDouble());
                        targetElem.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).Set(heightEle.AsDouble());
                    }
                    if (targetElem.Category.Name == "风管管件")
                    {
                        if (Utils.GetFittingType(targetElem) == FittingType.Elbow)//弯头
                        {
                            if (Utils.GetDuctElbowType(targetElem) == DuctElbowType.ElbowPlane)//平面的弯头
                            {
                                targetElem.LookupParameter("风管宽度").Set(widthEle.AsDouble());
                                targetElem.LookupParameter("风管高度").Set(heightEle.AsDouble());
                            }
                            if (Utils.GetDuctElbowType(targetElem) == DuctElbowType.ElbowOffset)//爬升的弯头
                            {
                                targetElem.LookupParameter("风管高度").Set(widthEle.AsDouble());
                                targetElem.LookupParameter("风管宽度").Set(heightEle.AsDouble());
                            }
                        }
                    }
                    if (targetElem.Category.Name == "风管附件")//如果风管附件存在“风管宽度”和“风管高度”这两个参数的话，修改成目标值
                    {
                        if ((targetElem.LookupParameter("风管宽度") != null) && (targetElem.LookupParameter("风管高度") != null))
                        {
                            targetElem.LookupParameter("风管宽度").Set(widthEle.AsDouble());
                            targetElem.LookupParameter("风管高度").Set(heightEle.AsDouble());
                        }

                    }
                    //变径、三通、四通、会自动跟着变化（参数名不固定）
                }
            }
            //桥架
            else if (mepCurveEle is CableTray)
            {
                //参照宽、高
                Parameter widthEle = element.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                Parameter heightEle = element.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                //选择目标管线
                IList<Reference> listEle = sel.PickObjects(ObjectType.Element, new CTSystemSelectionFilter(), "请选择管线");//多选方式
                //替换目标管线宽、高
                foreach (var item in listEle)
                {
                    Element targetElem = m_doc.GetElement(item);
                    if (targetElem is CableTray)//直管
                    {
                        targetElem.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(widthEle.AsDouble());
                        targetElem.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(heightEle.AsDouble());
                    }
                    if (targetElem.Category.Name == "电缆桥架配件")
                    {
                        if (Utils.GetFittingType(targetElem) == FittingType.Elbow)//弯头
                        {
                            targetElem.LookupParameter("桥架宽度").Set(widthEle.AsDouble());
                            targetElem.LookupParameter("桥架高度").Set(heightEle.AsDouble());
                        }
                        else if (Utils.GetFittingType(targetElem) == FittingType.Tee)//三通
                        {
                            targetElem.LookupParameter("桥架宽度 1").Set(widthEle.AsDouble());
                            targetElem.LookupParameter("桥架高度").Set(heightEle.AsDouble());
                        }
                        //变径会自动跟着变化，四通暂不考虑（参数名不固定）
                    }
                }
            }

        }
    }
}
