using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoorReview
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Assembly assembly = Assembly.UnsafeLoadFrom(@"\\192.168.0.251\在制项目2\品成Revit插件商店\品成Revit插件商店\108楼板翻模\FlippingFloor.dll");

            //Type commandType = assembly.GetTypes().FirstOrDefault(t => typeof(IExternalCommand).IsAssignableFrom(t) && !t.IsAbstract && t.FullName == "FlippingFloor.Command");
            //IExternalCommand exCommand = (IExternalCommand)Activator.CreateInstance(commandType);
            //Result result = exCommand.Execute(commandData, ref message, elements);

            //Type type = assembly.GetType("NewBTStore.UpdateCmd");
            //string info = "";
            //var types = assembly.GetTypes();
            //foreach (var item in types)
            //{
            //    object instance2;

            //    var propInfos = item.GetMethods();
            //    info += item.Name + "\n";
            //    foreach (var item2 in propInfos)
            //    {
            //        info += item2.Name + "||";
            //    }
            //    info += "\n";
            //}

            //TaskDialog.Show("revit", info);
            //var instance = Activator.CreateInstance(type);
            //var method = type.GetMethod("Execute", new Type[] { typeof(ExternalCommandData), typeof(string), typeof(ElementSet) });
            //Result result2 = (Result)(method?.Invoke(instance, new object[] { commandData, message, elements }));




            //return Result.Succeeded;

            ScopeWindow scopeWindow = new ScopeWindow();
            scopeWindow.ShowDialog();
            if (scopeWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            double scope = scopeWindow.Scope / 304.8;
            //TaskDialog.Show("revti", scope.ToString());

            var textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();

            var doors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().ToList();
            List<DoorInfo> doorInfos = new List<DoorInfo>();
            // HACK: 25.10.30 新增完整文本注释与不完整文字注释选项

            if (scopeWindow.Full)
            {
                foreach (var door in doors)
                {
                    // 判断文字注释是否与门方向平行，误差为0.18（10°）
                    //var textNote = textNotes.Where(x => IsParallel(x.BaseDirection, door as FamilyInstance, 0.18)).Where(x => (x.Coord + XYZ.BasisZ.Negate() * x.Coord.Z).DistanceTo((GetPoint(door) + XYZ.BasisZ.Negate() * GetPoint(door).Z)) < 5000 / 304.8).OrderBy(t => t.Coord.DistanceTo(GetPoint(door))).FirstOrDefault(); //判断距离需在同一Z平面上
                    var textNote = textNotes.Where(x => IsParallel(x.BaseDirection, door as FamilyInstance, 0.18)).Where(x => (x.Coord + XYZ.BasisZ.Negate() * x.Coord.Z).DistanceTo((GetPoint(door) + XYZ.BasisZ.Negate() * GetPoint(door).Z)) < scope).OrderBy(t => t.Coord.DistanceTo(GetPoint(door))).FirstOrDefault(); //判断距离需在同一Z平面上
                    if (textNote == null)
                    {
                        doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "未知", IsBold = true, TextColor = "yellow", FamilySymbol = door.Symbol });
                        continue;
                    }
                    string text = textNote.Text;
                    text = text.Replace("\r", "");
                    text = text.Replace("\n", "");
                    string num = Regex.Replace(text, "[^0-9]+", "");
                    if (num.Count() != 4)
                    {
                        doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "未知", NoteText = text, IsBold = true, TextColor = "yellow", FamilySymbol = door.Symbol });
                        continue;
                    }

                    double noteWidth = (Convert.ToDouble(num[0].ToString() + num[1].ToString()) * 100) / 304.8;
                    if (text.Contains("a")) noteWidth += 50 / 304.8;
                    double noteHeight = (Convert.ToDouble(num[2].ToString() + num[3].ToString()) * 100) / 304.8;
                    if (text.Contains("b")) noteHeight += 50 / 304.8;
                    double doorWidth = door.Symbol.get_Parameter(BuiltInParameter.FURNITURE_WIDTH).AsDouble();
                    double doorHeight = door.Symbol.get_Parameter(BuiltInParameter.FAMILY_HEIGHT_PARAM).AsDouble();

                    if (Math.Abs(noteWidth - doorWidth) < 0.001 && Math.Abs(noteHeight - doorHeight) < 0.001) doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "是", NoteText = text, FamilySymbol = door.Symbol });
                    else doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "否", NoteText = text, IsBold = true, TextColor = "red", TextBackColor = "blue", FamilySymbol = door.Symbol });
                    //c++;
                    //if (c > 50) break;
                }
            }
            else
            {
                List<TextNote> textContainsChinese;
                List<TextNote> textWithOutChinese;
                //对文字注释进行分类
                TextClassification(out textContainsChinese, out textWithOutChinese, textNotes);
                //寻找中文文本附近的文字
                Dictionary<ElementId, List<ElementId>> keyValuePairs = GetTextGroup(textContainsChinese, textWithOutChinese);
                //将文字正确排序，获得一个完整的文字信息
                List<TextNoteInfo> textNoteInfos = SortText(keyValuePairs, doc);

                foreach (var door in doors)
                {
                    // 判断文字注释是否与门方向平行，误差为0.18（10°）
                    //var textNote = textNotes.Where(x => IsParallel(x.BaseDirection, door as FamilyInstance, 0.18)).Where(x => (x.Coord + XYZ.BasisZ.Negate() * x.Coord.Z).DistanceTo((GetPoint(door) + XYZ.BasisZ.Negate() * GetPoint(door).Z)) < 5000 / 304.8).OrderBy(t => t.Coord.DistanceTo(GetPoint(door))).FirstOrDefault(); //判断距离需在同一Z平面上
                    var textNote = textNoteInfos.Where(x => IsParallel((x.ChineseTextId.GetElement(doc) as TextNote).BaseDirection, door, 0.18)).Where(x => (x.CreatePoint + XYZ.BasisZ.Negate() * x.CreatePoint.Z).DistanceTo((GetPoint(door) + XYZ.BasisZ.Negate() * GetPoint(door).Z)) < scope).OrderBy(t => t.CreatePoint.DistanceTo(GetPoint(door))).FirstOrDefault(); //判断距离需在同一Z平面上
                    if (textNote == null)
                    {
                        doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "未知", IsBold = true, TextColor = "yellow", FamilySymbol = door.Symbol });
                        continue;
                    }
                    string text = textNote.FullText;
                    text = text.Replace("\r", "");
                    text = text.Replace("\n", "");
                    string num = Regex.Replace(text, "[^0-9]+", "");
                    if (num.Count() != 4)
                    {
                        doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "未知", NoteText = text, IsBold = true, TextColor = "yellow", FamilySymbol = door.Symbol });
                        continue;
                    }

                    double noteWidth = (Convert.ToDouble(num[0].ToString() + num[1].ToString()) * 100) / 304.8;
                    double noteHeight = (Convert.ToDouble(num[2].ToString() + num[3].ToString()) * 100) / 304.8;
                    double doorWidth = door.Symbol.get_Parameter(BuiltInParameter.FURNITURE_WIDTH).AsDouble();
                    double doorHeight = door.Symbol.get_Parameter(BuiltInParameter.FAMILY_HEIGHT_PARAM).AsDouble();

                    if (Math.Abs(noteWidth - doorWidth) < 0.001 && Math.Abs(noteHeight - doorHeight) < 0.001) doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "是", NoteText = text, FamilySymbol = door.Symbol });
                    else doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "否", NoteText = text, IsBold = true, TextColor = "red", TextBackColor = "blue", FamilySymbol = door.Symbol });
                }
            }
            
            doorInfos = doorInfos.OrderBy(x => x.DoorName).ToList();

            MainWindow window = new MainWindow(uidoc);
            window.list.ItemsSource = doorInfos;
            window.Show();


            return Result.Succeeded;
        }
        private XYZ GetPoint(Element element)
        {
            return (element.Location as LocationPoint).Point;
        }
        private bool IsParallel(XYZ direction, Instance elem, double tolerance)
        {
            bool result = false;
            if (elem.Location == null) return result;
            if (elem.Location is LocationPoint locationPoint)
            {
                XYZ elemDir = elem.GetTransform().OfVector(XYZ.BasisX);
                if (elemDir.IsAlmostEqualTo(direction, tolerance) || elemDir.IsAlmostEqualTo(direction.Negate(), 0.18))
                {
                    result = true;
                }
            }

            return result;
        }
        private void TextClassification(out List<TextNote> textContainsChinese, out List<TextNote> textWithOutChinese, List<TextNote> textNotes)
        {
            textContainsChinese = new List<TextNote>();
            textWithOutChinese = new List<TextNote>();
            foreach (var item in textNotes)
            {
                string input = item.Text;

                bool containsChinese = Regex.IsMatch(input, @"[\u4e00-\u9fff]");
                if (containsChinese)
                {
                    textContainsChinese.Add(item);
                }
                else
                {
                    textWithOutChinese.Add(item);
                }
            }
        }
        private Dictionary<ElementId, List<ElementId>> GetTextGroup(List<TextNote> textContainsChinese, List<TextNote> textWithOutChinese)
        {
            Dictionary<ElementId, List<ElementId>> keyValuePairs = new Dictionary<ElementId, List<ElementId>>();

            foreach (var item in textContainsChinese)
            {
                List<ElementId> textNoteIds = new List<ElementId>();
                int count = textWithOutChinese.Count;
                for (int i = 0; i < textWithOutChinese.Count; i++)
                {
                    if (item.Coord.DistanceTo(textWithOutChinese[i].Coord) < 1000 / 304.8)
                    {
                        textNoteIds.Add(textWithOutChinese[i].Id);
                        //textWithOutChinese.Remove(textWithOutChinese[i]);
                    }
                    if (textNoteIds.Count == 2) break;
                }
                if (textNoteIds.Count == 1 || textNoteIds.Count == 2) keyValuePairs.Add(item.Id, textNoteIds);
            }
            return keyValuePairs;
        }
        private List<TextNoteInfo> SortText(Dictionary<ElementId, List<ElementId>> keyValuePairs, Document doc)
        {
            List<TextNoteInfo> textNoteInfos = new List<TextNoteInfo>();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.Count == 1)
                {
                    string fullText = (item.Key.GetElement(doc) as TextNote).Text +
                        (item.Value.First().GetElement(doc) as TextNote).Text;
                    fullText = fullText.Replace("\n", "");
                    fullText = fullText.Replace("\r", "");
                    fullText = fullText.Replace(" ", "");
                    XYZ point = (item.Key.GetElement(doc) as TextNote).Coord.Add((item.Value.First().GetElement(doc) as TextNote).Coord) / 2;
                    TextNoteInfo textNoteInfo = new TextNoteInfo(item.Key, fullText, point);
                    textNoteInfos.Add(textNoteInfo);
                }
                else//item.Value.Count == 2
                {
                    TextNote textNote = item.Key.GetElement(doc) as TextNote;
                    TextNote textNote1 = item.Value.First().GetElement(doc) as TextNote;
                    TextNote textNote2 = item.Value.Last().GetElement(doc) as TextNote;
                    string text1 = textNote1.Text;
                    bool containsNumber = Regex.IsMatch(text1, @"\d");
                    string fullText;
                    if (containsNumber)
                    {
                        fullText = textNote2.Text + textNote.Text + textNote1.Text;
                    }
                    else
                    {
                        fullText = textNote1.Text + textNote.Text + textNote2.Text;
                    }
                    fullText = fullText.Replace("\n", "");
                    fullText = fullText.Replace("\r", "");
                    fullText = fullText.Replace(" ", "");
                    TextNoteInfo textNoteInfo = new TextNoteInfo(item.Key, fullText, textNote.Coord);
                    textNoteInfos.Add(textNoteInfo);
                }
            }

            return textNoteInfos;
        }
    }
    public class TextNoteInfo
    {
        public TextNoteInfo() { }
        public TextNoteInfo(ElementId chineseTextId, string fullText, XYZ createPoint)
        {
            ChineseTextId = chineseTextId;
            FullText = fullText;
            CreatePoint = createPoint;
        }
        // 包含中文的文字
        public ElementId ChineseTextId { get; set; }
        // 文字信息
        public string FullText { get; set; }
        // 文字注释中心坐标点
        public XYZ CreatePoint { get; set; }
        // 宿主墙
        public Wall HostWall { get; set; }
        // 门弧中心点坐标
        public XYZ ArcPoint { get; set; }
        // 门方向（facing）
        public XYZ FacingDir { get; set; }
        // 面方向（hand）
        public XYZ HandDir { get; set; }
        // 弧线数量
        public int ArcCount { get; set; } = 0;
        // 若数量为2，判断弧线半径是否相同
        public bool? SameArc { get; set; } = null;
    }
    public static class Extension
    {
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
        public static Element GetElement(this ElementId elementId, Document doc)
        {
            return doc.GetElement(elementId);
        }
    }
}
