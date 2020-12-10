using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsVSeA
{
    public partial class FrmSNR_Status : Form
    {

        public static Class_User Class_User = new Class_User();

        public FrmSNR_Status()
        {
            InitializeComponent();
        }

        private void FrmSNR_Status_Load(object sender, EventArgs e)
        {
            Class_User.DataGridView_UI_Setup(this.DateGridV_MMLotStatuses);//设置datagridview显示UI
        }

        private void Btn_SNRStd_Qty_Click(object sender, EventArgs e)
        {
             List<CheckBox> LstBox;

            try
            {
                LstBox = new List<CheckBox>();

                string str = string.Empty;//查询字符串 拼接

                LstBox.Add(ChkBox0);
                LstBox.Add(ChkBox9);
                LstBox.Add(ChkBox12);
                LstBox.Add(ChkBox6);
                LstBox.Add(ChkBox2);

                for (int i = 0; i < LstBox.Count; i++)
                {
                    if (LstBox[i].Checked)
                    {
                        string[] Arr = LstBox[i].Text.Split('[',']');
                       
                        str += Arr[1] + ",";
                        
                    }
                }

                str = str.Substring(0, str.Length - 1);//去掉最右边的逗号

                str = str.Replace("'","");//去掉单引号

                DataTable dt = new DataTable();
                dt = Form1.SSQL.Qty_SNR_Std_Filter(str);
                if (dt != null && dt.Rows.Count > 0)
                {
                                        
                    Class_User.DataGridView_UI_Setup(this.DateGridV_MMLotStatuses);//设置datagridview显示UI
                    DateGridV_MMLotStatuses.DataSource = dt;
                    
                    DateGridV_MMLotStatuses.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MMLotStatuses.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MMLotStatuses.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MMLotStatuses.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dt.Dispose();
                }
                else
                {
                    
                    DateGridV_MMLotStatuses.DataSource = dt;

                    MessageBox.Show("查无数据 ！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
