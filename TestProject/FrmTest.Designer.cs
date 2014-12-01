namespace TestProject
{
    partial class FrmTest
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToStringWithDelimiter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToStringWithDelimiter
            // 
            this.btnToStringWithDelimiter.Location = new System.Drawing.Point(12, 12);
            this.btnToStringWithDelimiter.Name = "btnToStringWithDelimiter";
            this.btnToStringWithDelimiter.Size = new System.Drawing.Size(334, 23);
            this.btnToStringWithDelimiter.TabIndex = 0;
            this.btnToStringWithDelimiter.Text = "StaticFunction.ToStringWithDelimiter() 测试";
            this.btnToStringWithDelimiter.UseVisualStyleBackColor = true;
            this.btnToStringWithDelimiter.Click += new System.EventHandler(this.btnToStringWithDelimiter_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.btnToStringWithDelimiter);
            this.Name = "FrmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToStringWithDelimiter;
    }
}

