using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper.ShopTicketChecking
{
    public partial class QtyCheckingFrm : Form
    {
        public DataTable _dt;
        public QtyCheckingFrm(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;
        }

        private void QtyCheckingFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dt;
            lbl_TotalPiece.Text = _dt.Rows.Count.ToString();
            List<DataRow> errorList = new List<DataRow>();
            foreach (DataRow item in _dt.Rows)
            {
                if (item["Result"].ToString() == "Error")
                {
                    errorList.Add(item);
                }
            }
            lbl_ErrorPiece.Text = errorList.Count.ToString();

            //着色
            var correctCS = new DataGridViewCellStyle() { ForeColor = System.Drawing.Color.DarkGreen };
            var errorCS = new DataGridViewCellStyle() { ForeColor = System.Drawing.Color.Red };

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 2; j < dataGridView1.ColumnCount; j++)//一二列不用比较
                {
                    dataGridView1[j, i].Style = correctCS;
                    if (null != dataGridView1[j, i].Value)
                    {
                        if (dataGridView1[j, i].Value.ToString() == ""
                            || dataGridView1[j, i].Value.ToString() == "Varies"
                            || dataGridView1[j, i].Value.ToString() == "Error")
                        {
                            dataGridView1[j, i].Style = errorCS;
                        }
                    }
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
