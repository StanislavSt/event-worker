using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Phidgets;
using Phidgets.Events;

namespace EventApp
{
    public partial class entranceApp : Form
    {
        DataHelper dh;
        private List<Person> persons;
        private RFID rfidentranceApp;
        private TextBox tbEntranceApp;


        public entranceApp()
        {
            InitializeComponent();

            for (int i = 1900; i <= 1997; i++)
            {
                comboBox_Year_AssignChip.Items.Add(i.ToString());
            }
            dh = new DataHelper();
            persons = dh.GetAllPeople();
            rfidentranceApp = new RFID();
            rfidentranceApp.open();
            rfidentranceApp.Attach += rfid_AttachEntranceApp;
            rfidentranceApp.Tag += new TagEventHandler(GetBraceletIDentranceApp);
            tb_TicketID_AssignChip.Text = dh.GetLastIDfromDB().ToString();

        }

        private void rfid_AttachEntranceApp(object sender, AttachEventArgs e)
        {
            ((RFID)sender).waitForAttachment(3000);
            ((RFID)sender).LED = true;
            ((RFID)sender).Antenna = true;

        }

        private void GetBraceletIDentranceApp(object sender, TagEventArgs e)
        {

            if (tbEntranceApp != null)
            {
                tbEntranceApp.Text = e.Tag.ToString();
            }
            else
            {
                if (e.Tag.ToString() == "2800b81df0")
                {
                    foreach (Person p in dh.GetAllPeople())
                    {
                        if (p.FirstName == "Blagovest")
                        {
                            tb_TicketID_AssignChip.Text = p.TicketID.ToString();
                            tb_FirstName_AssignChip.Text = p.FirstName;
                            tb_LastName_AssignChip.Text = p.LastName;
                            tb_Email_AssignChip.Text = p.Email;
                            comboBox_Day_AssignChip.Text = "25";
                            comboBox_Month_AssignChip.Text = "March";
                            comboBox_Year_AssignChip.Text = "1994";
                        
                        }
                    }
                
                
                
                }
            }
        }

        private void btn_Register_AssignChip_Click(object sender, EventArgs e)
        {
            listBox_AssignChip.Items.Clear();
            try
            {
                if (tb_TicketID_AssignChip.Text != "" && tb_FirstName_AssignChip.Text != ""
                    && tb_LastName_AssignChip.Text != "" && tb_Email_AssignChip.Text != ""
                    && comboBox_Day_AssignChip.Text != "" && comboBox_Month_AssignChip.Text != ""
                    && comboBox_Year_AssignChip.Text != "")
                {
                    int day = Convert.ToInt32(comboBox_Day_AssignChip.SelectedItem);
                    int month = Convert.ToInt32((comboBox_Month_AssignChip.SelectedIndex + 1));
                    int year = Convert.ToInt32(comboBox_Year_AssignChip.SelectedItem);
                    int TicketID = Convert.ToInt32(tb_TicketID_AssignChip.Text);
                    string FirstName = tb_FirstName_AssignChip.Text;
                    string LastName = tb_LastName_AssignChip.Text;
                    DateTime dob = new DateTime(year, month, day);
                    string Email = tb_Email_AssignChip.Text;
                    DateTime dt = DateTime.Now;
                    bool found = false;
                    string braceletid = "";

                    Person P = null;
                    foreach (Person PR in persons)
                    {
                        if (PR.TicketID == TicketID)
                        {
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        P = new Person(TicketID, FirstName, LastName, dob, Email, dt);
                        if (dh.AddAPersontoDB(P))
                        {
                            persons.Add(P);
                            if (ShowInputDialog(ref braceletid) == DialogResult.OK)
                            {
                                if (dh.InsertBraceletID(braceletid) == true)
                                {
                                    P.SetBraceletID(braceletid);
                                    P.SetCheckInDateTime(DateAndTime.Now);
                                    dh.SetBraceletIDForPerson(P, braceletid);
                                    dh.SetCheckInForDB(P);
                                    tbEntranceApp = null;
                                    tb_TicketID_AssignChip.Text = dh.GetLastIDfromDB().ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Bracelet registration failed!");
                                }
                            }
                            else
                            {
                                tbEntranceApp = null;
                            }

                            foreach (string s in P.ListOfString())
                            {
                                listBox_AssignChip.Items.Add(s);
                            }
                        }
                    }
                    else if (found == true)
                    {
                        foreach (Person Per in persons)
                        {
                            if (Per.TicketID == TicketID)
                            {
                                if (ShowInputDialog(ref braceletid) == DialogResult.OK)
                                {
                                    if (dh.InsertBraceletID(braceletid))
                                    {
                                        dh.SetBraceletIDForPerson(Per, braceletid);
                                        dh.SetCheckInForDB(Per);
                                        Per.SetBraceletID(braceletid);
                                        Per.SetCheckInDateTime(DateAndTime.Now);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Bracelet registration failed!");
                                    }

                                }
                                foreach (string s in Per.ListOfString())
                                {
                                    listBox_AssignChip.Items.Add(s);
                                }
                            }
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Please fill all fields!");
                }

            }

            catch (FormatException)
            {
                MessageBox.Show("Please, complete all information correctly!");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");

            }


            tb_FirstName_AssignChip.Clear();
            tb_LastName_AssignChip.Clear();
            tb_Email_AssignChip.Clear();
            comboBox_Day_AssignChip.Text = "";
            comboBox_Month_AssignChip.Text = "";
            comboBox_Year_AssignChip.Text = "";
            tb_TicketID_AssignChip.Text = dh.GetLastIDfromDB().ToString();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            listBox_Search.Visible = true;
            dataGridViewPPL_Search.Visible = false;
            listBox_Search.Items.Clear();
            bool bfound = false;

            try
            {
                if (tb_LastName_Search.Text != "" && tb_FirstName_Search.Text != "")
                {
                    string fname = tb_FirstName_Search.Text;
                    string lname = tb_LastName_Search.Text;

                    foreach (Person p in persons)
                    {
                        if (p.FirstName == fname && p.LastName == lname)
                        {
                            bfound = true;

                            foreach (string s in p.ListOfString())
                            {
                                listBox_Search.Items.Add(s);
                            }
                        }
                    }
                }

                if (bfound == false)
                { MessageBox.Show("Sorry, but we don't have person with this given information!"); }
            }

            catch (FormatException)
            { MessageBox.Show("Please fill all the data correctly!"); }

            tb_FirstName_Search.Clear();
            tb_LastName_Search.Clear();
        }

        private void btn_ShowAll_Search_Click(object sender, EventArgs e)
        {
            listBox_Search.Visible = false;
            dataGridViewPPL_Search.Visible = true;
            dataGridViewPPL_Search.Rows.Clear();
            foreach (Person p in persons)
            {
                DataGridViewImageCell imageCell = null;
                Bitmap image = null;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewPPL_Search);

                row.Cells[0].Value = p.TicketID.ToString();
                row.Cells[1].Value = p.FirstName;
                row.Cells[2].Value = p.LastName;
                row.Cells[3].Value = p.ListOfStringDataGrid()[0];
                row.Cells[4].Value = p.ListOfStringDataGrid()[1];
                if (p.CheckInDateTime <= p.CheckOutDateTime)
                {
                    image = Properties.Resources.redCross;
                    imageCell = new DataGridViewImageCell();
                    imageCell.Value = image;
                }
                else
                {
                    image = Properties.Resources.Green_tick;
                    imageCell = new DataGridViewImageCell();
                    imageCell.Value = image;
                }

                row.Cells[5] = imageCell;
                dataGridViewPPL_Search.Rows.Add(row);
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

            tbEntranceApp = new TextBox();
            tbEntranceApp.Size = new System.Drawing.Size(size.Width - 10, 23);
            tbEntranceApp.Location = new System.Drawing.Point(5, 5);
            tbEntranceApp.Text = input;
            inputBox.Controls.Add(tbEntranceApp);

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
            input = tbEntranceApp.Text;
            return result;
        }

        private void entranceApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rfidentranceApp.Attached==true)
            {
                rfidentranceApp.LED = false;
                rfidentranceApp.Antenna = false;
                rfidentranceApp.close();
            }
        }
    }
}
