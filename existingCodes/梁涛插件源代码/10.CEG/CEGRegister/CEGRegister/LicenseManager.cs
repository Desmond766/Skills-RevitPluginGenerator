using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CEGRegister
{
    public class LicenseManager
    {
        public static string sKey = "BIMTRANS";

        public string ComputerId { get; set; }

        public LicType LicenseType { get; set; }

        public string TrailDate { get; set; }

        public static void GenerateLic(string computerId, string LicenseType, string trailDate, string filePath)
        {
            string text = computerId + "|" + LicenseType.ToString();
            if (LicenseType == "TRAIL")
            {
                text = text + "|" + trailDate;
            }

            string text2 = "";
            try
            {
                text2 = Utils.MD5Encrypt(text, sKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("证书生成出错\n" + ex.Message);
                return;
            }

            File.WriteAllText(filePath, text2);
        }

        public bool ReadLic(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("证书不存在!\n" + filePath);
                return false;
            }

            string pToDecrypt = File.ReadAllText(filePath);
            string[] array = new string[0];
            try
            {
                array = Utils.MD5Decrypt(pToDecrypt, sKey).Split('|');
            }
            catch (Exception ex)
            {
                MessageBox.Show("证书格式错误!\n" + ex.Message);
                return false;
            }

            if (array.Count() < 2)
            {
                MessageBox.Show("证书格式错误!");
                return false;
            }

            ComputerId = array[0];
            LicenseType = ((!(array[1] == "FULL")) ? LicType.TRAIL : LicType.FULL);
            if (LicenseType == LicType.TRAIL && array.Count() == 3)
            {
                TrailDate = array[2];
            }

            return true;
        }

        public bool IsVaildLic(string cilentComputerId)
        {
            if (cilentComputerId != ComputerId)
            {
                return false;
            }

            //if (LicenseType == LicType.TRAIL && DateTime.Now.Date > DateTime.Parse(TrailDate))
            if (LicenseType == LicType.TRAIL && TimeNow.time > DateTime.Parse(TrailDate))
            {
                return false;
            }
            return true;
        }
    }
    public enum LicType
    {
        FULL,
        TRAIL
    }
}
