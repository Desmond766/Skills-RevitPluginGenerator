//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
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
using System.Diagnostics;
using System.IO;

namespace SystemHide
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
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
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;


            try
            {
                while (true)
                {
                    //拾取管线
                    Reference r = sel.PickObject(ObjectType.Element);
                    Element e = doc.GetElement(r);

                    //将视图中可见的桥架、桥架配件、线管、线管配件过滤收集起来
                    FilteredElementCollector collectorCableTray = new FilteredElementCollector(doc, doc.ActiveView.Id);
                    collectorCableTray.OfCategory(BuiltInCategory.OST_CableTray);
                    FilteredElementCollector collectorCableTaryFitting = new FilteredElementCollector(doc, doc.ActiveView.Id);
                    collectorCableTaryFitting.OfCategory(BuiltInCategory.OST_CableTrayFitting);
                    FilteredElementCollector collectorConduit = new FilteredElementCollector(doc, doc.ActiveView.Id);
                    collectorConduit.OfCategory(BuiltInCategory.OST_Conduit);
                    FilteredElementCollector collectorConduitFitting = new FilteredElementCollector(doc, doc.ActiveView.Id);
                    collectorConduitFitting.OfCategory(BuiltInCategory.OST_ConduitFitting);
                    //将视图中可见的所有构件收集起来
                    FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                    //创建一个list用来收集满足条件的同类构件
                    List<ElementId> list = new List<ElementId>();
                    string sys = "";

                    //拾取的是桥架或者桥架配件的情况，判断：族的类型名称
                    if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                        || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTrayFitting)
                    {
                        sys = e.Name;
                        foreach (Element item in collectorCableTray)
                        {
                            if (item.Name == sys)
                            {
                                list.Add(item.Id);
                            }
                        }
                        foreach (Element item in collectorCableTaryFitting)
                        {
                            FamilyInstance itemFamilyInstance = item as FamilyInstance;
                            if (itemFamilyInstance.Name == sys)
                            {
                                list.Add(item.Id);
                            }
                        }

                    }
                    //拾取的是线管或者线管配件的情况，判断：族的类型名称
                    else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit
                        || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_ConduitFitting)
                    {
                        sys = e.Name;
                        foreach (Element item in collectorConduit)
                        {
                            if (item.Name == sys)
                            {
                                list.Add(item.Id);
                            }
                        }
                        foreach (Element item in collectorConduitFitting)
                        {
                            FamilyInstance itemFamilyInstance = item as FamilyInstance;
                            if (itemFamilyInstance.Name == sys)
                            {
                                list.Add(item.Id);
                            }
                        }
                    }
                    //拾取的是风管的情况，判断：系统类型参数
                    else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                        || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctFitting
                        || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctAccessory)
                    {
                        sys = e.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).AsValueString();
                        foreach (Element item in collector)
                        {
                            if (null == item.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM))
                            {
                                continue;
                            }
                            else if (item.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).AsValueString() == sys)
                            {
                                list.Add(item.Id);
                            }
                        }
                    }
                    //拾取的是水管的情况，判断：系统类型参数
                    else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                        || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeFitting
                        || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeAccessory)
                    {
                        sys = e.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsValueString();
                        foreach (Element item in collector)
                        {
                            if (null == item.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM))
                            {
                                continue;
                            }
                            else if (item.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsValueString() == sys)
                            {
                                list.Add(item.Id);
                            }
                        }
                    }
                    //将收集到list里的构件隐藏
                    using (Transaction t = new Transaction(doc, "关闭系统"))
                    {
                        t.Start();
                        doc.ActiveView.HideElementsTemporary(list);
                        t.Commit();
                    }
                }
            }
            catch
            {

            }

            return Result.Succeeded;
        }
        #region 找到不同盘符的共享盘
        /// <summary>
        /// 找到不同盘符的共享盘
        /// </summary>
        /// <param name="specifiedPath">指定的路径</param>
        /// <returns>大家电脑上可以识别到的路径</returns>
        public static string SharedPath(string path)
        {
            //列出用户共享盘可能的盘符
            List<string> strList = new List<string>()
        {
            "A", "B", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            for (int i = 0; i < strList.Count; i++)
            {
                string SharePath = path.Replace("X", strList[i]);
                if (Directory.Exists(SharePath))
                {
                    path = SharePath;
                    break;
                }
            }
            return path;
        }

        #endregion
    }
}
