using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EventApp
{
    public partial class Login : Form
    {
        DataHelper dh;
        public Login()
        {
            InitializeComponent();
            dh = new DataHelper();
            this.Size = new Size(400, 418);
            pictureBox6.Location = new Point(50, 60);
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            checkBox_checkInOutApp.Visible = false;
            checkBox_entranceApp.Visible = false;
            checkBox_equipmentApp.Visible = false;
            checkBox_inspectionApp.Visible = false;
            checkBox_shopApp.Visible = false;
            checkBox_tentApp.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            tb_regUser.Visible = false;
            tb_regPass.Visible = false;
            tb_regPassConf.Visible = false;
            btn_register.Visible = false;
            btn_logout.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entranceApp eapp = new entranceApp();
            eapp.ShowDialog();
            eapp.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckInOutApp eapp = new CheckInOutApp();
            eapp.ShowDialog();
            eapp.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tentApp eapp = new tentApp();
            eapp.ShowDialog();
            eapp.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            EquipmentApp eapp = new EquipmentApp();
            eapp.ShowDialog();
            eapp.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            shopApp eapp = new shopApp();
            
            eapp.ShowDialog();
            eapp.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            inspectionApp eapp = new inspectionApp();
            eapp.ShowDialog();
            eapp.Hide();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string entranceapp = "";
            string equipapp = "";
            string shopapp = "";
            string checkinoutapp = "";
            string paypalapp = "";
            string tentapp = "";
            string inspectionapp = "";
            if (tb_username.Text == "admin" && tb_password.Text == "admin")
            {
                this.Size = new Size(500, 650);
                pictureBox6.Location = new Point(113, 60);
                button1.Visible = true;
                button1.Location = new Point(70, 390);
                button2.Visible = true;
                button2.Location = new Point(190, 390);
                button3.Visible = true;
                button3.Location = new Point(310, 390);
                button4.Visible = true;
                button4.Location = new Point(70, 480);
                button5.Visible = true;
                button5.Location = new Point(190, 480);
                button6.Visible = true;
                button6.Location = new Point(310, 480);
                button7.Visible = true;
                btn_logout.Visible = true;
                btn_logout.Location = new Point(80, 318);
                checkBox_checkInOutApp.Visible = true;
                checkBox_entranceApp.Visible = true;
                checkBox_equipmentApp.Visible = true;
                checkBox_inspectionApp.Visible = true;
                checkBox_shopApp.Visible = true;
                checkBox_tentApp.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                tb_regUser.Visible = true;
                tb_regPass.Visible = true;
                tb_regPassConf.Visible = true;
                btn_register.Visible = true;
                btn_logout.Visible = true;

                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                tb_username.Visible = false;
                tb_password.Visible = false;
                btn_login.Visible = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else
            {   
                if (dh.SelectUserLoginDB(tb_username.Text, tb_password.Text, ref entranceapp, ref equipapp, ref shopapp, ref inspectionapp, ref paypalapp, ref checkinoutapp, ref tentapp))
                {
                    this.Size = new Size(500, 500);
                    pictureBox6.Location = new Point(113, 60);
                    button1.Visible = true;
                    button1.Location = new Point(70, 170);
                    button2.Visible = true;
                    button2.Location = new Point(190, 170);
                    button3.Visible = true;
                    button3.Location = new Point(310, 170);
                    button4.Visible = true;
                    button4.Location = new Point(70, 260);
                    button5.Visible = true;
                    button5.Location = new Point(190, 260);
                    button6.Visible = true;
                    button6.Location = new Point(310, 260);
                    btn_logout.Visible = true;
                    btn_logout.Location = new Point(280, 380);
                    button7.Visible = false;

                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    tb_username.Visible = false;
                    tb_password.Visible = false;
                    btn_login.Visible = false;
                    if (entranceapp == "yes")
                    {
                        button1.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = false;
                    }
                    if (equipapp == "yes")
                    {
                        button4.Enabled = true;
                    }
                    else
                    {
                        button4.Enabled = false;
                    }
                    if (shopapp == "yes")
                    {

                        button5.Enabled = true;
                    }
                    else
                    {
                        button5.Enabled = false;
                    }
                    if (inspectionapp == "yes")
                    {

                        button6.Enabled = true;
                    }
                    else
                    {
                        button6.Enabled = false;
                    }
                    if (tentapp == "yes")
                    {
                        button3.Enabled = true;
                    }
                    else
                    {
                        button3.Enabled = false;
                    }
                    if (checkinoutapp == "yes")
                    {
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled = false;
                    }
                }
                else
                {
                    label1.Visible = true;
                    label1.ForeColor=Color.Red;
                    label1.Text="Invalid username or pasword!";
                }
            }
            this.CenterToScreen();
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Visible = false;
            label2.Visible = false;
            tb_password.Clear();
            tb_username.Clear();
            this.Size = new Size(400, 418);
            pictureBox6.Location = new Point(60, 60);
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            checkBox_checkInOutApp.Visible = false;
            checkBox_entranceApp.Visible = false;
            checkBox_equipmentApp.Visible = false;
            checkBox_inspectionApp.Visible = false;
            checkBox_shopApp.Visible = false;
            checkBox_tentApp.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            tb_regUser.Visible = false;
            tb_regPass.Visible = false;
            tb_regPassConf.Visible = false;
            btn_register.Visible = false;
            btn_logout.Visible = false;

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            tb_username.Visible = true;
            tb_password.Visible = true;
            btn_login.Visible = true;
            this.CenterToScreen();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (tb_regUser.Text != "" && tb_regPass.Text != "" && tb_regPassConf.Text != "")
            {
                label1.Text = "";
                label1.Visible = false;
                int nrofaccess = 0;
                label2.Visible = true;
                string entranceapp = "";
                string equipapp = "";
                string shopapp = "";
                string checkinoutapp = "";
                string paypalapp = "no";
                string tentapp = "";
                string inspectionapp = "";
                if (checkBox_entranceApp.Checked)
                {
                    entranceapp = "yes";
                    nrofaccess++;
                }
                else
                {
                    entranceapp = "no";
                }
                if (checkBox_inspectionApp.Checked)
                {
                    inspectionapp = "yes";
                    nrofaccess++;
                }
                else
                {
                    inspectionapp = "no";
                }
                if (checkBox_shopApp.Checked)
                {
                    shopapp = "yes";
                    nrofaccess++;
                }
                else
                {
                    shopapp = "no";
                }
                if (checkBox_tentApp.Checked)
                {
                    tentapp = "yes";
                    nrofaccess++;
                }
                else
                {
                    tentapp = "no";
                }
                if (checkBox_equipmentApp.Checked)
                {
                    equipapp = "yes";
                    nrofaccess++;
                }
                else
                {
                    equipapp = "no";
                }
                if (checkBox_checkInOutApp.Checked)
                {
                    checkinoutapp = "yes";
                    nrofaccess++;
                }
                else
                {
                    checkinoutapp = "no";
                }
                if (tb_regPass.Text == tb_regPassConf.Text)
                {
                    if (nrofaccess != 0)
                    {
                        int result = dh.RegisterUserDB(tb_regUser.Text, tb_regPass.Text, entranceapp, equipapp, inspectionapp, checkinoutapp, tentapp, paypalapp, shopapp);
                        if (result == 1)
                        {
                            label2.ForeColor = Color.Green;
                            label2.Text = "Account successfully registered";
                            tb_regPass.Text = "";
                            tb_regPassConf.Text = "";
                            tb_regUser.Text = "";
                        }
                        else if (result == 2)
                        {
                            label2.ForeColor = Color.Red;
                            label2.Text = "This username already exists!";
                        }
                        else
                        {
                            label2.ForeColor = Color.Red;
                            label2.Text = "Unsuccessful attempt,try again!";
                        }
                    }
                    else
                    {
                        label2.ForeColor = Color.Red;
                        label2.Text = "User must have access to atleast 1 application!";
                    }
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Passwords don't match!";
                }
            }
            else
            {
                label2.Visible = true;
                label2.ForeColor = Color.Red;
                label2.Text = "All fields are required!";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            PayPalApp eapp = new PayPalApp();
            eapp.ShowDialog();
            eapp.Hide();
        }
        

    }
}
