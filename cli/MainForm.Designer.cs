namespace OpenSSL.CLI
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.KMS_Tab = new System.Windows.Forms.TabPage();
            this.KMS_Panel = new System.Windows.Forms.Panel();
            this.Forum_Tab = new System.Windows.Forms.TabPage();
            this.Forum_Panel = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.KMS_Tab.SuspendLayout();
            this.Forum_Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "SilentPigeon Client";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.KMS_Tab);
            this.tabControl1.Controls.Add(this.Forum_Tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 491);
            this.tabControl1.TabIndex = 3;
            // 
            // KMS_Tab
            // 
            this.KMS_Tab.Controls.Add(this.KMS_Panel);
            this.KMS_Tab.Location = new System.Drawing.Point(4, 25);
            this.KMS_Tab.Name = "KMS_Tab";
            this.KMS_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.KMS_Tab.Size = new System.Drawing.Size(819, 462);
            this.KMS_Tab.TabIndex = 0;
            this.KMS_Tab.Text = "KMS";
            this.KMS_Tab.UseVisualStyleBackColor = true;
            // 
            // KMS_Panel
            // 
            this.KMS_Panel.BackColor = System.Drawing.SystemColors.Control;
            this.KMS_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KMS_Panel.Location = new System.Drawing.Point(3, 3);
            this.KMS_Panel.Name = "KMS_Panel";
            this.KMS_Panel.Size = new System.Drawing.Size(813, 456);
            this.KMS_Panel.TabIndex = 0;
            // 
            // Forum_Tab
            // 
            this.Forum_Tab.BackColor = System.Drawing.SystemColors.Control;
            this.Forum_Tab.Controls.Add(this.Forum_Panel);
            this.Forum_Tab.Location = new System.Drawing.Point(4, 25);
            this.Forum_Tab.Name = "Forum_Tab";
            this.Forum_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Forum_Tab.Size = new System.Drawing.Size(819, 462);
            this.Forum_Tab.TabIndex = 1;
            this.Forum_Tab.Text = "Forum";
            // 
            // Forum_Panel
            // 
            this.Forum_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Forum_Panel.Location = new System.Drawing.Point(3, 3);
            this.Forum_Panel.Name = "Forum_Panel";
            this.Forum_Panel.Size = new System.Drawing.Size(813, 456);
            this.Forum_Panel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 578);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "LoginForm";
            this.tabControl1.ResumeLayout(false);
            this.KMS_Tab.ResumeLayout(false);
            this.Forum_Tab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage KMS_Tab;
        private System.Windows.Forms.TabPage Forum_Tab;
        private System.Windows.Forms.Panel KMS_Panel;
        private System.Windows.Forms.Panel Forum_Panel;
    }
}