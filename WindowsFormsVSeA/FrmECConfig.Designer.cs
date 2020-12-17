namespace WindowsFormsVSeA
{
    partial class FrmECConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TB_MachineID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_CO_Qty = new System.Windows.Forms.Button();
            this.DateGridV_ECConfig_1 = new System.Windows.Forms.DataGridView();
            this.Btn_NPOI_Excel_Chk = new System.Windows.Forms.Button();
            this.Btn_Test = new System.Windows.Forms.Button();
            this.DateGridV_ECConfig_2 = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_ECConfig_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_ECConfig_2)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_MachineID
            // 
            this.TB_MachineID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_MachineID.Location = new System.Drawing.Point(241, 19);
            this.TB_MachineID.Name = "TB_MachineID";
            this.TB_MachineID.Size = new System.Drawing.Size(172, 31);
            this.TB_MachineID.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "加工中心ID(EC202000)：";
            // 
            // Btn_CO_Qty
            // 
            this.Btn_CO_Qty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CO_Qty.Location = new System.Drawing.Point(462, 13);
            this.Btn_CO_Qty.Name = "Btn_CO_Qty";
            this.Btn_CO_Qty.Size = new System.Drawing.Size(108, 44);
            this.Btn_CO_Qty.TabIndex = 45;
            this.Btn_CO_Qty.Text = "查询";
            this.Btn_CO_Qty.UseVisualStyleBackColor = true;
            this.Btn_CO_Qty.Click += new System.EventHandler(this.Btn_CO_Qty_Click);
            // 
            // DateGridV_ECConfig_1
            // 
            this.DateGridV_ECConfig_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_ECConfig_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_ECConfig_1.EnableHeadersVisualStyles = false;
            this.DateGridV_ECConfig_1.Location = new System.Drawing.Point(12, 92);
            this.DateGridV_ECConfig_1.Name = "DateGridV_ECConfig_1";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_ECConfig_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_ECConfig_1.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.DateGridV_ECConfig_1.RowTemplate.Height = 30;
            this.DateGridV_ECConfig_1.Size = new System.Drawing.Size(889, 648);
            this.DateGridV_ECConfig_1.TabIndex = 46;
            // 
            // Btn_NPOI_Excel_Chk
            // 
            this.Btn_NPOI_Excel_Chk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_NPOI_Excel_Chk.Location = new System.Drawing.Point(651, 13);
            this.Btn_NPOI_Excel_Chk.Name = "Btn_NPOI_Excel_Chk";
            this.Btn_NPOI_Excel_Chk.Size = new System.Drawing.Size(104, 44);
            this.Btn_NPOI_Excel_Chk.TabIndex = 47;
            this.Btn_NPOI_Excel_Chk.Text = "Excel校验";
            this.Btn_NPOI_Excel_Chk.UseVisualStyleBackColor = true;
            this.Btn_NPOI_Excel_Chk.Click += new System.EventHandler(this.Btn_NPOI_Excel_Chk_Click);
            // 
            // Btn_Test
            // 
            this.Btn_Test.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Test.Location = new System.Drawing.Point(918, 13);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(105, 44);
            this.Btn_Test.TabIndex = 48;
            this.Btn_Test.Text = "button1";
            this.Btn_Test.UseVisualStyleBackColor = true;
            this.Btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // DateGridV_ECConfig_2
            // 
            this.DateGridV_ECConfig_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_ECConfig_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_ECConfig_2.EnableHeadersVisualStyles = false;
            this.DateGridV_ECConfig_2.Location = new System.Drawing.Point(918, 92);
            this.DateGridV_ECConfig_2.Name = "DateGridV_ECConfig_2";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_ECConfig_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_ECConfig_2.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DateGridV_ECConfig_2.RowTemplate.Height = 30;
            this.DateGridV_ECConfig_2.Size = new System.Drawing.Size(538, 648);
            this.DateGridV_ECConfig_2.TabIndex = 46;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(30, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(113, 24);
            this.label24.TabIndex = 49;
            this.label24.Text = "From数据库:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(924, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 49;
            this.label1.Text = "From Excel:";
            // 
            // FrmECConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 844);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.Btn_Test);
            this.Controls.Add(this.Btn_NPOI_Excel_Chk);
            this.Controls.Add(this.DateGridV_ECConfig_2);
            this.Controls.Add(this.DateGridV_ECConfig_1);
            this.Controls.Add(this.Btn_CO_Qty);
            this.Controls.Add(this.TB_MachineID);
            this.Controls.Add(this.label3);
            this.Name = "FrmECConfig";
            this.Text = "EC Config";
            this.Load += new System.EventHandler(this.FrmECConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_ECConfig_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_ECConfig_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_MachineID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_CO_Qty;
        private System.Windows.Forms.DataGridView DateGridV_ECConfig_1;
        private System.Windows.Forms.Button Btn_NPOI_Excel_Chk;
        private System.Windows.Forms.Button Btn_Test;
        private System.Windows.Forms.DataGridView DateGridV_ECConfig_2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
    }
}