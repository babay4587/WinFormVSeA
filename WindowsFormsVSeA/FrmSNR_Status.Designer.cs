namespace WindowsFormsVSeA
{
    partial class FrmSNR_Status
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DateGridV_MMLotStatuses = new System.Windows.Forms.DataGridView();
            this.Btn_SNRStd_Qty = new System.Windows.Forms.Button();
            this.ChkBox9 = new System.Windows.Forms.CheckBox();
            this.ChkBox12 = new System.Windows.Forms.CheckBox();
            this.ChkBox6 = new System.Windows.Forms.CheckBox();
            this.ChkBox2 = new System.Windows.Forms.CheckBox();
            this.ChkBox0 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_MMLotStatuses)).BeginInit();
            this.SuspendLayout();
            // 
            // DateGridV_MMLotStatuses
            // 
            this.DateGridV_MMLotStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_MMLotStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_MMLotStatuses.EnableHeadersVisualStyles = false;
            this.DateGridV_MMLotStatuses.Location = new System.Drawing.Point(12, 88);
            this.DateGridV_MMLotStatuses.Name = "DateGridV_MMLotStatuses";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_MMLotStatuses.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_MMLotStatuses.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DateGridV_MMLotStatuses.RowTemplate.Height = 30;
            this.DateGridV_MMLotStatuses.Size = new System.Drawing.Size(1408, 724);
            this.DateGridV_MMLotStatuses.TabIndex = 6;
            // 
            // Btn_SNRStd_Qty
            // 
            this.Btn_SNRStd_Qty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SNRStd_Qty.Location = new System.Drawing.Point(65, 40);
            this.Btn_SNRStd_Qty.Name = "Btn_SNRStd_Qty";
            this.Btn_SNRStd_Qty.Size = new System.Drawing.Size(105, 42);
            this.Btn_SNRStd_Qty.TabIndex = 7;
            this.Btn_SNRStd_Qty.Text = "查询";
            this.Btn_SNRStd_Qty.UseVisualStyleBackColor = true;
            this.Btn_SNRStd_Qty.Click += new System.EventHandler(this.Btn_SNRStd_Qty_Click);
            // 
            // ChkBox9
            // 
            this.ChkBox9.AutoSize = true;
            this.ChkBox9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBox9.Location = new System.Drawing.Point(185, 43);
            this.ChkBox9.Name = "ChkBox9";
            this.ChkBox9.Size = new System.Drawing.Size(95, 28);
            this.ChkBox9.TabIndex = 8;
            this.ChkBox9.Text = "报废[9]";
            this.ChkBox9.UseVisualStyleBackColor = true;
            // 
            // ChkBox12
            // 
            this.ChkBox12.AutoSize = true;
            this.ChkBox12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBox12.Location = new System.Drawing.Point(281, 43);
            this.ChkBox12.Name = "ChkBox12";
            this.ChkBox12.Size = new System.Drawing.Size(124, 28);
            this.ChkBox12.TabIndex = 8;
            this.ChkBox12.Text = "已完成[12]";
            this.ChkBox12.UseVisualStyleBackColor = true;
            // 
            // ChkBox6
            // 
            this.ChkBox6.AutoSize = true;
            this.ChkBox6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBox6.Location = new System.Drawing.Point(408, 43);
            this.ChkBox6.Name = "ChkBox6";
            this.ChkBox6.Size = new System.Drawing.Size(86, 28);
            this.ChkBox6.TabIndex = 8;
            this.ChkBox6.Text = "QC[6]";
            this.ChkBox6.UseVisualStyleBackColor = true;
            // 
            // ChkBox2
            // 
            this.ChkBox2.AutoSize = true;
            this.ChkBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBox2.Location = new System.Drawing.Point(498, 43);
            this.ChkBox2.Name = "ChkBox2";
            this.ChkBox2.Size = new System.Drawing.Size(148, 28);
            this.ChkBox2.TabIndex = 8;
            this.ChkBox2.Text = "加工中Prcs[2]";
            this.ChkBox2.UseVisualStyleBackColor = true;
            // 
            // ChkBox0
            // 
            this.ChkBox0.AutoSize = true;
            this.ChkBox0.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBox0.Location = new System.Drawing.Point(656, 43);
            this.ChkBox0.Name = "ChkBox0";
            this.ChkBox0.Size = new System.Drawing.Size(142, 28);
            this.ChkBox0.TabIndex = 8;
            this.ChkBox0.Text = "未开始n/a[0]";
            this.ChkBox0.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(65, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1345, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "查看物料扫描保存后表EC_SETUP_MAT_LABEL_TEMP数据，存在会有问题，逻辑：1.首先写表:EC_SETUP_MAT_LABEL;WO Start后" +
    "写入EC_SETUP_MAT_LABEL_TEMP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(805, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(623, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "WO End后EC_SETUP_MAT_LABEL保留; EC_SETUP_MAT_LABEL_TEMP清空";
            // 
            // FrmSNR_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 824);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkBox0);
            this.Controls.Add(this.ChkBox2);
            this.Controls.Add(this.ChkBox6);
            this.Controls.Add(this.ChkBox12);
            this.Controls.Add(this.ChkBox9);
            this.Controls.Add(this.Btn_SNRStd_Qty);
            this.Controls.Add(this.DateGridV_MMLotStatuses);
            this.Name = "FrmSNR_Status";
            this.Text = "序列号状态查询";
            this.Load += new System.EventHandler(this.FrmSNR_Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_MMLotStatuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DateGridV_MMLotStatuses;
        private System.Windows.Forms.Button Btn_SNRStd_Qty;
        private System.Windows.Forms.CheckBox ChkBox9;
        private System.Windows.Forms.CheckBox ChkBox12;
        private System.Windows.Forms.CheckBox ChkBox6;
        private System.Windows.Forms.CheckBox ChkBox2;
        private System.Windows.Forms.CheckBox ChkBox0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}