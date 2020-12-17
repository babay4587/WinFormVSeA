namespace WindowsFormsVSeA
{
    partial class FrmHUT
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
            this.DataGridV_Hut = new System.Windows.Forms.DataGridView();
            this.Btn_Hut_Qty = new System.Windows.Forms.Button();
            this.Tb_Hut_SNR = new System.Windows.Forms.TextBox();
            this.Tb_Hut_Num = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_HUT_Del = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Hut)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridV_Hut
            // 
            this.DataGridV_Hut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridV_Hut.Location = new System.Drawing.Point(13, 93);
            this.DataGridV_Hut.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridV_Hut.Name = "DataGridV_Hut";
            this.DataGridV_Hut.RowTemplate.Height = 30;
            this.DataGridV_Hut.Size = new System.Drawing.Size(810, 390);
            this.DataGridV_Hut.TabIndex = 0;
            // 
            // Btn_Hut_Qty
            // 
            this.Btn_Hut_Qty.Location = new System.Drawing.Point(13, 12);
            this.Btn_Hut_Qty.Name = "Btn_Hut_Qty";
            this.Btn_Hut_Qty.Size = new System.Drawing.Size(95, 43);
            this.Btn_Hut_Qty.TabIndex = 1;
            this.Btn_Hut_Qty.Text = "查询";
            this.Btn_Hut_Qty.UseVisualStyleBackColor = true;
            this.Btn_Hut_Qty.Click += new System.EventHandler(this.Btn_Hut_Qty_Click);
            // 
            // Tb_Hut_SNR
            // 
            this.Tb_Hut_SNR.Location = new System.Drawing.Point(242, 18);
            this.Tb_Hut_SNR.Name = "Tb_Hut_SNR";
            this.Tb_Hut_SNR.Size = new System.Drawing.Size(201, 31);
            this.Tb_Hut_SNR.TabIndex = 2;
            // 
            // Tb_Hut_Num
            // 
            this.Tb_Hut_Num.Location = new System.Drawing.Point(564, 18);
            this.Tb_Hut_Num.Name = "Tb_Hut_Num";
            this.Tb_Hut_Num.Size = new System.Drawing.Size(259, 31);
            this.Tb_Hut_Num.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "序列号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "载具号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "序列号与载具号均可模糊查询";
            // 
            // Btn_HUT_Del
            // 
            this.Btn_HUT_Del.Location = new System.Drawing.Point(837, 14);
            this.Btn_HUT_Del.Name = "Btn_HUT_Del";
            this.Btn_HUT_Del.Size = new System.Drawing.Size(94, 39);
            this.Btn_HUT_Del.TabIndex = 4;
            this.Btn_HUT_Del.Text = "删除绑定";
            this.Btn_HUT_Del.UseVisualStyleBackColor = true;
            this.Btn_HUT_Del.Click += new System.EventHandler(this.Btn_HUT_Del_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "需先查询，并必须选PK列的值才能删除！";
            // 
            // FrmHUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 496);
            this.Controls.Add(this.Btn_HUT_Del);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tb_Hut_Num);
            this.Controls.Add(this.Tb_Hut_SNR);
            this.Controls.Add(this.Btn_Hut_Qty);
            this.Controls.Add(this.DataGridV_Hut);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmHUT";
            this.Text = "HUT载具查询";
            this.Load += new System.EventHandler(this.FrmHUT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Hut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridV_Hut;
        private System.Windows.Forms.Button Btn_Hut_Qty;
        private System.Windows.Forms.TextBox Tb_Hut_SNR;
        private System.Windows.Forms.TextBox Tb_Hut_Num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_HUT_Del;
        private System.Windows.Forms.Label label4;
    }
}