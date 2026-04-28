using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace SplitSubSlab
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //视图判断
            if (!(doc.ActiveView is View3D))
            {
                message = "请在三维视图下运行！";
                return Result.Cancelled;
            }

            ////洞口多loop情况
            //Reference reference = sel.PickObject(ObjectType.Element, new OpeningSelectFilter());
            //Opening ops = doc.GetElement(reference) as Opening;
            //List<List<Curve>> loops = DivideBoundaryLoops(ops.BoundaryCurves);
            //TaskDialog.Show("R", loops.Count().ToString());

            while (true)
            {
                try
                {
                    //选择洞口
                    Reference reference = sel.PickObject(ObjectType.Element, new OpeningSelectFilter());
                    Opening ops = doc.GetElement(reference) as Opening;

                    //宿主板
                    Floor hostFloor = ops.Host as Floor;
                    ElementId levelId = hostFloor.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId();
                    Level level = doc.GetElement(levelId) as Level;
                    FloorType floorType = hostFloor.FloorType;
                    double baseOffset = hostFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();

                    List<XYZ> vertexs = new List<XYZ>();

                    //CurveArray profile = ops.BoundaryCurves;
                    //洞口的BoundaryCurves返回的CurveArray顺序打乱了，需要重排
                    //Q:Autodesk Revit Argument Exception, The curves do not form a closed contiguous loop
                    //A:Your curves are probably not sorted into the correct contiguous order.
                    //https://stackoverflow.com/questions/48271079/autodesk-revit-argument-exception-the-curves-do-not-form-a-closed-contiguous-lo
                    //https://github.com/jeremytammik/RoomEditorApp/blob/master/RoomEditorApp/ContiguousCurveSorter.cs
                    List<Curve> curves = new List<Curve>();
                    foreach (Curve item in ops.BoundaryCurves)
                    {
                        curves.Add(item);
                    }
                    CurveUtils.SortCurvesContiguous(doc.Application.Create, curves, false);
                    CurveArray profile = uiapp.Application.Create.NewCurveArray();
                    foreach (Curve item in curves)
                    {
                        //收集顶点
                        vertexs.Add(item.GetEndPoint(0));
                        profile.Append(item.CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ * 10.0)));
                    }

                    //创建板
                    Floor newFloor = null;
                    using (Transaction tran = new Transaction(doc, "SubSlab_Create"))
                    {
                        tran.Start();
                        newFloor = doc.Create.NewFloor(profile, floorType, level, false, XYZ.BasisZ);
                        newFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).Set(baseOffset);
                        tran.Commit();
                    }

                    //如果宿主板是平的，已经可以了
                    if (null != hostFloor.SlabShapeEditor)
                    {
                        if (hostFloor.SlabShapeEditor.SlabShapeVertices.Size == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    //激活修改子图元
                    SlabShapeEditor editor = null;
                    using (Transaction tran = new Transaction(doc, "SubSlab_Enable"))
                    {
                        tran.Start();
                        editor = newFloor.SlabShapeEditor;
                        editor.Enable();
                        tran.Commit();
                    }

                    //计算每个顶点需要偏移的高度
                    List<double> offsetList = GetOffsetList(doc, editor, hostFloor);

                    //修改子图元
                    using (Transaction tran = new Transaction(doc, "SubSlab_Edit"))
                    {
                        tran.Start();
                        for (int i = 0; i < editor.SlabShapeVertices.Size; i++)
                        {
                            editor.ModifySubElement(editor.SlabShapeVertices.get_Item(i), offsetList[i]);
                        }
                        tran.Commit();
                    }
                }
                //ESC退出布置
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "取消选择，程序结束");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }
            }

            return Result.Succeeded;
        }

        #region 获得子图元偏移高度
        private List<double> GetOffsetList(Document doc, SlabShapeEditor editor, Floor hostFloor)
        {
            //向上偏移一个初始高度
            double moveUp = 10000.0;
            List<double> offsetList = new List<double>();
            foreach (SlabShapeVertex item in editor.SlabShapeVertices)
            {
                XYZ point = item.Position + XYZ.BasisZ * moveUp;
                XYZ reflectPoint = GetReflectPoint(
                    doc.ActiveView as View3D,
                    point,
                    XYZ.BasisZ.Negate(),
                    hostFloor);
                if (null != reflectPoint)
                {
                    offsetList.Add(moveUp - reflectPoint.DistanceTo(point));
                }
                else
                {
                    offsetList.Add(0.0);
                }
            }
            return offsetList;
        }
        #endregion

        #region 指定一个点及方向，返回反射点
        /// <summary>
        /// 指定一个点及方向，返回反射点
        /// </summary>
        /// <param name="view">当前文档</param>
        /// <param name="point">指定点</param>
        /// <param name="direction">指定方向</param>
        /// <returns>反射点</returns>
        private XYZ GetReflectPoint(View3D view, XYZ point, XYZ direction, Floor hostFloor)
        {
            XYZ offsetPoint = point + direction.Normalize() * 0.00001;

            //List<ElementFilter> filterList = new List<ElementFilter>();
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            //LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);

            ReferenceIntersector referenceIntersector = new ReferenceIntersector(hostFloor.Id, FindReferenceTarget.All, view);
            //此处存在BUG，仅仅将RvtLink当做一类构件进行判断，而不是进入RvtLink去判断文件中的各个类
            //详见Using ReferenceIntersector in Linked Files
            //http://thebuildingcoder.typepad.com/blog/2015/07/using-referenceintersector-in-linked-files.html
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(offsetPoint, direction);
            return null == referenceWithContext ? null : referenceWithContext.GetReference().GlobalPoint;
        }
        #endregion
        
        private List<List<Curve>> DivideBoundaryLoops(CurveArray curves)
        {
            List<List<Curve>> loops = new List<List<Curve>>();
            List<Curve> curveSet = new List<Curve>();

            //初始化
            foreach (Curve item in curves)
            {
                curveSet.Add(item);
            }

            //循环
            while(curveSet.Count > 0)
            {
                TaskDialog.Show("r", curveSet.Count.ToString());
                XYZ vertexPostion = curveSet[0].GetEndPoint(0);
                List<Curve> loop = new List<Curve>();
                Curve curveFound = null;
                foreach (Curve item in curveSet)
                {
                    if (item.GetEndPoint(0).IsAlmostEqualTo(vertexPostion))
                    {
                        vertexPostion = item.GetEndPoint(1);
                        curveFound = item;
                        break;
                    }
                    if (item.GetEndPoint(1).IsAlmostEqualTo(vertexPostion))
                    {
                        vertexPostion = item.GetEndPoint(0);
                        curveFound = item;
                        break;
                    }
                }
                if (null != curveFound)
                {
                    loop.Add(curveFound);
                    curveSet.Remove(curveFound);
                }
                else
                {
                    loops.Add(loop);
                    break;
                }
            }
            return loops;
        }
    }

    public class OpeningSelectFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Opening;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

}
