using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutBox
{
    class Utils
    {
        #region 验证注册
        /// <summary>
        /// 验证注册
        /// </summary>
        /// <returns></returns>
        public static bool AddInCheckIn()
        {
            var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(assemblyPath), "BimtransToolReg.log");
            if (!File.Exists(path))
            {
                MessageBox.Show("插件未注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            var regData = File.ReadAllLines(path);
            if (regData.Length != 2)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            var regStr = regData[0];
            var localKey = regData[1];
            var diskNum = GetVolumeSerial("C");
            var generateKey = MD5Encrypt(regStr + diskNum);
            if (generateKey != localKey)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            //注册码,授权类型,授权时间
            var regParams = Base64Decode(regStr).Split(',');
            if (regParams.Length != 3)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            //验证授权类型
            if (regParams[1] != "0")
            {
                if (regParams[1] == "1")
                {
                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    string timestamp = Convert.ToInt64(ts.TotalSeconds).ToString();
                    //授权过期
                    if (int.Parse(timestamp) > int.Parse(regParams[2]))
                    {
                        MessageBox.Show("授权已过期，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                        return false;
                    }
                }
                else
                {
                    //授权类型错误
                    MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Base64解密
        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;

            try
            {
                byte[] bytes = Convert.FromBase64String(result);
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }
        #endregion

        #region 获得硬盘序列号
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(
            string PathName,
            StringBuilder VolumeNameBuffer,
            UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber,
            ref UInt32 MaximumComponentLength,
            ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer,
            UInt32 FileSystemNameSize);

        public static string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += "://"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
            return Convert.ToString(serNum);
        }
        #endregion

        #region 给一个字符串进行MD5加密
        /// <summary>  
        /// 给一个字符串进行MD5加密
        /// </summary>  
        /// <param name="strText">待加密字符串</param>  
        /// <returns>加密后的字符串</returns>  
        public static string MD5Encrypt(string strText)
        {
            char[] md5Chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strText));
            char[] chars = new char[result.Length * 2];
            int i = 0;
            foreach (byte b in result)
            {
                char c0 = md5Chars[(b & 0xf0) >> 4];
                chars[i++] = c0;
                char c1 = md5Chars[b & 0xf];
                chars[i++] = c1;
            }
            return new String(chars);
        }
        #endregion

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        public static void DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, new Plane((p1 - p2).CrossProduct(p1), p2));
            doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion

        #region 获得三维视图
        /// <summary>
        /// 获得三维视图
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <returns>三维视图</returns>
        public static View3D Get3DView(Document doc)
        {
            View3D view = null;
            List<Element> list = new List<Element>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            list.AddRange(collector.OfClass(typeof(View3D)).ToElements());
            foreach (Autodesk.Revit.DB.View3D v in list)
            {
                if (v != null && !v.IsTemplate && v.Name == "{三维}")
                {
                    view = v as View3D;
                    break;
                }
            }
            return view;
        }
        #endregion

        #region Geometrical Comparison
        const double _eps = 1.0e-9;

        public static double Eps
        {
            get
            {
                return _eps;
            }
        }

        public static double MinLineLength
        {
            get
            {
                return _eps;
            }
        }

        public static double TolPointOnPlane
        {
            get
            {
                return _eps;
            }
        }

        public static bool IsZero(double a, double tolerance)
        {
            return tolerance > Math.Abs(a);
        }

        public static bool IsZero(double a)
        {
            return IsZero(a, _eps);
        }

        public static bool IsEqual(double a, double b)
        {
            return IsZero(b - a);
        }

        public static int Compare(double a, double b)
        {
            return IsEqual(a, b) ? 0 : (a < b ? -1 : 1);
        }

        public static int Compare(XYZ p, XYZ q)
        {
            int diff = Compare(p.X, q.X);
            if (0 == diff)
            {
                diff = Compare(p.Y, q.Y);
                if (0 == diff)
                {
                    diff = Compare(p.Z, q.Z);
                }
            }
            return diff;
        }

        public static bool IsEqual(XYZ p, XYZ q)
        {
            return 0 == Compare(p, q);
        }

        /// <summary>
        /// Return true if the vectors v and w 
        /// are non-zero and perpendicular.
        /// </summary>
        bool IsPerpendicular(XYZ v, XYZ w)
        {
            double a = v.GetLength();
            double b = v.GetLength();
            double c = Math.Abs(v.DotProduct(w));
            return _eps < a
              && _eps < b
              && _eps > c;
            // c * c < _eps * a * b
        }

        public static bool IsParallel(XYZ p, XYZ q)
        {
            return p.CrossProduct(q).IsZeroLength();
        }

        public static bool IsHorizontal(XYZ v)
        {
            return IsZero(v.Z);
        }

        public static bool IsVertical(XYZ v)
        {
            return IsZero(v.X) && IsZero(v.Y);
        }

        public static bool IsVertical(XYZ v, double tolerance)
        {
            return IsZero(v.X, tolerance)
              && IsZero(v.Y, tolerance);
        }

        public static bool IsHorizontal(Edge e)
        {
            XYZ p = e.Evaluate(0);
            XYZ q = e.Evaluate(1);
            return IsHorizontal(q - p);
        }

        public static bool IsHorizontal(PlanarFace f)
        {
            return IsVertical(f.Normal);
        }

        public static bool IsVertical(PlanarFace f)
        {
            return IsHorizontal(f.Normal);
        }

        public static bool IsVertical(CylindricalFace f)
        {
            return IsVertical(f.Axis);
        }

        /// <summary>
        /// Return the maximum value from an array of real numbers.
        /// </summary>
        public static double Max(double[] a)
        {
            Debug.Assert(1 == a.Rank, "expected one-dimensional array");
            Debug.Assert(0 == a.GetLowerBound(0), "expected zero-based array");
            Debug.Assert(0 < a.GetUpperBound(0), "expected non-empty array");
            double max = a[0];
            for (int i = 1; i <= a.GetUpperBound(0); ++i)
            {
                if (max < a[i])
                {
                    max = a[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Return the midpoint between two points.
        /// </summary>
        public static XYZ Midpoint(XYZ p, XYZ q)
        {
            return p + 0.5 * (q - p);
        }

        /// <summary>
        /// Return the midpoint of a Line.
        /// </summary>
        public static XYZ Midpoint(Line line)
        {
            return Midpoint(line.GetEndPoint(0),
              line.GetEndPoint(1));
        }

        /// <summary>
        /// Return the normal of a Line in the XY plane.
        /// </summary>
        public static XYZ Normal(Line line)
        {
            XYZ p = line.GetEndPoint(0);
            XYZ q = line.GetEndPoint(1);
            XYZ v = q - p;

            //Debug.Assert( IsZero( v.Z ),
            //  "expected horizontal line" );

            return v.CrossProduct(XYZ.BasisZ).Normalize();
        }
        #endregion // Geometrical Comparison

    }
}
