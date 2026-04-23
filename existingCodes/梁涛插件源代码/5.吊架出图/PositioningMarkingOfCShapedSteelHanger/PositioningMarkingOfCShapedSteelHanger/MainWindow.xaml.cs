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

namespace PositioningMarkingOfCShapedSteelHanger
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsCShape { get; private set; } = false;
        public bool IsTag { get; private set; } = false;
        public bool UpSet { get; private set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            var p = Properties.Settings.Default;
            if(p.IsTag) rb_tag.IsChecked = true;
            else rb_text.IsChecked = true;
            if (p.IsCShape) rb_cs.IsChecked = true;
            else rb_pm.IsChecked = true;
            if (p.UpSet) rb_upset.IsChecked = true;
            else rb_downset.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_cs.IsChecked == true) IsCShape = true;
                if (rb_tag.IsChecked == true) IsTag = true;
                if (rb_upset.IsChecked == true) UpSet = true;

                Properties.Settings.Default.IsCShape = IsCShape;
                Properties.Settings.Default.IsTag = IsTag;
                Properties.Settings.Default.UpSet = UpSet;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.IsChecked == true)
            {
                rb_tag.IsEnabled = false;
                rb_text.IsChecked = true;
            }
            else if (radioButton.IsChecked == false)
            {
                rb_tag.IsEnabled = true;
            }
        }

        private void rb_cs_Click(object sender, RoutedEventArgs e)
        {
            if (rb_cs.IsChecked == true)
            {
                rb_tag.IsEnabled = true;
            }
        }
    }
}
