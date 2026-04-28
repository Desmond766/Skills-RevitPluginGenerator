using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Line = Autodesk.Revit.DB.Line;

namespace ParameterizedMEPCurveLayout
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class ProfileFrame
    {
        /// <summary>
        /// 创建剖面框
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="mEPCurves"></param>
        /// <param name="structDistance"></param>
        /// <returns></returns>
        public static ViewSection Create(Document doc, IList<MEPCurve> mEPCurves, string structDistance)
        {
            //TaskDialog.Show("Asda","ASdA");
            ViewSection sectionView;
            //对选中的管线进行排序
            using (Transaction tran = new Transaction(doc, "创建剖面框"))
            {
                tran.Start();
                // 创建剖面视图
                // 获取剖面类型
                ElementId viewFamilyTypeId = null;
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                ICollection<Element> viewTypes = collector.OfClass(typeof(ViewFamilyType)).ToElements();
                foreach (ViewFamilyType view in viewTypes)
                {
                    // 检查视图是否为剖面视图
                    // 获取 ViewFamilyType
                    //ViewFamilyType familyType = doc.GetElement(view.GetTypeId()) as ViewFamilyType;
                    if (view?.FamilyName == "剖面")
                    {
                        viewFamilyTypeId = view.Id;
                        break;
                    }

                }
                mEPCurves = mEPCurves.OrderByDescending(x => Tools.GetMEPCurveCentrePoint(x).Y).ToList();
                BoundingBoxXYZ boundingBoxXYZ = new BoundingBoxXYZ();

                MEPCurve mEP = mEPCurves[(int)Math.Floor((decimal)mEPCurves.Count / 2)];
                double maxZ = Tools.GetMEPCurveCentrePoint(mEP).Z;
                double minZ = Tools.GetMEPCurveCentrePoint(mEP).Z;
                GetBeamBottomHeigth(doc, mEP, ref minZ, ref maxZ);

                if (double.Parse(structDistance) == 0)
                {
                    TaskDialog.Show("提示", "结构间距为0");
                }

                if (Tools.IsHorizontal(mEP))
                {
                    XYZ firstPoint = Tools.GetMEPCurveCentrePoint(mEPCurves.OrderByDescending(x => Tools.GetMEPCurveCentrePoint(x).Y).ToList().First());
                    XYZ minPoint = new XYZ(firstPoint.Y - double.Parse(structDistance) / 304.8 + mEPCurves.First().ParameterWidth(), minZ, firstPoint.X);

                    XYZ maxPoint = new XYZ(firstPoint.Y + mEPCurves.First().ParameterWidth(), maxZ, firstPoint.X + (150 / 304.8));
                    //TaskDialog.Show("asdas", minPoint.ToString() + "\n" + maxPoint.ToString());
                    //TaskDialog.Show("asdas", firstPoint.ToString());
                    //坐标转换
                    XYZ newViewDirection = new XYZ(0, 1, 0);
                    XYZ upDirection = new XYZ(0, 0, 1);
                    boundingBoxXYZ.Min = minPoint;
                    boundingBoxXYZ.Max = maxPoint;
                    Transform transform = Transform.Identity;
                    transform.BasisX = newViewDirection.Normalize();
                    transform.BasisY = upDirection.Normalize();
                    transform.BasisZ = newViewDirection.CrossProduct(upDirection).Normalize();
                    boundingBoxXYZ.Transform = transform;
                }
                else
                {
                    XYZ firstPoint = Tools.GetMEPCurveCentrePoint(mEPCurves.OrderBy(x => Tools.GetMEPCurveCentrePoint(x).X).ToList().First());
                    XYZ minPoint = new XYZ(-firstPoint.X - double.Parse(structDistance) / 304.8 + mEPCurves.First().ParameterWidth(), minZ, firstPoint.Y);

                    XYZ maxPoint = new XYZ(-firstPoint.X + mEPCurves.First().ParameterWidth(), maxZ, firstPoint.Y + (150 / 304.8));
                    //MessageBox.Show(minPoint.ToString());
                    //MessageBox.Show(maxPoint.ToString());
                    //坐标转换
                    XYZ newViewDirection = new XYZ(-1, 0, 0);
                    XYZ upDirection = new XYZ(0, 0, 1);
                    boundingBoxXYZ.Min = minPoint;
                    boundingBoxXYZ.Max = maxPoint;
                    Transform transform = Transform.Identity;
                    transform.BasisX = newViewDirection.Normalize();
                    transform.BasisY = upDirection.Normalize();
                    //transform.BasisZ = newViewDirection.CrossProduct(upDirection).Normalize();
                    transform.BasisZ = new XYZ(0, 1, 0);

                    boundingBoxXYZ.Transform = transform;
                }



                //创建
                sectionView = ViewSection.CreateSection(doc, viewFamilyTypeId, boundingBoxXYZ);
                
                tran.Commit();
            }
            return sectionView;
        }

        /// <summary>
        /// 获取结构净距
        /// </summary>
        public static double GetStructuralClearance(Document doc, IList<MEPCurve> mEPCurves)
        {
            MEPCurve mEP = mEPCurves[(int)Math.Floor((decimal)mEPCurves.Count / 2)];
            XYZ centerPoint = Tools.GetMEPCurveCentrePoint(mEP);
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
            // 创建一条射线，方向为Y轴方向及-Y轴方向

            // 进行射线检测，获取第一个与射线相交的结构柱元素
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            // 使用ReferenceIntersector进行射线与模型元素的交互检测
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(filter, FindReferenceTarget.Face, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;

            XYZ direction;
            if (Tools.IsHorizontal(mEP))
            {
                direction = XYZ.BasisY;
            }
            else
            {
                direction = XYZ.BasisX;
            }
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(centerPoint, direction);
            double top = 0;
            if (referenceWithContext != null)
            {
                top = referenceWithContext.Proximity;
            }

            referenceWithContext = referenceIntersector.FindNearest(centerPoint, -direction);
            double bot = 0;
            if (referenceWithContext != null)
            {
                bot = referenceWithContext.Proximity;
            }
            if (top == 0 || bot == 0)
            {
                return 0;
            }
            return Math.Round((top + bot) * 304.8);
        }

        /// <summary>
        /// 获取梁底净高
        /// </summary>
        public static void GetBeamBottomHeigth(Document doc, MEPCurve mEP, ref double minZ, ref double maxZ)
        {
            XYZ centerPoint = Tools.GetMEPCurveCentrePoint(mEP);
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
            // 创建一条射线，方向为Y轴方向及-Y轴方向

            // 进行射线检测，获取第一个与射线相交的结构柱元素
            ElementCategoryFilter floorFilter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
            // 使用ReferenceIntersector进行射线与模型元素的交互检测
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorFilter, FindReferenceTarget.Face, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(centerPoint, -XYZ.BasisZ);
            double bot = 0;
            if (referenceWithContext != null)
            {
                //TaskDialog.Show("asdasd", doc.GetElement(referenceWithContext.GetReference()).Id.ToString());
                bot = referenceWithContext.Proximity;
            }

            ElementCategoryFilter framingFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
            ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(framingFilter, FindReferenceTarget.Face, view3D);
            referenceIntersector1.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(centerPoint, XYZ.BasisZ);
            double top = 0;
            if (referenceWithContext1 != null)
            {
                Element elem = doc.GetElement(referenceWithContext1.GetReference());
                //BoundingBoxXYZ boundingBox = elem.get_BoundingBox(view3D);
                //XYZ topXYZ = boundingBox.Min;
                top = referenceWithContext1.Proximity;
                //maxZ = topXYZ.Z;
            }
            if (top == 0)
            {
                TaskDialog.Show("提示", "顶部无梁");
            }
            maxZ += top;
            minZ -= bot;
        }
    }
}
