using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingFloor
{
    public class HiddenCADCommand : IExternalEventHandler
    {
        public List<Category> categories = new List<Category>();
        public Category category { get; set; }
        public bool hide { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            string info = "";
            if (hide)
            {
                info = "隐藏";
            }
            else
            {
                info = "显示";
            }
            using (Transaction t = new Transaction(doc,$"{info}选中CAD图层"))
            {
                t.Start();
                if (hide)
                {
                    doc.ActiveView.SetCategoryHidden(category.Id, hide);
                }
                else
                {
                    foreach (Category c in categories)
                    {
                        doc.ActiveView.SetCategoryHidden(c.Id, hide);
                    }
                }
                t.Commit();
            }
        }

        public string GetName()
        {
            return "HiddenCADCommand";
        }
    }
}
