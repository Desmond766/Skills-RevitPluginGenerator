using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HeightOFSprayPipeToTopPlate
{
    public class CalculatedHeightDifference
    {
        /// <summary>
        /// 获取高差
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="view"></param>
        /// <param name="inputValue"></param>
        public static void GetHeightDifference(Document doc, View view, string inputValue, List<string> elemCategory)
        {
            if (elemCategory.Count == 0) return;
            //TaskDialog.Show("sadas","开始运行");
            //获取所有水管
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
            FilteredElementCollector collector = new FilteredElementCollector(doc, view.Id);
            List<Element> pipes = collector.WherePasses(categoryFilter).ToList();

            //支管中心射线向上获取楼板地面
            View3D view3D = null;
            FilteredElementCollector viewCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (Element element in viewCollector)
            {
                View3D view3 = element as View3D;

                if (view3.Name.Equals("3D 支吊架"))
                {
                    // 将获取到的3D视图添加到列表中
                    view3D = view3;
                }
            }

            if (!elemCategory.Contains("喷淋支管")) goto Next;
            //过滤喷淋支管 直径小于65
            List<MEPCurve> targetPipes = new List<MEPCurve>();
            foreach (Element elem in pipes)
            {
                MEPCurve pipe = elem as MEPCurve;
                if (Util.VerticalOHorizontal(pipe))
                {
                    continue;
                }
                if (IsSprayPipe(pipe) && (pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 304.8) <= 65)
                {
                    targetPipes.Add(pipe);
                }
            }
            if (targetPipes.Count==0)
            {
                TaskDialog.Show("提示", "没有喷淋支管");
            }

            //Transform transform = Util.CoordinateTransformation(doc);
            foreach (MEPCurve pipe in targetPipes)
            {
                XYZ centerPoint = Util.GetMEPCurveCentrePoint(pipe);
                //centerPoint=transform.OfPoint(centerPoint);
                ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
                // 使用ReferenceIntersector进行射线与模型元素的交互检测
                ReferenceIntersector referenceIntersector = new ReferenceIntersector(filter, FindReferenceTarget.Face, view3D);
                referenceIntersector.FindReferencesInRevitLinks = true;
                ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(centerPoint, XYZ.BasisZ);
                double actualHeightDifference = 0;
                if (referenceWithContext != null)
                {

                    actualHeightDifference = referenceWithContext.Proximity;

                    JudgingHeightDifference(doc,view,inputValue, Math.Round(actualHeightDifference * 304.8, 1), pipe);
                }
            }
        Next:
            if (!elemCategory.Contains("套管")) return;
            using (FilteredElementCollector bushCol = new FilteredElementCollector(doc, doc.ActiveView.Id))
            {
                bushCol.OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance));
                var bushs = bushCol.Cast<FamilyInstance>().Where(b => b.Symbol.Name.Contains("套管")).ToList();
                foreach (var bush in bushs)
                {
                    XYZ centerPoint = (bush.Location as LocationPoint).Point;

                    ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
                    // 使用ReferenceIntersector进行射线与模型元素的交互检测
                    ReferenceIntersector referenceIntersector = new ReferenceIntersector(filter, FindReferenceTarget.Face, view3D);
                    referenceIntersector.FindReferencesInRevitLinks = true;
                    ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(centerPoint, XYZ.BasisZ);
                    double actualHeightDifference = 0;
                    if (referenceWithContext != null)
                    {

                        actualHeightDifference = referenceWithContext.Proximity;

                        JudgingHeightDifference(doc, view, inputValue, Math.Round(actualHeightDifference * 304.8, 1), bush);
                    }
                }
            }
        }
        /// <summary>
        /// 判断高差 是否等于制定值  不等则添加注释 
        /// </summary>
        public static void JudgingHeightDifference(Document doc, View view, string inputValue, double actualHeightDifference, MEPCurve mEPCurve)
        {
            //与指定值判断
            double inputHeightDifference;

            Double.TryParse(inputValue, out inputHeightDifference);
            if (inputHeightDifference != actualHeightDifference)
            {

                //不等 获取支管位置
                XYZ point = Util.GetMEPCurveCentrePoint(mEPCurve);
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                ICollection<Element> textNoteTypes = collector.OfClass(typeof(TextNoteType)).ToElements();
                TextNoteType textNoteType = null;
                foreach (TextNoteType textType in textNoteTypes)
                {
                    // 检查视图是否为剖面视图
                    // 获取 ViewFamilyType
                    //ViewFamilyType familyType = doc.GetElement(view.GetTypeId()) as ViewFamilyType;
                    if (textType?.FamilyName == "文字")
                    {
                        textNoteType = textType;
                        break;
                    }
                }
                //添加注释
                TextNote.Create(doc, view.Id, point, actualHeightDifference.ToString(), textNoteType.Id);
            }
        }
        public static void JudgingHeightDifference(Document doc, View view, string inputValue, double actualHeightDifference, FamilyInstance familyInstance)
        {
            //与指定值判断
            double inputHeightDifference;

            Double.TryParse(inputValue, out inputHeightDifference);
            if (inputHeightDifference != actualHeightDifference)
            {

                //不等 获取支管位置
                XYZ point = (familyInstance.Location as LocationPoint).Point;
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                ICollection<Element> textNoteTypes = collector.OfClass(typeof(TextNoteType)).ToElements();
                TextNoteType textNoteType = null;
                foreach (TextNoteType textType in textNoteTypes)
                {
                    // 检查视图是否为剖面视图
                    // 获取 ViewFamilyType
                    //ViewFamilyType familyType = doc.GetElement(view.GetTypeId()) as ViewFamilyType;
                    if (textType?.FamilyName == "文字")
                    {
                        textNoteType = textType;
                        break;
                    }
                }
                //添加注释
                TextNote.Create(doc, view.Id, point, actualHeightDifference.ToString(), textNoteType.Id);
            }
        }

        /// <summary>
        /// 删除所有的TextNote
        /// </summary>
        /// <param name="doc"></param>
        public static void DelAllTextNote(Document doc)
        {
            // 创建一个过滤器以获取所有 TextNote 元素
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> elements=collector.OfClass(typeof(TextNote)).ToElements();
            // 遍历所有 TextNote 元素，并删除它们
            foreach (Element element in elements)
            {
                doc.Delete(element.Id);
            }
        }

        public static bool IsSprayPipe(MEPCurve mEPCurve)
        {
            string pipeType = mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsValueString();
            if (pipeType.Contains("喷淋"))
            {
                return true;
            }
            return false;
        }
    }
}
