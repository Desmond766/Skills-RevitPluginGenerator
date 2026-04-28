using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    class Utils
    {
        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        public static void DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, Plane.CreateByNormalAndOrigin((p1 - p2).CrossProduct(p1), p2));
            doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion

        #region 获得向下投影到楼板的点
        public static XYZ GetClearHeightPoint(View3D view, Document doc, XYZ point_Do)
        {
            XYZ point;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            Reference r2 = referenceWithContext.GetReference();
            point = r2.GlobalPoint;
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return point;

        }
        #endregion

        #region 获得管线向下投影的净高 考虑高低板
        public static double GetClearHeight(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            Reference r2 = referenceWithContext.GetReference();
            distance = r2.GlobalPoint.DistanceTo(point_Do);
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion
        
        #region 获得管线向上投影的净高
        public static double GetClearHeightUp(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ);

            Reference r2 = referenceWithContext.GetReference();
            distance = r2.GlobalPoint.DistanceTo(point_Do);
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion

        #region 获得管线一半的宽度
        public static double GetHalfWide(Element mep)
        {
            double wide=0.0;
            //风管
            if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                wide= mep.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble()/2;
            }
            //水管
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble()/2;
            }
            //线槽
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble()/2;
            }


            return wide;
        }

        #endregion

        #region 获得管线一半的高度
        public static double GetHalfHeight(Element mep)
        {
            double height = 0.0;
            //风管
            if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            { 
                height = mep.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble() / 2;
            }
            //水管
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                height = mep.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble() / 2;
            }
            //线槽
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                height = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble() / 2;
            }


            return height;
        }

        #endregion

        #region 加密
        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] array = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < pToDecrypt.Length / 2; i++)
            {
                int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
                array[i] = (byte)num;
            }

            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            return Encoding.Default.GetString(memoryStream.ToArray());
        }

        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            foreach (byte b in array)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }

            stringBuilder.ToString();
            return stringBuilder.ToString();
        }

        public static string GetVolumeSerial(string strDriveLetter)
        {
            uint VolumeSerialNumber = 0u;
            uint MaximumComponentLength = 0u;
            StringBuilder stringBuilder = new StringBuilder(256);
            uint FileSystemFlags = 0u;
            StringBuilder stringBuilder2 = new StringBuilder(256);
            strDriveLetter += "://";
            long volumeInformation = GetVolumeInformation(strDriveLetter, stringBuilder, (uint)stringBuilder.Capacity, ref VolumeSerialNumber, ref MaximumComponentLength, ref FileSystemFlags, stringBuilder2, (uint)stringBuilder2.Capacity);
            return Convert.ToString(VolumeSerialNumber);
        }

        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, uint VolumeNameSize, ref uint VolumeSerialNumber, ref uint MaximumComponentLength, ref uint FileSystemFlags, StringBuilder FileSystemNameBuffer, uint FileSystemNameSize);
        #endregion
        #region 根据族名称找族下某类型名称ID

        public static ElementId FindTypeIdByFamilyName(Document doc, string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

        }

        #endregion
        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion
        #region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        public static XYZ GetProjectivePoint(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        {
            XYZ pLine = new XYZ();
            double k = (standardEndPoint.Y - standardStartPoint.Y) / (standardEndPoint.X - standardStartPoint.X);
            if (Math.Abs(k) < 0.1) //if (k == 0)
            {
                pLine = new XYZ(modifyStartPoint.X, standardStartPoint.Y, modifyStartPoint.Z);

            }
            else if (Math.Abs(standardEndPoint.X - standardStartPoint.X) < 0.1)
            {
                pLine = new XYZ(standardEndPoint.X, modifyStartPoint.Y, modifyStartPoint.Z);
            }
            else
            {
                double x = (k * (standardStartPoint.X) + ((modifyStartPoint.X) / k) + modifyStartPoint.Y - standardStartPoint.Y) / (1 / k + k);
                double y = -1 / k * (x - modifyStartPoint.X) + modifyStartPoint.Y;
                pLine = new XYZ(x, y, modifyStartPoint.Z);

            }
            return pLine;
        }

        #endregion
        #region 得到Z 小的点

        public static XYZ GetMinZPoint(XYZ point1, XYZ point2)
        {
            double d = point1.Z - point2.Z;
            if (d > 0)
            {
                return point2;
            }
            else
            {
                return point1;
            }


        }
        #endregion
        #region 指定一个点及方向，返回反射点
        /// <summary>
        /// 指定一个点及方向，返回反射点
        /// </summary>
        /// <param name="view">当前文档</param>
        /// <param name="point">指定点</param>
        /// <param name="direction">指定方向</param>
        /// <returns>反射点</returns>
        public static XYZ GetReflectPoint(View3D view, XYZ point, XYZ direction, ElementId id)
        {
            XYZ reflecPoint = XYZ.Zero;

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_CableTray));
            LogicalOrFilter mepFilter = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(mepFilter, FindReferenceTarget.All, view);

            IList<ReferenceWithContext> referenceWithContextList = referenceIntersector.Find(point, direction);

            foreach (var item in referenceWithContextList)
            {
                if (item.GetReference().ElementId == id)
                {
                    reflecPoint = item.GetReference().GlobalPoint;
                }
            }

            return reflecPoint;



        }
        #endregion
        #region 判断点p(x,y)在两点p1(x1,y1),p2(x2,y2)的左边还是右边
        public static bool YLeftOfLine(XYZ p, XYZ p1, XYZ p2)
        {
            double tmpx = (p1.Y - p2.Y) / (p1.X - p2.X) * (p.X - p2.X) + p2.Y;

            if (tmpx > p.Y)//当tmpx>p.X的时候，说明点在线的左边，小于在右边，等于则在线上。
            {
                return true;
            }

            return false;
        }
        #endregion
        #region 判断点p(x,y)在两点p1(x1,y1),p2(x2,y2)的左边还是右边
        public static bool LeftOfLine(XYZ p, XYZ p1, XYZ p2)
        {
            //斜率：(p1.X - p2.X) / (p1.Y - p2.Y)
            //找到点p在通过点p2且与p1和p2形成的直线平行的直线上的投影点的横坐标。类似line.Project(point).XYZPoint
            double tmpx = (p1.X - p2.X) / (p1.Y - p2.Y) * (p.Y - p2.Y) + p2.X;

            if (tmpx > p.X)//当tmpx>p.X的时候，说明点在线的左边，小于在右边，等于则在线上。
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
