# Sample Snippet: AssemblyViewCreater

Source project: `existingCodes\品成插件源代码\通用\AssemblyViewCreater\AssemblyViewCreater`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

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

namespace AssemblyViewCreater
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public List<ElementId> selectedSheetList = new List<ElementId>();
        public List<AssemblyViewInfo> assemblyInfoList = new List<AssemblyViewInfo>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // select
            if (sel.GetElementIds().Count == 0)
            {
                message = "Select Schedule First!";
                return Result.Cancelled;
            }

            // collect info
            foreach (ElementId id in sel.GetElementIds())
            {
                Element elem = doc.GetElement(id);
                if (elem is Viewport)
                {
                    Viewport viewPortInst = elem as Viewport;
                    ViewSection vs = doc.GetElement(viewPortInst.ViewId) as ViewSection;

                    AssemblyViewInfo info = new AssemblyViewInfo()
                    {
                        Name = vs.Name,
                        TemplateId = vs.ViewTemplateId,
                        Position = viewPortInst.GetBoxCenter(),
                        direction = GetAssemblyViewDirection(vs.Name)
                    };
                    assemblyInfoList.Add(info);
                }
            }
            if (assemblyInfoList.Count == 0)
            {
                message = "No Assembly Slected!";
                return Result.Cancelled;
            }
            
            //show dialog
            AssemblySheetFrm frm = new AssemblySheetFrm(doc);
            frm.ShowDialog();
            selectedSheetList = frm.selectedSheetList;

            using (Transaction tran = new Transaction(doc, "View"))
            {
                tran.Start();
                foreach (ElementId id in selectedSheetList)
                {
                    //try
                    //{
                    ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                    ElementId assemblyInstanceId = sheet.AssociatedAssemblyInstanceId;
                    if (null != sheet)
                    {
                        foreach (AssemblyViewInfo info in assemblyInfoList)
                        {
                            //create schedule
                            ViewSection schedule = AssemblyViewUtils.CreateDetailSection
                                (doc, assemblyInstanceId, info.direction, info.TemplateId, true);
                            schedule.Name = info.Name;
                            //schedule.Title = info.TitleOnSheet;
                            //add to sheet
                            Viewport.Create(doc, sheet.Id, schedule.Id, info.Position);
                        }
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    TaskDialog.Show("r", ex.Message + ex.StackTrace);
                    //    continue;
                    //}
                }
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AssemblyViewCreater
{
    class Utils
    {
        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion

        #region 根据族名称找族下某类型名称ID

        public static ElementId FindTypeIdByFamilyName(Document doc, string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

        }

        #endregion
        
        #region 根据族名称找族下某类型名称ID

        public static void ParameterSet(IList<Reference> collection, string param, Document doc)
        {
            foreach (Reference item in collection)
            {
                Element elem = doc.GetElement(item);
                elem.LookupParameter(param).Set("プレートナット");
            }


            return ;

        }

        #endregion
        
    }
}

```

## AssemblyFrm.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewCreater
{
    public partial class AssemblyFrm : System.Windows.Forms.Form
    {
        private Document _doc;
        private List<string> _assemblyNameList = new List<string>();
        private List<AssemblyInstance> _assemblyList = new List<AssemblyInstance>();

        public List<AssemblyInstance> selectedList = new List<AssemblyInstance>();
        public AssemblyFrm(Document doc)
        {
            _doc = doc;
            // collect assemblyNameList
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            _assemblyList = collector.OfClass(typeof(AssemblyInstance))
                .Cast<AssemblyInstance>().OrderBy(u => u.Name).ToList();
            foreach (var item in _assemblyList)
            {
                _assemblyNameList.Add(item.Name);
            }

            InitializeComponent();
        }

        private void AssemblyFrm_Load(object sender, EventArgs e)
        {
            cbx_AssemblyList.DataSource = _assemblyNameList;
            //Init();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            selectedList = CollectApplyToAssemblys();
            DialogResult = DialogResult.OK;
            Close();
        }

        private List<AssemblyInstance> CollectApplyToAssemblys()
        {
            List<AssemblyInstance> applyToAssemblys = new List<AssemblyInstance>();
            for (int i = 0; i < cbx_AssemblyList.Items.Count; i++)
            {
                if (cbx_AssemblyList.GetItemChecked(i))
                {
                    applyToAssemblys.Add(_assemblyList[i]);
                }
            }
// ... truncated ...
```

