using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangerClassificationAnnotation
{
    public static class Message
    {

        public static void show(this int text)
        {
            TaskDialog.Show("提示", text.ToString());
        }
        public static void show(this string text)
        {
            TaskDialog.Show("提示", text);
        }
        public static void show(this double text)
        {
            TaskDialog.Show("提示", text.ToString());
        }
        public static void show(this XYZ text)
        {
            TaskDialog.Show("提示", text.ToString());
        }
        public static void show(this ElementId text)
        {
            TaskDialog.Show("提示", text.ToString());
        }
    }
}
