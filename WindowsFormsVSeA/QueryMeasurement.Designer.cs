namespace WindowsFormsVSeA
{
    partial class QueryMeasurement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryMeasurement));
            this.dataGV_Measure_1 = new System.Windows.Forms.DataGridView();
            this.Tb_Measure_OrdID1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Btn_MeasureQty = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Measure_SNR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Measure_Back = new System.Windows.Forms.Button();
            this.Btn_Measure_Filter = new System.Windows.Forms.Button();
            this.TB_Measure_Value = new System.Windows.Forms.TextBox();
            this.TB_Measure_ID = new System.Windows.Forms.TextBox();
            this.TB_Filter_SNR = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_Measure_1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGV_Measure_1
            // 
            this.dataGV_Measure_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGV_Measure_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_Measure_1.EnableHeadersVisualStyles = false;
            this.dataGV_Measure_1.Location = new System.Drawing.Point(12, 118);
            this.dataGV_Measure_1.Name = "dataGV_Measure_1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_Measure_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV_Measure_1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGV_Measure_1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGV_Measure_1.RowTemplate.Height = 30;
            this.dataGV_Measure_1.Size = new System.Drawing.Size(1672, 516);
            this.dataGV_Measure_1.TabIndex = 4;
            // 
            // Tb_Measure_OrdID1
            // 
            this.Tb_Measure_OrdID1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tb_Measure_OrdID1.Location = new System.Drawing.Point(107, 21);
            this.Tb_Measure_OrdID1.Name = "Tb_Measure_OrdID1";
            this.Tb_Measure_OrdID1.Size = new System.Drawing.Size(133, 31);
            this.Tb_Measure_OrdID1.TabIndex = 35;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(12, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 24);
            this.label21.TabIndex = 36;
            this.label21.Text = "Order ID:";
            // 
            // Btn_MeasureQty
            // 
            this.Btn_MeasureQty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_MeasureQty.Location = new System.Drawing.Point(541, 21);
            this.Btn_MeasureQty.Name = "Btn_MeasureQty";
            this.Btn_MeasureQty.Size = new System.Drawing.Size(90, 39);
            this.Btn_MeasureQty.TabIndex = 37;
            this.Btn_MeasureQty.Text = "查询";
            this.Btn_MeasureQty.UseVisualStyleBackColor = true;
            this.Btn_MeasureQty.Click += new System.EventHandler(this.Btn_MeasureQty_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(256, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "SNR:";
            // 
            // Btn_Measure_SNR
            // 
            this.Btn_Measure_SNR.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Measure_SNR.Location = new System.Drawing.Point(313, 21);
            this.Btn_Measure_SNR.Name = "Btn_Measure_SNR";
            this.Btn_Measure_SNR.Size = new System.Drawing.Size(210, 31);
            this.Btn_Measure_SNR.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(309, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 24);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tip:SNR可输%，但不能为空";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Btn_Measure_Back);
            this.groupBox1.Controls.Add(this.Btn_Measure_Filter);
            this.groupBox1.Controls.Add(this.TB_Measure_Value);
            this.groupBox1.Controls.Add(this.TB_Measure_ID);
            this.groupBox1.Controls.Add(this.TB_Filter_SNR);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(647, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1034, 100);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据过滤";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(524, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 21);
            this.label3.TabIndex = 39;
            this.label3.Text = "Tip:SNR与测量值不为空时 从DB模糊查询";
            // 
            // Btn_Measure_Back
            // 
            this.Btn_Measure_Back.BackColor = System.Drawing.Color.MintCream;
            this.Btn_Measure_Back.Location = new System.Drawing.Point(848, 55);
            this.Btn_Measure_Back.Name = "Btn_Measure_Back";
            this.Btn_Measure_Back.Size = new System.Drawing.Size(106, 35);
            this.Btn_Measure_Back.TabIndex = 31;
            this.Btn_Measure_Back.Text = "返回初始";
            this.Btn_Measure_Back.UseVisualStyleBackColor = false;
            this.Btn_Measure_Back.Click += new System.EventHandler(this.Btn_Measure_Back_Click);
            // 
            // Btn_Measure_Filter
            // 
            this.Btn_Measure_Filter.BackColor = System.Drawing.Color.OldLace;
            this.Btn_Measure_Filter.Location = new System.Drawing.Point(848, 15);
            this.Btn_Measure_Filter.Name = "Btn_Measure_Filter";
            this.Btn_Measure_Filter.Size = new System.Drawing.Size(106, 33);
            this.Btn_Measure_Filter.TabIndex = 30;
            this.Btn_Measure_Filter.Text = "检索";
            this.Btn_Measure_Filter.UseVisualStyleBackColor = false;
            this.Btn_Measure_Filter.Click += new System.EventHandler(this.Btn_Measure_Filter_Click);
            // 
            // TB_Measure_Value
            // 
            this.TB_Measure_Value.Location = new System.Drawing.Point(653, 31);
            this.TB_Measure_Value.Name = "TB_Measure_Value";
            this.TB_Measure_Value.Size = new System.Drawing.Size(175, 31);
            this.TB_Measure_Value.TabIndex = 28;
            // 
            // TB_Measure_ID
            // 
            this.TB_Measure_ID.Location = new System.Drawing.Point(407, 31);
            this.TB_Measure_ID.Name = "TB_Measure_ID";
            this.TB_Measure_ID.Size = new System.Drawing.Size(114, 31);
            this.TB_Measure_ID.TabIndex = 28;
            // 
            // TB_Filter_SNR
            // 
            this.TB_Filter_SNR.Location = new System.Drawing.Point(61, 31);
            this.TB_Filter_SNR.Name = "TB_Filter_SNR";
            this.TB_Filter_SNR.Size = new System.Drawing.Size(212, 31);
            this.TB_Filter_SNR.TabIndex = 28;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(559, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 24);
            this.label20.TabIndex = 29;
            this.label20.Text = "测量值:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(297, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 24);
            this.label19.TabIndex = 29;
            this.label19.Text = "测量值ID:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(6, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 24);
            this.label18.TabIndex = 29;
            this.label18.Text = "SNR:";
            // 
            // QueryMeasurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1696, 646);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_MeasureQty);
            this.Controls.Add(this.Btn_Measure_SNR);
            this.Controls.Add(this.Tb_Measure_OrdID1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dataGV_Measure_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QueryMeasurement";
            this.Text = "QueryMeasurement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_Measure_1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV_Measure_1;
        private System.Windows.Forms.TextBox Tb_Measure_OrdID1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button Btn_MeasureQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Btn_Measure_SNR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Measure_Back;
        private System.Windows.Forms.Button Btn_Measure_Filter;
        private System.Windows.Forms.TextBox TB_Measure_Value;
        private System.Windows.Forms.TextBox TB_Measure_ID;
        private System.Windows.Forms.TextBox TB_Filter_SNR;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
    }
}