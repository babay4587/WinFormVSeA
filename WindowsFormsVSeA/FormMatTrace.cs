using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsVSeA
{
    public partial class FormMatTrace : Form
    {
        public WindowsFormsVSeA.DoSQL SSQL = new DoSQL(); //新申明的实例化对象 SSQL，其中DBConnStr连接参数为空！

        public Class_User.UserModel UserUModel = new Class_User.UserModel();

        public DataTable dtSNRs = new DataTable();

        public FormMatTrace()
        {
            InitializeComponent();
        }

        private void FormMatTrace_Load(object sender, EventArgs e)
        {
            
            //TB_SNR.Text = Form1.CUModel.TranSerialNumber;
            //TBunicode.Text = Form1.CUModel.UniqueMatCode;
            //TBMatDesc.Text = Form1.CUModel.MaterialDesc;
            string ddb = Form1.SSQL.DBConnStr;
                        

        }

       

        private void BindTreeData(TreeNode tn, DataTable dtData, string strValue)
        {
            TreeNode tn1 = new TreeNode();
            tn1.Name = strValue;
            tn1.Text = strValue;
            tn.Nodes.Add(tn1);

            DataRow[] rows = dtData.Select(string.Format("SerialNumber='{0}'", strValue));
            if (rows.Length > 0)
            {
                foreach (DataRow dr in rows)
                {
                    TreeNode tn2 = new TreeNode();
                    tn2.Name = dr["SerialNumber"].ToString();
                    tn2.Text = dr["changetime"].ToString();
                    tn1.Nodes.Add(tn2);
                }
            }
        }

        private void checkBox_WO_Start_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WO_Start.CheckState == CheckState.Checked)
            {
                try
                {
                    if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                    {
                        MessageBox.Show("数据库未连接 ！");
                        return;
                    }


                    DataTable dtWOStr = new DataTable();

                    if (this.tb_WOStr.Text == "" || string.IsNullOrEmpty(this.tb_WOStr.Text))
                    {
                        MessageBox.Show("需要先输入 要查询已过站工站的短名，可 %模糊查询");
                        return;
                    }

                    dtWOStr = Form1.SSQL.Qty_NG_ShortName(tb_WOStr.Text.ToUpper());
                    if (dtWOStr != null || dtWOStr.Rows.Count > 0)
                    {
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.DataSource = dtWOStr;

                        Form1.Class_User.DataGridView_UI_Setup(this.dataGridView1);//设置datagridview显示UI
                        this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void checkBox_WO_End_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_WO_End.CheckState == CheckState.Checked)
                {

                    if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                    {
                        MessageBox.Show("数据库未连接 ！");
                        return;
                    }


                    DataTable dtWOEnd = new DataTable();

                    if (this.tb_WOEnd.Text == "" || string.IsNullOrEmpty(this.tb_WOEnd.Text))
                    {
                        MessageBox.Show("需要先输入 要查询未开始工站的短名，可 %模糊查询");
                        return;
                    }

                    dtWOEnd = Form1.SSQL.Qty_NG_ShortName(tb_WOEnd.Text.ToUpper());
                    if (dtWOEnd != null || dtWOEnd.Rows.Count > 0)
                    {
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.DataSource = dtWOEnd;

                        Form1.Class_User.DataGridView_UI_Setup(this.dataGridView1);//设置datagridview显示UI
                        this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (this.tb_WOStr.Text == "" || string.IsNullOrEmpty(this.tb_WOStr.Text))
                {
                    MessageBox.Show("需要先输入 已过站工站的短名");
                    return;
                }

                if (this.tb_WOEnd.Text == "" || string.IsNullOrEmpty(this.tb_WOEnd.Text))
                {
                    MessageBox.Show("需要先输入 未开始工站的短名");
                    return;
                }

                string StrDate = DTPicker_WOStartT.Value.ToString("yyyy-MM-dd");
                string EndDate = DTPicker_WOEndT.Value.ToString("yyyy-MM-dd");

                if (DTPicker_WOStartT.Value >= DTPicker_WOEndT.Value)
                {
                    MessageBox.Show("开始时间不能大于结束时间 ！");
                    return;
                }

                StrDate = StrDate + " 00:00:00";
                EndDate = EndDate + " 23:59:59";

                
                
                dtSNRs = Form1.SSQL.Qty_WO_End2Start_SNRs(this.tb_WOStr.Text, this.tb_WOEnd.Text, StrDate, EndDate);

                if (dtSNRs == null || dtSNRs.Rows.Count < 0)
                {
                    MessageBox.Show("查无数据 ！");
                    return;
                }
                else
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = dtSNRs;

                    Form1.Class_User.DataGridView_UI_Setup(this.dataGridView1);//设置datagridview显示UI

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    
                    this.label6.Text = dtSNRs.Rows.Count.ToString() + "  行";

                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = saveFileDialog1.FileName.ToString(); //获得文件路径
                    string FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); //获取文件路径，不带文件名
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string newFileName = fileNameExt+"_"+DateTime.Now.ToString("yyyyMMdd") ;

                    this.textBox_path.Text = Path.Combine(FilePath, newFileName + ".xlsx");

                    DataTable dt2Exl = new DataTable();
                    dt2Exl.Columns.Add("SNR", typeof(string));

                    if (dtSNRs == null || dtSNRs.Rows.Count < 0)
                    {
                        MessageBox.Show("未查询到数据，不能导出" );
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < dtSNRs.Rows.Count; i++)
                        {
                            DataRow newRow = dt2Exl.NewRow();
                            newRow["SNR"] = dataGridView1.Rows[i].Cells[1].Value.ToString(); //默认是第二列
                            dt2Exl.Rows.Add(newRow);

                        }
                    }

                    int WriteRows = ExcelHelper.DataTableToExcel(dt2Exl, this.textBox_path.Text);
                    MessageBox.Show("写入 EXCEL文件共：" + WriteRows.ToString() + " 行");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
