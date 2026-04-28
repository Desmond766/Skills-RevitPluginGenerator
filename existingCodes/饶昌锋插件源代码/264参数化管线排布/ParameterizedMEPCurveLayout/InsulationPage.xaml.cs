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
    /// InsulationPage.xaml 的交互逻辑
    /// 根据选项进行保温与非保温的排序
    /// </summary>
    public partial class InsulationPage : Page
    {
        public InsulationPage()
        {
            InitializeComponent();
        }

        public RadioButton GetInsulatedRadioButton()
        {
            return Insulated;
        }
        public TextBox GetInsulatedTextBox()
        {
            return StructDistance;
        }
    }
}
