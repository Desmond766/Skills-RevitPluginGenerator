using System;
using System.Windows;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Input;

namespace FlippingBeam
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        UIDocument uidoc { get; set; }
        Document doc { get; set; }
        public MainWindow(Document doc, UIDocument uidoc)
        {
            InitializeComponent();
            this.uidoc = uidoc;
            this.doc = doc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            // 连接到 Revit
            // 请确保已经引用了 Revit API 的程序集

            try
            {
                // 在 Revit 中选择元素
                Reference selectedElement = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, "请选择一个元素");
                string layerName = Command.GetLayerName(doc, selectedElement);
                // 在文本框中显示用户选择的元素名称
                if (textBox.Text == "")
                {
                    textBox.Text = layerName;
                }
                else
                {
                    textBox.Text += "," + layerName;
                }
            }
            catch (Exception)
            {

            }
            this.Show();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.Escape))
            {
                this.Show();
            }
        }
    }
}
