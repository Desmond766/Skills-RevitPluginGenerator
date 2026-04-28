using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_Tips.Text = string.Format("提示：将计算机ID复制给插件管理员，将Key.lic复制到插件目录"
                + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            tbx_ComputerID.Text = Utils.GetVolumeSerial("C");
            //注册文件
            string licFile = string.Format("{0}\\Key.lic",
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            if (File.Exists(licFile))
            {
                LicenseManager lm = new LicenseManager();
                if (lm.ReadLic(licFile))
                {
                    if (lm.IsVaildLic(tbx_ComputerID.Text))
                    {
                        if (lm.LicenseType == LicType.TRAIL)
                        {
                            lbl_LicenseType.Text = "试用";
                            lbl_TrailDays.Text = string.Format("剩余{0}天",
                                (DateTime.Parse(lm.TrailDate) - /*DateTime.Now.Date*/ TimeNow.time).Days);
                        }
                        else
                        {
                            lbl_LicenseType.Text = "无期限";
                        }
                    }
                    else
                    {
                        lbl_LicenseType.Text = "注册文件无效，请重新注册！";
                    }
                }
                //TaskDialog.Show("sds", lm.TrailDate);
            }
            else
            {
                lbl_LicenseType.Text = "无注册文件！";
            }
        }
    }
}
