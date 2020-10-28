namespace WindowsFormsVSeA
{
    partial class MES2SAPMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MES2SAPMonitor));
            this.TB_UnsentCount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_SAP_Monitor = new System.Windows.Forms.Button();
            this.dataGV_Monitor_1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_Monitor_1)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_UnsentCount
            // 
            this.TB_UnsentCount.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_UnsentCount.Location = new System.Drawing.Point(186, 37);
            this.TB_UnsentCount.Name = "TB_UnsentCount";
            this.TB_UnsentCount.Size = new System.Drawing.Size(177, 37);
            this.TB_UnsentCount.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(35, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 30);
            this.label19.TabIndex = 31;
            this.label19.Text = "未发送数量:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(389, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 30);
            this.label1.TabIndex = 31;
            this.label1.Text = "个";
            // 
            // Btn_SAP_Monitor
            // 
            this.Btn_SAP_Monitor.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SAP_Monitor.Location = new System.Drawing.Point(430, 30);
            this.Btn_SAP_Monitor.Name = "Btn_SAP_Monitor";
            this.Btn_SAP_Monitor.Size = new System.Drawing.Size(92, 54);
            this.Btn_SAP_Monitor.TabIndex = 32;
            this.Btn_SAP_Monitor.Text = "查询";
            this.Btn_SAP_Monitor.UseVisualStyleBackColor = true;
            this.Btn_SAP_Monitor.Click += new System.EventHandler(this.Btn_SAP_Monitor_Click);
            // 
            // dataGV_Monitor_1
            // 
            this.dataGV_Monitor_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGV_Monitor_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV_Monitor_1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV_Monitor_1.EnableHeadersVisualStyles = false;
            this.dataGV_Monitor_1.Location = new System.Drawing.Point(12, 97);
            this.dataGV_Monitor_1.Name = "dataGV_Monitor_1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_Monitor_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGV_Monitor_1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGV_Monitor_1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGV_Monitor_1.RowTemplate.Height = 30;
            this.dataGV_Monitor_1.Size = new System.Drawing.Size(1250, 483);
            this.dataGV_Monitor_1.TabIndex = 33;
            // 
            // MES2SAPMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 592);
            this.Controls.Add(this.dataGV_Monitor_1);
            this.Controls.Add(this.Btn_SAP_Monitor);
            this.Controls.Add(this.TB_UnsentCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MES2SAPMonitor";
            this.Text = "MES2SAPMonitor";
            this.Load += new System.EventHandler(this.MES2SAPMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_Monitor_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_UnsentCount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_SAP_Monitor;
        private System.Windows.Forms.DataGridView dataGV_Monitor_1;
    }
}