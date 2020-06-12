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
                if (this.dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("EC ShopFloor无数据");
                    return;
                }

                foreach (DataGridViewRow v in dataGridView1.Rows)
                {
                    if (v.Cells[0].Value != null)
                    {
                        var count = 0;
                        foreach (DataGridViewRow v2 in dataGridView1.Rows)
                        {
                            if (v2.Cells[0].Value != null)
                            {
                                if (v.Cells[0].Value.ToString().Trim().Equals(v2.Cells[0].Value.ToString().Trim()))
                                    count++;
                            }
                        }
                        if (count > 1)
                        {
                            MessageBox.Show("第1列有重复，重复的内容是:【" + v.Cells[5].Value+" || "+ v.Cells[6].Value + "】");
                            return;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.tB_Order.Text !="" || !string.IsNullOrEmpty( this.tB_Order.Text) )
                {
                    DataTable dt = new DataTable();
                    dt=SSQL.Qty_Batch_Order(this.tB_Order.Text);

                    dataGridView2.DataSource = dt;

                    dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                    dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
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

        private void tabPage2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                List<string> Conns = SSQL.GetConnectionStringsConfig();

                if (Conns.Count != 0)
                {
                    foreach (string i in Conns)
                    {
                        comboBox1.Items.Add(i);
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
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

                    if(textBox2.Text != "")
                    {
                        tb.Text = textBox2.Text;
                    }
                    else
                    {
                        return;
                    }

                    Ddt = xmlDo.Get_LOIP_EQid(Tb2.Text);

                    if (Ddt.Rows.Count > 0 || Ddt != null)
                    {
                        dataGridView3.DataSource = Ddt;

                        dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

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
            xmlDo.updateTest(this.Tb2.Text);
        }
    }
}
