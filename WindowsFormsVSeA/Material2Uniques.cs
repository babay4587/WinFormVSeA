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
    public partial class Material2Uniques : Form
    {
        public Material2Uniques()
        {
            InitializeComponent();
        }

        private void Btn_M2Uni_Qty_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable(); //查询物料号与物料名称 填写textbox
                
                if (!string.IsNullOrEmpty(this.TB_MatUni_A.Text)&& !string.IsNullOrEmpty(this.TB_MatUni_B.Text)&& !string.IsNullOrEmpty(this.TB_M2Uni_Interval.Text))
                {
                    string StrDate = DTPicker_M2Uni1.Value.ToString("yyyy-MM-dd");
                    double d = Convert.ToDouble(TB_M2Uni_Interval.Text);

                    if (d > 15)
                    {
                        MessageBox.Show("时间间隔不能大于15天！");
                        return;
                    }

                    DataTable dtMat = new DataTable();//填写物料名称查询
                    dtMat = Form1.SSQL.Qty_MMwDefVers_MatDesc(this.TB_MatUni_A.Text);
                    if (dtMat != null && dtMat.Rows.Count > 0)
                    {
                        Lb_Mat2Uni_A.Text = dtMat.Rows[0][2].ToString();
                    }
                    else
                    {
                        MessageBox.Show("物料号错误！");
                        return;
                    }

                    dtMat = Form1.SSQL.Qty_MMwDefVers_MatDesc(this.TB_MatUni_B.Text);
                    if (dtMat != null && dtMat.Rows.Count > 0)
                    {
                        Lb_Mat2Uni_B.Text = dtMat.Rows[0][2].ToString();
                    }
                    else
                    {
                        MessageBox.Show("物料号错误！");
                        return;
                    }


                    DTPicker_M2Uni2.Value = DTPicker_M2Uni1.Value.AddDays(d);
                    string EndDate = DTPicker_M2Uni2.Value.ToString("yyyy-MM-dd");

                    StrDate = StrDate + "  00:00";
                    EndDate = EndDate + " 23:59";

                    dt = Form1.SSQL.Qty_Material2Unique(this.TB_MatUni_A.Text,this.TB_MatUni_B.Text,StrDate,EndDate);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        GridV_M2Uni_1.DataSource = dt;

                        GridV_M2Uni_1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        GridV_M2Uni_1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                        GridV_M2Uni_1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        GridV_M2Uni_1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        GridV_M2Uni_1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        GridV_M2Uni_1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        DataRow dr = dt.NewRow();
                        dr[1] = "Summary Total:";
                        dr[2] = dt.Rows.Count;
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        MessageBox.Show("无对应数据！");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("物料料号或时间间隔天数未填写 ！");
                    return;
                }
                
                dt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Material2Uniques_Load(object sender, EventArgs e)
        {
            DTPicker_M2Uni2.Enabled = false;
        }

        private void Btn_MeasureBack_Click(object sender, EventArgs e)
        {

        }
    }
}
