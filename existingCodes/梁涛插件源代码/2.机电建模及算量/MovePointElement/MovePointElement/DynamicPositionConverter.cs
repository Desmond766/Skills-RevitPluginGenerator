using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MovePointElement
{
    public class DynamicPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double parentWidth = (double)values[0]; // 父容器宽度
            double threshold = 80; // 固定阈值
            double targetPosition = parentWidth - 400 + 80;
            // 若宽度 > 400，则返回一个结果使其离左侧距离为固定值，若宽度 < 400，则返回固定值80
            return new Thickness(0, 0, parentWidth > 400 ? targetPosition : threshold, 5);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
