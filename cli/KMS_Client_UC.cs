using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenSSL.CLI
{
    public partial class KMS_Client_UC : UserControl
    {
        private const string private_key_file = "Private_Keys.csv";
        private const string public_key_file = "Public_Keys.csv";
        public static string Private_key_file { get { return private_key_file; } }
        public static string Public_key_file { get { return public_key_file; } }

        private string username;
        Kms_Client client;
        public KMS_Client_UC(string username, Kms_Client client)
        {
            InitializeComponent();
            this.username = username;
            this.client = client;
            check_public_keys();
            check_private_key();
        }


        private void check_private_key()
        {
            try
            {
                var data = File.ReadAllLines(private_key_file);
                if (data.Length > 0 && !string.IsNullOrEmpty(data[0]) && data[0].Trim().Equals(username))
                { Private_key_status.Text = "Private Key is avilable."; Private_key_status.ForeColor = Color.Green; }
                else
                    Private_key_status.Text = "Private Key not available. Please update Private Key";
            }
            catch (Exception ex)
            {
                Private_key_status.Text = "Private Key not available. Please update Private Key";
            }
        }

        private void check_public_keys()
        {
            try
            {
                var data = File.ReadAllLines(public_key_file);
                if (data.Length > 0)
                { Public_key_status.Text = "Public Keys are avilable."; Public_key_status.ForeColor = Color.Green; }
                else
                    Public_key_status.Text = "Public Keys not available. Please update Public Key";
            }
            catch (Exception ex)
            {
                Public_key_status.Text = "Public Keys not available. Please update Public Key";
            }
        }
        private void Private_key_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string Key = client.getuserPKI();
                if (Key.Length > 100)
                {
                    File.WriteAllText(private_key_file, Key);
                    Private_key_status.Text = "Private Key Updated.";
                    Private_key_status.ForeColor = Color.Green;
                    Forum_Client.Instance.Update = true;
                }
            }
            catch (Exception ex) { }
        }

        private void Public_key_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string Key = client.getusersPKI();
                if (Key.Length > 100)
                {
                    File.WriteAllText(public_key_file, Key);
                    Public_key_status.Text = "Public Keys Updated.";
                    Public_key_status.ForeColor = Color.Green;
                    Forum_Client.Instance.Update = true;
                }
            }
            catch (Exception ex) { }
        }

        private void Logout_Btn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Logout", Logout_Btn);
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            MainForm.Instance.KMS_panel.Controls["KMS_Client_UC"].SendToBack();
        }
    }
}
