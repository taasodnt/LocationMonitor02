namespace LocationMonitor.MyForm
{
    partial class AddBeaconForm
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.selectCmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(218, 82);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "確認";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // selectCmb
            // 
            this.selectCmb.FormattingEnabled = true;
            this.selectCmb.Location = new System.Drawing.Point(12, 42);
            this.selectCmb.Name = "selectCmb";
            this.selectCmb.Size = new System.Drawing.Size(281, 23);
            this.selectCmb.TabIndex = 1;
            // 
            // AddBeaconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 123);
            this.Controls.Add(this.selectCmb);
            this.Controls.Add(this.confirmBtn);
            this.Name = "AddBeaconForm";
            this.Text = "AddBeaconForm";
            this.Load += new System.EventHandler(this.AddBeaconForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.ComboBox selectCmb;
    }
}