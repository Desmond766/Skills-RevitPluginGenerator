using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_CreateSectionViewPerpendicularToPipe
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            #region 判断加密

            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            ////获取选中管线
            Selection sel = uidoc.Selection;
            Reference r = sel.PickObject(ObjectType.Element);
            Element e = doc.GetElement(r);
            MEPCurve mepcurve = e as MEPCurve;

            //确认是直线管线
            LocationCurve lc = mepcurve.Location as LocationCurve;
            Line line = lc.Curve as Line;
            if (null == line)
            {
                message = "无法获取直管线。";
                return Result.Failed;
            }

            // 获取视图类型对象
            ViewFamilyType vft = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault<ViewFamilyType>(x => ViewFamily.Section == x.ViewFamily);

            BoundingBoxXYZ sectionBox = GetSectionViewPerpendiculatToPipe(mepcurve);


            // 创建垂直于管线剖视图
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("创建垂直于管线的剖面视图。");
                ViewSection.CreateSection(doc, vft.Id, sectionBox);
                tx.Commit();
            }

            return Result.Succeeded;
        }

        #region 获得垂直于管线的范围框
        /// <summary>
        /// 获得垂直于管线的范围框
        /// </summary>
        /// <param name="mepcurve">管线</param>
        /// <returns>范围框</returns>
        BoundingBoxXYZ GetSectionViewPerpendiculatToPipe(MEPCurve mepcurve)
        {
            LocationCurve lc = mepcurve.Location as LocationCurve;
            Line line = lc.Curve as Line;

            XYZ p = line.GetEndPoint(0);
            XYZ q = line.GetEndPoint(1);
            q = new XYZ(q.X, q.Y, p.Z);
            Line l=Line.CreateBound(p,q);

            // 使用 0.5 和 "true" 保证 Transform 的原点在管线中心点且向量是规范化的。

            Transform curveTransform = l.ComputeDerivatives(0.5, true);

            // Transform 包含了位置线的中心点和正切线，这样我们就能获取其位于 XY 平面的法线了。

            XYZ origin = curveTransform.Origin;
            XYZ viewdir = curveTransform.BasisX.Normalize();
            XYZ up = XYZ.BasisZ;
            XYZ right = up.CrossProduct(viewdir);

            // 设置视图 Transform，假设墙体是垂直方向的。对于非垂直方向墙体（例如：有斜坡的地板），我们需要其表面的法线

            Transform transform = Transform.Identity;
            transform.Origin = origin;
            transform.BasisX = right;
            transform.BasisY = up;
            transform.BasisZ = viewdir;

            BoundingBoxXYZ sectionBox = new BoundingBoxXYZ();
            sectionBox.Transform = transform;

            // Min & Max X 值定义位于墙体两侧的剖线长度；
            // Max Y 是剖视区域的高度；
            // Max Z (5) 是远端剪裁偏移
            double d;
            try
            {
                d = mepcurve.Width;
            }
            catch (Exception)
            {
                 d = mepcurve.Diameter;
            }

            BoundingBoxXYZ bb = mepcurve.get_BoundingBox(null);
            double minZ = bb.Min.Z;
            double maxZ = bb.Max.Z;
            double h = maxZ - minZ;

            sectionBox.Min = new XYZ(-4 * d, -20, 0);
            sectionBox.Max = new XYZ(4 * d, h + 10, 5);

            return sectionBox;
        }

        #endregion

    }
}
