using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDimensionText
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            using (Transaction t = new Transaction(doc, "change dimension text"))
            {
                t.Start();
                List<Dimension> dimensions = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Dimensions).OfClass(typeof(Dimension)).Cast<Dimension>().ToList();
                foreach (var item in dimensions)
                {
                    DimensionSegmentArray dimensionSegmentArray = item.Segments;
                    foreach (DimensionSegment segment in dimensionSegmentArray)
                    {
                        if (segment.Below == "Ø36 TEMINATOR ANCHOR")
                        {
                            segment.Below = "36mmØ HEADED BARS";
                        }
                    }
                }
                t.Commit();
            }
            return Result.Succeeded; 
        }
    }
}
