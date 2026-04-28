# Sample Snippet: MEPQuantities

Source project: `existingCodes\其他插件源代码\MEPQuantities\MEPQuantities`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## CableWireQuant\Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using System.Data;
using MEPQuantities.CableWireInfo;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using System.Text.RegularExpressions;

namespace MEPQuantities.CableWireQuant
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!Utils.SimpleEncryptCheck())
            {
                message = "插件未注册!!!\n\n请联系福州品成建筑工程设计有限公司 TEL:0591-87310215";
                return Result.Failed;
            }
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            //Selection sel = uiapp.ActiveUIDocument.Selection;
            //var ele = doc.GetElement(sel.PickObject(ObjectType.Element));
            //FamilyInstance instance = ele as FamilyInstance;
            //var cons = instance.MEPModel.ConnectorManager.Connectors.Cast<Connector>().ToList();
            //TaskDialog.Show("re", (cons[0].Origin.DistanceTo(cons[1].Origin)+4.63).ToString("0.00"));
            //return Result.Succeeded;

            //【1】实例化DataCollector（数据收集器）
            RouteData rd = new RouteData();
            CableData cd = new CableData();
            WireData wd = new WireData();
            SofeWireData swd = new SofeWireData();
            SelfData sd = new SelfData();

            Dictionary<Element, string> routeData = new Dictionary<Element, string>();
            //【2】初始化电气回路表
            if (rd.Initialize(doc.PathName.Replace(".rvt", "-电气回路表.csv")))
            {
                routeData = FindRouteData(doc);
            }
            else
            {
                message = "未找到电气回路表:\n"+ doc.PathName.Replace(".rvt", "-电气回路表.csv");
                return Result.Failed;
            }

            //【3】分类统计
            foreach (DataRow dr in rd.m_dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["电缆型号.规格"].ToString()))
                {
                    CableInfo ci = new CableInfo(dr, routeData);
                    ci.Initialize();
                    if (!string.IsNullOrEmpty(ci.id))
                    {
                        cd.Add(ci);
                    }
                }
                else if (!string.IsNullOrEmpty(dr["电线型号.规格"].ToString()))
                {
                    WireInfo wi = new WireInfo(dr, routeData);
                    wi.Initialize();
                    if (!string.IsNullOrEmpty(wi.id))
                    {
                        wd.Add(wi);
                    }
                }
                else if (!string.IsNullOrEmpty(dr["多芯软导线"].ToString()))
                {
                    SofeWire sw = new SofeWire(dr, routeData);
                    sw.Initialize();
                    if (!string.IsNullOrEmpty(sw.id))
                    {
                        swd.Add(sw);
                    }
                }
            }

            //【4】统计自身量
// ... truncated ...
```

