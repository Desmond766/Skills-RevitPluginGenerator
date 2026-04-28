using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Diagnostics;

namespace ARC_ClearBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
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
            //计时开始
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //主程序开始
            int num_Clear = 0;
            //遍历文档中的梁，修改族类型
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance));
            List<FamilyInstance> beams = collector.Cast<FamilyInstance>().Where(x => x.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam).ToList();
            List<FamilyInstance> errorBeam = new List<FamilyInstance>();
            using (Transaction t = new Transaction(doc, "ClearBeam"))
            {
                t.Start();
                foreach (FamilyInstance beam in beams)
                {
                    bool isErrorBeam = false;
                    SetSymbol(doc, beam, out isErrorBeam);
                    if (isErrorBeam)
                    {
                        errorBeam.Add(beam);
                    }
                }
                //清理HW-矩形梁族内未使用的族类型
                Family family_HWBeam = GetFamily(doc, "HW-矩形梁");
                if (null != family_HWBeam)
                {
                    //遍历族下的所有类型
                    List<ElementId> symbolIds = family_HWBeam.GetFamilySymbolIds().ToList();
                    if (symbolIds.Count != 0)
                    {
                        foreach (ElementId id in symbolIds)
                        {
                            FilteredElementCollector c = new FilteredElementCollector(doc);
                            FamilyInstanceFilter fif = new FamilyInstanceFilter(doc, id);
                            c.WherePasses(fif);
                            if (c.Count() == 0)
                            {
                                doc.Delete(id);
                                num_Clear += 1;
                            }
                        }
                    }
                }
                //将错误的梁赋上红色
                if (errorBeam.Count != 0)
                {
                    foreach (FamilyInstance beam in errorBeam)
                    {
                        //梁材质为实例参数
                        beam.get_Parameter(BuiltInParameter.STRUCTURAL_MATERIAL_PARAM).Set(GetMyErrorMaterial(doc));
                    }
                }
                t.Commit();
            }
            //结束计时
            sw.Stop();
            //输出程序运行结果
            string info = "遍历" + beams.Count().ToString() + "根梁；\n其中" + errorBeam.Count.ToString() + "根梁出错，标示为红色；\n清理" + num_Clear.ToString() + "个未使用的梁类型；\n用时" + sw.Elapsed.ToString();
            TaskDialog.Show("Revit", info);


            return Result.Succeeded;
        }

        #region 设置梁类型，判断该梁是否为出错的梁
        /// <summary>
        /// 设置梁类型，判断该梁是否为出错的梁
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <param name="familyInstance">梁</param>
        /// <param name="isErrorBeam">是否为出错的梁</param>
        private void SetSymbol(Document doc, FamilyInstance familyInstance, out bool isErrorBeam)
        {
            isErrorBeam = false;
            //判断梁类型，未知类型返回null
            string beamType = null;
            if (familyInstance.Name.Contains("KL"))
            {
                beamType = "KL";
            }
            else if (familyInstance.Name.Contains("L"))
            {
                //beamType = "L";
                beamType = "KL";////2020.10.12UPDATE
            }
            //未知梁类型
            else
            {
                return;
            }
            //获得梁的b和h
            string b = GetSymbolParameterValue(familyInstance, "b");
            string h = GetSymbolParameterValue(familyInstance, "h");

            string typeName = "S-" + beamType + "-" + b + "X" + h;//2020.10.12UPDATE

            //如果梁高小于100，错误
            if (double.Parse(h) / 304.8 < 0.3)
            {
                isErrorBeam = true;
                return;
            }
            //梁类型已正确
            //if (familyInstance.Name == "S-" + beamType + "-" + b + "*" + h)
            if (familyInstance.Name == typeName)//2020.10.12UPDATE
            {
                return;
            }
            //矩形梁族
            Family family_HWBeam = null;
            //矩形梁类型
            FamilySymbol symbol_HWBeam = null;
            //找到名为"HW-矩形梁"的族
            family_HWBeam = GetFamily(doc, "HW-矩形梁");
            bool existSymbol = false;
            if (null != family_HWBeam)
            {
                //遍历族下的所有类型
                List<ElementId> symbolIds = family_HWBeam.GetFamilySymbolIds().ToList();
                if (symbolIds.Count != 0)
                {
                    foreach (ElementId id in symbolIds)
                    {
                        //如果已经存在所需的族类型，赋值给构造柱族类型
                        if (doc.GetElement(id).Name == typeName)
                        {
                            symbol_HWBeam = doc.GetElement(id) as FamilySymbol;
                            familyInstance.Symbol = symbol_HWBeam;
                            existSymbol = true;
                            return;
                        }
                    }
                    //如果不存在所需的族类型，新建一个
                    if (!existSymbol)
                    {
                        //赋值第一个类型
                        FamilySymbol baseSymbol = doc.GetElement(symbolIds[0]) as FamilySymbol;
                        //改名为所需的族类型
                        symbol_HWBeam = baseSymbol.Duplicate(typeName) as FamilySymbol;
                        //修改参数
                        ParameterSet symbolParameters = symbol_HWBeam.Parameters;
                        foreach (Parameter parm in symbolParameters)
                        {
                            if (parm.Definition.Name == "b" || parm.Definition.Name == "宽度")
                            {
                                parm.Set(double.Parse(b) / 304.8);
                            }
                            if (parm.Definition.Name == "h" || parm.Definition.Name == "高度")
                            {
                                parm.Set(double.Parse(h) / 304.8);
                            }
                        }
                        familyInstance.Symbol = symbol_HWBeam;
                    }
                }
            }
        }
        #endregion

        #region 获得指定族
        /// <summary>
        /// 获得指定族
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <param name="name">族名</param>
        /// <returns>族</returns>
        private Family GetFamily(Document doc, string name)
        {
            Family myFamily = null;
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Family));
            foreach (Family family in collector)
            {
                if (family.Name == name)
                {
                    myFamily = family;
                    break;
                }
            }
            return myFamily;
        }
        #endregion

        #region 获得族参数值
        /// <summary>
        /// 获得族参数值
        /// </summary>
        /// <param name="familyInstance">实例</param>
        /// <param name="parameterName">族参数名</param>
        /// <returns>族参数值</returns>
        private string GetSymbolParameterValue(FamilyInstance familyInstance, string parameterName)
        {
            string parameterVaule = null;
            ParameterSet symbolParameters = familyInstance.Symbol.Parameters;
            foreach (Parameter parm in symbolParameters)
            {
                if (parm.Definition.Name == parameterName)
                {
                    parameterVaule = parm.AsValueString();
                    break;
                }
            }
            return parameterVaule;
        }
        #endregion

        #region 获得标示错误的材质
        /// <summary>
        /// 获得标示错误的材质ID
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <returns>标示错误的材质ID</returns>
        private ElementId GetMyErrorMaterial(Document doc)
        {
            Material material = null;
            bool existMaterial = false;
            FilteredElementCollector matCollector = new FilteredElementCollector(doc);
            IList<Element> materialList = matCollector.OfCategory(BuiltInCategory.OST_Materials).ToElements();
            foreach (Element mat in materialList)
            {
                if (mat.Name == "错误")
                {
                    material = mat as Material;
                    existMaterial = true;
                    break;
                }
            }
            if (!existMaterial)
            {
                ElementId materialId = Material.Create(doc, "错误");
                material = doc.GetElement(materialId) as Material;
                material.Color = new Color(255, 0, 0);
            }
            return material.Id;
        }
        #endregion
    }
}
