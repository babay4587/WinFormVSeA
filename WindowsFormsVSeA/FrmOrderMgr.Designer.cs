namespace WindowsFormsVSeA
{
    partial class FrmOrderMgr
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
            this.DateGridV_FrmOrder1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_FrmOrd_Mat = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Btn_FrmOrd_1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_FrmOrder1)).BeginInit();
            this.SuspendLayout();
            // 
            // DateGridV_FrmOrder1
            // 
            this.DateGridV_FrmOrder1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_FrmOrder1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_FrmOrder1.EnableHeadersVisualStyles = false;
            this.DateGridV_FrmOrder1.Location = new System.Drawing.Point(12, 79);
            this.DateGridV_FrmOrder1.Name = "DateGridV_FrmOrder1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_FrmOrder1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_FrmOrder1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DateGridV_FrmOrder1.RowTemplate.Height = 30;
            this.DateGridV_FrmOrder1.Size = new System.Drawing.Size(1408, 464);
            this.DateGridV_FrmOrder1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = "成品物料ID：";
            // 
            // TB_FrmOrd_Mat
            // 
            this.TB_FrmOrd_Mat.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_FrmOrd_Mat.Location = new System.Drawing.Point(150, 18);
            this.TB_FrmOrd_Mat.Name = "TB_FrmOrd_Mat";
            this.TB_FrmOrd_Mat.Size = new System.Drawing.Size(231, 31);
            this.TB_FrmOrd_Mat.TabIndex = 42;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(922, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(248, 24);
            this.label15.TabIndex = 43;
            this.label15.Text = "说明:通过成品料号查询工单号";
            // 
            // Btn_FrmOrd_1
            // 
            this.Btn_FrmOrd_1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_FrmOrd_1.Location = new System.Drawing.Point(410, 16);
            this.Btn_FrmOrd_1.Name = "Btn_FrmOrd_1";
            this.Btn_FrmOrd_1.Size = new System.Drawing.Size(117, 35);
            this.Btn_FrmOrd_1.TabIndex = 45;
            this.Btn_FrmOrd_1.Text = "查询";
            this.Btn_FrmOrd_1.UseVisualStyleBackColor = true;
            this.Btn_FrmOrd_1.Click += new System.EventHandler(this.Btn_FrmOrd_1_Click);
            // 
            // FrmOrderMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 555);
            this.Controls.Add(this.Btn_FrmOrd_1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TB_FrmOrd_Mat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateGridV_FrmOrder1);
            this.Name = "FrmOrderMgr";
            this.Text = "Production Order";
            this.Load += new System.EventHandler(this.FrmOrderMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_FrmOrder1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DateGridV_FrmOrder1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_FrmOrd_Mat;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Btn_FrmOrd_1;
    }
}