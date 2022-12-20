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

namespace invetory
{
    public partial class Form3 : Form
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        public Form3()
        {
            InitializeComponent();
            this.ActiveControl = TxtUser;
            TxtUser.Focus();
        }
        string filepath=@"/signup_store.txt";
        public void input()
         {
            if(!File.Exists(filepath))
            {
                File.Create(filepath);
            }
            StreamReader sr = new StreamReader(filepath);
            string line;
            while((line = sr.ReadLine()) != null)
            {

            }

         }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            TxtUser.BackColor = Color.White;
            TxtPass.BackColor = Color.White;
            TxtUser.BorderStyle = BorderStyle.None;
            TxtPass.BorderStyle = BorderStyle.None;
            Panel p1 = new Panel();
            p1.Size = new Size(TxtUser.Width, 1);
            p1.BackColor = Color.Red;
            Panel p2 = new Panel();
            p2.Size = new Size(TxtPass.Width, 1);
            p2.BackColor = Color.Red;
            this.Controls.Add(p1);
            this.Controls.Add(p2);
            p1.Location = new Point(TxtUser.Location.X, TxtUser.Location.Y + TxtUser.Height);
            p2.Location = new Point(TxtPass.Location.X, TxtPass.Location.Y + TxtPass.Height);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = TxtUser.Text;
            string pass = TxtPass.Text;
            if (user == "admin" && pass == "admin")
            {
                MessageBox.Show("You Are In");
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password!");
            }
            TxtUser.Clear();
            TxtPass.Clear();
        }
        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtPass.Focus();
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (showpass.Checked)
            {
                TxtPass.PasswordChar = '\0';
            }
            if (showpass.Checked == false)
            {
                TxtPass.PasswordChar = '*';
            }
        }
    }
}
