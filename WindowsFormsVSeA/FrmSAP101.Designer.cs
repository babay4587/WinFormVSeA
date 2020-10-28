namespace WindowsFormsVSeA
{
    partial class FrmSAP101
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSAP101));
            this.DateGridV_MatMas101_1 = new System.Windows.Forms.DataGridView();
            this.DTPicker1 = new System.Windows.Forms.DateTimePicker();
            this.DTPicker_E = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_MatmasQty = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_IntvalDay = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Orderid = new System.Windows.Forms.Button();
            this.Btn_Matid = new System.Windows.Forms.Button();
            this.DateGridV_MatMas101_2 = new System.Windows.Forms.DataGridView();
            this.Btn_SNRChk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_MatMas101_1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_MatMas101_2)).BeginInit();
            this.SuspendLayout();
            // 
            // DateGridV_MatMas101_1
            // 
            this.DateGridV_MatMas101_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_MatMas101_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_MatMas101_1.EnableHeadersVisualStyles = false;
            this.DateGridV_MatMas101_1.Location = new System.Drawing.Point(12, 98);
            this.DateGridV_MatMas101_1.Name = "DateGridV_MatMas101_1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_MatMas101_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_MatMas101_1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DateGridV_MatMas101_1.RowTemplate.Height = 30;
            this.DateGridV_MatMas101_1.Size = new System.Drawing.Size(1346, 443);
            this.DateGridV_MatMas101_1.TabIndex = 4;
            // 
            // DTPicker1
            // 
            this.DTPicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPicker1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker1.Location = new System.Drawing.Point(122, 13);
            this.DTPicker1.Name = "DTPicker1";
            this.DTPicker1.Size = new System.Drawing.Size(171, 31);
            this.DTPicker1.TabIndex = 5;
            this.DTPicker1.ValueChanged += new System.EventHandler(this.DTPicker1_ValueChanged);
            // 
            // DTPicker_E
            // 
            this.DTPicker_E.CalendarFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPicker_E.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPicker_E.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker_E.Location = new System.Drawing.Point(413, 12);
            this.DTPicker_E.Name = "DTPicker_E";
            this.DTPicker_E.Size = new System.Drawing.Size(171, 31);
            this.DTPicker_E.TabIndex = 5;
            this.DTPicker_E.ValueChanged += new System.EventHandler(this.DTPicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "开始时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(307, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = "结束时间：";
            // 
            // Btn_MatmasQty
            // 
            this.Btn_MatmasQty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_MatmasQty.Location = new System.Drawing.Point(805, 12);
            this.Btn_MatmasQty.Name = "Btn_MatmasQty";
            this.Btn_MatmasQty.Size = new System.Drawing.Size(89, 33);
            this.Btn_MatmasQty.TabIndex = 41;
            this.Btn_MatmasQty.Text = "查询";
            this.Btn_MatmasQty.UseVisualStyleBackColor = true;
            this.Btn_MatmasQty.Click += new System.EventHandler(this.Btn_MatmasQty_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(607, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 40;
            this.label3.Text = "间隔天数：";
            // 
            // TB_IntvalDay
            // 
            this.TB_IntvalDay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_IntvalDay.Location = new System.Drawing.Point(713, 13);
            this.TB_IntvalDay.Name = "TB_IntvalDay";
            this.TB_IntvalDay.Size = new System.Drawing.Size(72, 31);
            this.TB_IntvalDay.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Orderid);
            this.groupBox1.Controls.Add(this.Btn_Matid);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(915, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 81);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary Zone";
            // 
            // Btn_Orderid
            // 
            this.Btn_Orderid.BackColor = System.Drawing.SystemColors.Info;
            this.Btn_Orderid.Location = new System.Drawing.Point(118, 41);
            this.Btn_Orderid.Name = "Btn_Orderid";
            this.Btn_Orderid.Size = new System.Drawing.Size(75, 34);
            this.Btn_Orderid.TabIndex = 0;
            this.Btn_Orderid.Text = "工单号";
            this.Btn_Orderid.UseVisualStyleBackColor = false;
            this.Btn_Orderid.Click += new System.EventHandler(this.Btn_Orderid_Click);
            // 
            // Btn_Matid
            // 
            this.Btn_Matid.BackColor = System.Drawing.SystemColors.Info;
            this.Btn_Matid.Location = new System.Drawing.Point(15, 41);
            this.Btn_Matid.Name = "Btn_Matid";
            this.Btn_Matid.Size = new System.Drawing.Size(75, 34);
            this.Btn_Matid.TabIndex = 0;
            this.Btn_Matid.Text = "物料号";
            this.Btn_Matid.UseVisualStyleBackColor = false;
            this.Btn_Matid.Click += new System.EventHandler(this.Btn_Matid_Click);
            // 
            // DateGridV_MatMas101_2
            // 
            this.DateGridV_MatMas101_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_MatMas101_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_MatMas101_2.EnableHeadersVisualStyles = false;
            this.DateGridV_MatMas101_2.Location = new System.Drawing.Point(12, 552);
            this.DateGridV_MatMas101_2.Name = "DateGridV_MatMas101_2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_MatMas101_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DateGridV_MatMas101_2.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_MatMas101_2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DateGridV_MatMas101_2.RowTemplate.Height = 30;
            this.DateGridV_MatMas101_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DateGridV_MatMas101_2.Size = new System.Drawing.Size(911, 149);
            this.DateGridV_MatMas101_2.TabIndex = 4;
            // 
            // Btn_SNRChk
            // 
            this.Btn_SNRChk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SNRChk.Location = new System.Drawing.Point(690, 52);
            this.Btn_SNRChk.Name = "Btn_SNRChk";
            this.Btn_SNRChk.Size = new System.Drawing.Size(117, 35);
            this.Btn_SNRChk.TabIndex = 44;
            this.Btn_SNRChk.Text = "空SNR检查";
            this.Btn_SNRChk.UseVisualStyleBackColor = true;
            this.Btn_SNRChk.Click += new System.EventHandler(this.Btn_SNRChk_Click);
            // 
            // FrmSAP101
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 708);
            this.Controls.Add(this.Btn_SNRChk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TB_IntvalDay);
            this.Controls.Add(this.Btn_MatmasQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPicker_E);
            this.Controls.Add(this.DTPicker1);
            this.Controls.Add(this.DateGridV_MatMas101_2);
            this.Controls.Add(this.DateGridV_MatMas101_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSAP101";
            this.Text = "SAP MatMas 101";
            this.Load += new System.EventHandler(this.FrmSAP101_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_MatMas101_1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_MatMas101_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DateGridV_MatMas101_1;
        private System.Windows.Forms.DateTimePicker DTPicker1;
        private System.Windows.Forms.DateTimePicker DTPicker_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_MatmasQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_IntvalDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Orderid;
        private System.Windows.Forms.Button Btn_Matid;
        private System.Windows.Forms.DataGridView DateGridV_MatMas101_2;
        private System.Windows.Forms.Button Btn_SNRChk;
    }
}