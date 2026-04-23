using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTubeHangerNotes
{
    public class AddIndependentTag
    {
        public static void Add(Document doc, Element elem, View view)
        {
            LocationPoint locationPoint = elem.Location as LocationPoint;
            XYZ point = locationPoint.Point;
            ParameterSet parameters = elem.Parameters;
            string materId = null;
            string width = null;
            string height = null;
            foreach (Parameter param in parameters)
            {
                if (param.Definition.Name == "管道公称直径")
                {
                    width = param.AsValueString();
                }
                if (param.Definition.Name == "H")
                {
                    height = param.AsValueString();
                }

            }
            string text = "";
            //TaskDialog.Show("Asdas", materId);
            text ="DN"+ int.Parse(width) + " H≈" + height;
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                // 检查视图是否为剖面视图
                // 获取 ViewFamilyType
                //ViewFamilyType familyType = doc.GetElement(view.GetTypeId()) as ViewFamilyType;
                if (textType?.FamilyName == "文字")
                {
                    textNoteType = textType;
                    break;
                }
            }
            //if (flag)
            //{
            //    text.show();
            //}
            TextNote textNote = TextNote.Create(doc, view.Id, point, text, textNoteType.Id);
            //if (flag)
            //{
            //    textNote.Text.show();
            //    flag = false;
            //}
            //移动文本 使得文本下边中心对其元素中点
            //TextNoteType textNoteType = textNote.TextNoteType;
            //textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
            textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
            view.Document.Regenerate();
            double scale = view.Scale;
            double textNoteWidth = textNote.Width * scale;
            //double textNoteWidth = textNote.Width;
            //double textNoteHeight = boundingBox.Max.Y - boundingBox.Min.Y;

            //string height = textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).AsValueString();
            // 计算偏移量，使对齐点为文本的下边中心
            XYZ offset = new XYZ(-textNoteWidth / 2, 1.25, 0);

            // 移动文本注释的位置
            ElementTransformUtils.MoveElement(doc, textNote.Id, offset);
            BoundingBoxXYZ boundingBox = textNote.get_BoundingBox(view);
            double rota = locationPoint.Rotation;

            Line axis = Line.CreateBound(locationPoint.Point, locationPoint.Point + new XYZ(0, 0, 1));
            if (elem.Name == "风管法兰吊架-上固定" || elem.Name == "风管法兰吊架-下固定")
            {

                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota + (Math.PI / 2));
            }
            else
            {
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota);
            }
            while (true)
            {
                if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y > locationPoint.Point.Y)
                {
                    break;
                }
                else if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y == locationPoint.Point.Y)
                {
                    if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).X < locationPoint.Point.X)
                    {
                        break;
                    }
                }
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, Math.PI);
            }
        }
    }
}
