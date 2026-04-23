//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;

namespace LayoutByDwg
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }


            var doc = commandData.Application.ActiveUIDocument.Document;
            var uiSel = commandData.Application.ActiveUIDocument.Selection;

            using (Transaction t = new Transaction(doc, "批量布置构件"))
            {
                t.Start();
                //try
                //{
                //选择底图
                var reference = uiSel.PickObject(ObjectType.Element, "选择DWG底图");
                var element = doc.GetElement(reference);
                //弹出对话框
                SettingForm sf = new SettingForm();
                sf.nameList = GetGeomInstNameList(element);//获得DWG中的块名集合
                sf.ShowDialog();
                var transList = GetGeomInstTransByName(element, sf.selectName);//根据块名获得DWG中块的Transform
                //选择构件
                var referenceToLayOut = uiSel.PickObject(ObjectType.Element, "选择要布置的构件");
                var elementToLayOut = doc.GetElement(referenceToLayOut);
                if (!(elementToLayOut is FamilyInstance))
                {
                    MessageBox.Show("请选择点型、非系统族实例！");
                    return Result.Failed;
                }
                foreach (var item in transList)
                {
                    //在底图块的位置生成族
                    FamilyInstance fi = doc.Create.NewFamilyInstance(item.Origin, (elementToLayOut as FamilyInstance).Symbol,
                        Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    // 利用XYZ.BasisX预旋转
                    Transform tran = Transform.CreateRotation(XYZ.BasisZ, XYZ.BasisX.AngleTo(item.BasisX));
                    XYZ preRotate = tran.OfVector(XYZ.BasisX);
                    if (preRotate.IsAlmostEqualTo(item.BasisX))
                    {
                        ElementTransformUtils.RotateElement(doc, fi.Id,
                        Line.CreateBound(item.Origin, item.Origin + XYZ.BasisZ), XYZ.BasisX.AngleTo(item.BasisX));
                    }
                    else
                    {
                        ElementTransformUtils.RotateElement(doc, fi.Id,
                        Line.CreateBound(item.Origin, item.Origin + XYZ.BasisZ), XYZ.BasisX.AngleTo(item.BasisX) * -1.0);
                    }
                }
                //}
                //catch (Exception)
                //{
                //    //CODE HERE
                //}

                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        private void DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, new Plane((p1 - p2).CrossProduct(p1), p2));
            doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion

        #region 递归找GeometryInstance
        /// <summary>
        /// 递归找GeometryInstance
        /// </summary>
        /// <param name="geomInstance"></param>
        /// <returns></returns>
        private List<GeometryInstance> GetGeometryInstance(GeometryInstance geomInstance)
        {
            List<GeometryInstance> instanceInstList = new List<GeometryInstance>();
            foreach (GeometryObject instObj in geomInstance.SymbolGeometry)
            {
                GeometryInstance instanceInst = instObj as GeometryInstance;
                if (null == instanceInst)
                {
                    continue;
                }
                instanceInstList.Add(instanceInst);
                instanceInstList.AddRange(GetGeometryInstance(instanceInst));
            }
            return instanceInstList;
        }
        #endregion

        #region 根据块名获得DWG中块的位置
        /// <summary>
        /// 根据块名获得DWG中块的位置
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private List<XYZ> GetGeomInstLocationByName(Element element, string name)
        {
            List<XYZ> locationList = new List<XYZ>();
            foreach (GeometryObject geomObj in element.get_Geometry(new Options()))
            {
                //DWG第一层均为GeometryInstance
                GeometryInstance geomInstance = geomObj as GeometryInstance;
                if (null != geomInstance)
                {
                    foreach (GeometryObject instObj in geomInstance.SymbolGeometry)
                    {
                        //进入第二层寻找GeometryInstance
                        GeometryInstance instanceInst = instObj as GeometryInstance;
                        if (null == instanceInst)
                        {
                            continue;
                        }
                        if (instanceInst.Symbol.Name == name)
                        {
                            locationList.Add(geomInstance.Transform.OfPoint(instanceInst.Transform.Origin));
                        }
                        foreach (GeometryObject instInstObj in instanceInst.SymbolGeometry)
                        {
                            //进入第三层寻找GeometryInstance
                            GeometryInstance instanceInstInst = instInstObj as GeometryInstance;
                            if (null == instanceInstInst)
                            {
                                continue;
                            }
                            if (instanceInstInst.Symbol.Name == name)
                            {
                                locationList.Add(geomInstance.Transform.OfPoint(instanceInst.Transform.OfPoint(instanceInstInst.Transform.Origin)));
                            }
                        }
                    }
                }
            }
            return locationList;
        }
        #endregion

        #region 根据块名获得DWG中块的Transform
        /// <summary>
        /// 根据块名获得DWG中块的Transform
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private List<Transform> GetGeomInstTransByName(Element element, string name)
        {
            List<Transform> transList = new List<Transform>();
            foreach (GeometryObject geomObj in element.get_Geometry(new Options()))
            {
                //DWG第一层均为GeometryInstance
                GeometryInstance geomInstance = geomObj as GeometryInstance;
                if (null != geomInstance)
                {
                    foreach (GeometryObject instObj in geomInstance.SymbolGeometry)
                    {
                        //进入第二层寻找GeometryInstance
                        GeometryInstance instanceInst = instObj as GeometryInstance;
                        if (null == instanceInst)
                        {
                            continue;
                        }
                        if (instanceInst.Symbol.Name == name)
                        {
                            transList.Add(geomInstance.Transform.Multiply(instanceInst.Transform));
                        }
                        foreach (GeometryObject instInstObj in instanceInst.SymbolGeometry)
                        {
                            //进入第三层寻找GeometryInstance
                            GeometryInstance instanceInstInst = instInstObj as GeometryInstance;
                            if (null == instanceInstInst)
                            {
                                continue;
                            }
                            if (instanceInstInst.Symbol.Name == name)
                            {
                                transList.Add(geomInstance.Transform.Multiply(instanceInst.Transform.Multiply(instanceInstInst.Transform)));
                            }
                        }
                    }
                }
            }
            return transList;
        }
        #endregion

        #region 获得DWG中的块名集合
        /// <summary>
        /// 获得DWG中的块名集合
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private List<string> GetGeomInstNameList(Element element)
        {
            List<string> nameList = new List<string>();
            foreach (GeometryObject geomObj in element.get_Geometry(new Options()))
            {
                //DWG第一层均为GeometryInstance
                GeometryInstance geomInstance = geomObj as GeometryInstance;
                if (null != geomInstance)
                {
                    foreach (GeometryObject instObj in geomInstance.SymbolGeometry)
                    {
                        //进入第二层寻找GeometryInstance
                        GeometryInstance instanceInst = instObj as GeometryInstance;
                        if (null == instanceInst)
                        {
                            continue;
                        }
                        if (!nameList.Contains(instanceInst.Symbol.Name))
                        {
                            nameList.Add(instanceInst.Symbol.Name);
                        }
                        foreach (GeometryObject instInstObj in instanceInst.SymbolGeometry)
                        {
                            //进入第三层寻找GeometryInstance
                            GeometryInstance instanceInstInst = instInstObj as GeometryInstance;
                            if (null == instanceInstInst)
                            {
                                continue;
                            }
                            if (!nameList.Contains(instanceInstInst.Symbol.Name))
                            {
                                nameList.Add(instanceInstInst.Symbol.Name);
                            }
                        }
                    }
                }
            }
            nameList.Sort();
            return nameList;
        }
        #endregion

        #region 找到不同盘符的共享盘
        /// <summary>
        /// 找到不同盘符的共享盘
        /// </summary>
        /// <param name="specifiedPath">指定的路径</param>
        /// <returns>大家电脑上可以识别到的路径</returns>
        public static string SharedPath(string path)
        {
            //列出用户共享盘可能的盘符
            List<string> strList = new List<string>()
        {
            "A", "B", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            for (int i = 0; i < strList.Count; i++)
            {
                string SharePath = path.Replace("X", strList[i]);
                if (Directory.Exists(SharePath))
                {
                    path = SharePath;
                    break;
                }
            }
            return path;
        }

        #endregion

    }

    class Utils
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
            var seriesNum = regData[0];
            var localKey = regData[1];
            var diskNum = GetVolumeSerial("C");
            var generateKey = MD5Encrypt(seriesNum + diskNum);
            if (generateKey != localKey)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            return true;
        }
        #endregion
    }

}
