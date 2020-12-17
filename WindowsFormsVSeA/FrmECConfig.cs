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
    public partial class FrmECConfig : Form
    {
        public  WindowsFormsVSeA.ExcelHelper ExcelHelper = new ExcelHelper();
        public static Class_User Class_User = new Class_User();
        public DataView DVTrace = new DataView();

        public DataTable dt = new DataTable();

        public FrmECConfig()
        {
            InitializeComponent();
        }

        private void Btn_CO_Qty_Click(object sender, EventArgs e)
        {
            Class_User.DataGridView_UI_Setup(this.DateGridV_ECConfig_1);//设置datagridview显示UI

            try
            {
                if (!string.IsNullOrEmpty(TB_MachineID.Text))
                {
                    
                    dt = Form1.SSQL.EC_Config_Qty(TB_MachineID.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DateGridV_ECConfig_1.DataSource = dt;

                        foreach(DataColumn col in dt.Columns)
                        {
                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                if (dt.Rows[k][col].ToString().IndexOf(" ") >= 0)
                                {
                                    DateGridV_ECConfig_1.Rows[k].Cells[0].Style.BackColor = Color.LightGreen;
                                }
                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("输入Work Operation ID ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void FrmECConfig_Load(object sender, EventArgs e)
        {
            this.Size = new Size(980, 560);
        }

        private void Btn_NPOI_Excel_Chk_Click(object sender, EventArgs e)
        {
            string Path = @"../../TOOLS";
            string[] files = Directory.GetFiles(Path);

            DataTable Dt_right = new DataTable();

            List <DataTable>LstDt= ExcelHelper.ExcelToDataTable(files[0], 1, false);//暂时限定读取TOOLS下1个Excel文件;1:只读一个sheet；
            Dt_right = LstDt[0];

            if (Dt_right.Rows.Count > 0 && Dt_right.Rows.Count > 0)
            {
               

                DateGridV_ECConfig_2.DataSource = Dt_right;
            }

            CompareDT(dt, Dt_right);

            //var query=
            //    from MACHINE_ID_Left in dt.AsEnumerable()
            //    join MACHINE_ID_Right in Dt_right.AsEnumerable()
            //    on MACHINE_ID_Left.Field<string>("MACHINE_ID") equals
            //    MACHINE_ID_Right.Field<string>("MACHINE_ID") 
            //    select new
            //    {
            //        MACHINE_ID_Lf = MACHINE_ID_Left.Field<string>("MACHINE_ID"),
            //        Obj_Excel = MACHINE_ID_Right.Field<string>("Objectid")
            //    };

            //foreach(var v in query)
            //{
            //    v.MACHINE_ID_Lf
            //}
        }

        private void CompareDT(DataTable dtA, DataTable dtB)
        {
            List<string> ls = new List<string>();

            for (int i = 0; dtA.Rows.Count > i; i++)
            {
                for (int j = 0; dtB.Rows.Count > j; j++)
                {
                    if (dtA.Rows[i]["MACHINE_ID"].ToString() == dtB.Rows[j][0].ToString())
                    {
                        if (dtA.Rows[i]["Objectid"].ToString() != dtB.Rows[j][1].ToString())
                        {
                            //ls.Add(dtA.Rows[i]["Objectid"].ToString());
                            //dtB.Rows[j][1].ToString()
                                DateGridV_ECConfig_2.Rows[j].Cells[1].Style.BackColor = Color.LightGreen;
                        }
                    }
                }

            }
        }

        private void Btn_Test_Click(object sender, EventArgs e)
        {
            if (dt != null || dt.Rows.Count>0)
            {
                string d = "";
                
                
                    
                for(int i = 0; dt.Rows.Count > i; i++)
                {
                    d = dt.Rows[i]["ObjectID"].ToString();//比较object id
                }
                    
                
            }
        }
    }
}
