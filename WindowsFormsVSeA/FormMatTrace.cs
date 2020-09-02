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
    public partial class FormMatTrace : Form
    {
        public WindowsFormsVSeA.DoSQL SSQL = new DoSQL();

        public Class_User.UserModel UserUModel = new Class_User.UserModel();
        public FormMatTrace()
        {
            InitializeComponent();
        }

        private void FormMatTrace_Load(object sender, EventArgs e)
        {
            
            TB_SNR.Text = Form1.CUModel.TranSerialNumber;
            TBunicode.Text = Form1.CUModel.UniqueMatCode;
            TBMatDesc.Text = Form1.CUModel.MaterialDesc;

            if (this.TBAssembleTo.Text != "" || !string.IsNullOrEmpty(this.TBAssembleTo.Text))
            {
                DataTable dt = new DataTable();
                dt = SSQL.Qty_MMlot_TargetPK2SNR(this.TBAssembleTo.Text);

                if (dt != null && dt.Rows.Count > 0)
                {

                    TBAssembleTo.Text = dt.Rows[0][1].ToString();
                    string MaDesc = dt.Rows[0][0].ToString().Split('_')[0];

                    //TB_TargetMatDesc.Text= TB_TargetMatDesc.Text.Split('_')[0];

                    if ( !string.IsNullOrEmpty(MaDesc))
                    {
                        DataTable dtDefName = new DataTable();
                        dtDefName = SSQL.Qty_MMwDefVers_MatDesc(MaDesc);
                        this.TB_TargetMatDesc.Text = dtDefName.Rows[0][0].ToString();
                    }

                }
                else
                {
                    MessageBox.Show("未查询到 物料追溯 数据");
                }
            }
        }
    }
}
