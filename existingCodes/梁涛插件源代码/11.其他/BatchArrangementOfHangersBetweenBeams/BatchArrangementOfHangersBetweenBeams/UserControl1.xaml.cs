using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BatchArrangementOfHangersBetweenBeams
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : Window
    {
        public bool cancel { get; private set; } = true;
        private Document doc = null;
        public UserControl1(Document doc)
        {
            this.doc = doc;
            InitializeComponent();
            //comboBox2.Items.Add("C型钢");
            //comboBox2.Items.Add("walraven槽钢");
            List<FamilySymbol> familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().ToList();
            HashSet<string> familyName = new HashSet<string>();
            foreach (FamilySymbol item in familySymbols)
            {
                familyName.Add(item.Family.Name);
            }
            foreach (var item in familyName)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.SelectedIndex = 0;
        }
        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

                cancel = false;
                Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<FamilySymbol> familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name == comboBox2.SelectedValue.ToString()).ToList();
            comboBox.Items.Clear();
            foreach (FamilySymbol item in familySymbols)
            {
                comboBox.Items.Add(item.Name);
            }
            comboBox.SelectedIndex = 0;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == true)
            {
                tb.Visibility = System.Windows.Visibility.Visible;
                lb.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tb.Visibility = System.Windows.Visibility.Hidden;
                lb.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
