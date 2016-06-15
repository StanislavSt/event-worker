using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace EventApp
{
    public partial class tentApp : Form
    {
        RFID tentAppRFID;
        TextBox tbTentApp;
        string braceletid;
        DataHelper dh;
        List<TextBox> listoftextboxes;
        List<Label> labellist;
        List<TextBox> lbselectedtbs;
        int tentarea;
        int tentid;
        public tentApp()
        {
            InitializeComponent();
            dh = new DataHelper();
            tentAppRFID = new RFID();
            List<int> tentareas = dh.ListofTentAreas();
            if (tentareas != null)
            {
                foreach (int tentarea in tentareas)
                {
                    comboBox1.Items.Add(tentarea);
                }
            }
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Text = "There are no free tents!";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            listoftextboxes = new List<TextBox>();
            labellist = new List<Label>();
            listoftextboxes.Add(tb_person1);
            listoftextboxes.Add(tb_person2);
            listoftextboxes.Add(tb_person3);
            listoftextboxes.Add(tb_person4);
            listoftextboxes.Add(tb_person5);
            listoftextboxes.Add(tb_person6);
            labellist.Add(label1);
            labellist.Add(label2);
            labellist.Add(label3);
            labellist.Add(label4);
            labellist.Add(label5);
            labellist.Add(label6);
            foreach (TextBox tb in listoftextboxes)
            {
                tb.Visible = false;
            }
            foreach (Label lb in labellist)
            {
                lb.Visible = false;
            }
            tentAppRFID.open();
            tentAppRFID.Attach += tentAppRFID_Attach;
            tentAppRFID.Tag += tentAppRFID_Tag;
        }
        void tentAppRFID_Tag(object sender, TagEventArgs e)
        {
            if (tbTentApp != null)
            {
                tbTentApp.Text = e.Tag;
            }
        }

        void tentAppRFID_Attach(object sender, AttachEventArgs e)
        {
            ((RFID)sender).waitForAttachment(3000);
            ((RFID)sender).LED = true;
            ((RFID)sender).Antenna = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbselectedtbs = new List<TextBox>();
            foreach (TextBox tb in listoftextboxes)
            {
                tb.Visible = false;
            }
            foreach (Label lb in labellist)
            {
                lb.Visible = false;
            }
            int index = comboBox2.SelectedIndex;
            for (int i = 0; i < index + 1; i++)
            {
                listoftextboxes[i].Visible = true;
                labellist[i].Visible = true;
                lbselectedtbs.Add(listoftextboxes[i]);
            }
        }

        private void btn_Finish_RentTent_Click(object sender, EventArgs e)
        {
            bool empty = false;
            bool existingemail = false;
            foreach (TextBox tb in lbselectedtbs)
            {
                if (tb.Text == "")
                {
                    empty = true;
                }
            }
            if (empty)
            {
                MessageBox.Show("Please fill all the fields!");
            }
            else
            {
                foreach (TextBox tb in lbselectedtbs)
                {
                    if (dh.GetEmails(tb.Text))
                    {
                        existingemail = true;
                    }
                }
                if (existingemail)
                {
                    MessageBox.Show("One or more emails do not exist in our database.Try again!");
                }
                else
                {

                    List<string> emails = new List<string>();
                    foreach (TextBox tb in lbselectedtbs)
                    {
                        emails.Add(tb.Text);
                    }
                    if (ShowInputDialog(ref braceletid) == DialogResult.OK)
                    {
                        if (dh.UpdateBraceletMoney(braceletid, 30 + (emails.Count - 1) * 20))
                        {
                            if (dh.InsertPeopleInTentsDB(emails, tentid, emails.Count))
                            {
                                if (dh.UpdateTentDB(tentid))
                                {
                                    MessageBox.Show("You have successfully booked and paid for the tent!");
                                }
                                else
                                {
                                    MessageBox.Show("Something went wrong!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient amount in this bracelet!");
                        }
                    }
                }
            }
        }
        private DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.StartPosition = FormStartPosition.CenterParent;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter the bracelet ID";

            tbTentApp = new TextBox();
            tbTentApp.Size = new System.Drawing.Size(size.Width - 10, 23);
            tbTentApp.Location = new System.Drawing.Point(5, 5);
            tbTentApp.Text = input;
            inputBox.Controls.Add(tbTentApp);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = tbTentApp.Text;
            return result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tentarea = Convert.ToInt32(comboBox1.SelectedItem);
            tentid = dh.GetTentIdDB(tentarea);
        }

        private void tentApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tentAppRFID.Attached == true)
            {
                tentAppRFID.LED = false;
                tentAppRFID.Antenna = false;
                tentAppRFID.close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string braceletid = "";
            decimal amount = 0;
            if (ShowInputDialog(ref braceletid) == DialogResult.OK)
            {
                if (braceletid != "")
                {
                    int tentid = dh.GetTentIDForBracelet(braceletid, ref amount);
                    if (tentid > 0)
                    {
                        if (dh.UpdateBraceletMoney(braceletid, amount))
                        {
                            if (dh.UpdateTentsDB(tentid))
                            {
                                MessageBox.Show("Payment was successful!");
                            }
                            else
                            {
                                MessageBox.Show("Please try again!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient amount!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You don't have a booked tent!");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in the fields!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox_RentTent.Items.Clear();
            decimal price = 0;
            string email = textBox1.Text;
            string paid = "";
            int tentid = 0;
            List<string> fullnames = new List<string>();
            List<string> emails = dh.CheckTentsforEmail(email, ref fullnames, ref paid, ref price, ref tentid);
            if (emails.Count == 0)
            {
                listBox_RentTent.Items.Add("No reservation has been found with this e-mail!");
            }
            else
            {
                listBox_RentTent.Items.Add("Tent ID : " + tentid);
                for (int i = 0; i < fullnames.Count; i++)
                {
                    listBox_RentTent.Items.Add(fullnames[i].PadRight(25 - fullnames[i].Length) + "\tEmail: " + emails[i]);
                }
                listBox_RentTent.Items.Add("Has paid: " + paid);
                if (paid == "no")
                {
                    listBox_RentTent.Items.Add("Price: " + price);
                }
            }
        }
    }
}
