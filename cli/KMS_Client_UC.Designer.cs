namespace OpenSSL.CLI
{
    partial class KMS_Client_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Public_key_status = new System.Windows.Forms.Label();
            this.Public_key_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Private_key_status = new System.Windows.Forms.Label();
            this.Private_key_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Logout_Btn = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Logout_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // Public_key_status
            // 
            this.Public_key_status.AutoSize = true;
            this.Public_key_status.ForeColor = System.Drawing.Color.Red;
            this.Public_key_status.Location = new System.Drawing.Point(166, 295);
            this.Public_key_status.Name = "Public_key_status";
            this.Public_key_status.Size = new System.Drawing.Size(164, 17);
            this.Public_key_status.TabIndex = 16;
            this.Public_key_status.Text = ".......................................";
            // 
            // Public_key_btn
            // 
            this.Public_key_btn.Location = new System.Drawing.Point(436, 251);
            this.Public_key_btn.Name = "Public_key_btn";
            this.Public_key_btn.Size = new System.Drawing.Size(213, 46);
            this.Public_key_btn.TabIndex = 15;
            this.Public_key_btn.Text = "Update Keys";
            this.Public_key_btn.UseVisualStyleBackColor = true;
            this.Public_key_btn.Click += new System.EventHandler(this.Public_key_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Public Keys";
            // 
            // Private_key_status
            // 
            this.Private_key_status.AutoSize = true;
            this.Private_key_status.ForeColor = System.Drawing.Color.Red;
            this.Private_key_status.Location = new System.Drawing.Point(166, 158);
            this.Private_key_status.Name = "Private_key_status";
            this.Private_key_status.Size = new System.Drawing.Size(164, 17);
            this.Private_key_status.TabIndex = 13;
            this.Private_key_status.Text = ".......................................";
            // 
            // Private_key_btn
            // 
            this.Private_key_btn.Location = new System.Drawing.Point(436, 109);
            this.Private_key_btn.Name = "Private_key_btn";
            this.Private_key_btn.Size = new System.Drawing.Size(213, 46);
            this.Private_key_btn.TabIndex = 12;
            this.Private_key_btn.Text = "Update Key";
            this.Private_key_btn.UseVisualStyleBackColor = true;
            this.Private_key_btn.Click += new System.EventHandler(this.Private_key_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Private Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Key Management System Client";
            // 
            // Logout_Btn
            // 
            this.Logout_Btn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Logout_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout_Btn.Image = global::OpenSSL.CLI.Properties.Resources.logout;
            this.Logout_Btn.Location = new System.Drawing.Point(681, 29);
            this.Logout_Btn.Name = "Logout_Btn";
            this.Logout_Btn.Size = new System.Drawing.Size(59, 57);
            this.Logout_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logout_Btn.TabIndex = 18;
            this.Logout_Btn.TabStop = false;
            this.Logout_Btn.Click += new System.EventHandler(this.Logout_btn_Click);
            this.Logout_Btn.MouseHover += new System.EventHandler(this.Logout_Btn_MouseHover);
            // 
            // KMS_Client_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Logout_Btn);
            this.Controls.Add(this.Public_key_status);
            this.Controls.Add(this.Public_key_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Private_key_status);
            this.Controls.Add(this.Private_key_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KMS_Client_UC";
            this.Size = new System.Drawing.Size(777, 473);
            ((System.ComponentModel.ISupportInitialize)(this.Logout_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Public_key_status;
        private System.Windows.Forms.Button Public_key_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Private_key_status;
        private System.Windows.Forms.Button Private_key_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Logout_Btn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
