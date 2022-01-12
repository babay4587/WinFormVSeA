namespace WindowsFormsVSeA
{
    partial class FrmQtyWOgetOrder
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
            this.TB_Orderid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGV_WoGet = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_EC_Number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_ControlKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_WoType = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBRowCount = new System.Windows.Forms.TextBox();
            this.Tb_Filter1 = new System.Windows.Forms.TextBox();
            this.BT_DVFilter = new System.Windows.Forms.Button();
            this.Btn_Qty1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_WoGet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Orderid
            // 
            this.TB_Orderid.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Orderid.Location = new System.Drawing.Point(12, 39);
            this.TB_Orderid.Name = "TB_Orderid";
            this.TB_Orderid.Size = new System.Drawing.Size(108, 31);
            this.TB_Orderid.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "OrderID:";
            // 
            // dataGV_WoGet
            // 
            this.dataGV_WoGet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV_WoGet.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV_WoGet.Location = new System.Drawing.Point(12, 127);
            this.dataGV_WoGet.Name = "dataGV_WoGet";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_WoGet.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGV_WoGet.RowTemplate.Height = 30;
            this.dataGV_WoGet.Size = new System.Drawing.Size(1490, 600);
            this.dataGV_WoGet.TabIndex = 10;
            this.dataGV_WoGet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_WoGet_CellDoubleClick);
            this.dataGV_WoGet.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGV_WoGet_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "查询工站类型:";
            // 
            // TB_EC_Number
            // 
            this.TB_EC_Number.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_EC_Number.Location = new System.Drawing.Point(764, 24);
            this.TB_EC_Number.Name = "TB_EC_Number";
            this.TB_EC_Number.Size = new System.Drawing.Size(173, 31);
            this.TB_EC_Number.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(341, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "工站CtrlKey:";
            // 
            // TB_ControlKey
            // 
            this.TB_ControlKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_ControlKey.Location = new System.Drawing.Point(459, 24);
            this.TB_ControlKey.Name = "TB_ControlKey";
            this.TB_ControlKey.Size = new System.Drawing.Size(173, 31);
            this.TB_ControlKey.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(650, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "工站EC编号:";
            // 
            // TB_WoType
            // 
            this.TB_WoType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_WoType.Location = new System.Drawing.Point(149, 24);
            this.TB_WoType.Name = "TB_WoType";
            this.TB_WoType.Size = new System.Drawing.Size(173, 31);
            this.TB_WoType.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBRowCount);
            this.groupBox1.Controls.Add(this.Tb_Filter1);
            this.groupBox1.Controls.Add(this.BT_DVFilter);
            this.groupBox1.Controls.Add(this.Btn_Qty1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_WoType);
            this.groupBox1.Controls.Add(this.TB_EC_Number);
            this.groupBox1.Controls.Add(this.TB_ControlKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(224, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1218, 113);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "均可用%通配符";
            // 
            // TBRowCount
            // 
            this.TBRowCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBRowCount.Location = new System.Drawing.Point(1127, 77);
            this.TBRowCount.Name = "TBRowCount";
            this.TBRowCount.Size = new System.Drawing.Size(85, 31);
            this.TBRowCount.TabIndex = 15;
            // 
            // Tb_Filter1
            // 
            this.Tb_Filter1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tb_Filter1.Location = new System.Drawing.Point(764, 75);
            this.Tb_Filter1.Name = "Tb_Filter1";
            this.Tb_Filter1.Size = new System.Drawing.Size(173, 31);
            this.Tb_Filter1.TabIndex = 15;
            // 
            // BT_DVFilter
            // 
            this.BT_DVFilter.Location = new System.Drawing.Point(946, 75);
            this.BT_DVFilter.Name = "BT_DVFilter";
            this.BT_DVFilter.Size = new System.Drawing.Size(109, 34);
            this.BT_DVFilter.TabIndex = 14;
            this.BT_DVFilter.Text = "筛选";
            this.BT_DVFilter.UseVisualStyleBackColor = true;
            this.BT_DVFilter.Click += new System.EventHandler(this.BT_DVFilter_Click);
            // 
            // Btn_Qty1
            // 
            this.Btn_Qty1.Location = new System.Drawing.Point(946, 22);
            this.Btn_Qty1.Name = "Btn_Qty1";
            this.Btn_Qty1.Size = new System.Drawing.Size(109, 34);
            this.Btn_Qty1.TabIndex = 13;
            this.Btn_Qty1.Text = "查询";
            this.Btn_Qty1.UseVisualStyleBackColor = true;
            this.Btn_Qty1.Click += new System.EventHandler(this.Btn_Qty1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(1071, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "行数:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(672, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "总成料号:";
            // 
            // FrmQtyWOgetOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 558);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGV_WoGet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Orderid);
            this.Name = "FrmQtyWOgetOrder";
            this.Text = "FrmQtyWOgetOrder";
            this.Load += new System.EventHandler(this.FrmQtyWOgetOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_WoGet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Orderid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGV_WoGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_EC_Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_ControlKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_WoType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Qty1;
        private System.Windows.Forms.Button BT_DVFilter;
        private System.Windows.Forms.TextBox Tb_Filter1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBRowCount;
        private System.Windows.Forms.Label label6;
    }
}