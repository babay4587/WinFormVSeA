namespace WindowsFormsVSeA
{
    partial class SAP_Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAP_Report));
            this.dataGV_SAP_1 = new System.Windows.Forms.DataGridView();
            this.Tb_SAP_OrdBas1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Btn_eCar_Report = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_MatName = new System.Windows.Forms.TextBox();
            this.TB_MatID = new System.Windows.Forms.TextBox();
            this.LB_RowsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGV_SAP_2 = new System.Windows.Forms.DataGridView();
            this.Btn_SAP_Rpt_detail = new System.Windows.Forms.Button();
            this.DGV_MoveType = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_SAP_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_SAP_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MoveType)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGV_SAP_1
            // 
            this.dataGV_SAP_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGV_SAP_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_SAP_1.EnableHeadersVisualStyles = false;
            this.dataGV_SAP_1.Location = new System.Drawing.Point(12, 130);
            this.dataGV_SAP_1.Name = "dataGV_SAP_1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_SAP_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV_SAP_1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGV_SAP_1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGV_SAP_1.RowTemplate.Height = 30;
            this.dataGV_SAP_1.Size = new System.Drawing.Size(1106, 578);
            this.dataGV_SAP_1.TabIndex = 3;
            // 
            // Tb_SAP_OrdBas1
            // 
            this.Tb_SAP_OrdBas1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tb_SAP_OrdBas1.Location = new System.Drawing.Point(120, 12);
            this.Tb_SAP_OrdBas1.Name = "Tb_SAP_OrdBas1";
            this.Tb_SAP_OrdBas1.Size = new System.Drawing.Size(172, 31);
            this.Tb_SAP_OrdBas1.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(25, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 24);
            this.label21.TabIndex = 34;
            this.label21.Text = "Order ID:";
            // 
            // Btn_eCar_Report
            // 
            this.Btn_eCar_Report.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_eCar_Report.Location = new System.Drawing.Point(310, 12);
            this.Btn_eCar_Report.Name = "Btn_eCar_Report";
            this.Btn_eCar_Report.Size = new System.Drawing.Size(89, 34);
            this.Btn_eCar_Report.TabIndex = 32;
            this.Btn_eCar_Report.Text = "查询";
            this.Btn_eCar_Report.UseVisualStyleBackColor = true;
            this.Btn_eCar_Report.Click += new System.EventHandler(this.Btn_eCar_Report_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(751, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 24);
            this.label10.TabIndex = 37;
            this.label10.Text = "物料名称:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(430, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 24);
            this.label11.TabIndex = 38;
            this.label11.Text = "成品料号:";
            // 
            // TB_MatName
            // 
            this.TB_MatName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_MatName.Location = new System.Drawing.Point(843, 12);
            this.TB_MatName.Name = "TB_MatName";
            this.TB_MatName.Size = new System.Drawing.Size(425, 31);
            this.TB_MatName.TabIndex = 35;
            // 
            // TB_MatID
            // 
            this.TB_MatID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_MatID.Location = new System.Drawing.Point(522, 12);
            this.TB_MatID.Name = "TB_MatID";
            this.TB_MatID.Size = new System.Drawing.Size(211, 31);
            this.TB_MatID.TabIndex = 36;
            // 
            // LB_RowsCount
            // 
            this.LB_RowsCount.AutoSize = true;
            this.LB_RowsCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_RowsCount.Location = new System.Drawing.Point(120, 53);
            this.LB_RowsCount.Name = "LB_RowsCount";
            this.LB_RowsCount.Size = new System.Drawing.Size(0, 24);
            this.LB_RowsCount.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 39;
            this.label1.Text = "行数 :";
            // 
            // dataGV_SAP_2
            // 
            this.dataGV_SAP_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGV_SAP_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_SAP_2.EnableHeadersVisualStyles = false;
            this.dataGV_SAP_2.Location = new System.Drawing.Point(1124, 130);
            this.dataGV_SAP_2.Name = "dataGV_SAP_2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_SAP_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGV_SAP_2.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGV_SAP_2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGV_SAP_2.RowTemplate.Height = 30;
            this.dataGV_SAP_2.Size = new System.Drawing.Size(526, 578);
            this.dataGV_SAP_2.TabIndex = 3;
            // 
            // Btn_SAP_Rpt_detail
            // 
            this.Btn_SAP_Rpt_detail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SAP_Rpt_detail.Location = new System.Drawing.Point(310, 53);
            this.Btn_SAP_Rpt_detail.Name = "Btn_SAP_Rpt_detail";
            this.Btn_SAP_Rpt_detail.Size = new System.Drawing.Size(89, 39);
            this.Btn_SAP_Rpt_detail.TabIndex = 40;
            this.Btn_SAP_Rpt_detail.Text = "明细";
            this.Btn_SAP_Rpt_detail.UseVisualStyleBackColor = true;
            this.Btn_SAP_Rpt_detail.Click += new System.EventHandler(this.dataGV_SAP_1_CellContentClick);
            // 
            // DGV_MoveType
            // 
            this.DGV_MoveType.BackgroundColor = System.Drawing.Color.Linen;
            this.DGV_MoveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_MoveType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_MoveType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_MoveType.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_MoveType.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_MoveType.GridColor = System.Drawing.SystemColors.Info;
            this.DGV_MoveType.Location = new System.Drawing.Point(1290, 15);
            this.DGV_MoveType.Name = "DGV_MoveType";
            this.DGV_MoveType.RowHeadersVisible = false;
            this.DGV_MoveType.RowTemplate.Height = 30;
            this.DGV_MoveType.Size = new System.Drawing.Size(360, 96);
            this.DGV_MoveType.TabIndex = 42;
            this.DGV_MoveType.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_MoveType_CellFormatting);
            this.DGV_MoveType.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_MoveType_CellPainting);
            // 
            // SAP_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1662, 688);
            this.Controls.Add(this.DGV_MoveType);
            this.Controls.Add(this.Btn_SAP_Rpt_detail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_RowsCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TB_MatName);
            this.Controls.Add(this.TB_MatID);
            this.Controls.Add(this.Tb_SAP_OrdBas1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Btn_eCar_Report);
            this.Controls.Add(this.dataGV_SAP_2);
            this.Controls.Add(this.dataGV_SAP_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAP_Report";
            this.Text = "SAP_Report";
            this.Load += new System.EventHandler(this.SAP_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_SAP_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_SAP_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MoveType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV_SAP_1;
        private System.Windows.Forms.TextBox Tb_SAP_OrdBas1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button Btn_eCar_Report;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TB_MatName;
        private System.Windows.Forms.TextBox TB_MatID;
        private System.Windows.Forms.Label LB_RowsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGV_SAP_2;
        private System.Windows.Forms.Button Btn_SAP_Rpt_detail;
        private System.Windows.Forms.DataGridView DGV_MoveType;
    }
}