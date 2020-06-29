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
using OpenSSL.Core;
using OpenSSL.Crypto;
using System.Threading;

namespace OpenSSL.CLI
{
    public partial class Forum_Client : UserControl
    {
        private static Forum_Client _instance;
        public static Forum_Client Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Forum_Client();
                return _instance;
            }
        }

        private string User = string.Empty;
        private RSA user_priv_key = null;
        private Dictionary<string, RSA> Users_PKI = null;
        Frm_client forum_client;
        private bool update = false;

        public bool Update
        {
            get { return update; }
            set { update = value; }
        }

        public Forum_Client()
        {
            InitializeComponent();
            alluser_checkbox.Checked = true;
            Check_users.RunWorkerAsync();
        }

        private void Check_users_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (user_priv_key == null)
                    Read_User_PKI();
                if (Users_PKI == null || Users_PKI.Count < 1)
                    Read_Users_PKI();
                if (Users_list.Items.Count < 1)
                    Set_users();

                if (user_priv_key != null && Users_PKI != null && Users_list.Items.Count > 0 && forum_client == null)
                    getallmessages();

                if (update)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Msg_Display_window.Clear();
                        Read_User_PKI();
                        Read_Users_PKI();
                        Set_users();
                        if (user_priv_key != null && Users_PKI != null && Users_list.Items.Count > 0)
                            getallmessages();
                    });
                }
                this.Invoke((MethodInvoker)delegate
                    {
                        Username_Lbl.Text = "User: " + User;
                    });
                Thread.Sleep(1000);
            }
        }

        private void Read_User_PKI()
        {
            try
            {
                BIO bio = BIO.MemoryBuffer();
                var keys = File.ReadAllLines(KMS_Client_UC.Private_key_file);
                if (keys.Length > 25)
                {
                    byte[] bytes;
                    for (int i = 0; i < 28; i++)
                    {
                        if (i == 0)
                            User = keys[i];
                        else
                        {
                            string temp = keys[i] + "\n";
                            bytes = Encoding.ASCII.GetBytes(temp);
                            bio.Write(bytes, bytes.Length);
                        }
                    }
                    user_priv_key = RSA.FromPrivateKey(bio);
                }
            }
            catch (Exception ex)
            { }
        }
        private void Read_Users_PKI()
        {
            if (Users_PKI == null)
                Users_PKI = new Dictionary<string, RSA>();
            else
                Users_PKI.Clear();

            var keys = File.ReadAllLines(KMS_Client_UC.Public_key_file);
            if (keys.Length >= 99)
            {
                byte[] bytes;
                for (int i = 0; i < 10; i++)
                {
                    BIO bio = BIO.MemoryBuffer();
                    string user = "", temp;
                    for (int j = i * 10; j < (i + 1) * 10; j++)
                    {
                        if (j == i * 10)
                        {
                            user = keys[j];
                        }
                        else
                        {
                            temp = keys[j] + "\n";
                            bytes = Encoding.ASCII.GetBytes(temp);
                            bio.Write(bytes, bytes.Length);
                        }
                    }
                    Users_PKI.Add(user, RSA.FromPublicKey(bio));
                }

            }
        }
        private void Set_users()
        {
            this.Invoke((MethodInvoker)delegate
            {
                Users_list.Items.Clear();
                foreach (var item in Users_PKI.Keys)
                {
                    if (!item.Equals(User))
                        Users_list.Items.Add(item);
                }
            });
        }

        private void alluser_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if(alluser_checkbox.Checked)
                Users_list.Enabled = false;
            else
                Users_list.Enabled = true;
        }

        private void getallmessages()
        {
            if (forum_client == null)
                forum_client = new Frm_client(User);
            ////get msgs
            var resp = forum_client.GetMessages();
            ///display msgs
            foreach (var str in resp.Split('&'))
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        var userinfo = str.Split(',');
                        var username = userinfo[0].Trim();
                        var msgg = userinfo[1].Trim();

                        if (userinfo[1].Contains("smessage") || msgg.Length > 1024)
                        {
                            StringBuilder res = new StringBuilder();
                            StringBuilder temp = new StringBuilder();
                            for (int i = 1; i <= msgg.Length; i++)
                            {
                                temp.Append(msgg[i - 1]);
                                if (i % 128 == 0)
                                {
                                    res.Append(user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));
                                    temp.Clear();
                                }
                            }
                            if (temp.Length > 0)
                            {
                                res.Append(user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));
                                temp.Clear();
                            }
                            //var tmp_msgg = user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1);

                            msgg = Encoding.ASCII.GetString(Users_PKI[username].PublicDecrypt(StringToByteArray(res.ToString()), RSA.Padding.PKCS1));
                        }
                        else
                            msgg = Encoding.ASCII.GetString(Users_PKI[username].PublicDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));

                        this.Invoke((MethodInvoker)delegate
                        {
                            Msg_Display_window.AppendText(username + " : " + msgg + Environment.NewLine);
                        });
                    }

                }
                catch (Exception ex) { }
            }
        }

        public string single_user = string.Empty;
        private void Send_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                single_user = string.Empty;
                if (!alluser_checkbox.Checked)
                {
                    try
                    {
                        single_user = Users_list.GetItemText(Users_list.SelectedItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please select any user to send message.");
                        return;
                    }
                }
                Msgs_worker.RunWorkerAsync();
            }
            catch (Exception ex)
            { }
        }

        private void Msgs_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var msg = Msg_box.Text;
            ///// send msg

            msg = ByteArrayToString(user_priv_key.PrivateEncrypt(Encoding.ASCII.GetBytes(msg), RSA.Padding.PKCS1));
            String resp;
            if (!alluser_checkbox.Checked)
            {
                StringBuilder res = new StringBuilder();
                StringBuilder temp = new StringBuilder();
                for (int i = 1; i <= msg.Length; i++ )
                {
                    temp.Append(msg[i - 1]);
                    if (i % 32 == 0)
                    {
                        res.Append(ByteArrayToString(Users_PKI[single_user].PublicEncrypt(StringToByteArray(temp.ToString()), RSA.Padding.PKCS1)));
                        temp.Clear();
                    }
                }
                if(temp.Length>0)
                {
                    res.Append(ByteArrayToString(Users_PKI[single_user].PublicEncrypt(StringToByteArray(temp.ToString()), RSA.Padding.PKCS1)));
                    temp.Clear();
                }
                msg = res.ToString();
                resp = forum_client.SendMessage2(msg);
            }
            else
                resp = forum_client.SendMessage(msg);

            if (resp.Equals(string.Empty))
            {
                /////msg not sent, send again 
            }
            else
            {
                var userinfo = resp.Split('&');
                var username = userinfo[0].Substring(userinfo[0].IndexOf("=") + 1);
                var msgg = userinfo[1].Substring(userinfo[1].IndexOf("=") + 1);
                if (userinfo[1].Contains("smessage"))
                {
                    StringBuilder res = new StringBuilder();
                    StringBuilder temp = new StringBuilder();
                    for (int i = 1; i <= msgg.Length; i++)
                    {
                        temp.Append(msgg[i - 1]);
                        if (i % 128 == 0)
                        {
                            res.Append(user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));
                            temp.Clear();
                        }
                    }
                    if (temp.Length > 0)
                    {
                        res.Append(user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1)); 
                        temp.Clear();
                    } 
                    //var tmp_msgg = user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1);

                    msgg = Encoding.ASCII.GetString(Users_PKI[username].PublicDecrypt(StringToByteArray(res.ToString()), RSA.Padding.PKCS1));
                }
                else
                {
                    msgg = Encoding.ASCII.GetString(Users_PKI[username].PublicDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));

                } 
                this.Invoke((MethodInvoker)delegate
                {
                    Msg_Display_window.AppendText(username.Trim() + " " + msgg.Trim() + Environment.NewLine + Environment.NewLine);
                    Msg_box.Text = "";
                });
                /////msg sent add it to msg display box
            }
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public void Update_Msgbox(string str)
        {
            var userinfo = str.Split('&');
            var username = userinfo[0].Substring(userinfo[0].IndexOf("=") + 1);
            var msgg = userinfo[1].Substring(userinfo[1].IndexOf("=") + 1);

            if (userinfo[1].Contains("smessage"))
            {
                StringBuilder res = new StringBuilder();
                StringBuilder temp = new StringBuilder();
                for (int i = 1; i <= msgg.Length; i++)
                {
                    temp.Append(msgg[i - 1]);
                    if (i % 128 == 0)
                    {
                        res.Append(user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));
                        temp.Clear();
                    }
                }
                if (temp.Length > 0)
                {
                    res.Append(user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));
                    temp.Clear();
                }
                //var tmp_msgg = user_priv_key.PrivateDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1);

                msgg = Encoding.ASCII.GetString(Users_PKI[username].PublicDecrypt(StringToByteArray(res.ToString()), RSA.Padding.PKCS1));
            }
            else
                msgg = Encoding.ASCII.GetString(Users_PKI[username].PublicDecrypt(StringToByteArray(msgg), RSA.Padding.PKCS1));
            


            
            this.Invoke((MethodInvoker)delegate
            {
                Msg_Display_window.AppendText(username.Trim() + " " + msgg.Trim() + Environment.NewLine + Environment.NewLine);
                Msg_Display_window.ScrollToCaret();
            });
        }
    }
}
