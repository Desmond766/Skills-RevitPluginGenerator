using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace ARC_BeamMaterial
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        private static string _function;
        public static string Function
        {
            get { return Command._function; }
            set { Command._function = value; }
        }

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
            using (BeamMaterialForm main_Dialog = new BeamMaterialForm())
            {
                if (main_Dialog.ShowDialog() != DialogResult.OK)
                {
                    return Result.Failed;
                }
            }
            // 计时开始
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int num_Pass_SymbolParameter = 0;
            int num_Pass_InstanceParameter = 0;
            int num_Done = 0;
            // 过滤材质
            FilteredElementCollector matCollector = new FilteredElementCollector(doc);
            IList<Element> materialList = matCollector.OfCategory(BuiltInCategory.OST_Materials).ToElements();
            // 过滤结构梁
            FilteredElementCollector beamCollector = new FilteredElementCollector(doc);
            IList<Element> beamList = beamCollector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).ToElements();
            if (Function == "Add")
            {
                // 【1】判断当前文档中是否存在用于替换的材质
                Hashtable ht_Material = new Hashtable();
                foreach (Element mat in materialList)
                {
                    if (mat.Name.Length > 8)
                    {
                        if (mat.Name.Substring(0, 7) == "S-结构梁材质")
                        {
                            ht_Material.Add(mat.Name, mat.Id);
                        }
                    }
                }
                if (ht_Material.Count == 0)
                {
                    message = "错误：未发现结构梁材质！";
                    return Result.Failed;
                }
                // 【2】根据梁高替换梁材质
                using (Transaction t = new Transaction(doc, "PaintBeamByHeight"))
                {
                    t.Start();
                    foreach (Element beam in beamList)
                    {
                        //获得梁高，组合成结构梁材质名
                        string matName = null;
                        ParameterSet symbolParms = (beam as FamilyInstance).Symbol.Parameters;
                        foreach (Parameter parm in symbolParms)
                        {
                            //"h"参数无BuiltInParameter
                            if (parm.Definition.Name == "h")
                            {
                                matName = "S-结构梁材质-" + parm.AsValueString();
                                break;
                            }
                        }
                        //添加结构梁材质
                        if (matName != null && matName != "S-结构梁材质-")
                        {
                            ElementId matId = ht_Material[matName] as ElementId;
                            if (matId != null)
                            {
                                bool isSymbolParameter = false;
                                //类型参数
                                ParameterSet parms = (beam as FamilyInstance).Symbol.Parameters;
                                foreach (Parameter parm in parms)
                                {
                                    if (parm.Definition.Name == "结构材质")
                                    {
                                        isSymbolParameter = true;
                                        //材质已经正确
                                        if (parm.AsValueString() == matName)
                                        {
                                            num_Pass_SymbolParameter += 1;
                                        }
                                        else
                                        {
                                            parm.Set(matId);
                                            num_Done += 1;
                                        }
                                        break;
                                    }
                                }
                                //实例参数
                                if (!isSymbolParameter)
                                {
                                    Parameter materialParm = beam.get_Parameter(BuiltInParameter.STRUCTURAL_MATERIAL_PARAM);
                                    if (null != materialParm)
                                    {
                                        if (materialParm.AsValueString() == matName)
                                        {
                                            num_Pass_InstanceParameter += 1;
                                        }
                                        else
                                        {
                                            materialParm.Set(matId);
                                            num_Done += 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    t.Commit();
                }
            }
            else
            {
                // 【1】判断当前文档中是否存在用于替换的材质
                Element concrete_Material = null;
                foreach (Element mat in materialList)
                {
                    if (mat.Name == "混凝土 - 现场浇注混凝土")
                    {
                        concrete_Material = mat;
                        break;
                    }
                }
                if (concrete_Material == null)
                {
                    message = "错误：未发现\"混凝土 - 现场浇注混凝土\"材质！";
                    return Result.Failed;
                }
                // 【2】替换梁材质为 "混凝土 - 现场浇注混凝土"

                using (Transaction t = new Transaction(doc, "ClearBeamMaterial"))
                {
                    t.Start();
                    foreach (Element beam in beamList)
                    {
                        bool isSymbolParameter = false;
                        //类型参数
                        ParameterSet parms = (beam as FamilyInstance).Symbol.Parameters;
                        foreach (Parameter parm in parms)
                        {
                            if (parm.Definition.Name == "结构材质")
                            {
                                isSymbolParameter = true;
                                //材质已经正确
                                if (parm.AsValueString() == "混凝土 - 现场浇注混凝土")
                                {
                                    num_Pass_SymbolParameter += 1;
                                }
                                else
                                {
                                    parm.Set(concrete_Material.Id);
                                    num_Done += 1;
                                }
                                break;
                            }
                        }
                        //实例参数
                        if (!isSymbolParameter)
                        {
                            Parameter materialParm = beam.get_Parameter(BuiltInParameter.STRUCTURAL_MATERIAL_PARAM);
                            if (null != materialParm)
                            {
                                if (materialParm.AsValueString() == "混凝土 - 现场浇注混凝土")
                                {
                                    num_Pass_InstanceParameter += 1;
                                }
                                else
                                {
                                    materialParm.Set(concrete_Material.Id);
                                    num_Done += 1;
                                }
                            }
                        }
                    }
                    t.Commit();
                }
            }
            // 结束计时
            sw.Stop();
            // 输出程序运行结果
            string info = "共找到" + beamList.Count.ToString() + "根梁；";
            info += "\n" + num_Pass_SymbolParameter.ToString() + "根梁材质为类型参数，材质正确跳过；\n" + num_Pass_InstanceParameter.ToString() + "根梁材质为实例参数，材质正确跳过；";
            info += "\n" + num_Done.ToString() + "根梁材质完成匹配";
            info += "\n总用时" + sw.Elapsed.ToString();
            TaskDialog.Show("Revit", info);

            return Result.Succeeded;
        }
    }
}
