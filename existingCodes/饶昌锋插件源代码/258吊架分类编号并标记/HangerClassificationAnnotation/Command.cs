using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HangerClassificationAnnotation
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            bool flag = true;
            HangerFilter hangerFilter = new HangerFilter();
            Reference reference = null;
            try
            {
                reference = uidoc.Selection.PickObject(ObjectType.Element, hangerFilter, "请选择");
            }
            catch (Exception)
            {
                return Result.Cancelled;
            }
            FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            FamilySymbol familySymbol = familyInstance.Symbol;
            Family family = familySymbol.Family;
            Document familyDoc = doc.EditFamily(family);
            Element element = doc.GetElement(reference);
            //Parameter parameter = doc.GetElement(reference).LookupParameter("类别编号");
            Parameter isParameter = element.LookupParameter("类别编号");
            //创建新的属性 并重新加载到项目中
            if (isParameter == null)
            {
                using (Transaction tran1 = new Transaction(familyDoc, "添加属性"))
                {
                    tran1.Start();
                    CustomFamilyLoadOptions options = new CustomFamilyLoadOptions();
                    try
                    {
                        FamilyParameter familyParameter = familyDoc.FamilyManager.AddParameter("类别编号", BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.Text, true);
                    }
                    catch (Autodesk.Revit.Exceptions.ArgumentException)
                    {
                        familyDoc.LoadFamily(doc, options);
                    }
                    familyDoc.LoadFamily(doc, options);
                    tran1.Commit();
                }
            }

            //获取当前所有的族实例
            ElementFilter filter = new FamilyInstanceFilter(doc, familySymbol.Id);
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> elementList1 = collector1.WherePasses(filter).ToElements();
            collector1.Dispose();
            string[,] arrayList = new string[elementList1.Count, 4];
            List<int> letters = new List<int>();
            //字母列表 给类型编号用
            for (int i = 1; i <= 2000; i++)
            {
                letters.Add(i);
            }
            //给新创建的类别编号赋值 
            using (Transaction tran = new Transaction(doc, "修改类别编号"))
            {
                //tran.Start();
                ////清空参数
                //foreach (Element elem in elementList1)
                //{
                //    elem.LookupParameter("类别编号").Set("");
                //}
                //tran.Commit();
                tran.Start();
                //获取清空后的所有类型
                FilteredElementCollector collector2 = new FilteredElementCollector(doc);
                ICollection<Element> elementList2 = collector2.WherePasses(filter).ToElements();
                //遍历赋值
                foreach (Element elem in elementList2)
                {
                    string a = "";
                    string b = "";
                    string c = "";
                    ParameterSet parameterList = elem.Parameters;
                    foreach (Parameter parameter in parameterList)
                    {
                        if (parameter.Definition.Name == "a_楼板底高")
                        {
                            a = parameter.AsValueString();
                        }
                        if (parameter.Definition.Name == "b_底层管道底高" || parameter.Definition.Name == "风管高度"|| parameter.Definition.Name == "H")
                        {
                            b = parameter.AsValueString();
                        }
                        if (parameter.Definition.Name == "c_风管宽" || parameter.Definition.Name == "c_桥架宽" || parameter.Definition.Name == "风管宽度"|| parameter.Definition.Name == "r")
                        {
                            c = parameter.AsValueString();
                        }
                    }
                    if (elem.Name == "风管法兰吊架-上固定" || elem.Name == "风管法兰吊架-下固定")
                    {
                        int longA;
                        int longB;
                        int.TryParse(elem.LookupParameter("吊杆长度1").AsValueString(), out longA);
                        int.TryParse(elem.LookupParameter("吊杆长度1").AsValueString(), out longB);
                        a = longA > longB ? longA.ToString() : longB.ToString();
                    }
                    string parameterValue = elem.LookupParameter("类别编号").AsString();
                    if (parameterValue == null || parameterValue == "")
                    {
                        //没有值
                        for (int i = 0; i < elementList2.Count; i++)
                        {
                            //二维数组不为空 就进入
                            if (!(""==arrayList[i, 0] || arrayList[i, 0] == null))
                            {
                                //TaskDialog.Show("asd", text);
                                if (a==arrayList[i, 0] && b==arrayList[i, 1] && c==arrayList[i, 2])
                                {
                                    elem.LookupParameter("类别编号").Set(arrayList[i, 3]);
                                    break;
                                }
                            }
                            else
                            {
                                Random random = new Random();
                                int index = random.Next(letters.Count);
                                arrayList[i, 0] = a;
                                arrayList[i, 1] = b;
                                arrayList[i, 2] = c;
                                arrayList[i, 3] = familySymbol.Name + letters[index];
                                letters.Remove(letters[index]);
                                //letters.Count.show();
                                elem.LookupParameter("类别编号").Set(arrayList[i, 3]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //有值
                        for (int i = 0; i < elementList2.Count; i++)
                        {
                            //二维数组不为空 就进入
                            if (!(""==arrayList[i, 0]) || !(arrayList[i, 0] == null))
                            {
                                if (a==arrayList[i, 0] && b==arrayList[i, 1] && c==arrayList[i, 2])
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Random random = new Random();
                                int index = random.Next(letters.Count);
                                arrayList[i, 0] = a;
                                arrayList[i, 1] = b;
                                arrayList[i, 2] = c;
                                arrayList[i, 3] = parameterValue;
                                break;
                            }
                        }
                    }
                }
                tran.Commit();
            }
            //添加标记
            View view = uidoc.ActiveView;
            FilteredElementCollector collector3 = new FilteredElementCollector(doc);
            ICollection<Element> elementList3 = collector3.WherePasses(filter).ToElements();
            collector3.Dispose();
            using (Transaction tran = new Transaction(doc, "添加标记"))
            {
                tran.Start();
                foreach (Element elem in elementList3)
                {
                    AddIndependentTag.Add(doc, elem, view,ref flag);
                }
                tran.Commit();
            }
            return Result.Succeeded;
        }


    }


}
