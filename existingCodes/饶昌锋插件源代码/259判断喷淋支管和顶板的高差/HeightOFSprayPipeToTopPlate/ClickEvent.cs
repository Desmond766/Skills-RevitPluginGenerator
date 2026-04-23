using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HeightOFSprayPipeToTopPlate
{
    public class ClickEvent : IExternalEventHandler
    {
        private  View view;
        private  string inputValue;
        List<string> ELemCategorys = new List<string>();
        public ClickEvent(View view, List<string> elemCategorys)
        {
            this.view = view;
            this.ELemCategorys = elemCategorys;
        }

        public string InputValue { get => inputValue; set => inputValue = value; }

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            if (ELemCategorys.Count == 0) return;
            string trName = ELemCategorys.Aggregate((a, b) => a + "/" + b);
            //string trName = "ss";
            using (Transaction transaction = new Transaction(doc, $"{trName}与顶板的高差"))
            {

                try
                {
                    transaction.Start();
                    CalculatedHeightDifference.DelAllTextNote(doc);
                    CalculatedHeightDifference.GetHeightDifference(doc, view, InputValue, ELemCategorys);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    TaskDialog.Show("报错", ex.ToString());
                }
            }
        }

        public string GetName()
        {
            return "";
        }
    }
}
