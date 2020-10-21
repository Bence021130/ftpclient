using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ftpclient
{
    public partial class Form1 : Form
    {
            public static string address;
            public static string user;
            public static string pass;
        public Form1()
        {
            InitializeComponent();
            
        }
        private bool connection_test()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user, pass);
                request.GetResponse();
                request.Abort();
            }
            catch
            {
                return false;
            }
            return true;

                        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
                address = "ftp://" + textBox1.Text;
                user = textBox2.Text;
                pass = textBox3.Text;
            if (connection_test() == true)
            {
                //var frm = new Form2();
                Form2 frm = new Form2();
                frm.Show();
                Hide();
                MessageBox.Show("Sikeres csatlakozás!");
                
                
            }
            else
            {
                MessageBox.Show("Sikertelen csatlakozás! Kérlek próbáld meg újra!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
