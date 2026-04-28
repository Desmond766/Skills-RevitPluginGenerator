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
    class ReplaycerForOffset
    {
        //字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 构造函数
        public ReplaycerForOffset(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        //方法
        public void Replaycer(Reference reference)
        {
            Element element = m_doc.GetElement(reference);
            //收集标高
            MEPCurve mepCurveEle = element as MEPCurve;
            double offsetEle = mepCurveEle.LevelOffset;

            //选择目标管线
            Selection sel = m_uiapp.ActiveUIDocument.Selection;
            IList<Reference> listEle = sel.PickObjects(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择管线");//多选方式
            //替换目标管线标高
            foreach (var item in listEle)
            {
                (m_doc.GetElement(item) as MEPCurve).LevelOffset = offsetEle;//多选方式 
            }
        }

    }
}
