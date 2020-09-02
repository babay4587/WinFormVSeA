namespace WindowsFormsVSeA
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_dul = new System.Windows.Forms.TextBox();
            this.btn_duplicate = new System.Windows.Forms.Button();
            this.tB_RowCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Tb1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Tb2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_MatDesc = new System.Windows.Forms.TextBox();
            this.TB_Mat_Fert = new System.Windows.Forms.TextBox();
            this.tB_Order = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.TB_UniMat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dBConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSYSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qSYSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tBColorQ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tBColorP = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(153, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1683, 930);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_dul);
            this.tabPage1.Controls.Add(this.btn_duplicate);
            this.tabPage1.Controls.Add(this.tB_RowCount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Tb1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1675, 898);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Shopfloor Connections";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_dul
            // 
            this.tb_dul.Location = new System.Drawing.Point(1151, 61);
            this.tb_dul.Name = "tb_dul";
            this.tb_dul.Size = new System.Drawing.Size(138, 28);
            this.tb_dul.TabIndex = 6;
            // 
            // btn_duplicate
            // 
            this.btn_duplicate.Location = new System.Drawing.Point(1151, 16);
            this.btn_duplicate.Name = "btn_duplicate";
            this.btn_duplicate.Size = new System.Drawing.Size(138, 29);
            this.btn_duplicate.TabIndex = 5;
            this.btn_duplicate.Text = "重复EQID检查";
            this.btn_duplicate.UseVisualStyleBackColor = true;
            this.btn_duplicate.Click += new System.EventHandler(this.btn_duplicate_Click);
            // 
            // tB_RowCount
            // 
            this.tB_RowCount.Location = new System.Drawing.Point(898, 16);
            this.tB_RowCount.Name = "tB_RowCount";
            this.tB_RowCount.Size = new System.Drawing.Size(155, 28);
            this.tB_RowCount.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "总共通讯配置：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(33, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1607, 724);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "OPEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tb1
            // 
            this.Tb1.Location = new System.Drawing.Point(127, 17);
            this.Tb1.Name = "Tb1";
            this.Tb1.Size = new System.Drawing.Size(594, 28);
            this.Tb1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.Tb2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1675, 898);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "LOOPRO  ORDER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1197, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 34);
            this.button4.TabIndex = 6;
            this.button4.Text = "查找";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.EnableHeadersVisualStyles = false;
            this.dataGridView3.Location = new System.Drawing.Point(6, 92);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 30;
            this.dataGridView3.Size = new System.Drawing.Size(1607, 705);
            this.dataGridView3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "ShortName查询:条件*";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(862, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(265, 28);
            this.textBox2.TabIndex = 3;
            // 
            // Tb2
            // 
            this.Tb2.Location = new System.Drawing.Point(164, 27);
            this.Tb2.Name = "Tb2";
            this.Tb2.Size = new System.Drawing.Size(460, 28);
            this.Tb2.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 40);
            this.button3.TabIndex = 0;
            this.button3.Text = "OPEN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.TB_MatDesc);
            this.tabPage2.Controls.Add(this.TB_Mat_Fert);
            this.tabPage2.Controls.Add(this.tB_Order);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1675, 898);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "工单查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(810, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "物料名称:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "成品料号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "OrderID:";
            // 
            // TB_MatDesc
            // 
            this.TB_MatDesc.Location = new System.Drawing.Point(905, 50);
            this.TB_MatDesc.Name = "TB_MatDesc";
            this.TB_MatDesc.Size = new System.Drawing.Size(165, 28);
            this.TB_MatDesc.TabIndex = 6;
            // 
            // TB_Mat_Fert
            // 
            this.TB_Mat_Fert.Location = new System.Drawing.Point(616, 50);
            this.TB_Mat_Fert.Name = "TB_Mat_Fert";
            this.TB_Mat_Fert.Size = new System.Drawing.Size(165, 28);
            this.TB_Mat_Fert.TabIndex = 6;
            // 
            // tB_Order
            // 
            this.tB_Order.Location = new System.Drawing.Point(371, 50);
            this.tB_Order.Name = "tB_Order";
            this.tB_Order.Size = new System.Drawing.Size(124, 28);
            this.tB_Order.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1152, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 26);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            this.comboBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseDown);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(6, 102);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.Size = new System.Drawing.Size(1607, 705);
            this.dataGridView2.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.TB_UniMat);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1675, 898);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Unique Mat Query";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(507, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 38);
            this.button5.TabIndex = 11;
            this.button5.Text = "查询";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TB_UniMat
            // 
            this.TB_UniMat.Location = new System.Drawing.Point(102, 19);
            this.TB_UniMat.Name = "TB_UniMat";
            this.TB_UniMat.Size = new System.Drawing.Size(365, 28);
            this.TB_UniMat.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(19, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "唯一码:";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.EnableHeadersVisualStyles = false;
            this.dataGridView4.Location = new System.Drawing.Point(6, 104);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 30;
            this.dataGridView4.Size = new System.Drawing.Size(1532, 684);
            this.dataGridView4.TabIndex = 6;
            this.dataGridView4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellClick);
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            this.dataGridView4.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBConnectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(125, 33);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dBConnectToolStripMenuItem
            // 
            this.dBConnectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pSYSToolStripMenuItem,
            this.qSYSToolStripMenuItem});
            this.dBConnectToolStripMenuItem.Name = "dBConnectToolStripMenuItem";
            this.dBConnectToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.dBConnectToolStripMenuItem.Text = "DB Connect";
            // 
            // pSYSToolStripMenuItem
            // 
            this.pSYSToolStripMenuItem.Name = "pSYSToolStripMenuItem";
            this.pSYSToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.pSYSToolStripMenuItem.Text = "P_SYS";
            this.pSYSToolStripMenuItem.Click += new System.EventHandler(this.pSYSToolStripMenuItem_Click);
            // 
            // qSYSToolStripMenuItem
            // 
            this.qSYSToolStripMenuItem.Name = "qSYSToolStripMenuItem";
            this.qSYSToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.qSYSToolStripMenuItem.Text = "Q_SYS";
            this.qSYSToolStripMenuItem.Click += new System.EventHandler(this.qSYSToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(1, 45);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tBColorQ
            // 
            this.tBColorQ.BackColor = System.Drawing.SystemColors.Control;
            this.tBColorQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBColorQ.Location = new System.Drawing.Point(72, 248);
            this.tBColorQ.Name = "tBColorQ";
            this.tBColorQ.Size = new System.Drawing.Size(79, 21);
            this.tBColorQ.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Q-SYS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "P-SYS";
            // 
            // tBColorP
            // 
            this.tBColorP.BackColor = System.Drawing.SystemColors.Control;
            this.tBColorP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBColorP.Location = new System.Drawing.Point(72, 279);
            this.tBColorP.Name = "tBColorP";
            this.tBColorP.Size = new System.Drawing.Size(79, 21);
            this.tBColorP.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1707, 907);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBColorP);
            this.Controls.Add(this.tBColorQ);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "VSeA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Tb1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tB_RowCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_duplicate;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tB_Order;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Tb2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tb_dul;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dBConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSYSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qSYSToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_MatDesc;
        private System.Windows.Forms.TextBox TB_Mat_Fert;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox TB_UniMat;
        private System.Windows.Forms.TextBox tBColorQ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBColorP;
    }
}

