using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command11 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            IList<Reference> references = uIDoc.Selection.PickObjects(ObjectType.Element, new GridFilter(), "Box select all grids to be operated on");
            UserControl06 userControl06 = new UserControl06();
            userControl06.ShowDialog();
            if (userControl06.cancel)
            {
                return Result.Cancelled;
            }
            using (Transaction t = new Transaction(doc, "Operation number, 2D or 3D"))
            {
                t.Start();
                foreach (Reference reference in references)
                {
                    Grid grid = doc.GetElement(reference) as Grid;
                    DatumEnds datumEnds;
                    if (userControl06.direction.IsChecked == true)
                    {
                        datumEnds = DatumEnds.End0;
                    }
                    else
                    {
                        datumEnds = DatumEnds.End1;
                    }
                    if (userControl06.hideNum.IsChecked == true)
                    {
                        //grid.HideBubbleInView(DatumEnds.End0, uIDoc.ActiveGraphicalView);
                        grid.HideBubbleInView(datumEnds, uIDoc.ActiveGraphicalView);
                        if (userControl06.twoD.IsChecked == true)
                        {
                            grid.SetDatumExtentType(datumEnds, uIDoc.ActiveGraphicalView, DatumExtentType.ViewSpecific);
                        }
                        else
                        {
                            grid.SetDatumExtentType(datumEnds, uIDoc.ActiveGraphicalView, DatumExtentType.Model);
                        }
                    }
                    else
                    {
                        //grid.ShowBubbleInView(DatumEnds.End0, uIDoc.ActiveGraphicalView);
                        grid.ShowBubbleInView(datumEnds, uIDoc.ActiveGraphicalView);
                        if (userControl06.twoD.IsChecked == true)
                        {
                            grid.SetDatumExtentType(datumEnds, uIDoc.ActiveGraphicalView, DatumExtentType.ViewSpecific);
                        }
                        else
                        {
                            grid.SetDatumExtentType(datumEnds, uIDoc.ActiveGraphicalView, DatumExtentType.Model);
                        }
                    }
                }
                t.Commit();
            }
            return Result.Succeeded;
        }
    }
    public class GridFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue.Equals(-2000220))
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
