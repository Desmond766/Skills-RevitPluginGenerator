using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DimensionChecking
{
    public static class Utils
    {
        public static FamilySymbol GetTitleOnSheet(Document doc, ViewSheet vs)
        {
            //https://forums.autodesk.com/t5/revit-api-forum/how-to-get-a-viewsheet-s-title-block/td-p/5430779

            // 1. to collect all objects in the view
            IList<Element> m_alltitleblocks = new List<Element>();
            IList<Element> m_elementsOnSheet = new List<Element>();
            FamilySymbol myTitleBlock = null;

            foreach (Element e in new FilteredElementCollector(doc).OwnedByView(vs.Id))
            {
                m_elementsOnSheet.Add(e);
            }

            // 2. then Get all the titleblocks in the document

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol));
            collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

            m_alltitleblocks = collector.ToElements();

            // 3. Then I simply went through the elements on view untill i found the title sheet:

            foreach (Element el in m_elementsOnSheet)
            {
                foreach (FamilySymbol fs in m_alltitleblocks)
                {
                    if (el.GetTypeId().IntegerValue == fs.Id.IntegerValue)
                    {
                        myTitleBlock = fs;
                        break;
                    }
                }
            }

            return myTitleBlock;

        }

        public static FamilyInstance GetTitleInstanceOnSheet(Document doc, ViewSheet vs)
        {
            //https://forums.autodesk.com/t5/revit-api-forum/how-to-get-a-viewsheet-s-title-block/td-p/5430779

            // 1. to collect all objects in the view
            IList<Element> m_alltitleblocks = new List<Element>();
            IList<Element> m_elementsOnSheet = new List<Element>();
            FamilyInstance myTitleBlock = null;

            foreach (Element e in new FilteredElementCollector(doc).OwnedByView(vs.Id))
            {
                m_elementsOnSheet.Add(e);
            }

            // 2. then Get all the titleblocks in the document

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol));
            collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

            m_alltitleblocks = collector.ToElements();

            // 3. Then I simply went through the elements on view untill i found the title sheet:

            foreach (Element el in m_elementsOnSheet)
            {
                foreach (FamilySymbol fs in m_alltitleblocks)
                {
                    if (el.GetTypeId().IntegerValue == fs.Id.IntegerValue)
                    {
                        myTitleBlock = el as FamilyInstance;
                        break;
                    }
                }
            }

            return myTitleBlock;

        }

        public static List<View> GetViewOnSheet(Document doc, ViewSheet vs)
        {
            List<View> viewList = new List<View>();
            foreach (ElementId id in vs.GetAllViewports())
            {
                Viewport vp = doc.GetElement(id) as Viewport;
                View v = doc.GetElement(vp.ViewId) as View;
                viewList.Add(v);
            }
            return viewList;
        }
        public static string GetParameterByName(Element elem, string parameterName)
        {
            var parameterList = elem.GetParameters(parameterName);
            if (parameterList.Count > 0)
            {
                if (!string.IsNullOrEmpty(parameterList.First().AsValueString()))
                {
                    return parameterList.First().AsValueString();
                }
                if (!string.IsNullOrEmpty(parameterList.First().AsString()))
                {
                    return parameterList.First().AsString();
                }
            }
            return null;
        }

        #region 循环遍历找到element的所有Solids
        //https://blog.csdn.net/lushibi/article/details/45825291
        //Options.ComputeReferences必须为true，否是拿到的几何体的Reference都将是null
        //如果遍历GeometryElement的时候，碰到GeometryInstance，那么需要调用GetSymbolGeometry，
        //获取更多几何体，而不能调用GetInstanceGeometry，因为后者得到的几何体也是无法创建Dimension的
        static public List<Solid> GetElementSymbolSolids(Element elem, Options opt = null)
        {
            if (null == elem)
            {
                return null;
            }
            if (null == opt)
                opt = new Options();
            List<Solid> solids = new List<Solid>();
            try
            {
                var geoElem = elem.get_Geometry(opt);
                foreach (var go in geoElem)
                {
                    solids.AddRange(GetSymbolSolids(go));
                }
            }
            catch (Exception ex)
            {
                // In Revit, sometime get the geometry will failed.
                string error = ex.Message;
            }
            return solids;
        }

        static public List<Solid> GetSymbolSolids(GeometryObject gObj)
        {
            List<Solid> solids = new List<Solid>();
            if (gObj is Solid) // already solid
            {
                Solid solid = gObj as Solid;
                if (solid.Faces.Size > 0 && solid.Volume > 0) // some solid may have not any face?!
                    solids.Add(gObj as Solid);
            }
            else if (gObj is GeometryInstance) // find solids from GeometrySymbol
            {
                //var geoElem = (gObj as GeometryInstance).GetInstanceGeometry();
                var geoElem = (gObj as GeometryInstance).GetSymbolGeometry();
                foreach (var go in geoElem)
                {
                    solids.AddRange(GetSymbolSolids(go));
                }
            }
            else if (gObj is GeometryElement) // find solids from GeometryElement, this will not happen at all?
            {
                var geoElem = (gObj as GeometryElement);
                foreach (var go in geoElem)
                {
                    solids.AddRange(GetSymbolSolids(go));
                }
            }
            return solids;
        }


        static public List<Solid> GetElementInstanceSolids(Element elem, Options opt = null)
        {
            if (null == elem)
            {
                return null;
            }
            if (null == opt)
                opt = new Options();
            List<Solid> solids = new List<Solid>();
            try
            {
                var geoElem = elem.get_Geometry(opt);
                foreach (var go in geoElem)
                {
                    solids.AddRange(GetInstanceSolids(go));
                }
            }
            catch (Exception ex)
            {
                // In Revit, sometime get the geometry will failed.
                string error = ex.Message;
            }
            return solids;
        }

        static public List<Solid> GetInstanceSolids(GeometryObject gObj)
        {
            List<Solid> solids = new List<Solid>();
            if (gObj is Solid) // already solid
            {
                Solid solid = gObj as Solid;
                if (solid.Faces.Size > 0 && solid.Volume > 0) // some solid may have not any face?!
                    solids.Add(gObj as Solid);
            }
            else if (gObj is GeometryInstance) // find solids from GeometrySymbol
            {
                //var geoElem = (gObj as GeometryInstance).GetInstanceGeometry();
                var geoElem = (gObj as GeometryInstance).GetInstanceGeometry();
                foreach (var go in geoElem)
                {
                    solids.AddRange(GetInstanceSolids(go));
                }
            }
            else if (gObj is GeometryElement) // find solids from GeometryElement, this will not happen at all?
            {
                var geoElem = (gObj as GeometryElement);
                foreach (var go in geoElem)
                {
                    solids.AddRange(GetInstanceSolids(go));
                }
            }
            return solids;
        }

        #endregion

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static ModelCurve CreateModelLine(Document doc, XYZ p1, XYZ p2)
        {
            using (var line = Line.CreateBound(p1, p2))
            {
                using (var skPlane = SketchPlane.Create(doc, ToPlane(p1, p2)))
                {
                    if (doc.IsFamilyDocument)
                    {
                        return doc.FamilyCreate.NewModelCurve(line, skPlane);
                    }
                    else
                    {
                        return doc.Create.NewModelCurve(line, skPlane);
                    }
                }
            }
        }
        #endregion

        #region 点所在平面
        /// <summary>
        /// 点所在平面
        /// </summary>
        /// <param name="point"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static Autodesk.Revit.DB.Plane ToPlane(XYZ point, XYZ other)
        {
            var v = other - point;
            if (v.Normalize().IsAlmostEqualTo(XYZ.BasisX)
                || v.Normalize().IsAlmostEqualTo(XYZ.BasisX.Negate()))
            {
                return Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(XYZ.BasisZ, point);
            }
            var angle = v.AngleTo(XYZ.BasisX);
            var norm = v.CrossProduct(XYZ.BasisX).Normalize();

            if (Math.Abs(angle - 0) < 1e-4)
            {
                angle = v.AngleTo(XYZ.BasisY);
                norm = v.CrossProduct(XYZ.BasisY).Normalize();
            }

            if (Math.Abs(angle - 0) < 1e-4)
            {
                angle = v.AngleTo(XYZ.BasisZ);
                norm = v.CrossProduct(XYZ.BasisZ).Normalize();
            }
            //return new Autodesk.Revit.DB.Plane(norm, point);
            return Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(norm, point);//2018
        }
        #endregion

        //public static AutoTicketingHelper.PrecastCategory CheckCEGCategory(FamilyInstance instance)
        //{
        //    AutoTicketingHelper.PrecastCategory cegCategory = AutoTicketingHelper.PrecastCategory.UNKNOW;
        //    string categoryStr = Utils.GetParameterByName(instance.Symbol, "CONSTRUCTION_PRODUCT");
        //    switch (categoryStr)
        //    {
        //        case "TGIRDER":
        //            cegCategory = AutoTicketingHelper.PrecastCategory.ITBEAM;
        //            break;
        //        case "SPANDREL NONBEARING":
        //            cegCategory = AutoTicketingHelper.PrecastCategory.SPANDREL;
        //            break;
        //        case "COLUMN":
        //            cegCategory = AutoTicketingHelper.PrecastCategory.COLUMN;
        //            break;
        //        case "DOUBLE TEE":
        //            cegCategory = AutoTicketingHelper.PrecastCategory.DOUBLETEE;
        //            break;
        //        case "WALL PANEL HORIZONTAL":
        //            cegCategory = AutoTicketingHelper.PrecastCategory.WALL;
        //            break;
        //        case "Z-STAIR":
        //            cegCategory = AutoTicketingHelper.PrecastCategory.STAIR;
        //            break;
        //        default:
        //            cegCategory = AutoTicketingHelper.PrecastCategory.UNKNOW;
        //            break;
        //    }
        //    return cegCategory;
        //}

        public static FamilySymbol GetFamilySymbol(Document doc, string familyName, string typeName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            var list = collector.OfClass(typeof(Family));
            if (0 == list.Count())
            {
                return null;
            }
            var faList = list.Where(u => u.Name == familyName);
            if (0 == faList.Count())
            {
                return null;
            }
            Family fa = faList.First() as Family;
            foreach (var id in fa.GetFamilySymbolIds())
            {
                FamilySymbol fs = doc.GetElement(id) as FamilySymbol;
                if (fs.Name == typeName)
                {
                    return fs;
                }
            }
            return null;
        }

        public static double GetParameterDoubleByName(Element elem, string parameterName)
        {
            var parameterList = elem.GetParameters(parameterName);
            if (parameterList.Count > 0)
            {
                if (parameterList.First().StorageType == StorageType.Double)
                {
                    return parameterList.First().AsDouble();
                }
            }
            return 0.0;
        }

        public static void CopyParameters(Element source, Element target)
        {
            foreach (Parameter p in target.Parameters)
            {
                if (!p.IsReadOnly)
                {
                    if (p.Definition.ParameterType == ParameterType.YesNo)
                    {
                        p.Set(1);
                    }
                }
                //if (p.Definition.ParameterType == ParameterType.Text)
                //{
                //    pp.Set(p.AsString());
                //}
                //if (p.Definition.ParameterType == ParameterType.Text)
                //{
                //    pp.Set(p.AsString());
                //}
            }
        }

        #region 根据字符串算英尺

        public static double ConvertFeet(string s)
        {
            double feet;

            string ft;
            string inch;
            double a = 0.0; ;
            double b = 0.0; ;

            int i = s.IndexOf("-");
            if (i == -1)//没有英尺，如 8 3/4"         11"         
            {
                ft = "0";
                inch = s.Substring(0, s.Length - 1);
            }
            else
            {
                ft = s.Substring(0, i - 2);
                inch = s.Substring(i + 2, s.Length - i - 3);
            }
            ft = Regex.Replace(ft, @"\D", "");//删除非数字的字符

            //TaskDialog.Show("a", fee + "\n" + inc);
            try
            {
                a = double.Parse(ft);



                int i2 = inch.IndexOf("/");
                //TaskDialog.Show("/i2", i2.ToString());
                if (i2 != -1)
                {
                    int i3 = inch.IndexOf(" ", 1);
                    //TaskDialog.Show("i3", i3.ToString());
                    if (i3 != -1)
                    {
                        string s1 = inch.Substring(0, i3);
                        string s2 = inch.Substring(i3 + 1, i2 - i3 - 1);
                        string s3 = inch.Substring(i2 + 1, inch.Length - i2 - 1);

                        double d1 = double.Parse(s1);
                        double d2 = double.Parse(s2);
                        double d3 = double.Parse(s3);

                        b = (d1 * d3 + d2) / d3;
                        //TaskDialog.Show("a", s1 + "\n" + s2 + "\n" + s3);
                    }

                }
                else
                {
                    b = double.Parse(inch);
                }
            }
            catch (Exception)//替换文字的格式不对，比如9' - 4"  写成9'-4" （没有空格） 
            {
                //TaskDialog.Show("Revit", s + " is invaid feet inch format！");
                return -1.0;
            }
            //TaskDialog.Show("a", s + "\n" + a.ToString() + "\n" + b.ToString());

            feet = a + (b / 12);


            return feet;

        }

        public static double ConvertFeet2(string s)
        {
            double feet;

            string ft;
            string inch;
            double a = 0.0; ;
            double b = 0.0; ;

            s = s.Trim();
            int i = s.IndexOf("-");
            if (i == -1)//没有英尺，如8 3/4"或11"         
            {
                ft = "0'";
                inch = s.Substring(0, s.Length - 1);

            }
            else//11' - 1 1/4"
            {
                ft = s.Split('-')[0].Trim();
                inch = s.Split('-')[1].Trim();
            }

            string pattern1 = @"\d+'";//11';
            Regex regex1 = new Regex(pattern1);
            if (!regex1.Match(ft).Success)
            {
                TaskDialog.Show("r", "feetError");
                return -1.0;
            }
            ft = Regex.Replace(ft, @"\D", "");//删除非数字的字符

            try
            {
                a = double.Parse(ft);

                int i2 = inch.IndexOf("/");
                if (i2 != -1)//8 3/4"或0 3/4"
                {
                    string pattern4 = @"\d+\s\d+/\d+""";//8 3/4";
                    Regex regex4 = new Regex(pattern4);
                    string pattern5 = @"\d+\s\d+/\d+''";//8 3/4'';
                    Regex regex5 = new Regex(pattern5);
                    if (!regex4.Match(inch).Success && !regex5.Match(inch).Success)
                    {
                        TaskDialog.Show("r", "inchError2");
                        return -1.0;
                    }
                    int i3 = inch.IndexOf(" "); 
                    if (i3 != -1)
                    {
                        string s1 = inch.Split(' ')[0];
                        string s2 = inch.Split(' ')[1].Split('/')[0];
                        string s3 = inch.Split(' ')[1].Split('/')[1].Replace("\"","").Replace("'", "");
                        double d1 = double.Parse(s1);
                        double d2 = double.Parse(s2);
                        double d3 = double.Parse(s3);

                        b = d1 + d2 / d3;
                    }
                    else//1'-3/4"缺少个0
                    {
                        TaskDialog.Show("r", "inchError2");
                        return -1.0;
                    }

                }
                else//11"
                {
                    string pattern2 = @"\d+''";//11'';
                    Regex regex2 = new Regex(pattern2);
                    string pattern3 = @"\d+""";//11";
                    Regex regex3 = new Regex(pattern3);
                    if (!regex2.Match(inch).Success && !regex3.Match(inch).Success)
                    {
                        TaskDialog.Show("r", "inchError1");
                        return -1.0;
                    }
                    inch = Regex.Replace(inch, @"\D", "");//删除非数字的字符
                    b = double.Parse(inch);
                }
            }
            catch (Exception ex)//替换文字的格式不对 
            {
                TaskDialog.Show("r", "otherError"+ex.StackTrace);
                return -1.0;
            }

            feet = a + (b / 12);

            return feet;

        }
        #endregion

        public static string GetInteger(string str)
        {
            return Regex.Replace(str, @"[^\d]*", "");
        }
        public static string RemoveInteger(string str)
        {
            return Regex.Replace(str, @"\d", "");
        }

    }
}
