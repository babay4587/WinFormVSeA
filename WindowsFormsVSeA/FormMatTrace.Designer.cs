namespace WindowsFormsVSeA
{
    partial class FormMatTrace
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_WOStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_WOEnd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTPicker_WOEndT = new System.Windows.Forms.DateTimePicker();
            this.DTPicker_WOStartT = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_WO_End = new System.Windows.Forms.CheckBox();
            this.checkBox_WO_Start = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "已过站点:";
            // 
            // tb_WOStr
            // 
            this.tb_WOStr.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.tb_WOStr.Location = new System.Drawing.Point(110, 29);
            this.tb_WOStr.Name = "tb_WOStr";
            this.tb_WOStr.Size = new System.Drawing.Size(197, 29);
            this.tb_WOStr.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(572, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "开始时间:";
            // 
            // textBox_path
            // 
            this.textBox_path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_path.Location = new System.Drawing.Point(962, 62);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(290, 31);
            this.textBox_path.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label3.Location = new System.Drawing.Point(572, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "结束时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label4.Location = new System.Drawing.Point(10, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "未开始站点:";
            // 
            // tb_WOEnd
            // 
            this.tb_WOEnd.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.tb_WOEnd.Location = new System.Drawing.Point(110, 67);
            this.tb_WOEnd.Name = "tb_WOEnd";
            this.tb_WOEnd.Size = new System.Drawing.Size(197, 29);
            this.tb_WOEnd.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.DTPicker_WOEndT);
            this.groupBox1.Controls.Add(this.DTPicker_WOStartT);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox_path);
            this.groupBox1.Controls.Add(this.checkBox_WO_End);
            this.groupBox1.Controls.Add(this.checkBox_WO_Start);
            this.groupBox1.Controls.Add(this.tb_WOEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_WOStr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1272, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WO Select";
            // 
            // DTPicker_WOEndT
            // 
            this.DTPicker_WOEndT.CalendarFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPicker_WOEndT.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.DTPicker_WOEndT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker_WOEndT.Location = new System.Drawing.Point(656, 69);
            this.DTPicker_WOEndT.Name = "DTPicker_WOEndT";
            this.DTPicker_WOEndT.Size = new System.Drawing.Size(171, 29);
            this.DTPicker_WOEndT.TabIndex = 14;
            // 
            // DTPicker_WOStartT
            // 
            this.DTPicker_WOStartT.CalendarFont = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPicker_WOStartT.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.DTPicker_WOStartT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker_WOStartT.Location = new System.Drawing.Point(656, 28);
            this.DTPicker_WOStartT.Name = "DTPicker_WOStartT";
            this.DTPicker_WOStartT.Size = new System.Drawing.Size(171, 29);
            this.DTPicker_WOStartT.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(429, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "过站未开始查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_WO_End
            // 
            this.checkBox_WO_End.AutoSize = true;
            this.checkBox_WO_End.Location = new System.Drawing.Point(313, 69);
            this.checkBox_WO_End.Name = "checkBox_WO_End";
            this.checkBox_WO_End.Size = new System.Drawing.Size(100, 25);
            this.checkBox_WO_End.TabIndex = 3;
            this.checkBox_WO_End.Text = "点击选择";
            this.checkBox_WO_End.UseVisualStyleBackColor = true;
            this.checkBox_WO_End.CheckedChanged += new System.EventHandler(this.checkBox_WO_End_CheckedChanged);
            // 
            // checkBox_WO_Start
            // 
            this.checkBox_WO_Start.AutoSize = true;
            this.checkBox_WO_Start.Location = new System.Drawing.Point(313, 33);
            this.checkBox_WO_Start.Name = "checkBox_WO_Start";
            this.checkBox_WO_Start.Size = new System.Drawing.Size(100, 25);
            this.checkBox_WO_Start.TabIndex = 3;
            this.checkBox_WO_Start.Text = "点击选择";
            this.checkBox_WO_Start.UseVisualStyleBackColor = true;
            this.checkBox_WO_Start.CheckedChanged += new System.EventHandler(this.checkBox_WO_Start_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label6.Location = new System.Drawing.Point(849, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "行:";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(12, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1076, 396);
            this.dataGridView1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(853, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 31);
            this.button2.TabIndex = 16;
            this.button2.Text = "导出为Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label7.Location = new System.Drawing.Point(987, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "保存路径:";
            // 
            // FormMatTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 535);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMatTrace";
            this.Text = "FormMatTrace";
            this.Load += new System.EventHandler(this.FormMatTrace_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_WOStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_WOEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_WO_End;
        private System.Windows.Forms.CheckBox checkBox_WO_Start;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker DTPicker_WOEndT;
        private System.Windows.Forms.DateTimePicker DTPicker_WOStartT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}