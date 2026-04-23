using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangerClassificationAnnotation
{
    internal class CustomFamilyLoadOptions : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true; // 设置为 true 可以覆盖参数值

            // 返回 true 以继续加载族文件，返回 false 则取消加载
            return true;
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true; // 设置为 true 可以覆盖参数值

            // 设置共享族文件的来源
            source = FamilySource.Family;

            // 返回 true 以继续加载共享族文件，返回 false 则取消加载
            return true;
        }
    }
}
