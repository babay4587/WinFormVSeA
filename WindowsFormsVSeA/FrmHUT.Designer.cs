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
            this.components = new System.ComponentModel.Container();
            this.DataGridV_Hut = new System.Windows.Forms.DataGridView();
            this.Btn_Hut_Qty = new System.Windows.Forms.Button();
            this.Tb_Hut_SNR = new System.Windows.Forms.TextBox();
            this.Tb_Hut_Num = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_HUT_Del = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Hut_monitor = new System.Windows.Forms.Button();
            this.tB_timerInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_StopMonitor = new System.Windows.Forms.Button();
            this.Btn_Hut_His = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Hut_count = new System.Windows.Forms.TextBox();
            this.DTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            this.DataGridV_Hut.Size = new System.Drawing.Size(936, 421);
            this.DataGridV_Hut.TabIndex = 0;
            // 
            // Btn_Hut_Qty
            // 
            this.Btn_Hut_Qty.Location = new System.Drawing.Point(702, 6);
            this.Btn_Hut_Qty.Name = "Btn_Hut_Qty";
            this.Btn_Hut_Qty.Size = new System.Drawing.Size(95, 39);
            this.Btn_Hut_Qty.TabIndex = 1;
            this.Btn_Hut_Qty.Text = "查询";
            this.Btn_Hut_Qty.UseVisualStyleBackColor = true;
            this.Btn_Hut_Qty.Click += new System.EventHandler(this.Btn_Hut_Qty_Click);
            // 
            // Tb_Hut_SNR
            // 
            this.Tb_Hut_SNR.Location = new System.Drawing.Point(104, 10);
            this.Tb_Hut_SNR.Name = "Tb_Hut_SNR";
            this.Tb_Hut_SNR.Size = new System.Drawing.Size(201, 31);
            this.Tb_Hut_SNR.TabIndex = 2;
            // 
            // Tb_Hut_Num
            // 
            this.Tb_Hut_Num.Location = new System.Drawing.Point(426, 10);
            this.Tb_Hut_Num.Name = "Tb_Hut_Num";
            this.Tb_Hut_Num.Size = new System.Drawing.Size(259, 31);
            this.Tb_Hut_Num.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "序列号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "载具号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "序列号与载具号均可模糊查询";
            // 
            // Btn_HUT_Del
            // 
            this.Btn_HUT_Del.Location = new System.Drawing.Point(821, 6);
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
            this.label4.Location = new System.Drawing.Point(338, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "需先查询，并必须选PK列的值才能删除！";
            // 
            // Btn_Hut_monitor
            // 
            this.Btn_Hut_monitor.Location = new System.Drawing.Point(956, 93);
            this.Btn_Hut_monitor.Name = "Btn_Hut_monitor";
            this.Btn_Hut_monitor.Size = new System.Drawing.Size(96, 42);
            this.Btn_Hut_monitor.TabIndex = 5;
            this.Btn_Hut_monitor.Text = "监控";
            this.Btn_Hut_monitor.UseVisualStyleBackColor = true;
            this.Btn_Hut_monitor.Click += new System.EventHandler(this.Btn_Hut_monitor_Click);
            // 
            // tB_timerInterval
            // 
            this.tB_timerInterval.Location = new System.Drawing.Point(956, 483);
            this.tB_timerInterval.Name = "tB_timerInterval";
            this.tB_timerInterval.Size = new System.Drawing.Size(100, 31);
            this.tB_timerInterval.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(956, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "时间间隔(单位：秒)";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_StopMonitor
            // 
            this.btn_StopMonitor.Location = new System.Drawing.Point(956, 156);
            this.btn_StopMonitor.Name = "btn_StopMonitor";
            this.btn_StopMonitor.Size = new System.Drawing.Size(96, 42);
            this.btn_StopMonitor.TabIndex = 8;
            this.btn_StopMonitor.Text = "停止监控";
            this.btn_StopMonitor.UseVisualStyleBackColor = true;
            this.btn_StopMonitor.Click += new System.EventHandler(this.btn_StopMonitor_Click);
            // 
            // Btn_Hut_His
            // 
            this.Btn_Hut_His.Location = new System.Drawing.Point(956, 223);
            this.Btn_Hut_His.Name = "Btn_Hut_His";
            this.Btn_Hut_His.Size = new System.Drawing.Size(96, 43);
            this.Btn_Hut_His.TabIndex = 9;
            this.Btn_Hut_His.Text = "历史记录";
            this.Btn_Hut_His.UseVisualStyleBackColor = true;
            this.Btn_Hut_His.Click += new System.EventHandler(this.Btn_Hut_His_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(956, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "监控必须连接P系统";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(956, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "历史记录须连接Q系统";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(956, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "记录行数:";
            // 
            // TB_Hut_count
            // 
            this.TB_Hut_count.Location = new System.Drawing.Point(1048, 277);
            this.TB_Hut_count.Name = "TB_Hut_count";
            this.TB_Hut_count.Size = new System.Drawing.Size(74, 31);
            this.TB_Hut_count.TabIndex = 7;
            // 
            // DTimePicker1
            // 
            this.DTimePicker1.Location = new System.Drawing.Point(960, 327);
            this.DTimePicker1.Name = "DTimePicker1";
            this.DTimePicker1.Size = new System.Drawing.Size(162, 31);
            this.DTimePicker1.TabIndex = 10;
            // 
            // FrmHUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 540);
            this.Controls.Add(this.DTimePicker1);
            this.Controls.Add(this.Btn_Hut_His);
            this.Controls.Add(this.btn_StopMonitor);
            this.Controls.Add(this.TB_Hut_count);
            this.Controls.Add(this.tB_timerInterval);
            this.Controls.Add(this.Btn_Hut_monitor);
            this.Controls.Add(this.Btn_HUT_Del);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.Button Btn_Hut_monitor;
        private System.Windows.Forms.TextBox tB_timerInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_StopMonitor;
        private System.Windows.Forms.Button Btn_Hut_His;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Hut_count;
        private System.Windows.Forms.DateTimePicker DTimePicker1;
    }
}