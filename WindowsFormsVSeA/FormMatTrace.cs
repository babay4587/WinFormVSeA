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
        public WindowsFormsVSeA.DoSQL SSQL = new DoSQL(); //新申明的实例化对象 SSQL，其中DBConnStr连接参数为空！

        public Class_User.UserModel UserUModel = new Class_User.UserModel();

        public DataTable dt = new DataTable();
        public FormMatTrace()
        {
            InitializeComponent();
        }

        private void FormMatTrace_Load(object sender, EventArgs e)
        {
            
            TB_SNR.Text = Form1.CUModel.TranSerialNumber;
            TBunicode.Text = Form1.CUModel.UniqueMatCode;
            TBMatDesc.Text = Form1.CUModel.MaterialDesc;
            string ddb = Form1.SSQL.DBConnStr;

            
            if (this.TB_SNR.Text != "" || !string.IsNullOrEmpty(this.TB_SNR.Text))
            {
                
                dt =Form1.SSQL.Qty_MMlot_TargetPK2SNR(this.TB_SNR.Text);

                if (dt != null && dt.Rows.Count > 0)
                {

                    TBAssembleTo.Text = dt.Rows[0][1].ToString();
                    string MaDesc = dt.Rows[0][0].ToString().Split('_')[0];

                    //TB_TargetMatDesc.Text= TB_TargetMatDesc.Text.Split('_')[0];

                    if ( !string.IsNullOrEmpty(MaDesc))
                    {
                        DataTable dtDefName = new DataTable();
                        dtDefName = Form1.SSQL.Qty_MMwDefVers_MatDesc(MaDesc);
                        this.TB_TargetMatDesc.Text = dtDefName.Rows[0][2].ToString();
                    }

                }
                else
                {
                    MessageBox.Show("未查询到 物料追溯 数据");
                }
            }
        }

        /// <summary>
        /// 点击 操作TreeView控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTreeAct_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DtTre = new DataTable();

                if (string.IsNullOrEmpty(TBAssembleTo.Text))
                {
                    MessageBox.Show("无可追溯数据");
                    return;
                }

                TreeNode tn = new TreeNode("RootCode");
                //tn.Name = "全部";
                //tn.Text = "全部";
                TreeV1.Nodes.Add(tn);

                if (string.IsNullOrEmpty(TBunicode.Text.Split('_')[1].ToString()))
                {
                    MessageBox.Show("唯一码：物料号不存在；应该为 : MaterialNumber_UniqueCode 格式");
                    return;
                }

                DtTre = Form1.SSQL.Qty_CTEMat(TBunicode.Text.Split('_')[1].ToString());

                if (DtTre.Rows.Count > 0 || dt != null)
                {
                    foreach (DataRow Row in DtTre.Rows)
                    {
                        string strValue = Row["SerialNumber"].ToString()+";"+Row["changetime"].ToString();

                        TreeNode tn1 = new TreeNode(strValue);
                        
                        TreeV1.Nodes.Add(tn1);
                        //if (tn.Nodes.Count > 0)
                        //{
                        //    if (!tn.Nodes.ContainsKey(strValue))
                        //    {
                        //        BindTreeData(tn, DtTre, strValue);
                        //    }
                        //}
                        //else
                        //{
                        //    BindTreeData(tn, DtTre, strValue);
                        //}
                    }
                }

               
                TreeV1.ExpandAll();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
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

    }
}
