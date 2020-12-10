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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TB_MachineID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_CO_Qty = new System.Windows.Forms.Button();
            this.DateGridV_ECConfig_1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_ECConfig_1)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_MachineID
            // 
            this.TB_MachineID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_MachineID.Location = new System.Drawing.Point(241, 29);
            this.TB_MachineID.Name = "TB_MachineID";
            this.TB_MachineID.Size = new System.Drawing.Size(172, 31);
            this.TB_MachineID.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "加工中心ID(EC202000)：";
            // 
            // Btn_CO_Qty
            // 
            this.Btn_CO_Qty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_CO_Qty.Location = new System.Drawing.Point(462, 23);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_ECConfig_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_ECConfig_1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DateGridV_ECConfig_1.RowTemplate.Height = 30;
            this.DateGridV_ECConfig_1.Size = new System.Drawing.Size(1394, 641);
            this.DateGridV_ECConfig_1.TabIndex = 46;
            // 
            // FrmECConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 844);
            this.Controls.Add(this.DateGridV_ECConfig_1);
            this.Controls.Add(this.Btn_CO_Qty);
            this.Controls.Add(this.TB_MachineID);
            this.Controls.Add(this.label3);
            this.Name = "FrmECConfig";
            this.Text = "EC Config";
            this.Load += new System.EventHandler(this.FrmECConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_ECConfig_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_MachineID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_CO_Qty;
        private System.Windows.Forms.DataGridView DateGridV_ECConfig_1;
    }
}