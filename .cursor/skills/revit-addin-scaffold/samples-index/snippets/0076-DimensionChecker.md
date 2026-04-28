# Sample Snippet: DimensionChecker

Source project: `existingCodes\品成插件源代码\通用\DimensionChecker`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Autodesk.Revit.DB.SpecTypeId;

namespace DimensionChecker
{
    internal class Utils
    {
        #region 根据字符串算英尺
        
        public static double ConvertFeet( string s)
        {
            double feet;

            string fee;
            string inc;
            double a = 0.0; ;
            double b = 0.0; ;

            int i = s.IndexOf("-");
            if (i == -1)//没有英尺，如 8 3/4"         11"         
            {
                fee = "0";
                inc = s.Substring(0, s.Length - 1);

            }
            else
            {
                fee = s.Substring(0, i - 2);
                inc = s.Substring(i + 2, s.Length - i - 3);
            }
            fee = Regex.Replace(fee, @"\D", "");//删除非数字的字符

            //TaskDialog.Show("a", fee + "\n" + inc);
            try
            {
                a = double.Parse(fee);
           
            

            int i2 = inc.IndexOf("/");
            //TaskDialog.Show("/i2", i2.ToString());
            if (i2 != -1)
            {
                int i3 = inc.IndexOf(" ", 1);
                //TaskDialog.Show("i3", i3.ToString());
                if (i3 != -1)
                {
                    string s1 = inc.Substring(0, i3);
                    string s2 = inc.Substring(i3 + 1, i2 - i3 - 1);
                    string s3 = inc.Substring(i2 + 1, inc.Length - i2 - 1);

                    double d1 = double.Parse(s1);
                    double d2 = double.Parse(s2);
                    double d3 = double.Parse(s3);

                    b = (d1 * d3 + d2) / d3;
                    //TaskDialog.Show("a", s1 + "\n" + s2 + "\n" + s3);
                }
                
            }
            else
            {
                b = double.Parse(inc);
            }
            }
            catch (Exception)//替换文字的格式不对，比如9' - 4"  写成9'-4" （没有空格） 
            {
                TaskDialog.Show("Revit", "修改替换的文字格式！");
            }
            //TaskDialog.Show("a", s + "\n" + a.ToString() + "\n" + b.ToString());

            feet = a + (b / 12);


            return feet;

        }
        #endregion


        


// ... truncated ...
```

## DimensionChecker.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionChecker
{
    [Transaction(TransactionMode.Manual)]
    public class DimensionChecker : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Selection sel = uiapp.ActiveUIDocument.Selection;


            //选择dimension
            //多选
            IList<Reference> allRef = sel.PickObjects(ObjectType.Element, new DimensionFilter(), "框选要检查的Dimension");
            List<Element> list = new List<Element>();
            foreach (Reference item in allRef)
            {
                list.Add(doc.GetElement(item));
            }

            if (list.Count() == 0)
            {
                TaskDialog.Show("Revit", "未找到要检查的Dimension！");
                return Result.Cancelled;
            }
            //TaskDialog.Show("a", list.Count.ToString());

            //用来收集出错的Dimension
            List<ElementId> ids = new List<ElementId>();

            foreach (Element item in list)
            {
                Double tL = 0.0;
                Double sL = 0.0;
                double tL1 = 0.0;

                //获取Dimension的总长
                Parameter totalL = item.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH);
                tL = totalL.AsDouble();

                Dimension dimension = item as Dimension;
                if (dimension.Value == null)
                {
                    DimensionSegmentArray dsa = dimension.Segments;
                    if (dsa != null)
                    {
                        foreach (DimensionSegment ds in dsa)
                        {

                            string s = ds.ValueString;
                            string pre = ds.Prefix;
                            string suf = ds.Suffix;

                            if (!string.IsNullOrEmpty(pre))
                            {
                                s = s.Substring(pre.Length + 1, s.Length - pre.Length - 1);

                            }
                            if (!string.IsNullOrEmpty(suf))
                            {
                                s = s.Substring(0, s.Length - suf.Length - 1);

                            }
                            //TaskDialog.Show("a", s);

                            sL = Utils.ConvertFeet(s);
                            tL1 = tL1 + sL;

                        }

                        //TaskDialog.Show("a", tL.ToString() + "\n" + tL1.ToString() + "\n" + Math.Abs(tL - tL1).ToString());
                        if (Math.Abs(tL - tL1) >= 0.005)//比较
                        {
                            ids.Add(item.Id);
                        }
                    }
                    //else
                    //{
// ... truncated ...
```

## DimensionFilter.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionChecker
{
    internal class DimensionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue==(int)BuiltInCategory.OST_Dimensions)
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

```

