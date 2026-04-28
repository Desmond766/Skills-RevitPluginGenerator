using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// WindowControl.xaml 的交互逻辑
    /// </summary>
    public partial class WindowControl : Page
    {
        private bool isDragging;
        private Point lastPosition;
        public WindowControl()
        {
            InitializeComponent();
            TransformChange();
        }
        

        /// <summary>
        /// 指定元素鼠标按下时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastPosition = e.GetPosition(canvas);
            rectangle.CaptureMouse();
            //TaskDialog.Show("asdasd", lastPosition.ToString());
        }


        /// <summary>
        /// 指定元素鼠标移动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(canvas);
                double offsetX = currentPosition.X - lastPosition.X;
                double offsetY = currentPosition.Y - lastPosition.Y;

                Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) + offsetX);
                Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) + offsetY);

                lastPosition = currentPosition;
            }
        }


        /// <summary>
        /// 指定元素鼠标放开时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            rectangle.ReleaseMouseCapture();
        }

        private void TransformChange()
        {
            // 创建 ScaleTransform
            ScaleTransform scaleTransform = new ScaleTransform();
            //scaleTransform.ScaleY = -0.5;
            //scaleTransform.CenterY = canvas.Height;

            // 将 ScaleTransform 应用于 Canvas 的 RenderTransform
            canvas.RenderTransform = scaleTransform;

            // 在 Canvas 中添加你的元素
            // ...

            // 将 Canvas 添加到窗口中
        }
    }
}
