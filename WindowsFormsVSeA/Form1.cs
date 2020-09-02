using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;




namespace WindowsFormsVSeA
{
    public partial class Form1 : Form
    {
        public WindowsFormsVSeA.XmlDo xmlDo = new XmlDo();

        public WindowsFormsVSeA.DoSQL  SSQL = new DoSQL();

        public TextBox tb = new TextBox();

        public static string DBConnStr = string.Empty;

        public static Class_User.UserModel CUModel = new Class_User.UserModel();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Tb1.Text = openFileDialog1.FileName;

                string Fn = string.Empty;
                Fn = Path.GetExtension(openFileDialog1.FileName);

                if (Fn.ToUpper() == ".XML")
                {
                    DataTable Ddt = new DataTable();

                    Ddt = xmlDo.Sfloor_Conn(Tb1.Text);

                    if(Ddt.Rows.Count>0 || Ddt != null)
                    {
                        dataGridView1.DataSource = Ddt;

                        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        tB_RowCount.Text = dataGridView1.Rows.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("非XML文件");
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                dataGridView1.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }

            for (int i = e.RowIndex + e.RowCount; i < this.dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void btn_duplicate_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDuplicate=false;
                for(int nbRow = 0; nbRow < dataGridView1.Rows.Count-1; nbRow++)
                {
                    for(int NextRow = nbRow+ 1; NextRow <= dataGridView1.Rows.Count-2; NextRow++)
                    {
                        if (dataGridView1.Rows[nbRow].Cells[6].Value.ToString() == dataGridView1.Rows[NextRow].Cells[6].Value.ToString())
                        {
                            isDuplicate = true;
                            dataGridView1.Rows[nbRow].Cells[6].Style.BackColor = Color.LightGreen;
                            dataGridView1.Rows[NextRow].Cells[6].Style.BackColor = Color.LightGreen;
                        }
                    }
                   

                        if (isDuplicate)
                        {
                            //MessageBox.Show(dataGridView1[6, nbRow].Value.ToString());
                            isDuplicate = false;
                        }

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
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                if (this.tB_Order.Text !="" || !string.IsNullOrEmpty( this.tB_Order.Text) )
                {
                    DataTable dt = new DataTable();
                    dt=SSQL.Qty_Mat_Order(this.tB_Order.Text);


                    if(dt!=null && dt.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dt;

                        TB_Mat_Fert.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                        TB_MatDesc.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();

                        dataGridView2.Columns[0].Visible =false;
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[2].Visible = false;

                        dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                        dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("未查询到 Order 数据");
                    }
                }
                else
                {
                    MessageBox.Show("order id is null");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coboSele = comboBox1.SelectedItem.ToString();

            string connStatus = SSQL.DbConn(coboSele); //根据combo选项更改数据库连接
        }

        

        private void button3_Click(object sender, EventArgs e)
        {


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Tb2.Text = openFileDialog1.FileName;

                string Fn = string.Empty;
                Fn = Path.GetExtension(openFileDialog1.FileName);

                if (Fn.ToUpper() == ".XML")
                {
                    DataTable Ddt = new DataTable();

                   
                    Ddt = xmlDo.Get_LOIP_EQid(Tb2.Text);

                    if (Ddt.Rows.Count > 0 || Ddt != null)
                    {
                        dataGridView3.DataSource = Ddt;

                        dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView3.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView3.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        //tB_RowCount.Text = dataGridView1.Rows.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("非XML文件");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // xmlDo.updateTest(this.Tb2.Text);
            Class_User.UserModel Equip = new Class_User.UserModel();
            Equip.EquipmentID = textBox2.Text;
            dataGridView3.DefaultCellStyle.BackColor = Color.White;
            if (dataGridView3.RowCount <= 1||textBox2.Text=="")
            {
                MessageBox.Show("无数据可查询 或 要查询的数据为空!");
                return;
            }

            for(int i=0;i< dataGridView3.Rows.Count; i++)
            {
                for(int j = 0; j < dataGridView3.Columns.Count; j++)
                {

                    if (Convert.ToString( dataGridView3[j,i].Value).Contains(textBox2.Text))
                    {
                        dataGridView3.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dataGridView3.Rows[i].Cells[j].Style.BackColor = Color.White;//清除上次查询的颜色
                    }
                }
                
            }
            

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Dictionary<int, string> dict = dataGridView1.Rows.Cast<DataGridViewRow>()
            .Select((x, i) => new { x = (x.Cells[0].Value ?? "").ToString(), i })
            .ToDictionary(x => x.i + 1, x => x.x);
            if (dict.Any(x => x.Key != e.RowIndex + 1 && x.Value == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                MessageBox.Show("和" + dict.First(x => x.Key != e.RowIndex + 1 && x.Value == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()).Key.ToString() + "行重复");
            }
        }

      

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (comboBox1.Items.Count == 0)
                {
                    List<string> Conns = SSQL.GetConnectionStringsConfig();

                    if (Conns.Count != 0)
                    {
                        foreach (string i in Conns)
                        {
                            comboBox1.Items.Add(i);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void qSYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("Q_connString") == "ok")
                {
                    
                    this.tBColorQ.BackColor = Color.SpringGreen;
                    this.tBColorP.BackColor = Color.Empty;
                    //MessageBox.Show("Q-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pSYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("P_connString") == "ok")
                {
                    this.tBColorP.BackColor = Color.SpringGreen;
                    this.tBColorQ.BackColor = Color.Empty;
                    //MessageBox.Show("P-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                List<string> Conns = SSQL.GetConnectionStringsConfig();

                if (comboBox1.Text== "Q_connString")
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (string.IsNullOrEmpty(this.TB_UniMat.Text))
                {
                    MessageBox.Show("请输入要查询的唯一码 ！");
                    return;
                }
                

                if (this.TB_UniMat.Text != "" || !string.IsNullOrEmpty(this.TB_UniMat.Text))
                {
                    DataTable dt = new DataTable();
                    dt = SSQL.Qty_UniqueMat(this.TB_UniMat.Text);
                    
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView4.DataSource = dt;

                        TB_Mat_Fert.Text = dataGridView4.Rows[0].Cells[0].Value.ToString();
                        TB_MatDesc.Text = dataGridView4.Rows[0].Cells[1].Value.ToString();

                        
                        dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                        dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }
                    else
                    {
                        MessageBox.Show("未查询到 Unique Code 数据");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string SNR = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //MessageBox.Show(SNR);
        }


       
private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string SNR = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            string Unicode= dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            string MatDesc = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();

            CUModel.TranSerialNumber = SNR;
            CUModel.MaterialDesc = MatDesc;
            CUModel.UniqueMatCode = Unicode;


            new FormMatTrace().Show();
        }

        
    }
}
