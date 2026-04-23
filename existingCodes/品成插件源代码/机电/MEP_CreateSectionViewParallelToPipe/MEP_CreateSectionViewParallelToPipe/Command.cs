using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_CreateSectionViewParallelToPipe
{
    [Transaction(TransactionMode.Manual)]
    public class Command:IExternalCommand
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

            BoundingBoxXYZ sectionBox = GetSectionViewParalleToPipe(mepcurve);
            
            // 创建平行于管线剖视图
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("创建平行于管线的剖面视图。");
                ViewSection.CreateSection(doc, vft.Id, sectionBox);
                tx.Commit();
            }
            
            return Result.Succeeded;
        }


        #region 获得平行于管线的范围框
        /// <summary>
        /// 获得平行于管线的范围框
        /// </summary>
        /// <param name="mepcurve">管线</param>
        /// <returns>范围框</returns>
        BoundingBoxXYZ GetSectionViewParalleToPipe(MEPCurve mepcurve)
        {
            LocationCurve lc = mepcurve.Location as LocationCurve;
            Line line = lc.Curve as Line;

            XYZ p = line.GetEndPoint(0);
            XYZ q = line.GetEndPoint(1);
            q = new XYZ(q.X, q.Y, p.Z);
            XYZ v = q - p;//修正z高度，避免transform坐标不正交，报错

            BoundingBoxXYZ bb = mepcurve.get_BoundingBox(null);


            double minZ = bb.Min.Z;
            double maxZ = bb.Max.Z;
            
            double w = v.GetLength();
            double h = maxZ - minZ;
            double d;
            try
            {
                d = mepcurve.Width;
            }
            catch (Exception)
            {
                d = mepcurve.Diameter;
            }
            double offset = 0.1 * w;
            
            XYZ min = new XYZ(-0.5*w, -18, -offset);
            XYZ max = new XYZ(0.5*w, h+5 , offset);

            XYZ midpoint = (p + q)/2;
            XYZ walldir = v.Normalize();
            XYZ up = XYZ.BasisZ;
            XYZ viewdir = walldir.CrossProduct(up);

            Transform t = Transform.Identity;
            t.Origin = midpoint;
            t.BasisX = walldir;
            t.BasisY = up;
            t.BasisZ = viewdir;

            BoundingBoxXYZ sectionBox = new BoundingBoxXYZ();
            if (null != t || Transform.Identity != t)
            {
                sectionBox.Transform = t;
                sectionBox.Min = min;
                sectionBox.Max = max; 
            }

            return sectionBox;
        }

        #endregion

    }
}
