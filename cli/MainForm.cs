using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenSSL.CLI
{
    public partial class MainForm : Form
    {
        static MainForm _obj;

        public static MainForm Instance {
            get
            {
                if (_obj == null)
                    _obj = new MainForm();
                return _obj;
            }
        }
        public Panel KMS_panel {
            get { return KMS_Panel; }
            set { KMS_panel = value; }
        }
        public MainForm()
        {
            InitializeComponent();
            if (_obj == null)
                _obj = this;
            if (!KMS_Panel.Controls.Contains(UserLogin.Instance))
            {
                KMS_Panel.Controls.Add(UserLogin.Instance);
                UserLogin.Instance.Dock = DockStyle.Fill;
                UserLogin.Instance.BringToFront();
            }
            else
                UserLogin.Instance.BringToFront();

            if (!Forum_Panel.Controls.Contains(Forum_Client.Instance))
            {
                Forum_Panel.Controls.Add(Forum_Client.Instance);
                Forum_Client.Instance.Dock = DockStyle.Fill;
                Forum_Client.Instance.BringToFront();
            }
            else
                Forum_Client.Instance.BringToFront();
        }



    }
}
