namespace WindowsFormsVSeA
{
    partial class Frm_EC_Printer
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
            this.DateGridV_EC_Printer = new System.Windows.Forms.DataGridView();
            this.Btn_ECPrinter_Qty = new System.Windows.Forms.Button();
            this.TB_FrmPrinter_Grp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tb_Printer_Name = new System.Windows.Forms.TextBox();
            this.Tb_Printer_Type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Add_EC_Printer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_PrinterDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_EC_Printer)).BeginInit();
            this.SuspendLayout();
            // 
            // DateGridV_EC_Printer
            // 
            this.DateGridV_EC_Printer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DateGridV_EC_Printer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridV_EC_Printer.EnableHeadersVisualStyles = false;
            this.DateGridV_EC_Printer.Location = new System.Drawing.Point(12, 116);
            this.DateGridV_EC_Printer.Name = "DateGridV_EC_Printer";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGridV_EC_Printer.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateGridV_EC_Printer.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DateGridV_EC_Printer.RowTemplate.Height = 30;
            this.DateGridV_EC_Printer.Size = new System.Drawing.Size(1376, 692);
            this.DateGridV_EC_Printer.TabIndex = 7;
            // 
            // Btn_ECPrinter_Qty
            // 
            this.Btn_ECPrinter_Qty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ECPrinter_Qty.Location = new System.Drawing.Point(12, 20);
            this.Btn_ECPrinter_Qty.Name = "Btn_ECPrinter_Qty";
            this.Btn_ECPrinter_Qty.Size = new System.Drawing.Size(105, 42);
            this.Btn_ECPrinter_Qty.TabIndex = 8;
            this.Btn_ECPrinter_Qty.Text = "浏览";
            this.Btn_ECPrinter_Qty.UseVisualStyleBackColor = true;
            this.Btn_ECPrinter_Qty.Click += new System.EventHandler(this.Btn_ECPrinter_Qty_Click);
            // 
            // TB_FrmPrinter_Grp
            // 
            this.TB_FrmPrinter_Grp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_FrmPrinter_Grp.Location = new System.Drawing.Point(283, 26);
            this.TB_FrmPrinter_Grp.Name = "TB_FrmPrinter_Grp";
            this.TB_FrmPrinter_Grp.Size = new System.Drawing.Size(175, 31);
            this.TB_FrmPrinter_Grp.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(128, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Group ID线体号：";
            // 
            // Tb_Printer_Name
            // 
            this.Tb_Printer_Name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tb_Printer_Name.Location = new System.Drawing.Point(766, 26);
            this.Tb_Printer_Name.Name = "Tb_Printer_Name";
            this.Tb_Printer_Name.Size = new System.Drawing.Size(175, 31);
            this.Tb_Printer_Name.TabIndex = 44;
            // 
            // Tb_Printer_Type
            // 
            this.Tb_Printer_Type.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tb_Printer_Type.Location = new System.Drawing.Point(1032, 26);
            this.Tb_Printer_Type.Name = "Tb_Printer_Type";
            this.Tb_Printer_Type.Size = new System.Drawing.Size(93, 31);
            this.Tb_Printer_Type.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(956, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "Type：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(666, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 43;
            this.label2.Text = "打印机名：";
            // 
            // Btn_Add_EC_Printer
            // 
            this.Btn_Add_EC_Printer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Add_EC_Printer.Location = new System.Drawing.Point(1149, 20);
            this.Btn_Add_EC_Printer.Name = "Btn_Add_EC_Printer";
            this.Btn_Add_EC_Printer.Size = new System.Drawing.Size(124, 42);
            this.Btn_Add_EC_Printer.TabIndex = 45;
            this.Btn_Add_EC_Printer.Text = "添加打印机";
            this.Btn_Add_EC_Printer.UseVisualStyleBackColor = true;
            this.Btn_Add_EC_Printer.Click += new System.EventHandler(this.Btn_Add_EC_Printer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(745, 24);
            this.label4.TabIndex = 46;
            this.label4.Text = "表 : EC_PRINTER_$94$ 先查找线体打印机是否存在，否在不能添加。Tips:先点击 浏览 按钮!";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(486, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 42);
            this.button1.TabIndex = 47;
            this.button1.Text = "查找打印机";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_PrinterDelete
            // 
            this.Btn_PrinterDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_PrinterDelete.Location = new System.Drawing.Point(1149, 68);
            this.Btn_PrinterDelete.Name = "Btn_PrinterDelete";
            this.Btn_PrinterDelete.Size = new System.Drawing.Size(124, 42);
            this.Btn_PrinterDelete.TabIndex = 48;
            this.Btn_PrinterDelete.Text = "删除打印机";
            this.Btn_PrinterDelete.UseVisualStyleBackColor = true;
            this.Btn_PrinterDelete.Click += new System.EventHandler(this.Btn_PrinterDelete_Click);
            // 
            // Frm_EC_Printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 820);
            this.Controls.Add(this.Btn_PrinterDelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_Add_EC_Printer);
            this.Controls.Add(this.Tb_Printer_Type);
            this.Controls.Add(this.Tb_Printer_Name);
            this.Controls.Add(this.TB_FrmPrinter_Grp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_ECPrinter_Qty);
            this.Controls.Add(this.DateGridV_EC_Printer);
            this.Name = "Frm_EC_Printer";
            this.Text = "生产线打印机";
            this.Load += new System.EventHandler(this.Frm_EC_Printer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridV_EC_Printer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DateGridV_EC_Printer;
        private System.Windows.Forms.Button Btn_ECPrinter_Qty;
        private System.Windows.Forms.TextBox TB_FrmPrinter_Grp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tb_Printer_Name;
        private System.Windows.Forms.TextBox Tb_Printer_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Add_EC_Printer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_PrinterDelete;
    }
}