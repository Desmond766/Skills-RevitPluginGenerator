using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace BatchUnJoin
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            var cutCategoryCol = new FilteredElementCollector(doc).WhereElementIsNotElementType()
                .Where(x => JoinGeometryUtils.GetJoinedElements(doc, x).Count() > 0)
                .GroupBy(z => z.Category.Name)
                .Select(y => y.First().Category)
                .Distinct().ToList();
            List<CategoryInfo> categoryInfos = new List<CategoryInfo>();
            foreach ( var c in cutCategoryCol )
            {
                categoryInfos.Add(new CategoryInfo() { CategoryId = c.Id, CategoryName = c.Name });
            }

            MainWindow mainWindow = new MainWindow(categoryInfos);
            mainWindow.ShowDialog();

            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            bool isCurrentView = mainWindow.IsCurrentView;
            LogicalOrFilter orFilter = mainWindow.OrFilter;
            bool unJoinByCategory = mainWindow.UnJoinByCategory;

            ListenUtils listenUtils = new ListenUtils();
            List<Element> unJoinElements = new List<Element>();
            if (unJoinByCategory)
            {
                if (isCurrentView) unJoinElements = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).WhereElementIsNotElementType().Where(e => JoinGeometryUtils.GetJoinedElements(doc, e).Count > 0).ToList();
                else unJoinElements = new FilteredElementCollector(doc).WherePasses(orFilter).WhereElementIsNotElementType().Where(e => JoinGeometryUtils.GetJoinedElements(doc, e).Count > 0).ToList();
            }
            else
            {
                try
                {
                    listenUtils.startListen();
                    unJoinElements = sel.PickObjects(ObjectType.Element, new UnJoinFilter(doc), "选择要取消连接的元素（按空格键完成框选，ESC键取消）").Select(re => doc.GetElement(re)).ToList();
                    listenUtils.stopListen();
                }
                catch (OperationCanceledException)
                {
                    listenUtils.stopListen();
                    MessageBox.Show("已取消操作");
                    return Result.Cancelled;
                }
            }

            using (TransactionGroup Tg = new TransactionGroup(doc, "批量取消连接"))
            {
                Tg.Start();

                foreach (var elem in unJoinElements)
                {
                    using (Transaction t = new Transaction(doc, "取消连接"))
                    {
                        t.Start();

                        var elemIds = JoinGeometryUtils.GetJoinedElements(doc, elem).ToList();
                        foreach (var id in elemIds)
                        {
                            JoinGeometryUtils.UnjoinGeometry(doc, elem, doc.GetElement(id));
                        }

                        t.Commit();
                    }
                }

                Tg.Assimilate();
            }

            return Result.Succeeded;
        }
    }
    public class CategoryInfo : INotifyPropertyChanged
    {
        private ElementId _categoryId;
        public ElementId CategoryId { get => _categoryId; set { _categoryId = value; OnPropertyChanged(nameof(CategoryId)); } }
        private string _categoryName;
        public string CategoryName { get => _categoryName; set { _categoryName = value; OnPropertyChanged(nameof(CategoryName)); } }
        private bool _selectCategory = false;
        public bool SelectCategory { get => _selectCategory; set { _selectCategory = value; OnPropertyChanged(nameof(SelectCategory)); } }
        private string _buttonName = "+";
        public string ButtonName { get { return _buttonName; } set { _buttonName = value; OnPropertyChanged(nameof(ButtonName)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class UnJoinFilter : ISelectionFilter
    {
        private Document Doc;
        public UnJoinFilter(Document doc)
        {
            Doc = doc;
        }
        public bool AllowElement(Element elem)
        {
            if (JoinGeometryUtils.GetJoinedElements(Doc, elem).Count > 0)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
