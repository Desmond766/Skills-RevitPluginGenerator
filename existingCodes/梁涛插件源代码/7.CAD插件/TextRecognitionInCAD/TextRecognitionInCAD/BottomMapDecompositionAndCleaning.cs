using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices.Filters;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace TextRecognitionInCAD
{
    public class BottomMapDecompositionAndCleaning
    {
        [CommandMethod("XP")]
        public void CleanBottomMap()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            PromptEntityOptions peo = new PromptEntityOptions("\n选择块参照:");
            peo.SetRejectMessage("\n必须选择块参照");
            peo.AddAllowedClass(typeof(BlockReference), true);

            PromptEntityResult per = ed.GetEntity(peo);
            if (per.Status != PromptStatus.OK)
                return;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockReference br =
                    tr.GetObject(per.ObjectId, OpenMode.ForRead) as BlockReference;

                BlockTableRecord space =
                    tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;

                List<Point2d> clipPts = GetXClipBoundary(br, tr);
                ed.WriteMessage("\n" + clipPts.Count);

                DBObjectCollection objs = new DBObjectCollection();
                br.Explode(objs);

                if (clipPts != null)
                {
                    Wipeout wipe = CreateWipeout(clipPts, br.BlockTransform);

                    space.AppendEntity(wipe);
                    tr.AddNewlyCreatedDBObject(wipe, true);
                }
                //if (clipPts != null && clipPts.Count > 3)
                //{
                //    Polyline clipBoundary = CreateClipPolyline(clipPts, br.BlockTransform);

                //    space.AppendEntity(clipBoundary);
                //    tr.AddNewlyCreatedDBObject(clipBoundary, true);
                //}


                //// 删除块参照裁剪范围内的元素
                //foreach (DBObject obj in objs)
                //{
                //    Entity ent = obj as Entity;
                //    if (ent == null) continue;

                //    if (clipPts == null)
                //    {
                //        space.AppendEntity(ent);
                //        tr.AddNewlyCreatedDBObject(ent, true);
                //        continue;
                //    }

                //    if (IsInsideClip(ent, clipPts, br.BlockTransform))
                //    {
                //        space.AppendEntity(ent);
                //        tr.AddNewlyCreatedDBObject(ent, true);
                //    }
                //    else
                //    {
                //        ent.Dispose();
                //    }
                //}

                //br.UpgradeOpen();
                //br.Erase();

                tr.Commit();
            }
        }
        Wipeout CreateWipeout(List<Point2d> pts, Matrix3d blockTransform)
        {
            Point2dCollection wcsPts = new Point2dCollection();

            foreach (Point2d pt in pts)
            {
                Point3d p = new Point3d(pt.X, pt.Y, 0);
                p = p.TransformBy(blockTransform);

                wcsPts.Add(new Point2d(p.X, p.Y));
            }

            Wipeout wipe = new Wipeout();
            wipe.SetFrom(wcsPts, new Vector3d(0, 0, 1));

            return wipe;
        }
        // 根据坐标点创建区域覆盖
        Polyline CreateClipPolyline(List<Point2d> pts, Matrix3d blockTransform)
        {
            Polyline pl = new Polyline();

            for (int i = 0; i < pts.Count; i++)
            {
                Point3d p = new Point3d(pts[i].X, pts[i].Y, 0);
                p = p.TransformBy(blockTransform);

                pl.AddVertexAt(i, new Point2d(p.X, p.Y), 0, 0, 0);
            }

            pl.Closed = true;

            return pl;
        }

        /// 获取XClip裁剪边界
        private List<Point2d> GetXClipBoundary(BlockReference br, Transaction tr)
        {
            if (br.ExtensionDictionary.IsNull)
                return null;

            DBDictionary extDict =
                tr.GetObject(br.ExtensionDictionary, OpenMode.ForRead) as DBDictionary;

            if (!extDict.Contains("ACAD_FILTER"))
                return null;

            DBDictionary filterDict =
                tr.GetObject(extDict.GetAt("ACAD_FILTER"), OpenMode.ForRead) as DBDictionary;

            if (!filterDict.Contains("SPATIAL"))
                return null;

            SpatialFilter filter =
                tr.GetObject(filterDict.GetAt("SPATIAL"), OpenMode.ForRead) as SpatialFilter;

            SpatialFilterDefinition def = filter.Definition;

            Point2dCollection pts = def.GetPoints();

            List<Point2d> result = new List<Point2d>();

            foreach (Point2d pt in pts)
                result.Add(pt);

            return result;
        }

        /// 判断实体是否在裁剪范围内
        private bool IsInsideClip(Entity ent, List<Point2d> polygon, Matrix3d blockTransform)
        {
            Extents3d? ext = ent.Bounds;
            if (ext == null)
                return false;

            Point3d center = new Point3d(
                (ext.Value.MinPoint.X + ext.Value.MaxPoint.X) / 2,
                (ext.Value.MinPoint.Y + ext.Value.MaxPoint.Y) / 2,
                0);

            center = center.TransformBy(blockTransform);

            Point2d pt = new Point2d(center.X, center.Y);

            return PointInPolygon(pt, polygon);
        }

        /// 点在多边形内判断
        private bool PointInPolygon(Point2d point, List<Point2d> polygon)
        {
            bool inside = false;
            int j = polygon.Count - 1;

            for (int i = 0; i < polygon.Count; i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                    (point.X < (polygon[j].X - polygon[i].X) *
                    (point.Y - polygon[i].Y) /
                    (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    inside = !inside;
                }

                j = i;
            }

            return inside;
        }
    }
}
