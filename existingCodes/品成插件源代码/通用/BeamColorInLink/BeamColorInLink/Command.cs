//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;

using Autodesk.Revit.DB.Mechanical;
using System.Xml;
using Autodesk.Revit.UI.Events;
using System.IO;
using System.Windows.Forms;
using RevitUtils;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace BeamColorInLink
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public bool _isShowBeamSize = true;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密

            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            ElementId viewId = doc.ActiveView.Id;

            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Cancelled;
            }
            _isShowBeamSize = sf.IsShowBeamSize;

            ListenUtils listenUtils = new ListenUtils();
            //【1】框选，过滤出梁
            #region 【1】框选，过滤出梁
            IList<Reference> iList;//选取到的链接构件集合
            // UPDATE:26.2.3框选后可按空格键完成框选
            try
            {
                listenUtils.startListen();
                iList = sel.PickObjects(ObjectType.LinkedElement, new LinkBeamFilter(doc), "框选连接构件集合（按空格键完成框选，ESC键取消）");//选取到的链接构件集合
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<FamilyInstance> beamList = new List<FamilyInstance>();//链接梁集合

            int beamnum_Y = 0;
            int beamnum_N = 0;
            foreach (Reference item in iList)
            {
                RevitLinkInstance linkIns = doc.GetElement(item) as RevitLinkInstance;
                Element elem = linkIns.GetLinkDocument().GetElement(item.LinkedElementId);//得到链接构件
                FamilyInstance f = elem as FamilyInstance;
                try
                {
                    if (f.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        beamList.Add(f);
                    }
                }
                catch
                {
                    beamnum_N += 1;
                    continue;
                }
            }
            beamnum_Y = beamList.Count;
            #endregion

            //【2】计算净高
            #region 【2】计算净高
            int num_Done = 0;
            int num_Pass = 0;
            Dictionary<FamilyInstance, double> list = new Dictionary<FamilyInstance, double>();
            List<double> heightList = new List<double>();
            List<BeamInfo> beamInfos = new List<BeamInfo>();
            foreach (FamilyInstance item in beamList)
            {
                try
                {
                    double height =Utils.GetBeamClearHeight(doc, item);//计算梁下净高
                    list.Add(item, height);
                    if (!heightList.Contains(height))
                    {
                        heightList.Add(height);
                    }

                    double b = 0;
                    double h = 0;
                    FamilySymbol familySymbol = doc.GetElement(item.GetTypeId()) as FamilySymbol;
                    foreach (Parameter para in familySymbol.Parameters)
                    {
                        if (para.Definition.Name == "b") b = Convert.ToDouble(para.AsValueString());
                        if (para.Definition.Name == "h") h = Convert.ToDouble(para.AsValueString());
                    }
                    if (height < Properties.Settings.Default.ErrorBeamHigh)
                    {
                        BeamInfo beamInfo = new BeamInfo() { B = b, H = h, BeamId = item.Id, BeamHigh = height };
                        beamInfos.Add(beamInfo);
                    }
                }
                catch
                {
                    num_Pass += 1;
                    continue;
                }
            }
            num_Done = list.Count;

            heightList.Sort();
            string info = "共找到" + beamnum_Y.ToString() + "根梁。" + "\n" + "成功计算" + num_Done.ToString() + "个，跳过" + num_Pass.ToString() +
                "个。\n";
            // + "最低的梁下净高为：" + heightList[0].ToString() + "mm。"
            TaskDialog.Show("提示", info);
            #endregion

            //【3】添加注释文字：在梁上标记净高文字
            #region 【3】添加注释文字
            using (Transaction t = new Transaction(doc, "标记梁净高"))
            {
                t.Start();
                List<TextNote> textList = new List<TextNote>();
                double errorHigh = Properties.Settings.Default.ErrorBeamHigh;
                foreach (KeyValuePair<FamilyInstance, double> kv in list)
                {
                    try
                    {
                        LocationCurve beamLocationCurve = kv.Key.Location as LocationCurve;
                        Line beamLine = beamLocationCurve.Curve as Line;
                        //文字插入的点
                        XYZ point = (beamLine.GetEndPoint(0) + beamLine.GetEndPoint(1)) / 2;

                        TextNoteOptions opts = new TextNoteOptions();
                        opts.HorizontalAlignment = HorizontalTextAlignment.Center;
                        opts.TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);

                        string contextStr = "";
                        if (_isShowBeamSize)
                        {
                            contextStr = GetBeamSize2(kv.Key) + " BL+ " + kv.Value.ToString();
                        }
                        else
                        {
                            contextStr = kv.Value.ToString();
                        }

                        TextNote tn = TextNote.Create(doc, viewId, point, contextStr, opts);
                        var beamInfo = beamInfos.FirstOrDefault(b => b.BeamId == kv.Key.Id);
                        if (beamInfo != null) beamInfos.First(b => b.BeamId == kv.Key.Id).TextNoteId = tn.Id;

                        Color color = GetColorByClearHeight(kv.Value, errorHigh);
                        OverrideGraphicSettings ogs = new OverrideGraphicSettings();
                        ogs.SetProjectionLineColor(color);
                        doc.ActiveView.SetElementOverrides(tn.Id, ogs);

                        MoveRotateToFit(doc, kv.Key, tn);

                    }
                    catch (Exception)
                    {
                        //
                    }
                }
                
                t.Commit();
            }
            #endregion

            ShowWindow showWindow = new ShowWindow();
            beamInfos = beamInfos.OrderBy(x => x.B).ThenBy(y => y.H).ThenBy(z => z.BeamHigh).ToList();
            showWindow.list.ItemsSource = beamInfos;
            showWindow.Title = $"不满足净高(<{Properties.Settings.Default.ErrorBeamHigh}mm)的梁";
            showWindow.Show();

            return Result.Succeeded;
        }

        private Color GetColorByClearHeight(double clearHeight, double errorBeamHigh)
        {
            Color c = null;
            if (clearHeight < errorBeamHigh)
            {
                c = new Color(255, 0, 0);
            }
            else if (errorBeamHigh <= clearHeight && clearHeight < errorBeamHigh + 200)
            {
                c = new Color(255, 140, 140);
            }
            else if (errorBeamHigh + 200 <= clearHeight && clearHeight < errorBeamHigh + 400)
            {
                c = new Color(232, 116, 0);
            }
            else if (errorBeamHigh + 400 <= clearHeight && clearHeight < errorBeamHigh + 600)
            {
                c = new Color(243, 194, 129);
            }
            else
            {
                c = new Color(234, 207, 21);
            }
            return c;
        }
        /// <summary>
        /// 梁尺寸//2021-8-23 BY JL
        /// </summary>
        /// <param name="beamInst"></param>
        /// <returns></returns>
        private string GetBeamSize(FamilyInstance beamInst)
        {
            return beamInst.Name.Split('-').Last().Replace("*", "x");
        }

        private string GetBeamSize2(FamilyInstance beamInst)
        {
            string bstring = "";
            string hstring = "";
            foreach (Parameter p in beamInst.Symbol.Parameters)
            {
                if (p.Definition.Name == "梁宽")
                {
                    bstring = p.AsValueString();
                }
                if (p.Definition.Name == "梁高")
                {
                    hstring = p.AsValueString();
                }
                if (p.Definition.Name == "b" && bstring == "")
                {
                    bstring = p.AsValueString();
                }
                if (p.Definition.Name == "h" && hstring == "")
                {
                    hstring = p.AsValueString();
                }
            }
            return bstring + "x" + hstring;
        }

        /// <summary>
        /// 旋转对齐//2021-8-23 BY JL
        /// </summary>
        /// <param name="beamInst"></param>
        /// <param name="tn"></param>
        private void MoveRotateToFit(Document doc, FamilyInstance beamInst, TextNote tn)
        {
            var curve = (beamInst.Location as LocationCurve).Curve;
            XYZ midPt = (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2.0;
            XYZ beamDir = XYZ.Zero;
            if (curve is Line)
            {
                beamDir = (curve as Line).Direction.Normalize();
            }
            else
            {
                beamDir = (curve.GetEndPoint(0) - curve.GetEndPoint(1)).Normalize();
            }
            double angle = XYZ.BasisX.AngleTo(beamDir);
            var axis = Line.CreateBound(tn.Coord, tn.Coord + XYZ.BasisZ);

            //旋转
            if (angle > 0.0001)
            {
                // 利用XYZ.BasisX预旋转
                Transform tran = Transform.CreateRotation(XYZ.BasisZ, angle);
                XYZ preRotate = tran.OfVector(XYZ.BasisX);
                if (preRotate.IsAlmostEqualTo(beamDir)
                 || preRotate.IsAlmostEqualTo(beamDir.Negate()))
                {
                    ElementTransformUtils.RotateElement(
                    doc, tn.Id, axis, angle);
                }
                else
                {
                    ElementTransformUtils.RotateElement(
                    doc, tn.Id, axis, angle * -1.0);
                }
            }

            //移动
            ElementTransformUtils.MoveElement(
                doc, tn.Id, tn.UpDirection * 220.0/ 304.8);
        }

    }
    public class LinkBeamFilter : ISelectionFilter
    {
        readonly Document Doc;
        public LinkBeamFilter(Document doc)
        {
            Doc = doc;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            if (Doc.GetElement(reference) is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                Element linkElem = linkDoc.GetElement(reference.LinkedElementId);
                if (linkElem.Category.Id.IntegerValue == -2001320) return true;
            }
            return false;
        }
    }
    public class BeamInfo
    {
        public double B { get; set; }
        public double H { get; set; }
        public ElementId BeamId { get; set; }
        public double BeamHigh { get; set; }
        public ElementId TextNoteId { get; set; }
    }
}