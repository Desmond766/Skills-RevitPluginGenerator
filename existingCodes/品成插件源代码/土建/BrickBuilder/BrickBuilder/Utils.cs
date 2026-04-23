using Autodesk.Revit.DB;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BrickBuilder
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Utils
    {
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

        #region 判断点是否在面上
        /// <summary>
        /// 判断点是否在面上
        /// Disjunct Planar Face Outer Loops
        /// http://thebuildingcoder.typepad.com/blog/2017/10/disjunct-outer-loops-from-planar-face-with-separate-parts.html
        /// </summary>
        /// <param name="point"></param>
        /// <param name="PFace"></param>
        /// <returns></returns>
        public static bool PointIsInsideFace(XYZ point, PlanarFace PFace)
        {
            Transform Trans = PFace.ComputeDerivatives(
              new UV(0, 0));
            XYZ Pt = Trans.Inverse.OfPoint(point);
            IntersectionResult Res = null;
            bool outval = PFace.IsInside(
              new UV(Pt.X, Pt.Y), out Res);
            return outval;
        }
        #endregion

        #region 射线法求交点
        /// <summary>
        /// 射线法求交点
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="targetElement"></param>
        /// <param name="startPoint"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static XYZ FindIntersectionPoint(Document doc, Element targetElement, XYZ startPoint, XYZ direction)
        {
            var view3d = doc.ActiveView as View3D;
            if (null == view3d)
            {
                return null;
            }
            ReferenceIntersector intersector = new ReferenceIntersector(targetElement.Id, FindReferenceTarget.All, view3d);
            var context = intersector.FindNearest(startPoint, direction);
            return null != context ? context.GetReference().GlobalPoint : null;
        }
        #endregion
        
        #region 绘制模型线
		/// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static void CreateModelLine(Document doc, XYZ p1, XYZ p2)
        {
            using (var line = Line.CreateBound(p1, p2))
            {
                using (var skPlane = SketchPlane.Create(doc, ToPlane(p1, p2)))
                {
                    if (doc.IsFamilyDocument)
                    {
                        doc.FamilyCreate.NewModelCurve(line, skPlane);
                    }
                    else
                    {
                        doc.Create.NewModelCurve(line, skPlane);
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
            return new Autodesk.Revit.DB.Plane(norm, point);
        }
        #endregion
        
    }
}
