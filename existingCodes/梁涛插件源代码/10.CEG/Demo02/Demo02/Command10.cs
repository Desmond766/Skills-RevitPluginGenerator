using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command10 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new SpecializedEquipmentFilter(), "Choose a dedicated device");
            XYZ point = uIDoc.Selection.PickPoint();
            FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            string para = familyInstance.LookupParameter("IDENTITY_DESCRIPTION").AsString();
            string text = "IDENTITY_DESCRIPTION : " + para;


            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字")
                {
                    textNoteType = textType;
                    break;
                }
            }

            View view = uIDoc.ActiveView;
            using (Transaction t = new Transaction(doc, "Creating Text Annotations"))
            {
                t.Start();
                TextNote textNote = TextNote.Create(doc, view.Id, point, text, textNoteType.Id);
                textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
                textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
                view.Document.Regenerate();
                t.Commit();
            }
            return Result.Succeeded;
        }
    }
}
