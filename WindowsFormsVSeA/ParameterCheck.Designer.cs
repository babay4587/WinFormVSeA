namespace WindowsFormsVSeA
{
    partial class ParameterCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_filepath = new System.Windows.Forms.TextBox();
            this.BT_importExcel = new System.Windows.Forms.Button();
            this.DGV_fromExcel = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BT_Crosschk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGV_MESPara = new System.Windows.Forms.DataGridView();
            this.Bt_Mes_Para = new System.Windows.Forms.Button();
            this.dataGV_ResultDisplay = new System.Windows.Forms.DataGridView();
            this.Bt_StartCHK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox_Chaji = new System.Windows.Forms.CheckBox();
            this.TB_WorkOP = new System.Windows.Forms.TextBox();
            this.checkBox_ColCHK = new System.Windows.Forms.CheckBox();
            this.Bt_UpdateObjID = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_MachineID = new System.Windows.Forms.CheckBox();
            this.checkBox_Shortname = new System.Windows.Forms.CheckBox();
            this.textBox_machineid = new System.Windows.Forms.TextBox();
            this.textBox_shortname = new System.Windows.Forms.TextBox();
            this.button_importShopfloor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_fromExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_MESPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_ResultDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Infra List Excel汇总表导入路径：";
            // 
            // TB_filepath
            // 
            this.TB_filepath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TB_filepath.Location = new System.Drawing.Point(16, 47);
            this.TB_filepath.Name = "TB_filepath";
            this.TB_filepath.Size = new System.Drawing.Size(667, 31);
            this.TB_filepath.TabIndex = 1;
            // 
            // BT_importExcel
            // 
            this.BT_importExcel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.BT_importExcel.Location = new System.Drawing.Point(699, 43);
            this.BT_importExcel.Name = "BT_importExcel";
            this.BT_importExcel.Size = new System.Drawing.Size(104, 35);
            this.BT_importExcel.TabIndex = 2;
            this.BT_importExcel.Text = "导入Excel";
            this.BT_importExcel.UseVisualStyleBackColor = true;
            this.BT_importExcel.Click += new System.EventHandler(this.BT_importExcel_Click);
            // 
            // DGV_fromExcel
            // 
            this.DGV_fromExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_fromExcel.DefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_fromExcel.Location = new System.Drawing.Point(12, 86);
            this.DGV_fromExcel.Name = "DGV_fromExcel";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_fromExcel.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_fromExcel.RowTemplate.Height = 30;
            this.DGV_fromExcel.Size = new System.Drawing.Size(925, 434);
            this.DGV_fromExcel.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Location = new System.Drawing.Point(967, 86);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(750, 434);
            this.dataGridView1.TabIndex = 4;
            // 
            // BT_Crosschk
            // 
            this.BT_Crosschk.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.BT_Crosschk.Location = new System.Drawing.Point(1127, 41);
            this.BT_Crosschk.Name = "BT_Crosschk";
            this.BT_Crosschk.Size = new System.Drawing.Size(123, 37);
            this.BT_Crosschk.TabIndex = 5;
            this.BT_Crosschk.Text = "交叉检查";
            this.BT_Crosschk.UseVisualStyleBackColor = true;
            this.BT_Crosschk.Click += new System.EventHandler(this.BT_Crosschk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(963, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "交叉检查前需先从主页面导入连接配置XML文件";
            // 
            // dataGV_MESPara
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_MESPara.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGV_MESPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV_MESPara.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGV_MESPara.Location = new System.Drawing.Point(12, 581);
            this.dataGV_MESPara.Name = "dataGV_MESPara";
            this.dataGV_MESPara.RowTemplate.Height = 30;
            this.dataGV_MESPara.Size = new System.Drawing.Size(925, 300);
            this.dataGV_MESPara.TabIndex = 6;
            // 
            // Bt_Mes_Para
            // 
            this.Bt_Mes_Para.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Mes_Para.Location = new System.Drawing.Point(16, 531);
            this.Bt_Mes_Para.Name = "Bt_Mes_Para";
            this.Bt_Mes_Para.Size = new System.Drawing.Size(146, 43);
            this.Bt_Mes_Para.TabIndex = 7;
            this.Bt_Mes_Para.Text = " MES DB查询";
            this.Bt_Mes_Para.UseVisualStyleBackColor = true;
            this.Bt_Mes_Para.Click += new System.EventHandler(this.Bt_Mes_Para_Click);
            // 
            // dataGV_ResultDisplay
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_ResultDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGV_ResultDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV_ResultDisplay.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGV_ResultDisplay.Location = new System.Drawing.Point(967, 581);
            this.dataGV_ResultDisplay.Name = "dataGV_ResultDisplay";
            this.dataGV_ResultDisplay.RowTemplate.Height = 30;
            this.dataGV_ResultDisplay.Size = new System.Drawing.Size(750, 300);
            this.dataGV_ResultDisplay.TabIndex = 8;
            // 
            // Bt_StartCHK
            // 
            this.Bt_StartCHK.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Bt_StartCHK.Location = new System.Drawing.Point(965, 533);
            this.Bt_StartCHK.Name = "Bt_StartCHK";
            this.Bt_StartCHK.Size = new System.Drawing.Size(123, 43);
            this.Bt_StartCHK.TabIndex = 9;
            this.Bt_StartCHK.Text = "执行校验";
            this.Bt_StartCHK.UseVisualStyleBackColor = true;
            this.Bt_StartCHK.Click += new System.EventHandler(this.Bt_StartCHK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(185, 543);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 25);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Work-Op ID Filter";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox_Chaji
            // 
            this.checkBox_Chaji.AutoSize = true;
            this.checkBox_Chaji.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Chaji.Location = new System.Drawing.Point(1273, 545);
            this.checkBox_Chaji.Name = "checkBox_Chaji";
            this.checkBox_Chaji.Size = new System.Drawing.Size(218, 25);
            this.checkBox_Chaji.TabIndex = 10;
            this.checkBox_Chaji.Text = "Infra与MES配置差集校验";
            this.checkBox_Chaji.UseVisualStyleBackColor = true;
            // 
            // TB_WorkOP
            // 
            this.TB_WorkOP.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TB_WorkOP.Location = new System.Drawing.Point(361, 541);
            this.TB_WorkOP.Name = "TB_WorkOP";
            this.TB_WorkOP.Size = new System.Drawing.Size(99, 31);
            this.TB_WorkOP.TabIndex = 11;
            // 
            // checkBox_ColCHK
            // 
            this.checkBox_ColCHK.AutoSize = true;
            this.checkBox_ColCHK.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ColCHK.Location = new System.Drawing.Point(1096, 545);
            this.checkBox_ColCHK.Name = "checkBox_ColCHK";
            this.checkBox_ColCHK.Size = new System.Drawing.Size(164, 25);
            this.checkBox_ColCHK.TabIndex = 10;
            this.checkBox_ColCHK.Text = "单列重复数据校验";
            this.checkBox_ColCHK.UseVisualStyleBackColor = true;
            // 
            // Bt_UpdateObjID
            // 
            this.Bt_UpdateObjID.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Bt_UpdateObjID.Location = new System.Drawing.Point(1496, 533);
            this.Bt_UpdateObjID.Name = "Bt_UpdateObjID";
            this.Bt_UpdateObjID.Size = new System.Drawing.Size(123, 41);
            this.Bt_UpdateObjID.TabIndex = 12;
            this.Bt_UpdateObjID.Text = "更新OBJID";
            this.Bt_UpdateObjID.UseVisualStyleBackColor = true;
            this.Bt_UpdateObjID.Click += new System.EventHandler(this.Bt_UpdateObjID_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(466, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tip:过滤后不能进行差集校验";
            // 
            // checkBox_MachineID
            // 
            this.checkBox_MachineID.AutoSize = true;
            this.checkBox_MachineID.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_MachineID.Location = new System.Drawing.Point(1382, 8);
            this.checkBox_MachineID.Name = "checkBox_MachineID";
            this.checkBox_MachineID.Size = new System.Drawing.Size(169, 25);
            this.checkBox_MachineID.TabIndex = 14;
            this.checkBox_MachineID.Text = "MACHINE_ID过滤";
            this.checkBox_MachineID.UseVisualStyleBackColor = true;
            this.checkBox_MachineID.CheckedChanged += new System.EventHandler(this.checkBox_MachineID_CheckedChanged);
            // 
            // checkBox_Shortname
            // 
            this.checkBox_Shortname.AutoSize = true;
            this.checkBox_Shortname.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Shortname.Location = new System.Drawing.Point(1569, 7);
            this.checkBox_Shortname.Name = "checkBox_Shortname";
            this.checkBox_Shortname.Size = new System.Drawing.Size(155, 25);
            this.checkBox_Shortname.TabIndex = 14;
            this.checkBox_Shortname.Text = "ShortName过滤";
            this.checkBox_Shortname.UseVisualStyleBackColor = true;
            // 
            // textBox_machineid
            // 
            this.textBox_machineid.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox_machineid.Location = new System.Drawing.Point(1382, 45);
            this.textBox_machineid.Name = "textBox_machineid";
            this.textBox_machineid.Size = new System.Drawing.Size(134, 31);
            this.textBox_machineid.TabIndex = 1;
            // 
            // textBox_shortname
            // 
            this.textBox_shortname.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox_shortname.Location = new System.Drawing.Point(1583, 45);
            this.textBox_shortname.Name = "textBox_shortname";
            this.textBox_shortname.Size = new System.Drawing.Size(134, 31);
            this.textBox_shortname.TabIndex = 1;
            // 
            // button_importShopfloor
            // 
            this.button_importShopfloor.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_importShopfloor.Location = new System.Drawing.Point(967, 41);
            this.button_importShopfloor.Name = "button_importShopfloor";
            this.button_importShopfloor.Size = new System.Drawing.Size(142, 35);
            this.button_importShopfloor.TabIndex = 15;
            this.button_importShopfloor.Text = "Shopfloor导入";
            this.button_importShopfloor.UseVisualStyleBackColor = true;
            this.button_importShopfloor.Click += new System.EventHandler(this.button_importShopfloor_Click);
            // 
            // ParameterCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1731, 744);
            this.Controls.Add(this.button_importShopfloor);
            this.Controls.Add(this.checkBox_Shortname);
            this.Controls.Add(this.checkBox_MachineID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Bt_UpdateObjID);
            this.Controls.Add(this.TB_WorkOP);
            this.Controls.Add(this.checkBox_ColCHK);
            this.Controls.Add(this.checkBox_Chaji);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Bt_StartCHK);
            this.Controls.Add(this.dataGV_ResultDisplay);
            this.Controls.Add(this.Bt_Mes_Para);
            this.Controls.Add(this.dataGV_MESPara);
            this.Controls.Add(this.BT_Crosschk);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DGV_fromExcel);
            this.Controls.Add(this.BT_importExcel);
            this.Controls.Add(this.textBox_shortname);
            this.Controls.Add(this.textBox_machineid);
            this.Controls.Add(this.TB_filepath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ParameterCheck";
            this.Text = "ParameterCheck";
            this.Load += new System.EventHandler(this.ParameterCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_fromExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_MESPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_ResultDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_filepath;
        private System.Windows.Forms.Button BT_importExcel;
        private System.Windows.Forms.DataGridView DGV_fromExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BT_Crosschk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGV_MESPara;
        private System.Windows.Forms.Button Bt_Mes_Para;
        private System.Windows.Forms.DataGridView dataGV_ResultDisplay;
        private System.Windows.Forms.Button Bt_StartCHK;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox_Chaji;
        private System.Windows.Forms.TextBox TB_WorkOP;
        private System.Windows.Forms.CheckBox checkBox_ColCHK;
        private System.Windows.Forms.Button Bt_UpdateObjID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_MachineID;
        private System.Windows.Forms.CheckBox checkBox_Shortname;
        private System.Windows.Forms.TextBox textBox_machineid;
        private System.Windows.Forms.TextBox textBox_shortname;
        private System.Windows.Forms.Button button_importShopfloor;
    }
}