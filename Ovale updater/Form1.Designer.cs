namespace Ovale_updater
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OvaleScriptsTab = new System.Windows.Forms.TabPage();
            this.OvaleTab = new System.Windows.Forms.TabPage();
            this.OvaleScriptsLogTextbox = new System.Windows.Forms.TextBox();
            this.OvaleLogTextbox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.OvaleScriptsTab.SuspendLayout();
            this.OvaleTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.OvaleScriptsTab);
            this.tabControl1.Controls.Add(this.OvaleTab);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // OvaleScriptsTab
            // 
            this.OvaleScriptsTab.Controls.Add(this.OvaleScriptsLogTextbox);
            this.OvaleScriptsTab.Location = new System.Drawing.Point(4, 22);
            this.OvaleScriptsTab.Name = "OvaleScriptsTab";
            this.OvaleScriptsTab.Padding = new System.Windows.Forms.Padding(3);
            this.OvaleScriptsTab.Size = new System.Drawing.Size(571, 429);
            this.OvaleScriptsTab.TabIndex = 0;
            this.OvaleScriptsTab.Text = "Ovale scripts log";
            this.OvaleScriptsTab.UseVisualStyleBackColor = true;
            // 
            // OvaleTab
            // 
            this.OvaleTab.Controls.Add(this.OvaleLogTextbox);
            this.OvaleTab.Location = new System.Drawing.Point(4, 22);
            this.OvaleTab.Name = "OvaleTab";
            this.OvaleTab.Padding = new System.Windows.Forms.Padding(3);
            this.OvaleTab.Size = new System.Drawing.Size(571, 429);
            this.OvaleTab.TabIndex = 1;
            this.OvaleTab.Text = "Ovale log";
            this.OvaleTab.UseVisualStyleBackColor = true;
            // 
            // OvaleScriptsLogTextbox
            // 
            this.OvaleScriptsLogTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OvaleScriptsLogTextbox.Location = new System.Drawing.Point(3, 3);
            this.OvaleScriptsLogTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.OvaleScriptsLogTextbox.Multiline = true;
            this.OvaleScriptsLogTextbox.Name = "OvaleScriptsLogTextbox";
            this.OvaleScriptsLogTextbox.ReadOnly = true;
            this.OvaleScriptsLogTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OvaleScriptsLogTextbox.Size = new System.Drawing.Size(565, 423);
            this.OvaleScriptsLogTextbox.TabIndex = 0;
            // 
            // OvaleLogTextbox
            // 
            this.OvaleLogTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OvaleLogTextbox.Location = new System.Drawing.Point(3, 3);
            this.OvaleLogTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.OvaleLogTextbox.Multiline = true;
            this.OvaleLogTextbox.Name = "OvaleLogTextbox";
            this.OvaleLogTextbox.ReadOnly = true;
            this.OvaleLogTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OvaleLogTextbox.Size = new System.Drawing.Size(565, 423);
            this.OvaleLogTextbox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 518);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(250, 150);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ovale updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.OvaleScriptsTab.ResumeLayout(false);
            this.OvaleScriptsTab.PerformLayout();
            this.OvaleTab.ResumeLayout(false);
            this.OvaleTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OvaleScriptsTab;
        private System.Windows.Forms.TextBox OvaleScriptsLogTextbox;
        private System.Windows.Forms.TabPage OvaleTab;
        private System.Windows.Forms.TextBox OvaleLogTextbox;
    }
}

