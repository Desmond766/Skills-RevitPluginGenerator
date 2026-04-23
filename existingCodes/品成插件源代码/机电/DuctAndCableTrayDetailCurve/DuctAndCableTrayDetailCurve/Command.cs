using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;

using Autodesk.Revit.DB.Mechanical;
using System.Xml;
using Autodesk.Revit.UI.Events;

namespace DuctAndCableTrayDetailCurve
{
    [Transaction(TransactionMode.Manual)]
    public class Command: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //框选,选择桥架和风管加入ductOrCableTrayList
            IList<Reference> list = sel.PickObjects(ObjectType.Element);
            List<Element> ductOrCableTrayList = new List<Element>();
            foreach (Reference reference in list)
            {
                Element elem = doc.GetElement(reference);
                if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                    || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
                {
                    ductOrCableTrayList.Add(elem);
                }
            }

            Options option = new Options();
            option.View = doc.ActiveView;
            DetailCurve detailCurve;

            //对风管和桥架添加边框
            using (Transaction t = new Transaction(doc, "详图线"))
            {
                t.Start();

                foreach (Element elem in ductOrCableTrayList)
                {
                    GeometryElement geomElement = elem.get_Geometry(option);
                    if (null == geomElement)
                    {
                        continue;
                    }
                    foreach (GeometryObject geomobj in geomElement)
                    {
                        Solid geomSolid = geomobj as Solid;
                        if (null == geomSolid)
                        {
                            continue;
                        }
                        foreach (Face geomFace in geomSolid.Faces)
                        {
                            if (!(geomFace is PlanarFace))
                            {
                                continue;
                            }
                            EdgeArrayArray edgeArrayArray = geomFace.EdgeLoops;
                            EdgeArray edgeArray = edgeArrayArray.get_Item(0) as EdgeArray;
                            for (int i = 0; i < edgeArray.Size; i++)
                            {
                                Line line = edgeArray.get_Item(i).AsCurve() as Line;
                                try//有在该平面中无法画线的情况如：两点在同一个位置
                                {
                                    detailCurve = doc.Create.NewDetailCurve(doc.ActiveView, line);
                                }
                                catch (Exception)
                                {
                                    //throw;
                                }
                            }
                        }
                    }
                }

                t.Commit();

            }


            return Result.Succeeded;

        }
    }
}
