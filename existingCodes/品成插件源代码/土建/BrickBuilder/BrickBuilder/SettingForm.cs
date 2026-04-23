using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BrickBuilder
{
    public partial class SettingForm : System.Windows.Forms.Form
    {
        //属性
        public BrickWall wallInfo;
        public Autodesk.Revit.DB.Wall m_wall;
        //记录上次输入
        public static List<string> lastData; 

        //构造函数
        public SettingForm(Autodesk.Revit.DB.Wall wall)
        {
            InitializeComponent();
            m_wall = wall;
        }

        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (null != lastData)
            {
                tbx_WallSerial.Text = lastData[0];

                cbx_TopBrickMat.Text = lastData[1];
                tbx_TopBrickLength.Text = lastData[2];
                tbx_TopBrickWidth.Text = lastData[3];
                tbx_TopBrickTickness.Text = lastData[4];
                tbx_TopHeight.Text = lastData[5];

                cbx_MiddleBrickMat.Text = lastData[6];
                tbx_MiddleBrickLength.Text = lastData[7];
                tbx_MiddleBrickWidth.Text = lastData[8];
                tbx_MiddleBrickTickness.Text = lastData[9];
                tbx_MiddleBrickOffset.Text = lastData[10];

                cbx_BottomBrickMat.Text = lastData[11];
                tbx_BottomBrickLength.Text = lastData[12];
                tbx_BottomBrickWidth.Text = lastData[13];
                tbx_BottomBrickTickness.Text = lastData[14];
                tbx_BottomBrickOffset.Text = lastData[15];

                tbx_hPlasterTick.Text = lastData[16];
                tbx_vPlasterTick.Text = lastData[17];
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            //创建墙信息
            wallInfo = new BrickWall(m_wall);
            //参数合法性检查
            if (!VauleValidCheck())
            {
                return;
            }
            //墙编号
            wallInfo.Serial = tbx_WallSerial.Text;
            //塞缝砖
            var topWall = new TopWall()
            {
                Brick = new Brick()
                {
                    Material = cbx_TopBrickMat.Text,
                    Length = double.Parse(tbx_TopBrickLength.Text) / 304.8,
                    Width = double.Parse(tbx_TopBrickWidth.Text) / 304.8,
                    Tickness = double.Parse(tbx_TopBrickTickness.Text) / 304.8
                },
                Height = double.Parse(tbx_TopHeight.Text) / 304.8,
                BasePoint = wallInfo.Start 
            };
            wallInfo.TopWall = topWall;
            //砌块砖
            var middleWall = new MiddleWall()
            {
                Brick = new Brick()
                {
                    Material = cbx_MiddleBrickMat.Text,
                    Length = double.Parse(tbx_MiddleBrickLength.Text) / 304.8,
                    Width = double.Parse(tbx_MiddleBrickWidth.Text) / 304.8,
                    Tickness = double.Parse(tbx_MiddleBrickTickness.Text) / 304.8
                },
                BrickOffset = double.Parse(tbx_MiddleBrickOffset.Text) / 100.0
                //Height与BasePoint再塞缝墙生成完后计算
            };
            wallInfo.MiddleWall = middleWall;
            //导墙砖
            var bottomWall = new BottomWall()
            {
                Brick = new Brick()
                {
                    Material = cbx_BottomBrickMat.Text,
                    Length = double.Parse(tbx_BottomBrickLength.Text) / 304.8,
                    Width = double.Parse(tbx_BottomBrickWidth.Text) / 304.8,
                    Tickness = double.Parse(tbx_BottomBrickTickness.Text) / 304.8
                },
                BrickOffset = double.Parse(tbx_BottomBrickOffset.Text) / 100.0
                //Height与BasePoint再塞缝墙生成完后计算
            };
            wallInfo.BottomWall = bottomWall;
            //灰缝
            wallInfo.HTickness = double.Parse(tbx_hPlasterTick.Text) / 304.8;
            wallInfo.VTickness = double.Parse(tbx_vPlasterTick.Text) / 304.8;

            //灰缝偏移
            var offset = wallInfo.Direction * wallInfo.VTickness + XYZ.BasisZ.Negate() * wallInfo.HTickness;
            wallInfo.TopWall.BasePoint += offset;

            //更新lastData
            lastData = new List<string>() { 
                tbx_WallSerial.Text,

                cbx_TopBrickMat.Text,
                tbx_TopBrickLength.Text,
                tbx_TopBrickWidth.Text,
                tbx_TopBrickTickness.Text,
                tbx_TopHeight.Text,

                cbx_MiddleBrickMat.Text,
                tbx_MiddleBrickLength.Text,
                tbx_MiddleBrickWidth.Text,
                tbx_MiddleBrickTickness.Text,
                tbx_MiddleBrickOffset.Text,

                cbx_BottomBrickMat.Text,
                tbx_BottomBrickLength.Text,
                tbx_BottomBrickWidth.Text,
                tbx_BottomBrickTickness.Text,
                tbx_BottomBrickOffset.Text,

                tbx_hPlasterTick.Text,
                tbx_vPlasterTick.Text,
            };

            //关闭窗口
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region 参数合法性检查
        /// <summary>
        /// 参数合法性检查
        /// </summary>
        /// <returns></returns>
        private bool VauleValidCheck()
        {
            if (string.IsNullOrEmpty(tbx_WallSerial.Text)

                || string.IsNullOrEmpty(cbx_TopBrickMat.Text)
                || string.IsNullOrEmpty(tbx_TopBrickLength.Text)
                || string.IsNullOrEmpty(tbx_TopBrickWidth.Text)
                || string.IsNullOrEmpty(tbx_TopBrickTickness.Text)
                || string.IsNullOrEmpty(tbx_TopHeight.Text)

                || string.IsNullOrEmpty(cbx_MiddleBrickMat.Text)
                || string.IsNullOrEmpty(tbx_MiddleBrickLength.Text)
                || string.IsNullOrEmpty(tbx_MiddleBrickWidth.Text)
                || string.IsNullOrEmpty(tbx_MiddleBrickTickness.Text)
                || string.IsNullOrEmpty(tbx_MiddleBrickOffset.Text)

                || string.IsNullOrEmpty(cbx_BottomBrickMat.Text)
                || string.IsNullOrEmpty(tbx_BottomBrickLength.Text)
                || string.IsNullOrEmpty(tbx_BottomBrickWidth.Text)
                || string.IsNullOrEmpty(tbx_BottomBrickTickness.Text)

                || string.IsNullOrEmpty(tbx_hPlasterTick.Text)
                || string.IsNullOrEmpty(tbx_vPlasterTick.Text)
                )
            {
                MessageBox.Show("所有参数设置不能为空！");
                return false;
            }
            if (double.Parse(tbx_TopBrickLength.Text) <= 0.0
                || double.Parse(tbx_TopBrickWidth.Text) <= 0.0
                || double.Parse(tbx_TopBrickTickness.Text) <= 0.0

                || double.Parse(tbx_MiddleBrickLength.Text) <= 0.0
                || double.Parse(tbx_MiddleBrickWidth.Text) <= 0.0
                || double.Parse(tbx_MiddleBrickTickness.Text) <= 0.0

                || double.Parse(tbx_BottomBrickLength.Text) <= 0.0
                || double.Parse(tbx_BottomBrickWidth.Text) <= 0.0
                || double.Parse(tbx_BottomBrickTickness.Text) <= 0.0
                )
            {
                MessageBox.Show("砖尺寸参数不能为负数！");
                return false;
            }
            if (wallInfo.Height 
                - double.Parse(tbx_TopHeight.Text) / 304.8 
                <= 0.0)
            {
                MessageBox.Show("塞缝高度超过墙高！");
                return false;
            }
            return true;
        }
        #endregion
        
    }
}
