using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Teigha.Runtime;
using Teigha.DatabaseServices;
using System.IO;
using System.Collections;
using Teigha.Geometry;
using static System.Net.Mime.MediaTypeNames;
using Curve = Autodesk.Revit.DB.Curve;

namespace FlippingBeam
{
    public class Class2
    {
        /// <summary>
        /// 取得链接cad的路径
        /// </summary>
        /// <param name="cadLinkTypeID"></param>
        /// <param name="revitDoc"></param>
        /// <returns></returns>
        public static string GetCADPath(ElementId cadLinkTypeID, Document revitDoc)
        {
            CADLinkType cadLinkType = revitDoc.GetElement(cadLinkTypeID) as CADLinkType;
            return ModelPathUtils.ConvertModelPathToUserVisiblePath(cadLinkType.GetExternalFileReference().GetAbsolutePath());
        }

        /// <summary>
        /// 取得CAD的文字信息
        /// </summary>
        /// <param name="dwgFile"></param>
        /// <returns></returns>
        public List<CADTextModel> GetCADTextInfo(string dwgFile)
        {
            List<CADTextModel> listCADModels = new List<CADTextModel>();
            using (new Services())
            {
                using (Database database = new Database(false, false))
                {
                    database.ReadDwgFile(dwgFile, FileShare.Read, true, "");
                    using (var trans = database.TransactionManager.StartTransaction())
                    {
                        using (BlockTable table = (BlockTable)database.BlockTableId.GetObject(OpenMode.ForRead))
                        {
                            using (SymbolTableEnumerator enumerator = table.GetEnumerator())
                            {
                                StringBuilder sb = new StringBuilder();
                                while (enumerator.MoveNext())
                                {
                                    using (BlockTableRecord record = (BlockTableRecord)enumerator.Current.GetObject(OpenMode.ForRead))
                                    {

                                        foreach (ObjectId id in record)
                                        {
                                            Entity entity = (Entity)id.GetObject(OpenMode.ForRead, false, false);
                                            CADTextModel model = new CADTextModel();
                                            switch (entity.GetRXClass().Name)
                                            {
                                                case "AcDbText":
                                                    Teigha.DatabaseServices.DBText text = (Teigha.DatabaseServices.DBText)entity;
                                                    model.Location = ConverCADPointToRevitPoint(text.Position);
                                                    model.Text = text.TextString;
                                                    model.Angel = text.Rotation;
                                                    model.Layer = text.Layer;
                                                    listCADModels.Add(model);
                                                    break;
                                                case "AcDbMText":
                                                    Teigha.DatabaseServices.MText mText = (Teigha.DatabaseServices.MText)entity;
                                                    model.Location = ConverCADPointToRevitPoint(mText.Location);
                                                    model.Text = mText.Text;
                                                    model.Angel = mText.Rotation;
                                                    model.Layer = mText.Layer;
                                                    listCADModels.Add(model);
                                                    break;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return listCADModels;
        }

        /// <summary>
        /// 取得cad的图层名称
        /// </summary>
        /// <param name="dwgFile"></param>
        /// <returns></returns>
        public static IList<string> GetLayerName(string dwgFile)
        {
            IList<string> cadLayerNames = new List<string>();
            using (new Services())
            {
                using (Database database = new Database(false, false))
                {
                    database.ReadDwgFile(dwgFile, FileShare.Read, true, "");
                    using (var trans = database.TransactionManager.StartTransaction())
                    {
                        using (LayerTable lt = (LayerTable)trans.GetObject(database.LayerTableId, OpenMode.ForRead))
                        {
                            foreach (ObjectId id in lt)
                            {
                                LayerTableRecord ltr = (LayerTableRecord)trans.GetObject(id, OpenMode.ForRead);
                                cadLayerNames.Add(ltr.Name);
                            }
                        }
                        trans.Commit();
                    }
                }
            }
            return cadLayerNames;
        }

        /// <summary>
        /// 取得CAD里的线，包括直线、多段线、圆曲线
        /// </summary>
        /// <param name="dwgFile"></param>
        /// <returns></returns>
        public List<CADGeometryModel> GetCADCurves(string dwgFile)
        {
            List<CADGeometryModel> listCADModels = new List<CADGeometryModel>();
            using (new Services())
            {
                using (Database database = new Database(false, false))
                {
                    database.ReadDwgFile(dwgFile, FileShare.Read, true, "");
                    using (var trans = database.TransactionManager.StartTransaction())
                    {
                        using (BlockTable table = (BlockTable)database.BlockTableId.GetObject(OpenMode.ForRead))
                        {
                            using (SymbolTableEnumerator enumerator = table.GetEnumerator())
                            {
                                StringBuilder sb = new StringBuilder();
                                while (enumerator.MoveNext())
                                {
                                    using (BlockTableRecord record = (BlockTableRecord)enumerator.Current.GetObject(OpenMode.ForRead))
                                    {

                                        foreach (ObjectId id in record)
                                        {
                                            Entity entity = (Entity)id.GetObject(OpenMode.ForRead, false, false);
                                            CADGeometryModel geoModel = new CADGeometryModel();
                                            switch (entity.GetRXClass().Name)
                                            {
                                                case "AcDbPolyline":
                                                    Teigha.DatabaseServices.Polyline pl = (Teigha.DatabaseServices.Polyline)entity;
                                                    IList<XYZ> listPoints = new List<XYZ>();
                                                    for (int i = 0; i < pl.NumberOfVertices; i++)
                                                    {
                                                        listPoints.Add(new XYZ(MillimetersToUnits(pl.GetPoint2dAt(i).X), MillimetersToUnits(pl.GetPoint2dAt(i).Y), 0));
                                                    }
                                                    PolyLine polyLine = PolyLine.Create(listPoints);
                                                    listCADModels.Add(new CADGeometryModel() { CadPolyLine = polyLine, LayerName = pl.Layer });
                                                    break;
                                                case "AcDbLine":
                                                    Teigha.DatabaseServices.Line line = (Teigha.DatabaseServices.Line)entity;
                                                    Autodesk.Revit.DB.Line revitLine = Autodesk.Revit.DB.Line.CreateBound(ConverCADPointToRevitPoint(line.StartPoint), ConverCADPointToRevitPoint(line.EndPoint));
                                                    listCADModels.Add(new CADGeometryModel() { CadCurve = revitLine as Autodesk.Revit.DB.Curve, LayerName = line.Layer });
                                                    break;
                                                case "AcDbArc":
                                                    Teigha.DatabaseServices.Arc arc = (Teigha.DatabaseServices.Arc)entity;
                                                    double enda, stara;
                                                    if (arc.StartAngle > arc.EndAngle)
                                                    {
                                                        enda = arc.StartAngle;
                                                        stara = arc.EndAngle;
                                                    }
                                                    else
                                                    {
                                                        enda = arc.EndAngle;
                                                        stara = arc.StartAngle;
                                                    }
                                                    Autodesk.Revit.DB.Arc revitArc = Autodesk.Revit.DB.Arc.Create(Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(new XYZ(arc.Normal.X, arc.Normal.Y, arc.Normal.Z),
                                                        ConverCADPointToRevitPoint(arc.Center)), MillimetersToUnits(arc.Radius), stara, enda);
                                                    listCADModels.Add(new CADGeometryModel() { CadCurve = revitArc as Autodesk.Revit.DB.Curve, LayerName = arc.Layer });
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return listCADModels;
        }

        /// <summary>
        /// 毫米转化成英寸
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double MillimetersToUnits(double value)
        {
            return UnitUtils.ConvertToInternalUnits(value, DisplayUnitType.DUT_MILLIMETERS);
        }

        /// <summary>
        /// 将CAD里的点转化为Revit里的点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private XYZ ConverCADPointToRevitPoint(Point3d point)
        {
            return new XYZ(MillimetersToUnits(point.X), MillimetersToUnits(point.Y), MillimetersToUnits(point.Z));
        }

        
    }
    public class CADTextModel
    {
        public XYZ Location { get; set; }
        public string Text { get; set; }
        public double Angel { get; set; }
        public string Layer { get; set; }
    }
    public class CADGeometryModel
    {
        public PolyLine CadPolyLine { get; set; }
        public Curve CadCurve { get; set; }
        public string LayerName { get; set; }
    }
}
