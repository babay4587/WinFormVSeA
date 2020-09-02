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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_SNR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBunicode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBMatDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBAssembleTo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_TargetMatDesc = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1119, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "SerialNumber:";
            // 
            // TB_SNR
            // 
            this.TB_SNR.Location = new System.Drawing.Point(169, 37);
            this.TB_SNR.Name = "TB_SNR";
            this.TB_SNR.Size = new System.Drawing.Size(197, 28);
            this.TB_SNR.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "UniqueCode:";
            // 
            // TBunicode
            // 
            this.TBunicode.Location = new System.Drawing.Point(504, 37);
            this.TBunicode.Name = "TBunicode";
            this.TBunicode.Size = new System.Drawing.Size(552, 28);
            this.TBunicode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Material Descript:";
            // 
            // TBMatDesc
            // 
            this.TBMatDesc.Location = new System.Drawing.Point(577, 79);
            this.TBMatDesc.Name = "TBMatDesc";
            this.TBMatDesc.Size = new System.Drawing.Size(479, 28);
            this.TBMatDesc.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Assembled To:";
            // 
            // TBAssembleTo
            // 
            this.TBAssembleTo.Location = new System.Drawing.Point(157, 27);
            this.TBAssembleTo.Name = "TBAssembleTo";
            this.TBAssembleTo.Size = new System.Drawing.Size(197, 28);
            this.TBAssembleTo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原SNR";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TBAssembleTo);
            this.groupBox2.Controls.Add(this.TB_TargetMatDesc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1076, 109);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标SNR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Material Descript:";
            // 
            // TB_TargetMatDesc
            // 
            this.TB_TargetMatDesc.Location = new System.Drawing.Point(565, 27);
            this.TB_TargetMatDesc.Name = "TB_TargetMatDesc";
            this.TB_TargetMatDesc.Size = new System.Drawing.Size(479, 28);
            this.TB_TargetMatDesc.TabIndex = 2;
            // 
            // FormMatTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 486);
            this.Controls.Add(this.TBunicode);
            this.Controls.Add(this.TBMatDesc);
            this.Controls.Add(this.TB_SNR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMatTrace";
            this.Text = "FormMatTrace";
            this.Load += new System.EventHandler(this.FormMatTrace_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_SNR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBunicode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBMatDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBAssembleTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TB_TargetMatDesc;
        private System.Windows.Forms.Label label5;
    }
}