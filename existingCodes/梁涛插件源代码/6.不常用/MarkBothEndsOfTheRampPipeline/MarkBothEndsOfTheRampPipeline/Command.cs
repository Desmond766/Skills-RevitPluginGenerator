using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkBothEndsOfTheRampPipeline
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            while (true)
            {
                Reference reference;
                XYZ point1;
                XYZ point2;
                try
                {
                    reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new PipeFilter(), "选择一根管道");
                    point1 = reference.GlobalPoint;
                    point2 = uIDoc.Selection.PickPoint("选择布置方向");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "结束布置");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }                
                //Pipe pipe = doc.GetElement(reference) as Pipe;
                Element element = doc.GetElement(reference);
                Line line = (element.Location as LocationCurve).Curve as Line;
                XYZ sP = line.GetEndPoint(0);
                XYZ eP = line.GetEndPoint(1);


                //判断引线方向
                XYZ crossDirection = line.Direction.CrossProduct(XYZ.BasisZ);
                if ((point2 + crossDirection * 1.0).DistanceTo(point1) < point2.DistanceTo(point1))
                {
                    crossDirection = crossDirection.Negate();
                }

                //根据名称找标签族
                //水管
                var tagFamilyName_RightAlign_ST = "PC_水管标记_右对齐_起点";
                var tagFamilyName_LeftAlign_ST = "PC_水管标记_左对齐_起点";
                ElementId tagTypeId_RightAlign_ST = null;
                ElementId tagTypeId_LeftAlign_ST = null;
                var tagFamilyName_RightAlign_ET = "PC_水管标记_右对齐_端点";
                var tagFamilyName_LeftAlign_ET = "PC_水管标记_左对齐_端点";
                ElementId tagTypeId_RightAlign_ET = null;
                ElementId tagTypeId_LeftAlign_ET = null;

                //燃气管
                var tagFamilyName_RightAlign_RST = "PC_燃气管标记_右对齐_起点";
                var tagFamilyName_LeftAlign_RST = "PC_燃气管标记_左对齐_起点";
                ElementId tagTypeId_RightAlign_RST = null;
                ElementId tagTypeId_LeftAlign_RST = null;
                var tagFamilyName_RightAlign_RET = "PC_燃气管标记_右对齐_端点";
                var tagFamilyName_LeftAlign_RET = "PC_燃气管标记_左对齐_端点";
                ElementId tagTypeId_RightAlign_RET = null;
                ElementId tagTypeId_LeftAlign_RET = null;

                //线管
                //var tagFamilyName_RightAlign_XST = "PC_水管标记_右对齐_起点";
                var tagFamilyName_LeftAlign_XST = "PC_线管标记_左对齐_起点";
                //ElementId tagTypeId_RightAlign_XST = null;
                ElementId tagTypeId_LeftAlign_XST = null;
                //var tagFamilyName_RightAlign_XET = "PC_水管标记_右对齐_端点";
                var tagFamilyName_LeftAlign_XET = "PC_线管标记_左对齐_端点";
                //ElementId tagTypeId_RightAlign_XET = null;
                ElementId tagTypeId_LeftAlign_XET = null;



                try
                {
                    //水管
                    tagTypeId_RightAlign_ST = FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_ST);
                    tagTypeId_LeftAlign_ST = FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_ST);
                    tagTypeId_RightAlign_ET = FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_ET);
                    tagTypeId_LeftAlign_ET = FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_ET);

                    //燃气管
                    tagTypeId_RightAlign_RST = FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_RST);
                    tagTypeId_LeftAlign_RST = FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_RST);
                    tagTypeId_RightAlign_RET = FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_RET);
                    tagTypeId_LeftAlign_RET = FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_RET);

                    //线管
                    //tagTypeId_RightAlign_XST =  FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_XST);
                    tagTypeId_LeftAlign_XST = FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_XST);
                    //tagTypeId_RightAlign_XET =  FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_XET);
                    tagTypeId_LeftAlign_XET = FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_XET);


                }
                catch
                {
                    TaskDialog.Show("提示", "检查是否载入品成标记族");
                    return Result.Cancelled;
                }
                ElementId sTagTypeId = null;
                ElementId eTagTypeId = null;

                //根据名称找族
                var arrowDetialFamilyName = "PC_标记_实心点";
                FamilySymbol arrowDetialSymbol = null;
                try
                {
                    arrowDetialSymbol = doc.GetElement(FindTypeIdByFamilyName(doc, arrowDetialFamilyName)) as FamilySymbol;
                }
                catch (Exception)
                {
                    TaskDialog.Show("提示", "检查是否载入品成标记点");
                    return Result.Cancelled;
                }

                Transaction t = new Transaction(doc, "坡道管线两边标注");
                t.Start();
                IndependentTag startTag = IndependentTag.Create(doc, doc.ActiveView.Id, reference, true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, XYZ.Zero);
                IndependentTag endTag = IndependentTag.Create(doc, doc.ActiveView.Id, reference, true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, XYZ.Zero);
                startTag.TagHeadPosition = line.GetEndPoint(0) + crossDirection * (1220 / 304.8);
                endTag.TagHeadPosition = line.GetEndPoint(1) + crossDirection * (1220 / 304.8);
                sTagTypeId = tagTypeId_LeftAlign_ST;
                eTagTypeId = tagTypeId_RightAlign_ET;

                double newZ = sP.Z <= eP.Z ? sP.Z : eP.Z;
                Line newLine = Line.CreateBound(new XYZ(sP.X, sP.Y, newZ), new XYZ(eP.X, eP.Y, newZ));
                //if (newLine.Direction.Normalize().IsAlmostEqualTo(XYZ.BasisX))
                //{
                //    sTagTypeId = tagTypeId_RightAlign_ST;
                //    eTagTypeId = tagTypeId_LeftAlign_ET;
                //}
                //else if (newLine.Direction.Normalize().IsAlmostEqualTo(XYZ.BasisX.Negate()))
                //{
                //    sTagTypeId = tagTypeId_LeftAlign_ST;
                //    eTagTypeId = tagTypeId_RightAlign_ET;
                //}
                //else if (newLine.Direction.Normalize().IsAlmostEqualTo(XYZ.BasisY))
                //{
                //    sTagTypeId = tagTypeId_RightAlign_ST;
                //    eTagTypeId = tagTypeId_LeftAlign_ET;
                //}
                //else if (newLine.Direction.Normalize().IsAlmostEqualTo(XYZ.BasisY.Negate()))
                //{
                //    sTagTypeId = tagTypeId_LeftAlign_ST;
                //    eTagTypeId = tagTypeId_RightAlign_ET;
                //}

                bool isRotaToXGreaterThan45;
                double angleToX = newLine.Direction.AngleTo(XYZ.BasisX);
                if (angleToX > Math.PI / 2) angleToX = Math.Abs(angleToX - Math.PI);
                //TaskDialog.Show("ww", (angleToX / Math.PI * 180) .ToString());
                if (angleToX > Math.PI / 4)
                {
                    isRotaToXGreaterThan45 = true;
                }
                else
                {
                    isRotaToXGreaterThan45 = false;
                }
                double slope = CalculateSlope(sP.X, sP.Y, eP.X, eP.Y);
                if (IsSlopeInRange(slope) && element is Pipe pipe && !IsErrorPipeline(newLine))
                {
                    //TaskDialog.Show("ll", newLine.Direction.AngleTo(XYZ.BasisY).ToString());
                    if (sP.Y > eP.Y)
                    {
                        if (pipe.LookupParameter("系统类型").AsValueString().Contains("给水"))
                        {
                            sTagTypeId = tagTypeId_RightAlign_ST;
                            eTagTypeId = tagTypeId_LeftAlign_ET;
                        }
                        else if (pipe.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                        {
                            sTagTypeId = tagTypeId_RightAlign_RST;
                            eTagTypeId = tagTypeId_LeftAlign_RET;
                        }
                        
                    }
                    else
                    {
                        if (pipe.LookupParameter("系统类型").AsValueString().Contains("给水"))
                        {
                            sTagTypeId = tagTypeId_LeftAlign_ST;
                            eTagTypeId = tagTypeId_RightAlign_ET;
                        }
                        else if (pipe.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                        {
                            sTagTypeId = tagTypeId_LeftAlign_RST;
                            eTagTypeId = tagTypeId_RightAlign_RET;
                        }
                        
                    }
                }
                else
                if (isRotaToXGreaterThan45 && element is Pipe)
                {
                    if (sP.Y > eP.Y)
                    {
                        if (element.LookupParameter("系统类型").AsValueString().Contains("给水"))
                        {
                            sTagTypeId = tagTypeId_LeftAlign_ST;
                            eTagTypeId = tagTypeId_RightAlign_ET;
                        }
                        else if (element.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                        {
                            sTagTypeId = tagTypeId_LeftAlign_RST;
                            eTagTypeId = tagTypeId_RightAlign_RET;
                        }
                    }
                    else
                    {
                        if (element.LookupParameter("系统类型").AsValueString().Contains("给水"))
                        {
                            sTagTypeId = tagTypeId_RightAlign_ST;
                            eTagTypeId = tagTypeId_LeftAlign_ET;
                        }
                        else if (element.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                        {
                            sTagTypeId = tagTypeId_RightAlign_RST;
                            eTagTypeId = tagTypeId_LeftAlign_RET;
                        }
                    }
                }
                else if (element is Pipe)
                {
                    if (sP.X > eP.X)
                    {
                        if (element.LookupParameter("系统类型").AsValueString().Contains("给水"))
                        {
                            sTagTypeId = tagTypeId_LeftAlign_ST;
                            eTagTypeId = tagTypeId_RightAlign_ET;
                        }
                        else if (element.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                        {
                            sTagTypeId = tagTypeId_LeftAlign_RST;
                            eTagTypeId = tagTypeId_RightAlign_RET;
                        }
                    }
                    else
                    {
                        if (element.LookupParameter("系统类型").AsValueString().Contains("给水"))
                        {
                            sTagTypeId = tagTypeId_RightAlign_ST;
                            eTagTypeId = tagTypeId_LeftAlign_ET;
                        }
                        else if (element.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                        {
                            sTagTypeId = tagTypeId_RightAlign_RST;
                            eTagTypeId = tagTypeId_LeftAlign_RET;
                        }
                    }
                }
                if (element is Conduit)
                {
                    sTagTypeId = tagTypeId_LeftAlign_XST;
                    eTagTypeId = tagTypeId_LeftAlign_XET;
                }


                //替换族类型
                if (startTag.GetTypeId() != sTagTypeId)
                {
                    startTag.ChangeTypeId(sTagTypeId);
                }
                if (endTag.GetTypeId() != eTagTypeId)
                {
                    endTag.ChangeTypeId(eTagTypeId);
                }
                t.Commit();
            }
            return Result.Succeeded;
        }
        #region 根据族名称找族下某类型名称ID
        /// <summary>
        /// 根据族名称找族下某类型名称ID
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns>指定族名称下的第一个族类型</returns>
        public static ElementId FindTypeIdByFamilyName(Document doc, string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

        }

        #endregion
        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion
        static double CalculateSlope(double x1, double y1, double x2, double y2)
        {
            // 检查垂直线情况，防止除以零
            if (x2 == x1)
            {
                // 对于垂直线，斜率为正无穷大或负无穷大
                return double.PositiveInfinity;
            }

            return (y2 - y1) / (x2 - x1);
        }

        static bool IsSlopeInRange(double slope)
        {
            // 检查斜率是否在 (-∞, -1] 范围内
            return slope <= -1;
        }

        public bool IsErrorPipeline(Line line)
        {
            if (line.Direction.AngleTo(XYZ.BasisX) < 0.000001 ||
                line.Direction.AngleTo(XYZ.BasisX.Negate()) < 0.000001 ||
                line.Direction.AngleTo(XYZ.BasisY) < 0.000001 ||
                line.Direction.AngleTo(XYZ.BasisY.Negate()) < 0.000001
                ) return true;
            return false;
        }
    }

    public class PipeFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Pipe pipe)
            {
                try
                {
                    if (pipe.LookupParameter("系统类型").AsValueString().Contains("给水") ||
                        pipe.LookupParameter("系统类型").AsValueString().Contains("燃气"))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else if (elem is Conduit conduit)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
