using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;

namespace MEP_AddSEblow
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;
            //定义几个变量
            Reference ref_Drain = null;
            Reference ref_SEblow = null;
            PipeType pt = null;
            ElementId systemTypeId = null;
            //选择S弯或P弯进行布置
            try
            {
                ref_SEblow = selection.PickObject(ObjectType.Element, "请选择一个含有系统类型的存水弯");
                Element sEblow = doc.GetElement(ref_SEblow);
                if (sEblow.Category.Id.IntegerValue != (int)BuiltInCategory.OST_PipeAccessory
                    || !sEblow.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("存水弯"))
                {
                    TaskDialog.Show("revit", "选择的构件不是存水弯, 程序结束");
                    return Result.Failed;
                }
                pt = GetConnectorPipeType(doc, sEblow as FamilyInstance);
                systemTypeId = sEblow.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsElementId();
                if (null == systemTypeId)
                {
                    TaskDialog.Show("revit", "选择的存水弯没有初始系统类型, 程序结束");
                    return Result.Failed;
                }
            }
            catch
            {
                TaskDialog.Show("Revit", "操作取消，程序结束");
                return Result.Cancelled;
            }
            //主程序开始
            while (true)
            {
                try
                {
                    using (Transaction t = new Transaction(doc, "Add SEblow"))
                    {
                        t.Start();
                        //选择地漏
                        ref_Drain = selection.PickObject(ObjectType.Element, "点击地漏进行布置");
                        Element drain = doc.GetElement(ref_Drain);
                        if (drain.Category.Id.IntegerValue != (int)BuiltInCategory.OST_PipeAccessory
                            || !drain.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains('漏'))
                        {
                            TaskDialog.Show("revit", "选择的构件不是地漏，跳过");
                            continue;
                        }
                        XYZ lPoint_drain = (drain.Location as LocationPoint).Point;
                        List<Connector> cons_drain = GetConnectors(drain as FamilyInstance);
                        XYZ conPoint_drain = cons_drain[0].Origin;
                        if (!(lPoint_drain - conPoint_drain).Normalize().IsAlmostEqualTo(XYZ.BasisZ))
                        {
                            TaskDialog.Show("revit", "仅支持向下的地漏，跳过");
                            continue;
                        }
                        //创建S弯或P弯
                        XYZ location = conPoint_drain + XYZ.BasisZ.Negate() * (500 / 304.8);
                        Element sEblow = doc.GetElement(ref_SEblow);
                        FamilySymbol sy = (sEblow as FamilyInstance).Symbol;
                        FamilyInstance new_SEblow = doc.Create.NewFamilyInstance(
                            location, sy, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                        //修改S弯或P弯的公称直径
                        double radius = double.Parse(GetNonBuiltInParameter(drain, "出口直径").AsValueString()) / 609.6;
                        GetNonBuiltInParameter(new_SEblow, "公称半径").Set(radius);
                        Connector con1 = cons_drain[0];
                        List<Connector> cons_SEblow = GetConnectors(new_SEblow);
                        Connector con2 = cons_SEblow[0];
                        foreach (Connector con in cons_SEblow)
                        {
                            if ((con1.Origin - con.Origin).Normalize().IsAlmostEqualTo(XYZ.BasisZ))
                            {
                                con2 = con;
                                break;
                            }
                        }
                        //创建管道
                        FilteredElementCollector levelCollector = new FilteredElementCollector(doc);
                        levelCollector.OfClass(typeof(Level));
                        Level le = levelCollector.FirstElement() as Level;
                        Pipe new_pipe = Pipe.Create(doc, pt.Id, le.Id, con1, con2);
                        if (null != systemTypeId)
                        {
                            new_pipe.SetSystemType(systemTypeId);
                        }
                        t.Commit();

                    }
                }
                //ESC退出布置
                catch(Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "结束布置");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit", ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }
            }
            return Result.Succeeded;
        }

        #region 返回连接件集合
        /// <summary>
        /// 返回连接件集合
        /// </summary>
        /// <param name="fi">配件</param>
        /// <returns>连接件集合</returns>
        private List<Connector> GetConnectors(FamilyInstance fi)
        {
            List<Connector> connectors = new List<Connector>();
            ConnectorSet conSet = fi.MEPModel.ConnectorManager.Connectors;
            foreach (Connector con in conSet)
            {
                if (con.ConnectorType == ConnectorType.End)
                {
                    connectors.Add(con);
                }
            }
            return connectors;
        }
        #endregion

        #region 取得非内置参数
        /// <summary>
        /// 取得非内置参数
        /// </summary>
        /// <param name="e">元素</param>
        /// <param name="parameterName">参数名</param>
        /// <returns>参数</returns>
        private Parameter GetNonBuiltInParameter(Element e, string parameterName)
        {
            ParameterSet parameterSet = e.Parameters;
            Parameter myParameter = null;
            foreach (Parameter p in parameterSet)
            {
                if (p.Definition.Name == parameterName)
                {
                    myParameter = p;
                }
            }
            return myParameter;
        }
        #endregion

        #region 返回配件所连接的管道的类型
        /// <summary>
        /// 返回配件所连接的管道的类型
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <param name="fi">配件</param>
        /// <returns>所连接的管道的类型</returns>
        private PipeType GetConnectorPipeType(Document doc, FamilyInstance fi)
        {
            //若S弯没有连接到管道，那么管道类型为过滤到的第一种管道类型
            FilteredElementCollector pipeTypeCollector = new FilteredElementCollector(doc);
            pipeTypeCollector.OfClass(typeof(PipeType));
            PipeType pt = pipeTypeCollector.FirstElement() as PipeType;
            //判断S弯
            List<XYZ> connectorPoint = new List<XYZ>();
            ConnectorSet conSet = fi.MEPModel.ConnectorManager.Connectors;
            foreach (Connector con in conSet)
            {
                if (con.ConnectorType == ConnectorType.End)
                {
                    if (con.IsConnected)
                    {
                        ConnectorSet conToSet = con.AllRefs;
                        ConnectorSetIterator csi = conToSet.ForwardIterator();
                        while (csi.MoveNext())
                        {
                            Connector conTo = csi.Current as Connector;
                            if (null != conTo)
                            {
                                if (conTo.Owner.Id.ToString() != fi.Id.ToString())
                                {
                                    if (conTo.Owner.Category.Name == "管道")
                                    {
                                        pt = (conTo.Owner as Pipe).PipeType;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return pt;
        }
        #endregion
    }
}
