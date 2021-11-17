
namespace OsuMapDownloader.settings
{
    partial class SettingsForm
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
            this.AutoImport = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AutoImport
            // 
            this.AutoImport.AutoSize = true;
            this.AutoImport.Location = new System.Drawing.Point(13, 13);
            this.AutoImport.Name = "AutoImport";
            this.AutoImport.Size = new System.Drawing.Size(85, 17);
            this.AutoImport.TabIndex = 0;
            this.AutoImport.Text = "AutoImport";
            this.AutoImport.UseVisualStyleBackColor = true;
            this.AutoImport.CheckedChanged += new System.EventHandler(this.AutoImportCheckBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 194);
            this.Controls.Add(this.AutoImport);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AutoImport;
    }
}