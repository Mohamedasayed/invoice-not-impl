using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVOICE_supermarket;
namespace invetory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<string> isertionlist = new List<string>();
        string filename = @"inventory.txt";
        FlowLayoutPanel display = new FlowLayoutPanel();
        Panel main = new Panel();
        Panel cashire_valult = new Panel();
        Panel cashier_prerecite = new Panel();
        TextBox show_recity = new TextBox();
        List<string> visited_iteam = new List<string>();
        Label tprice = new Label();
        int total = 0;
        Label delete;
        Button go_to_invoice = new Button();
        Button go_to_login = new Button();
        public void input()
        {
            StreamWriter sw1;
            if ((File.Exists(filename)) == false)
            {
                sw1 = File.CreateText(filename);
                sw1.Close();
            }
            if (File.ReadAllText(filename) == "")
            {

                sw1 = File.AppendText(filename);
                sw1.WriteLine(0);
                sw1.Close();
            }
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "")
                {

                    break;
                }
                isertionlist.Add(line);
            }
            sr.Close();
            if (isertionlist[0] != "0")
            {
                //  int iterate = 0;
                int numberofitims = int.Parse(isertionlist[0]);
                //indexer = int.Parse(isertionlist[0]);
                Button[] history = new Button[numberofitims + 1];
                MessageBox.Show(numberofitims.ToString());
                int j = 0;
                for (int i = 0; i < numberofitims; i++)
                {
                    Label id = new Label();
                    Label value = new Label();
                    Label quantaty = new Label();
                    delete = new Label();
                    //  Label value = new Label();
                    MessageBox.Show(isertionlist[1 + j] + j.ToString());
                    id.Text = "id : " + isertionlist[1 + j];
                    value.Text = "value : " + isertionlist[3 + j];
                    quantaty.Text = "quantaty :" + "0";
                    history[i] = new Button();
                    delete.Size = new Size(10, 10);
                    history[i].BackColor = Color.White;
                    history[i].Size = new Size(100, 50);
                    history[i].Controls.Add(value);
                    history[i].Controls.Add(quantaty);
                    history[i].Controls.Add(id);
                    history[i].Controls.Add(delete);
                    delete.BackColor = Color.Red;
                    id.Hide();
                    value.Hide();
                    quantaty.Hide();
                    history[i].Text = isertionlist[2 + j];
                    history[i].Click += new EventHandler(calculate);
                    delete.Click += new EventHandler(de_calculate);
                    display.Controls.Add(history[i]);
                    j += 6;

                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            input();
            this.Size = new Size(900, 600);
            main.Size = new Size(this.Width, this.Height);
            cashier_prerecite.Size = new Size(this.Width / 3, this.Height);
            cashier_prerecite.Location = new Point(this.Width - cashier_prerecite.Width - 15, 0);
            cashier_prerecite.BackColor = Color.FromArgb(46, 51, 73);
            cashire_valult.Size = new Size(this.Width - cashier_prerecite.Width, this.Height);
            cashire_valult.BackColor = Color.Transparent;
            display.BackColor = Color.White;
            display.Size = new Size(cashire_valult.Width - 150, cashire_valult.Height - 150);
            display.Location = new Point((cashire_valult.Width - display.Width) / 2, (cashire_valult.Height - display.Height) / 2);
            display.AutoScroll = true;
            show_recity.Size = new Size(260, 400);
            show_recity.Location = new Point((cashier_prerecite.Width - show_recity.Width) / 2, 10);
            show_recity.Multiline = true;
            show_recity.ScrollBars = ScrollBars.Both;
            cashire_valult.Controls.Add(display);
            main.Controls.Add(cashier_prerecite);
            main.Controls.Add(cashire_valult);
            cashire_valult.Controls.Add(tprice);
            cashier_prerecite.Controls.Add(show_recity);
            cashire_valult.Controls.Add(go_to_invoice);
            go_to_invoice.Location = new Point(80, 10);
            this.Controls.Add(main);
            show_recity.TextAlign = HorizontalAlignment.Center;
            go_to_invoice.BackColor = Color.Red;
            go_to_invoice.Click += new EventHandler(go_to_invoice_op);
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            main.Size = new Size(this.Width, this.Height);
            cashire_valult.Location = new Point(0, 0);
            cashier_prerecite.Size = new Size(this.Width / 3, this.Height);
            cashire_valult.Size = new Size(this.Width - (this.Width / 3), this.Height);
            cashier_prerecite.Location = new Point(cashire_valult.Location.X + cashire_valult.Width, 0);
            // show_recity.Size = new Size(300, 400);
            //display.Size = new Size(cashire_valult.Width - 500, cashire_valult.Height - 500);
            display.Location = new Point((cashire_valult.Width - display.Width) / 2, (cashire_valult.Height - display.Height) / 2);
            show_recity.Location = new Point((cashier_prerecite.Width - show_recity.Width) / 2, 10);

        }
        string s;
        string id = "";
        private void calculate(object sender, EventArgs e)
        {
            int c = 0;
            bool b2 = false;
            int x;
            Button b = sender as Button;
            foreach (Control control in b.Controls)
            {
                if (control is Label && control.Text.Contains("id : "))
                {
                    s = control.Text;
                    s = s.Remove(0, 5);
                    id = s;
                    MessageBox.Show(id + "SSs");

                }

            }
            foreach (Label control in b.Controls)
            {
                if (control is Label && control.Text.Contains("quantaty :"))
                {
                    s = control.Text;
                    s = s.Remove(0, 10);
                    c = int.Parse(s);
                    c++;
                    control.Text = "quantaty :" + c.ToString();
                    //MessageBox.Show(s);
                }
                // MessageBox.Show(control.Text);
            }
            foreach (Control control in b.Controls)
            {

                if (control is Label && control.Text.Contains("value : "))
                {
                    s = control.Text;
                    s = s.Remove(0, 8);
                    total += int.Parse(s);
                    MessageBox.Show(s);
                }
            }
            for (int i = 0; i < visited_iteam.Count; i++)
            {

                if (visited_iteam[i].Contains(("id :" + id)))
                {
                    MessageBox.Show(id);
                    b2 = true;
                    visited_iteam[i] = "id :" + id + ",, Name :" + b.Text + " : " + ",, Value: " + s + ",, Quantaty: " + c;
                }
            }
            if (b2 == false)
            {

                visited_iteam.Add("id :" + id + ",, Name :" + b.Text + " : " + ",, Value: " + s + ",, Quantaty: " + c);
            }
            show_recity.Clear();
            for (int i = 0; i < visited_iteam.Count; i++)
            {
                show_recity.AppendText("  " + visited_iteam[i] + "  ");


                // show_recity.Text += "\n";
            }
            tprice.Text = total.ToString();


        }
        private void de_calculate(object sender, EventArgs e)
        {

            MessageBox.Show("true");
            int c = 0;
            bool b2 = false;
            int x;
            Label p = sender as Label;
            Button b = (Button)p.Parent;
            foreach (Control control in b.Controls)
            {
                if (control is Label && control.Text.Contains("id : "))
                {
                    s = control.Text;
                    s = s.Remove(0, 5);
                    id = s;
                    MessageBox.Show(id + "SSs");

                }
            }
            foreach (Label control in b.Controls)
            {
                if (control is Label && control.Text.Contains("quantaty :"))
                {
                    s = control.Text;
                    s = s.Remove(0, 10);
                    c = int.Parse(s);
                    c--;
                    control.Text = "quantaty :" + c.ToString();
                    //MessageBox.Show(s);
                }
            }
            foreach (Control control in b.Controls)
            {

                if (control is Label && control.Text.Contains("value : "))
                {
                    s = control.Text;
                    s = s.Remove(0, 8);
                    total -= int.Parse(s);
                    MessageBox.Show(s);
                }
            }
            for (int i = 0; i < visited_iteam.Count; i++)
            {

                if (visited_iteam[i].Contains(("id :" + id)))
                {
                    MessageBox.Show(id);
                    b2 = true;
                    visited_iteam.RemoveRange(i, 1);
                }
            }
            if (b2 == false)
            {

                MessageBox.Show("cant be deleted");
            }
            show_recity.Clear();
            for (int i = 0; i < visited_iteam.Count; i++)
            {
                MessageBox.Show(visited_iteam[i]);
                show_recity.AppendText("  " + visited_iteam[i] + "  ");
            }
            tprice.Text = total.ToString();
        }
        public void go_to_invoice_op(object sender, EventArgs e)
        {
            Invoice ins = new Invoice();
            ins.Show();
            Form3 form = new Form3();
            form.Show();

        }


    }
}


