# Sample Snippet: MEP_Connecter

Source project: `existingCodes\品成插件源代码\机电\MEP_Connecter\MEP_Connecter`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.IO;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;

namespace MEP_Connecter
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //Reference r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "请选择要旋转的三通");
            //FamilyInstance familyinstance = doc.GetElement(r0) as FamilyInstance;
            //Location location = familyinstance.Location;
            //LocationPoint locationPoint = location as LocationPoint;
            //XYZ familyinstancePoint = locationPoint.Point;

            Reference r1 = sel.PickObject(ObjectType.Element, "请选择要与三通连接的支管");
            MEPCurve mepCurve1 = doc.GetElement(r1) as MEPCurve;
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            XYZ r1point0 = mepLine1.GetEndPoint(0);
            XYZ r1point1 = mepLine1.GetEndPoint(1);
            Line line1 = Line.CreateBound(r1point0, r1point1);

            Reference r2 = sel.PickObject(ObjectType.Element, "请选择要与三通连接的支管");
            MEPCurve mepCurve2 = doc.GetElement(r2) as MEPCurve;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
            XYZ r2point0 = mepLine2.GetEndPoint(0);
            XYZ r2point1 = mepLine2.GetEndPoint(1);
            Line line2 = Line.CreateBound(r2point0, r2point1);

            Curve curve1 = line1 as Curve;
            Curve curve2 = line1 as Curve;
            curve1.MakeUnbound();//unbound绑定
            curve2.MakeUnbound();
            XYZ xyz = null;
            xyz = IntersectionPoint(line1, line2);
            TaskDialog.Show("a", xyz.ToString());

            //var ductList = GetMainDuct(mepCurve1, mepCurve2);
            //MEPCurve MainDuct = ductList[0];//the main Pipe
            //MEPCurve LessDuct = ductList[1];// the minor Pipe
            //MEPCurve duct3 = null;//the main pipe
            //MEPCurve duct4 = null;//the main pipe
            IntersectionResultArray intersectPoint = new IntersectionResultArray();
            var x = curve1.Intersect(curve2, out intersectPoint);
            if (x == SetComparisonResult.Overlap)
            {
                using (Transaction tran = new Transaction(doc))
                {
                    tran.Start("1033067630");

                    var OrginPoint = intersectPoint.get_Item(0).XYZPoint;

                    Split(doc, mepCurve1, OrginPoint);

                    //duct3 = doc.GetElement(list[0]) as MEPCurve;
                    //duct4 = doc.GetElement(list[1]) as MEPCurve;
                    tran.Commit();
                }
            }

            //ConnectTwoDuctsWithElbow(doc, duct3, duct4, LessDuct);

            //using (Transaction t = new Transaction(doc, "旋转三通"))
            //{
            //    t.Start();
            //    Utils.DrawModelCurve(doc, xyz, familyinstancePoint);
            //    t.Commit();
            //}


            return Result.Succeeded;
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_Connecter
{
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

        


        //public static void CopyParameters(Pipe source, Pipe target)
        //{
        //    double diameter = source.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
        //    target.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameter);
        //    CopyPartition(source, target);
        //}

        //public static void CopyParameters1(Pipe source, Pipe target)
        //{

        //    CopyPartition(source, target);
        //}

        //private static void CopyPartition(Element source, Element target)
        //{
        //    Parameter partition = source.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
        //    if (null != partition)
        //    {
        //        target.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(partition.AsInteger());
        //    }
        //}

// ... truncated ...
```

