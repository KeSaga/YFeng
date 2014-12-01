namespace TestProject.StaticFunctionTest
{
    partial class FrmToStringWithDelimiterFromStringArrayTest
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lbListLength = new System.Windows.Forms.Label();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.richTxtBoxTestResult = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(260, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始测试";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbListLength
            // 
            this.lbListLength.AutoSize = true;
            this.lbListLength.Location = new System.Drawing.Point(12, 17);
            this.lbListLength.Name = "lbListLength";
            this.lbListLength.Size = new System.Drawing.Size(113, 12);
            this.lbListLength.TabIndex = 2;
            this.lbListLength.Text = "List<string>长度：";
            // 
            // numUpDown
            // 
            this.numUpDown.Location = new System.Drawing.Point(131, 15);
            this.numUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(120, 21);
            this.numUpDown.TabIndex = 3;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // richTxtBoxTestResult
            // 
            this.richTxtBoxTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtBoxTestResult.Location = new System.Drawing.Point(12, 42);
            this.richTxtBoxTestResult.Name = "richTxtBoxTestResult";
            this.richTxtBoxTestResult.ReadOnly = true;
            this.richTxtBoxTestResult.Size = new System.Drawing.Size(548, 315);
            this.richTxtBoxTestResult.TabIndex = 4;
            this.richTxtBoxTestResult.Text = "";
            // 
            // FrmToStringWithDelimiterFromStringArrayTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 369);
            this.Controls.Add(this.richTxtBoxTestResult);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.lbListLength);
            this.Controls.Add(this.btnStart);
            this.Name = "FrmToStringWithDelimiterFromStringArrayTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ToStringWithDelimiterFromStringArray(List<string> strList)函数测试";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbListLength;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.RichTextBox richTxtBoxTestResult;
    }
}