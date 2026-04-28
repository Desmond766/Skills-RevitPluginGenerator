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
    class RepalycerForSystemType
    {
        //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;
        
        // 构造函数
        public RepalycerForSystemType(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        
        //方法
        public void Replaycer(Reference reference)
        {
            Element element = m_doc.GetElement(reference);
            MEPCurve mepCurveEle = element as MEPCurve;

            Parameter systemTypeEle = null;//原管线系统
            Reference targetRef = null;//拾取目标管线
            Element targetEle = null;//目标管线
            Selection sel = m_uiapp.ActiveUIDocument.Selection;
            if (mepCurveEle is Pipe)
            {
                //原管线系统
                systemTypeEle = element.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM);
                //选择目标管线
                targetRef = sel.PickObject(ObjectType.Element, new PipeSelectionFilter(), "请选择水管");
                //替换目标管线系统 
                targetEle = m_doc.GetElement(targetRef);
                targetEle.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).Set(systemTypeEle.AsElementId());
            }
            else if (mepCurveEle is Duct)
            {
                //原管线系统
                systemTypeEle = element.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM);
                //选择目标管线
                targetRef = sel.PickObject(ObjectType.Element, new DuctSelectionFilter(), "请选择风管");
                //替换目标管线系统 
                targetEle = m_doc.GetElement(targetRef);
                targetEle.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).Set(systemTypeEle.AsElementId());
            }
            else
            {
                TaskDialog.Show("提示：", "请选择水管或风管。");
            }
        }
    }
}
