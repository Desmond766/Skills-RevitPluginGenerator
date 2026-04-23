using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CEGRegister
{
    public static class CheckRegClass
    {
        public static bool CheckReg()
        {
            string licFile = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Key.lic";
            return CheckReg(licFile);
        }

        public static bool CheckReg(string licFile)
        {
            LicenseManager licenseManager = new LicenseManager();
            if (licenseManager.ReadLic(licFile))
            {
                string volumeSerial = Utils.GetVolumeSerial("C");
                if (licenseManager.IsVaildLic(volumeSerial))
                {
                    return true;
                }

                MessageBox.Show("证书无效或过期，请重新注册!");
            }

            return false;
        }
    }
}
