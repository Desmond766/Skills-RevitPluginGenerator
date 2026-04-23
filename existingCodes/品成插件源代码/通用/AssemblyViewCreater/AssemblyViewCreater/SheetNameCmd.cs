using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewCreater
{
    [Transaction(TransactionMode.Manual)]
    public class SheetNameCmd : IExternalCommand
    {
        //图纸名字
        private static string _sheetName;
        public static string SheetName
        {
            get { return SheetNameCmd._sheetName; }
            set { SheetNameCmd._sheetName = value; }
        }

        // 图纸第一个编号
        private static double _sheetNameNo;
        public static double SheetNameNo
        {
            get { return SheetNameCmd._sheetNameNo; }
            set { SheetNameCmd._sheetNameNo = value; }
        }

        // 图纸名称中编号间隔
        private static double _space;
        public static double Space
        {
            get { return SheetNameCmd._space; }
            set { SheetNameCmd._space = value; }
        }

        // 编号固定部分
        private static string _numText;
        public static string NumText
        {
            get { return SheetNameCmd._numText; }
            set { SheetNameCmd._numText = value; }
        }

        // 第一个编号
        private static double _number;
        public static double Number
        {
            get { return SheetNameCmd._number; }
            set { SheetNameCmd._number = value; }
        }

        // 图纸编号间隔
        private static double _numspace;
        public static double Numspace
        {
            get { return SheetNameCmd._numspace; }
            set { SheetNameCmd._numspace = value; }
        }

        public List<ElementId> selectedSheetList = new List<ElementId>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;


            //show dialog
            AssemblySheetFrm frm = new AssemblySheetFrm(doc);
            frm.ShowDialog();
            selectedSheetList = frm.selectedSheetList;
           
            //弹出设置窗口
            using (SheetNameFrm nameFrm = new SheetNameFrm())
            {
                if (DialogResult.OK != nameFrm.ShowDialog())
                {
                    return Result.Failed;
                }
            }
            


            using (Transaction tran = new Transaction(doc, "Sheet Name"))
            {
                tran.Start();
                foreach (ElementId id in selectedSheetList)
                {
                    ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                    if (null != sheet)
                    {

                        sheet.get_Parameter(BuiltInParameter.SHEET_NAME).Set(_sheetName + _sheetNameNo.ToString());
                        _sheetNameNo = _sheetNameNo + _space;

                        sheet.get_Parameter(BuiltInParameter.SHEET_NUMBER).Set(_numText + _number);
                        _number = _number + _numspace;
                    }
                }

                tran.Commit();
            }

            return Result.Succeeded;
        }


    }
}
