using System;
using System.Windows.Forms;

namespace PlaceByCurve
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        //默认值
        public static string _offset = "0";
        public static string _spacing = "500";

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //初始化填入默认值
            tbx_Offset.Text = _offset;
            tbx_Spacing.Text = _spacing;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                var m_offset = double.Parse(tbx_Offset.Text) / 304.8;
                var m_spacing = double.Parse(tbx_Spacing.Text) / 304.8;
                if (m_offset < 0.0 || m_spacing < 0.0)
                {
                    MessageBox.Show("数据非法！");
                    return;
                }
                //赋值
                Command.offset = m_offset;
                Command.spacing = m_spacing;
                //更新默认值
                _offset = tbx_Offset.Text;
                _spacing = tbx_Spacing.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("数据非法！");
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
