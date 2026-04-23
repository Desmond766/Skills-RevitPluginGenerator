using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitUtils
{
    public class CreateUtils
    {
        /// <summary>
        /// 创建文字注释（内部无事务）
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="text">文本内容</param>
        /// <param name="centerP">创建点</param>
        /// <param name="elem">元素（用来校对文字注释旋转角度）</param>
        public static void CreateTextNote(UIDocument uidoc, string text, XYZ centerP, Element elem)
        {
            Document doc = uidoc.Document;
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
            View view = uidoc.ActiveView;
            TextNote textNote = TextNote.Create(doc, view.Id, centerP, text, textNoteType.Id);

            //移动文本 使得文本下边中心对其元素中点
            textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
            textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
            view.Document.Regenerate();
            double scale = view.Scale;
            double textNoteWidth = textNote.Width * scale;

            // 计算偏移量，使对齐点为文本的下边中心
            XYZ offset = new XYZ(-textNoteWidth / 2, 1.25, 0);

            // 移动文本注释的位置
            ElementTransformUtils.MoveElement(doc, textNote.Id, offset);

            LocationPoint locationPoint = elem.Location as LocationPoint;
            double rota = locationPoint.Rotation;

            Line axis = Line.CreateBound(centerP, centerP + new XYZ(0, 0, 1));
            //if (elem.Name == "风管法兰吊架-上固定" || elem.Name == "风管法兰吊架-下固定" || elem.Name.Contains("风管法兰抗震吊架"))
            //{

            //    ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota + (Math.PI / 2));
            //}
            //else
            //{
            //    ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota);
            //}
            ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota);
            return;
            while (true)
            {
                if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y > centerP.Y)
                {
                    break;
                }
                else if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y == centerP.Y)
                {
                    if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).X < centerP.X)
                    {
                        break;
                    }
                }
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, Math.PI);
            }
        }
    }
}
