using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Autodesk.Revit.DB.Events;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class QuickPrintCmd2 : IExternalCommand
    {
        public List<string> selectedAssemblyList = new List<string>();
        public PrintSetting selectedPrintSetting = null;
        public string selectedPrinter = null;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // 定义Windows消息常量
        public const uint BM_CLICK = 0x00F5; // 按钮点击消息

        #region 寻找另存为中的按钮
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        // 定义回调委托，用于EnumChildWindows
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        // 存储目标按钮的标题
        public static string TargetButtonTitle { get; set; } = "是(&Y)";
        // 存储找到的目标按钮句柄
        public static IntPtr FoundButtonHandle { get; private set; } = IntPtr.Zero;
        #endregion

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            //IntPtr dialogHandle = FindWindow("#32770", "确认另存为");

            //IntPtr subHandle1 = FindWindowEx(dialogHandle, IntPtr.Zero, "DirectUIHWND", null);

            //IntPtr subHandle2 = FindWindowEx(subHandle1, IntPtr.Zero, "CtrlNotifySink", null);

            //IntPtr buttonHandle = FindDeepChildButton("确认另存为", "#32770");

            ////IntPtr saveButtonHandle = FindWindowEx(subHandle2, IntPtr.Zero, "Button", "是(&Y)");

            //if (buttonHandle == IntPtr.Zero)
            //{
            //    TaskDialog.Show("reivt", "savenull");
            //    return Result.Failed;
            //}

            //SendMessage(buttonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            //TaskDialog.Show("revit", "sd");
            //return Result.Succeeded;

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            uiapp.Application.ViewPrinted += new EventHandler<ViewPrintedEventArgs>(OnViewPrinted);
            //uiapp.Application.ViewPrinting += new EventHandler<ViewPrintingEventArgs>(OnViewPrinting);

            QuickPrintCmd2Frm frm = new QuickPrintCmd2Frm(doc);
            frm.ShowDialog();
            selectedAssemblyList = frm.selectedAssemblyList;
            selectedPrintSetting = frm.selectedPrintSetting;
            selectedPrinter = frm.selectedPrinter;
            using (Transaction trans = new Transaction(doc, "CEG Quick Print2"))
            {
                trans.Start();

                foreach (string currentAssemblyName in selectedAssemblyList)
                {
                    //https://blog.csdn.net/lushibi/article/details/44922281
                    //打印机设置
                    PrintManager pm = doc.PrintManager;

                    //默认地址
                    String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string shtprtflenm = path + "\\" + currentAssemblyName
                        + "(" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + ").pdf";
                    if (currentAssemblyName.Contains("/"))
                    {
                        message = "Assembly name contain '/' can not print";
                        return Result.Cancelled;
                    }
                    if (File.Exists(shtprtflenm))
                    {
                        try
                        {
                            File.Delete(shtprtflenm);
                        }
                        catch (Exception ex)
                        {
                            message = ex.Message;
                            return Result.Cancelled;
                        }
                    }

                    //设置打印哪些图纸
                    pm.PrintRange = PrintRange.Select;
                    var vss = pm.ViewSheetSetting;
                    ViewSet sheetSet = GetAllSheets(doc, currentAssemblyName);

                    //其他设置
                    pm.PrintToFileName = shtprtflenm;
                    pm.CombinedFile = true;
                    pm.PrintToFile = true;
                    pm.PrintSetup.CurrentPrintSetting = selectedPrintSetting;
                    pm.Apply();

                    ////如果设置的是同样的视图，会报错
                    //if (!SameSheets(vss.InSession.Views, sheetSet))
                    //{
                    //    vss.InSession.Views = sheetSet;
                    //}
                    //pm.SubmitPrint();

                    //bool needToCreateNewSet = true;
                    FilteredElementCollector filteredElementCollectorSets = new FilteredElementCollector(doc);
                    filteredElementCollectorSets.OfClass(typeof(ViewSheetSet));
                    //foreach (Element e in filteredElementCollectorSets)
                    //{
                    //    if (e is ViewSheetSet)
                    //    {
                    //        ViewSheetSet vSet = (ViewSheetSet)e;
                    //        if (vSet.Name == "Quick Print")
                    //        {
                    //            vSet.Views = sheetSet;
                    //            vss.CurrentViewSheetSet = vSet;

                    //            vss.CurrentViewSheetSet.Views = vSet.Views;

                    //            try
                    //            {
                    //                vss.Save();
                    //            }
                    //            catch { }
                    //            pm.Apply();
                    //            needToCreateNewSet = false;
                    //        }
                    //    }
                    //}
                    //if (needToCreateNewSet == true)
                    //{
                    //    vss.CurrentViewSheetSet.Views = sheetSet;
                    //    try
                    //    {
                    //        vss.SaveAs("Quick Print");
                    //    }
                    //    catch { }
                    //    pm.Apply();
                    //    //needToCreateNewSet = false;
                    //}

                    string timeStamp = Utils.GetTimeStamp();
                    vss.CurrentViewSheetSet.Views = sheetSet;
                    vss.SaveAs("Quick Print" + "_" + timeStamp);
                    //TaskDialog.Show("abc", (pm.PrintToFile = true).ToString() + "\n" + pm.PrintToFile);
                    pm.Apply();
                    //TaskDialog.Show("revit", pm.PrintToFileName +"\n" + pm.PrintToFile);

                    pm.SubmitPrint();
                    //doc.Print(sheetSet, true);
                    //TaskDialog.Show("revit", currentAssemblyName);
                    var delVSS = filteredElementCollectorSets.Where(e => e is ViewSheetSet)
                        .FirstOrDefault(e => e.Name == "Quick Print" + "_" + timeStamp);
                    if (delVSS != null) doc.Delete(delVSS.Id);

                    //IntPtr dialogHandle = FindWindow("#32770", "Save As");
                    //if (dialogHandle == IntPtr.Zero) continue;
                    //IntPtr saveButtonHandle = FindWindowEx(dialogHandle, IntPtr.Zero, "Button", "保存(&S)");

                    //if (saveButtonHandle != IntPtr.Zero) SendMessage(saveButtonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                }
                trans.Commit();
            }

            uiapp.Application.ViewPrinted -= new EventHandler<ViewPrintedEventArgs>(OnViewPrinted);
            //uiapp.Application.ViewPrinting -= new EventHandler<ViewPrintingEventArgs>(OnViewPrinting);
            return Result.Succeeded;

            DateTime dateTime = DateTime.Now;
            while (DateTime.Now.Subtract(dateTime).TotalSeconds <= 2)
            {
                IntPtr dialogHandle = FindWindow("#32770", "Save As");
                if (dialogHandle == IntPtr.Zero) continue;
                IntPtr saveButtonHandle = FindWindowEx(dialogHandle, IntPtr.Zero, "Button", "保存(&S)");

                if (saveButtonHandle == IntPtr.Zero) continue;

                dateTime = DateTime.Now;
                SendMessage(saveButtonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);

                //DateTime subTime = DateTime.Now;
                //while (DateTime.Now.Subtract(subTime).TotalSeconds <= 1)
                //{
                //    IntPtr saveAsBtnHandle = FindDeepChildButton("确认另存为", "#32770");
                //    if (saveAsBtnHandle != IntPtr.Zero)
                //    {
                //        SendMessage(saveAsBtnHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                //        break;
                //    }
                //}
            }

            return Result.Succeeded;
        }
        public void OnViewPrinting(object sender, ViewPrintingEventArgs e)
        {
            IntPtr dialogHandle = FindWindow("#32770", "Save As");
            if (dialogHandle == IntPtr.Zero) return;
            IntPtr saveButtonHandle = FindWindowEx(dialogHandle, IntPtr.Zero, "Button", "保存(&S)");
            if (saveButtonHandle != IntPtr.Zero) SendMessage(saveButtonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }
        public void OnViewPrinted(object sender, ViewPrintedEventArgs e)
        {
            IntPtr dialogHandle = FindWindow("#32770", "Save As");
            if (dialogHandle == IntPtr.Zero) return;
            IntPtr saveButtonHandle = FindWindowEx(dialogHandle, IntPtr.Zero, "Button", "保存(&S)");
            if (saveButtonHandle != IntPtr.Zero) SendMessage(saveButtonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }
        //public void OnViewPrinted(object sender, ViewPrintedEventArgs e)
        //{
        //    IntPtr dialogHandle = FindWindow("#32770", "Save As");
        //    if (dialogHandle == IntPtr.Zero) return;
        //    IntPtr saveButtonHandle = FindWindowEx(dialogHandle, IntPtr.Zero, "Button", "保存(&S)");
        //    if (saveButtonHandle != IntPtr.Zero) SendMessage(saveButtonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);


        //    return;
        //    // 1. 获取触发事件的文档
        //    Document doc = e.Document;

        //    // 2. 检查事件状态（例如，打印是否成功）[3,7](@ref)
        //    if (e.Status != RevitAPIEventStatus.Succeeded)
        //    {
        //        TaskDialog.Show("打印后处理", "警告：视图打印可能未成功完成，后续操作被跳过。");
        //        return;
        //    }

        //    // 3. 在这里添加你的自定义逻辑
        //    // 例如：记录打印完成的视图信息[3](@ref)
        //    string viewName = e.View?.Name ?? "未知视图";
        //    string message = $"视图 '{viewName}' 已完成打印。\n";
        //    message += $"总视图数: {e.TotalViews}, 当前视图索引: {e.Index}";

        //    TaskDialog.Show("打印完成通知", message);

        //    // 示例：在打印完成后，对文档进行一些修改（例如，添加一个打印完成标记）
        //    // 注意：任何对文档的修改都必须在事务内进行[7](@ref)
        //    try
        //    {
        //        using (Transaction trans = new Transaction(doc, "打印后操作"))
        //        {
        //            if (trans.Start() == TransactionStatus.Started)
        //            {
        //                // 在这里进行你的文档操作，例如创建或修改元素
        //                // doc.Create.NewTextNote(...); [3](@ref)

        //                trans.Commit();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TaskDialog.Show("错误", $"在打印后处理过程中发生异常：{ex.Message}");
        //    }
        //}
        private bool EnumChildWindowsProc(IntPtr hWnd, IntPtr lParam)
        {
            StringBuilder windowTitle = new StringBuilder(256);
            GetWindowText(hWnd, windowTitle, windowTitle.Capacity);

            // 检查当前窗口标题是否匹配
            if (windowTitle.ToString().Contains(TargetButtonTitle))
            {
                FoundButtonHandle = hWnd;
                return false; // 找到目标，停止枚举
            }

            // 无论当前窗口是否匹配，都继续枚举它的子窗口（递归查找）
            EnumChildWindows(hWnd, EnumChildWindowsProc, IntPtr.Zero);

            // 如果已经在深层递归中找到了目标，就停止最外层的枚举
            return (FoundButtonHandle == IntPtr.Zero);
        }
        private IntPtr FindDeepChildButton(string parentWindowTitle, string parentClassName = null)
        {
            FoundButtonHandle = IntPtr.Zero; // 重置查找结果

            // 1. 首先查找顶层的“另存为”窗口
            IntPtr hParentWnd = FindWindow(parentClassName, parentWindowTitle);
            if (hParentWnd == IntPtr.Zero)
            {
                Console.WriteLine($"未找到标题为『{parentWindowTitle}』的窗口。");
                return IntPtr.Zero;
            }
            Console.WriteLine($"找到父窗口，句柄: {hParentWnd}");

            // 2. 开始递归枚举所有子窗口
            EnumChildWindows(hParentWnd, EnumChildWindowsProc, IntPtr.Zero);

            //if (FoundButtonHandle != IntPtr.Zero)

            return FoundButtonHandle;
        }

        private ViewSet GetAllSheets(Document doc, string assemblyName)
        {
            ViewSet sheetSet = new ViewSet();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Autodesk.Revit.DB.View));
            foreach (ElementId id in collector.ToElementIds())
            {
                ViewSheet sheet = (doc.GetElement(id) as ViewSheet);
                if (null != sheet)
                {
                    if (sheet.IsAssemblyView)
                    {
                        if (doc.GetElement(sheet.AssociatedAssemblyInstanceId).Name == assemblyName)
                        //if (sheet.SheetNumber.Contains(assemblyName))//W-61 W-61X
                        {
                            sheetSet.Insert(sheet);
                        }
                    }
                }
            }
            return sheetSet;
        }

        private bool SameSheets(ViewSet set1, ViewSet set2)
        {
            if (set1.Size != set2.Size)
            {
                return false;
            }

            foreach (View item in set1)
            {
                if (!set2.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
