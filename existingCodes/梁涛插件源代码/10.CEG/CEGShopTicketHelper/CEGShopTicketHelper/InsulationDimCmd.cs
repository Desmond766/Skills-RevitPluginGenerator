using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class InsulationDimCmd : IExternalCommand
    {
        string InsulationFamilyName = "CEG - INSULATION - ";
        double dimensionOffset = 1.5;
        double textOffset = 1.3;
        double textVauleToOffset = 1.0;
        double textOverlapDis = 2.0;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //筛选正确的保温块
            List<Element> elemList = new List<Element>();
            foreach (ElementId id in sel.GetElementIds())
            {
                Element elem = doc.GetElement(id);
                if (elem.Name.StartsWith(InsulationFamilyName)
                    && elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DetailComponents)
                {
                    elemList.Add(elem);
                }
            }
            if (elemList.Count == 0)
            {
                message = "please select insulation item before running this tool!";
                return Result.Cancelled;
            }

            //尺寸标注
            using (Transaction trans = new Transaction(doc, "InsulationDim"))
            {
                trans.Start();

                Line line1 = null;
                Line line2 = null;
                ReferenceArray referenceArray1 = null;
                ReferenceArray referenceArray2 = null;
                Dimension dim1 = null;
                Dimension dim2 = null;

                foreach (Element elem in elemList)
                {
                    
                    XYZ maxPt = elem.get_BoundingBox(doc.ActiveView).Max;//左上角
                    XYZ minPt = elem.get_BoundingBox(doc.ActiveView).Min;//右下角
                    XYZ upDir = doc.ActiveView.UpDirection;
                    XYZ rightDir = doc.ActiveView.RightDirection;

                    //maxPt和minPt不固定
                    //因此根据中心点找到左上和右下
                    //默认up方向为DIM_WIDTH right方向为DIM_LENGTH
                    XYZ center = (maxPt + minPt) / 2.0;
                    double width = elem.GetParameters("DIM_WIDTH").First().AsDouble();
                    double length = elem.GetParameters("DIM_LENGTH").First().AsDouble();
                    maxPt = center - rightDir * length / 2.0 + upDir * width / 2.0;
                    minPt = center + rightDir * length / 2.0 - upDir * width / 2.0;

                    string symbolName = (elem as FamilyInstance).Symbol.Name;

                    //默认line1为上和line2为左
                    line1 = Line.CreateUnbound(maxPt + upDir * dimensionOffset, rightDir);
                    line2 = Line.CreateUnbound(maxPt - rightDir * dimensionOffset, upDir);
                    //需要更新方向的
                    if (symbolName == InsulationFamilyName + "C"
                        || symbolName == InsulationFamilyName + "E"
                        || symbolName == InsulationFamilyName + "I")
                    {
                        line1 = Line.CreateUnbound(minPt - upDir * dimensionOffset, rightDir);
                    }
                    if (symbolName == InsulationFamilyName + "D"
                        || symbolName == InsulationFamilyName + "E"
                        || symbolName == InsulationFamilyName + "G")
                    {
                        line2 = Line.CreateUnbound(minPt + rightDir * dimensionOffset, upDir);
                    }
                    //找到referenceArray
                    referenceArray1 = GetReferenceArrayByDirection(elem, doc.ActiveView, upDir);
                    referenceArray2 = GetReferenceArrayByDirection(elem, doc.ActiveView, rightDir);
                    //更新referenceArray,FGHI排除0"
                    if (symbolName == InsulationFamilyName + "F" 
                        || symbolName == InsulationFamilyName + "G")
                    {
                        ReferenceArray referenceArrayNew = new ReferenceArray();
                        referenceArrayNew.Append(referenceArray1.get_Item(0));
                        referenceArrayNew.Append(referenceArray1.get_Item(1));
                        referenceArrayNew.Append(referenceArray1.get_Item(2));
                        referenceArray1 = referenceArrayNew;
                    }
                    if (symbolName == InsulationFamilyName + "H"
                        || symbolName == InsulationFamilyName + "I")
                    {
                        ReferenceArray referenceArrayNew = new ReferenceArray();
                        referenceArrayNew.Append(referenceArray2.get_Item(0));
                        referenceArrayNew.Append(referenceArray2.get_Item(1));
                        referenceArrayNew.Append(referenceArray2.get_Item(2));
                        referenceArray2 = referenceArrayNew;
                    }
                    //创建尺寸
                    dim1 = doc.Create.NewDimension(doc.ActiveView, line1, referenceArray1);
                    dim2 = doc.Create.NewDimension(doc.ActiveView, line2, referenceArray2);
                    AdjustDimensionTextPos(dim1);
                    AdjustDimensionTextPos(dim2);
                }
                trans.Commit();
            }
            
            return Result.Succeeded;
        }

        //https://adndevblog.typepad.com/aec/2015/05/revitapi-create-dimension-on-detail-component.html
        private ReferenceArray GetReferenceArrayByDirection(Element element, View view, XYZ dir)
        {
            Transform transform = (element as FamilyInstance).GetTransform();
            ReferenceArray referenceArray = new ReferenceArray();

            Options options = new Options();
            options.ComputeReferences = true;
            if (view != null)
                options.View = view;
            else
                options.DetailLevel = ViewDetailLevel.Fine;
            var geoElem = element.get_Geometry(options);
            foreach (var item in geoElem)
            {
                Line line = item as Line;
                if (line != null)
                {
                    //in this case, code will never be executed to here
                }
                else
                {
                    GeometryInstance geoInst = item as GeometryInstance;
                    if (geoInst != null)
                    {
                        GeometryElement geoElemTmp =
                            geoInst.GetSymbolGeometry();
                        foreach (GeometryObject geomObjTmp in geoElemTmp)
                        {
                            Line line2 = geomObjTmp as Line;
                            if (line2 != null)
                            {
                                //check if it is what you want
                                if (transform.OfVector(line2.Direction).IsAlmostEqualTo(dir)
                                || transform.OfVector(line2.Direction).Negate().IsAlmostEqualTo(dir))
                                {
                                    referenceArray.Append(line2.Reference);
                                }
                            }
                        }
                    }
                }
            }
            return referenceArray;
        }

        private void AdjustDimensionTextPos(Dimension dim)
        {
            if (dim.Segments.Size == 2)
            {
                DimensionSegment dimSeg1 = dim.Segments.get_Item(0);
                DimensionSegment dimSeg2 = dim.Segments.get_Item(1);
                XYZ dir = dimSeg1.TextPosition - dimSeg2.TextPosition;
                if (dimSeg1.Value < textVauleToOffset && dir.GetLength() < textOverlapDis)
                {
                    dimSeg1.TextPosition += dir.Normalize() * textOffset;
                }
                if (dimSeg2.Value < textVauleToOffset && dir.GetLength() < textOverlapDis)
                {
                    dimSeg2.TextPosition += dir.Normalize().Negate() * textOffset;
                }
            }
            if (dim.Segments.Size == 3)
            {
                DimensionSegment dimSeg1 = dim.Segments.get_Item(0);
                DimensionSegment dimSeg2 = dim.Segments.get_Item(1);
                DimensionSegment dimSeg3 = dim.Segments.get_Item(2);
                XYZ dir1 = dimSeg1.TextPosition - dimSeg2.TextPosition;
                XYZ dir2 = dimSeg2.TextPosition - dimSeg3.TextPosition;
                if (dimSeg1.Value < textVauleToOffset && dir1.GetLength() < textOverlapDis)
                {
                    dimSeg1.TextPosition += dir1.Normalize() * textOffset;
                }
                if (dimSeg2.Value < textVauleToOffset && dir1.GetLength() < textOverlapDis)
                {
                    dimSeg2.TextPosition += dir1.Normalize().Negate() * textOffset;
                }
                if (dimSeg2.Value < textVauleToOffset && dir2.GetLength() < textOverlapDis)
                {
                    dimSeg2.TextPosition += dir2.Normalize() * textOffset;
                }
                if (dimSeg3.Value < textVauleToOffset && dir2.GetLength() < textOverlapDis)
                {
                    dimSeg3.TextPosition += dir2.Normalize().Negate() * textOffset;
                }
            }
        }

    }
}
