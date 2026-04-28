using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateMaskByHeight
{
    public static class MarkColor
    {
        static string[] name = new string[15];
        public static string GetMarkColorName(this double row_height, int minValue, int maxValue)
        {
            
            if (row_height < 0)
            {
                if (row_height > -maxValue && row_height < -minValue)
                {
                    return name[13] = "坡道满足";
                }
                return name[14] = "坡道不满足";
            }

            //相对值
            else if (row_height < minValue)
            {
                if (row_height > minValue - minValue / 4)
                {
                    return name[2] = "净高大于" + (minValue - minValue / 4);
                }
                else if (row_height > minValue - minValue / 2)
                {
                    return name[3] = "净高大于" + (minValue - minValue / 2);
                }
                else if (row_height > minValue / 4)
                {
                    return name[4] = "净高大于" + (minValue / 4);
                }
                else
                {
                    return name[5] = "净高大于0";
                }
            }
            if (row_height > maxValue)
            {
                double value = 5000 - maxValue;
                if (row_height < maxValue + value / 3)
                {
                    return name[6] = "净高小于" + (maxValue + value / 3);
                }
                else if (row_height < maxValue + (value / 3) * 2)
                {
                    return name[7] = "净高小于" + (maxValue + (value / 3) * 2);
                }
                else
                {
                    return name[8] = "净高小于5000";
                }
            }
            if (row_height > minValue || row_height < maxValue)
            {
                double value = maxValue - minValue;
                if (row_height < minValue + value / 6)
                {
                    return name[9] = "净高小于" + (minValue + value / 6);
                }
                else if (row_height < minValue + value / 3)
                {
                    return name[10] = "净高小于" + (minValue + value / 4);
                }
                else if (row_height < minValue + value / 2)
                {
                    return name[11] = "净高小于" + (minValue + value / 2);
                }
                else if (row_height < minValue + (value / 6) * 4)
                {
                    return name[12] = "净高小于" + (minValue + (value / 6) * 4);
                }
                else if (row_height < minValue + (value / 6) * 5)
                {
                    return name[13] = "净高小于" + (minValue + (value / 6) * 5);
                }
                else
                {
                    return name[14] = "净高小于" + maxValue;
                }
            }
            return name[15] = "错误";
        }

        public static Color GetMarkColor(this string markColorName)
        {
            if (markColorName == name[0])
            {
                return new Color(255, 0, 0);
            }
            if (markColorName == name[1])
            {
                return new Color(250, 0, 150);
            }
            if (markColorName == name[2])
            {
                return new Color(255, 0, 255);
            }
            if (markColorName == name[3])
            {
                return new Color(255, 153, 204);
            }
            if (markColorName == name[4])
            {
                return new Color(0, 250, 0);

            }
            if (markColorName == name[5])
            {
                return new Color(255, 255, 0);

            }
            if (markColorName == name[6])
            {
                return new Color(0, 100, 250);

            }
            if (markColorName == name[7])
            {
                return new Color(250, 150, 30);
            }
            if (markColorName == name[8])
            {
                return new Color(160, 220, 30);
            }
            if (markColorName == name[9])
            {
                return new Color(000, 255, 255);

            }
            if (markColorName == name[10])
            {
                return new Color(128, 128, 255);

            }
            if (markColorName == name[11])
            {
                return new Color(000, 130, 200);

            }
            if (markColorName == name[12])
            {
                return new Color(050, 200, 200);

            }
            if (markColorName == name[13])
            {
                return new Color(100, 100, 100);

            }
            if (markColorName == name[14])
            {
                return new Color(150, 080, 050);
            }
            return new Color(0, 0, 0);
        }
    }
}
