using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace invetory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int indexer = 0;
        bool editor = false;
        List<string> isertionlist = new List<string>();
        List<Panel> iventory_list = new List<Panel>();
        List<PictureBox> parralle_iventory_list = new List<PictureBox>();
        List<Panel> generate = new List<Panel>();
        Panel mainpanel = new Panel();
        Panel Add_iteam_in_inventory = new Panel();
        //items in (Add_iteam_in_inventory) panel
        PictureBox iteam_photo = new PictureBox();
        string photo_location = @"E:\invetory\invetory\bin\Debug\\120px-OOjs_UI_icon_add.svg.png";
        Button add_iteam_photo = new Button();
        TextBox iteam_name = new TextBox();
        TextBox iteam_description = new TextBox();
        TextBox iteam_value = new TextBox();
        TextBox iteam_quantaty = new TextBox();
        TextBox iteam_expire_date = new TextBox();
        Button add_iteam = new Button();
        //end of items
        FlowLayoutPanel inventory_valult = new FlowLayoutPanel();
        Panel Add_category_in_inventory = new Panel();
        string filename = @"inventory.txt";

        public void output()
        {

            if ((File.Exists(filename)) != true)
            {
                MessageBox.Show("inventor file not found : ");
        
                //  sw = File.CreateText(filename);
                //   sw.Close();
            }
            else
            {
                File.WriteAllText(filename, "");
                //  MessageBox.Show(isertionlist[1]);


                MessageBox.Show("1");
                StreamWriter sw = File.AppendText(filename);

                sw.WriteLine(isertionlist[0]);
                for (int i = 0; i < isertionlist.Count; i += 6)
                {
                    // File.OpenWrite(filename);
                    //sw = File.AppendText(filename);
                    //sw.WriteLine(isertionlist[0 + i]);
                    // sw.WriteLine(iteam_description.Text);
                    if (i != isertionlist.Count - 1)
                    {
                        MessageBox.Show(isertionlist[1 + i]);
                        sw.WriteLine(isertionlist[1 + i]);
                        sw.WriteLine(isertionlist[2 + i]);
                        sw.WriteLine(isertionlist[3 + i]);
                        sw.WriteLine(isertionlist[4 + i]);
                        sw.WriteLine(isertionlist[5 + i]);
                        sw.WriteLine(isertionlist[6 + i]);

                    }

                }
                sw.Close();
            }
        }
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
                indexer = int.Parse(isertionlist[0]);
                Panel[] history = new Panel[numberofitims + 1];
                MessageBox.Show(indexer.ToString());

                MessageBox.Show(numberofitims.ToString());

                int j = 0;
                for (int i = 0; i < numberofitims; i++)
                {
                    MessageBox.Show(isertionlist[1 + j] + j.ToString());
                    history[i] = new Panel();
                    Label id = new Label();
                    Label name = new Label();
                    Label value = new Label();
                    Label quantait = new Label();
                    Label expire_date = new Label();
                    Button delet_button = new Button();
                    PictureBox pictureBoxhistory = new PictureBox();
                    history[i].BackColor = Color.White;
                    history[i].Size = new Size(120, 140);
                    id.Text = "id : " + isertionlist[1 + j];
                    name.Text = "name : " + isertionlist[2 + j];
                    value.Text = "cost : " + isertionlist[3 + j];
                    quantait.Text = "quantaty : " + isertionlist[4 + j];
                    expire_date.Text = "expire : " + isertionlist[5 + j];
                    history[i].Controls.Add(id);
                    history[i].Controls.Add(name);
                    history[i].Controls.Add(value);
                    history[i].Controls.Add(quantait);
                    history[i].Controls.Add(expire_date);
                    id.Hide();
                    value.Hide();
                    quantait.Hide();
                    expire_date.Hide();
                    delet_button.Text = "X";
                    delet_button.FlatStyle = new FlatStyle();
                    delet_button.FlatAppearance.BorderSize = 0;
                    delet_button.Size = new Size(20, 20);
                    delet_button.Location = new Point(history[i].Width - 20, 3);
                    delet_button.Click += new EventHandler(delet_opreation);
                    delet_button.MouseHover += new EventHandler(in_before_delet_opreation_animation);
                    delet_button.MouseLeave += new EventHandler(out_before_delet_opreation_animation);
                    history[i].Controls.Add(delet_button);
                    history[i].Controls.Add(pictureBoxhistory);
                    pictureBoxhistory.BackColor = Color.Aqua;
                    pictureBoxhistory.Location = new Point(0, 20);
                    pictureBoxhistory.Size = new Size(120, 120);
                    pictureBoxhistory.Image = Image.FromFile(isertionlist[6 + j]);
                    pictureBoxhistory.SizeMode = PictureBoxSizeMode.CenterImage;
                    generate.Add(history[i]);
                    inventory_valult.Controls.Add(generate[i]);
                    pictureBoxhistory.MouseHover += new EventHandler(flash_in_item_details);
                    pictureBoxhistory.MouseLeave += new EventHandler(flash_out_item_details);
                    pictureBoxhistory.DoubleClick += new EventHandler(in_item_details);
                    pictureBoxhistory.Click += new EventHandler(out_item_details);
                    j += 6;

                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            input();
            this.Size = new Size(900, 600);
            mainpanel.Size = new Size(this.Width, this.Height);
            mainpanel.BackColor = Color.Blue;
            Add_iteam_in_inventory.Size = new Size(this.Width / 5, this.Height);
            Add_iteam_in_inventory.BackColor = Color.FromArgb(46, 51, 73);
            this.SizeChanged += new EventHandler(mainpanelsizechange);
            add_iteam.Click += new EventHandler(additeambutton);
            this.Controls.Add(mainpanel);
            iteam_photo.Size = new Size(120, 120);
            iteam_photo.Location = new Point((Add_iteam_in_inventory.Width - iteam_photo.Width) / 2, 80);
            // iteam_photo.BackColor = Color.Black;
            iteam_photo.BorderStyle = BorderStyle.FixedSingle;
            iteam_photo.Click += new EventHandler(addphotopicture);
            iteam_name.Location = new Point((Add_iteam_in_inventory.Width - iteam_name.Width) / 2, 240);
            iteam_description.Location = new Point((Add_iteam_in_inventory.Width - iteam_name.Width) / 2, 260);
            iteam_value.Location = new Point((Add_iteam_in_inventory.Width - iteam_description.Width) / 2, 280);
            iteam_quantaty.Location = new Point((Add_iteam_in_inventory.Width - iteam_quantaty.Width) / 2, 300);
            iteam_expire_date.Location = new Point((Add_iteam_in_inventory.Width - iteam_expire_date.Width) / 2, 320);
            add_iteam.Location = new Point((Add_iteam_in_inventory.Width - iteam_expire_date.Width) / 2, 340);
            mainpanel.Controls.Add(Add_iteam_in_inventory);
            inventory_valult.Size = new Size((this.Width - Add_iteam_in_inventory.Width) - 12, this.Height);
            inventory_valult.Location = new Point((Add_iteam_in_inventory.Location.X + Add_iteam_in_inventory.Width), 0);
            inventory_valult.BackColor = Color.LightGray;
            inventory_valult.AutoScroll = true;
            mainpanel.Controls.Add(inventory_valult);
            ///add_iteam_photo.Click += new EventHandler(addphotobutton);
            Add_iteam_in_inventory.Controls.Add(iteam_photo);
            //Add_iteam_in_inventory.Controls.Add(add_iteam_photo);
            Add_iteam_in_inventory.Controls.Add(iteam_name);
            // Add_iteam_in_inventory.Controls.Add(iteam_description);
            Add_iteam_in_inventory.Controls.Add(iteam_quantaty);
            Add_iteam_in_inventory.Controls.Add(iteam_value);
            Add_iteam_in_inventory.Controls.Add(iteam_expire_date);
            Add_iteam_in_inventory.Controls.Add(add_iteam);
            Add_iteam_in_inventory.AutoSize = true;
            iteam_photo.Image = new Bitmap(@"E:\invetory\invetory\bin\Debug\\120px-OOjs_UI_icon_add.svg.png");
        }
        public void mainpanelsizechange(object sender, EventArgs e)
        {
            mainpanel.Size = new Size(this.Width, this.Height);
            Add_iteam_in_inventory.Size = new Size(this.Width / 5, this.Height);
            iteam_photo.Location = new Point((Add_iteam_in_inventory.Width - iteam_photo.Width) / 2, 80);
            inventory_valult.Size = new Size((this.Width - Add_iteam_in_inventory.Width) - 5, this.Height);
            inventory_valult.Location = new Point((Add_iteam_in_inventory.Location.X + Add_iteam_in_inventory.Width), 0);
        }
        Panel generate_items;
        public void addphotobutton(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //  dialog.ShowDialog();
            dialog.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                iteam_photo.Image = new Bitmap(dialog.FileName);
               // photo_location = dialog.FileName;
                iteam_photo.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        public void addphotopicture(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //  dialog.ShowDialog();
            dialog.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                iteam_photo.Image = new Bitmap(dialog.FileName);
               // photo_location = dialog.FileName;
                iteam_photo.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        Label value_label = new Label();
        // Label name = new Label();
        // Label name = new Label();
        public void additeambutton(object sender, EventArgs e)
        {
            if (check_before_click() == true)
            {
                Label id = new Label();
                Label name = new Label();
                Label value = new Label();
                Label quantait = new Label();
                Label expire_date = new Label();
                Button delet_button = new Button();
                PictureBox picture = new PictureBox();
                // MessageBox.Show(indexer.ToString());
                iventory_list.Add(Add_iteam_in_inventory);
                generate_items = new Panel();
                generate_items.BackColor = Color.White;
                generate_items.Controls.Add(picture);
                generate_items.Size = new Size(120, 140);
                id.Text = "id : " + indexer.ToString();
                name.Text = "name : " + iteam_name.Text;
                value.Text = "cost : " + iteam_value.Text;
                quantait.Text = "quantaty : " + iteam_quantaty.Text;
                expire_date.Text = "expire : " + iteam_expire_date.Text;
                generate_items.Controls.Add(id);
                generate_items.Controls.Add(name);
                generate_items.Controls.Add(value);
                generate_items.Controls.Add(quantait);
                generate_items.Controls.Add(expire_date);
                id.Hide();
                value.Hide();
                quantait.Hide();
                expire_date.Hide();
                delet_button.Text = "X";
                delet_button.FlatStyle = new FlatStyle();
                delet_button.FlatAppearance.BorderSize = 0;
                delet_button.Size = new Size(20, 20);
                delet_button.Location = new Point(generate_items.Width - 20, 0);
                delet_button.Click += new EventHandler(delet_opreation);
                delet_button.MouseHover += new EventHandler(in_before_delet_opreation_animation);
                delet_button.MouseLeave += new EventHandler(out_before_delet_opreation_animation);
                generate_items.Controls.Add(delet_button);
                picture.Location = new Point(0, 20);
                picture.BorderStyle = BorderStyle.FixedSingle;
                picture.Image = iteam_photo.Image;
                picture.Size = new Size(120, 120);
                picture.SizeMode = PictureBoxSizeMode.CenterImage;
                picture.DoubleClick += new EventHandler(in_item_details);
                picture.Click += new EventHandler(out_item_details);
                generate.Add(generate_items);
                picture.MouseHover += new EventHandler(flash_in_item_details);
                picture.MouseLeave += new EventHandler(flash_out_item_details);
                inventory_valult.Controls.Add(generate[generate.Count - 1]);
                indexer++;
                insert();
                output();
            }
        }
        public void flash_in_item_details(object sender, EventArgs e)
        {
            if (editor == false)
            {
                PictureBox b = sender as PictureBox;
                Panel panel;
                panel = (Panel)b.Parent;
                panel.Size = new Size(240, 120);
                b.Location = new Point(0, 0);
                foreach (Control elsement in panel.Controls)
                {
                    if (elsement is Label && elsement.Text.Contains("name"))
                    {
                        elsement.Location = new Point(b.Location.X + 140, 5);
                        elsement.AutoSize = true;
                    }
                    if (elsement is Label && elsement.Text.Contains("cost"))
                    {
                        elsement.Location = new Point(b.Location.X + 140, 25);
                        elsement.AutoSize = true;
                        elsement.Show();
                    }
                    if (elsement is Label && elsement.Text.Contains("quantaty"))
                    {
                        elsement.Location = new Point(b.Location.X + 140, 40);
                        elsement.AutoSize = true;
                        elsement.Show();
                    }
                    if (elsement is Label && elsement.Text.Contains("expire"))
                    {
                        elsement.Location = new Point(b.Location.X + 140, 55);
                        elsement.AutoSize = true;
                        elsement.Show();
                    }
                    if (elsement is Button)
                    {
                        elsement.Location = new Point(b.Location.X + 220, 0);
                        elsement.Size = new Size(20, 20);
                    }
                }
            }
        }
        public void flash_out_item_details(object sender, EventArgs e)
        {
            if (editor == false)
            {

                PictureBox b = sender as PictureBox;
                Panel panel;
                panel = (Panel)b.Parent;
                panel.Size = new Size(120, 140);
                b.Location = new Point(0, 20);
                foreach (Control elsement in panel.Controls)
                {
                    if (elsement is Label && elsement.Text.Contains("name"))
                    {
                        elsement.Location = new Point(0, 0);

                    }
                    if (elsement is Button)
                    {
                        elsement.Location = new Point(panel.Width - elsement.Width, 0);

                    }
                }
            }
        }
        public void in_item_details(object sender, EventArgs e)
        {
            editor = true;
            Label label = new Label();
            Label label1 = new Label();
            Label label2 = new Label();
            Button button = new Button();
            PictureBox b = sender as PictureBox;
            Panel panel;
            panel = (Panel)b.Parent;
            panel.Size = new Size(240, 120);
            b.Location = new Point(0, 0);
            foreach (Control elsement in panel.Controls)
            {
                if (elsement is Label && elsement.Text.Contains("name"))
                {
                    elsement.Location = new Point(b.Location.X + 140, 5);
                    elsement.AutoSize = true;
                }
                if (elsement is Label && elsement.Text.Contains("cost"))
                {
                    elsement.Location = new Point(b.Location.X + 140, 25);
                    elsement.AutoSize = true;
                    elsement.Show();
                }
                if (elsement is Label && elsement.Text.Contains("quantaty"))
                {
                    elsement.Location = new Point(b.Location.X + 140, 40);
                    elsement.AutoSize = true;
                    elsement.Show();
                }
                if (elsement is Label && elsement.Text.Contains("expire"))
                {
                    elsement.Location = new Point(b.Location.X + 140, 55);
                    elsement.AutoSize = true;
                    elsement.Show();
                }
                if (elsement is Button)
                {
                    elsement.Location = new Point(b.Location.X + 220, 0);
                    elsement.Size = new Size(20, 20);
                }
            }
        }
        public void out_item_details(object sender, EventArgs e)
        {
            editor = false;
            Label label = new Label();
            Button button = new Button();
            PictureBox b = sender as PictureBox;
            Panel panel;
            panel = (Panel)b.Parent;
            panel.Size = new Size(120, 140);
            b.Location = new Point(0, 20);
            foreach (Control elsement in panel.Controls)
            {
                if (elsement is Label && elsement.Text.Contains("name"))
                {
                    elsement.Location = new Point(0, 0);

                }
                if (elsement is Button)
                {
                    elsement.Location = new Point(100, 0);

                }
            }
        }
        public void delet_opreation(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Panel panel;
            panel = (Panel)b.Parent;
            Panel far_parent = (Panel)panel.Parent;
            far_parent.Controls.Remove(panel);
            string s = "";
            foreach (Control l in panel.Controls)
            {
                if (l.Text.Contains("id") && l is Label)
                {
                    s = l.Text;
                }
            }
            s = s.Remove(0, 5);
            for (int i = 1; i < isertionlist.Count; i++)
            {
                if (isertionlist[i] == s)
                {
                    isertionlist.RemoveRange(i, 6);
                }
            }
            for (int i = 0; i < isertionlist.Count; i++)
            {
                MessageBox.Show(isertionlist[i]);
            }
            indexer--;
            isertionlist[0] = indexer.ToString();
            for (int i = int.Parse(s) + 1; i < isertionlist.Count; i += 6)
            {
                string c;
                c = isertionlist[i];
                int x = int.Parse(c);
                x--;
                isertionlist[i] = x.ToString();
            }
            output();
            //isertionlist.RemoveRange();
        }
        public void in_before_delet_opreation_animation(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Panel panel;
            b.BackColor = Color.Red;
            panel = (Panel)b.Parent;
            panel.BackColor = Color.Red;
        }
        public void out_before_delet_opreation_animation(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.Transparent;
            Panel panel;
            panel = (Panel)b.Parent;
            panel.BackColor = Color.White;
        }
        public void insert()
        {
            int c1 = indexer;
            c1--;
            MessageBox.Show("2");
            if (isertionlist.Count == 0)
            {
                isertionlist.Insert(0, indexer.ToString());
            }
            else
            {
                isertionlist[0] = indexer.ToString();
            }
            isertionlist.Add(c1.ToString());
            isertionlist.Add(iteam_name.Text);
            isertionlist.Add(iteam_value.Text);
            isertionlist.Add(iteam_quantaty.Text);
            isertionlist.Add(iteam_expire_date.Text);
            // isertionlist.Add(iteam_description.Text);
           // isertionlist.Add(photo_location);
            /* for (int i = 0; i < isertionlist.Count; i++)
             {

                 MessageBox.Show(isertionlist[0 + i]);
             }
             MessageBox.Show("end");*/
        }
        public bool check_before_click()
        {
            if (iteam_name.Text == "")
            {
                return false;
            }
            return true;
        }

    }
}
