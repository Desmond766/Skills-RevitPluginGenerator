using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Autodesk.Revit.DB.SpecTypeId;

namespace DimensionChecker
{
    internal class Utils
    {
        #region 根据字符串算英尺
        
        public static double ConvertFeet( string s)
        {
            double feet;

            string fee;
            string inc;
            double a = 0.0; ;
            double b = 0.0; ;

            int i = s.IndexOf("-");
            if (i == -1)//没有英尺，如 8 3/4"         11"         
            {
                fee = "0";
                inc = s.Substring(0, s.Length - 1);

            }
            else
            {
                fee = s.Substring(0, i - 2);
                inc = s.Substring(i + 2, s.Length - i - 3);
            }
            fee = Regex.Replace(fee, @"\D", "");//删除非数字的字符

            //TaskDialog.Show("a", fee + "\n" + inc);
            try
            {
                a = double.Parse(fee);
           
            

            int i2 = inc.IndexOf("/");
            //TaskDialog.Show("/i2", i2.ToString());
            if (i2 != -1)
            {
                int i3 = inc.IndexOf(" ", 1);
                //TaskDialog.Show("i3", i3.ToString());
                if (i3 != -1)
                {
                    string s1 = inc.Substring(0, i3);
                    string s2 = inc.Substring(i3 + 1, i2 - i3 - 1);
                    string s3 = inc.Substring(i2 + 1, inc.Length - i2 - 1);

                    double d1 = double.Parse(s1);
                    double d2 = double.Parse(s2);
                    double d3 = double.Parse(s3);

                    b = (d1 * d3 + d2) / d3;
                    //TaskDialog.Show("a", s1 + "\n" + s2 + "\n" + s3);
                }
                
            }
            else
            {
                b = double.Parse(inc);
            }
            }
            catch (Exception)//替换文字的格式不对，比如9' - 4"  写成9'-4" （没有空格） 
            {
                TaskDialog.Show("Revit", "修改替换的文字格式！");
            }
            //TaskDialog.Show("a", s + "\n" + a.ToString() + "\n" + b.ToString());

            feet = a + (b / 12);


            return feet;

        }
        #endregion


        


    }
}
