namespace OpenSSL.CLI
{
    partial class Forum_Client
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
            this.Msg_Display_window = new System.Windows.Forms.RichTextBox();
            this.Msg_box = new System.Windows.Forms.TextBox();
            this.Send_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Users_list = new System.Windows.Forms.ListBox();
            this.alluser_checkbox = new System.Windows.Forms.CheckBox();
            this.Check_users = new System.ComponentModel.BackgroundWorker();
            this.Msgs_worker = new System.ComponentModel.BackgroundWorker();
            this.Username_Lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Msg_Display_window
            // 
            this.Msg_Display_window.Location = new System.Drawing.Point(3, 69);
            this.Msg_Display_window.Name = "Msg_Display_window";
            this.Msg_Display_window.ReadOnly = true;
            this.Msg_Display_window.Size = new System.Drawing.Size(662, 310);
            this.Msg_Display_window.TabIndex = 0;
            this.Msg_Display_window.Text = "";
            // 
            // Msg_box
            // 
            this.Msg_box.Location = new System.Drawing.Point(3, 385);
            this.Msg_box.Multiline = true;
            this.Msg_box.Name = "Msg_box";
            this.Msg_box.Size = new System.Drawing.Size(662, 67);
            this.Msg_box.TabIndex = 1;
            // 
            // Send_Btn
            // 
            this.Send_Btn.Location = new System.Drawing.Point(671, 385);
            this.Send_Btn.Name = "Send_Btn";
            this.Send_Btn.Size = new System.Drawing.Size(130, 67);
            this.Send_Btn.TabIndex = 2;
            this.Send_Btn.Text = "Send";
            this.Send_Btn.UseVisualStyleBackColor = true;
            this.Send_Btn.Click += new System.EventHandler(this.Send_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Forum Server Messages";
            // 
            // Users_list
            // 
            this.Users_list.FormattingEnabled = true;
            this.Users_list.ItemHeight = 16;
            this.Users_list.Location = new System.Drawing.Point(671, 69);
            this.Users_list.Name = "Users_list";
            this.Users_list.Size = new System.Drawing.Size(130, 308);
            this.Users_list.TabIndex = 4;
            // 
            // alluser_checkbox
            // 
            this.alluser_checkbox.AutoSize = true;
            this.alluser_checkbox.Checked = true;
            this.alluser_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alluser_checkbox.Location = new System.Drawing.Point(671, 42);
            this.alluser_checkbox.Name = "alluser_checkbox";
            this.alluser_checkbox.Size = new System.Drawing.Size(90, 21);
            this.alluser_checkbox.TabIndex = 5;
            this.alluser_checkbox.Text = "Everyone";
            this.alluser_checkbox.UseVisualStyleBackColor = true;
            this.alluser_checkbox.CheckedChanged += new System.EventHandler(this.alluser_checkbox_CheckedChanged);
            // 
            // Check_users
            // 
            this.Check_users.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Check_users_DoWork);
            // 
            // Msgs_worker
            // 
            this.Msgs_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Msgs_worker_DoWork);
            // 
            // Username_Lbl
            // 
            this.Username_Lbl.AutoSize = true;
            this.Username_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Lbl.Location = new System.Drawing.Point(15, 49);
            this.Username_Lbl.Name = "Username_Lbl";
            this.Username_Lbl.Size = new System.Drawing.Size(69, 20);
            this.Username_Lbl.TabIndex = 6;
            this.Username_Lbl.Text = "............";
            // 
            // Forum_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Username_Lbl);
            this.Controls.Add(this.alluser_checkbox);
            this.Controls.Add(this.Users_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Send_Btn);
            this.Controls.Add(this.Msg_box);
            this.Controls.Add(this.Msg_Display_window);
            this.Name = "Forum_Client";
            this.Size = new System.Drawing.Size(813, 456);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Msg_Display_window;
        private System.Windows.Forms.TextBox Msg_box;
        private System.Windows.Forms.Button Send_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Users_list;
        private System.Windows.Forms.CheckBox alluser_checkbox;
        private System.ComponentModel.BackgroundWorker Check_users;
        private System.ComponentModel.BackgroundWorker Msgs_worker;
        private System.Windows.Forms.Label Username_Lbl;
    }
}
