using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Parameter = Autodesk.Revit.DB.Parameter;

namespace Demo02
{
    public class ChangeParameter
    {
        public static void changeParameter(Document doc, string familyName, string familySymbolName, string parameterName, string parameterValue, ref bool flag)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            // 使用 OfCategory 方法指定要获取的元素类别，这里是族的类别
            ICollection<Element> familyElements = collector.OfClass(typeof(Family)).ToElements();

            // 遍历获取的族，筛选指定名字的族
            foreach (Element familyElement in familyElements)
            {
                Family family = familyElement as Family;
                if (family != null && family.Name == familyName)
                {
                    //根据族获取所有族类型id 并遍历
                    ISet<ElementId> familySymbols = family.GetFamilySymbolIds();
                    foreach (ElementId item in familySymbols)
                    {
                        FamilySymbol familySymbol = doc.GetElement(item) as FamilySymbol;
                        if (familySymbol.Name == familySymbolName)
                        {
                            ParameterSet parameterSet = familySymbol.Parameters;
                            foreach (Parameter parameter in parameterSet)
                            {
                                if (parameter.Definition.Name == parameterName)
                                {
                                    parameter.Set(parameterValue);
                                    //MessageBox.Show("Modified Successfully");
                                    flag = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
