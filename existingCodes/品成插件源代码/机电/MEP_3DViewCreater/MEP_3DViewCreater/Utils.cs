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
using System.Windows.Forms;

namespace MEP_3DViewCreater
{

    class Utils
    {
       #region 将复选框选中的项，生成List

       public static List<string> CollectedOptionsToList(CheckedListBox clbx)
       {
           List<string> list = new List<string>();
           for (int i = 0; i < clbx.Items.Count; i++)
           {
               if (clbx.GetItemChecked(i))
               {
                   list.Add(clbx.GetItemText(clbx.Items[i]));
               }
           }
           return list;
       }

       #endregion
    }
}
