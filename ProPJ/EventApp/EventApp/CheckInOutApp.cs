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
    public partial class CheckInOutApp : Form
    {
        DataHelper dh;
        private List<Person> persons;
        private RFID rfidexitApp;

        public CheckInOutApp()
        {
            InitializeComponent();
            dh = new DataHelper();
            persons = dh.GetAllPeople();
            rfidexitApp = new RFID();
            rfidexitApp.Attach += rfid_AttachExitApp;
            rfidexitApp.Tag += new TagEventHandler(GetBraceletIDexitApp);
            rfidexitApp.open();
            
        }

        private void rfid_AttachExitApp(object sender, AttachEventArgs e)
        {
            ((RFID)sender).waitForAttachment(3000);
            ((RFID)sender).LED = true;
            ((RFID)sender).Antenna = true;

        }
       
        private void GetBraceletIDexitApp(object sender, TagEventArgs e)
        {
            listBox_CheckOut.Items.Clear();
            tb_BraceletID_CheckOut.Text = e.Tag.ToString();
            if (dh.GetEquipmentForPersonDB(tb_BraceletID_CheckOut.Text).Count == 0)
            {
                    btn_CheckOut_CheckOut.PerformClick();
                    btn_GetInfo_CheckOut.PerformClick();
                
            }
            else
            {
                MessageBox.Show("Please, return the equipment first!");
                btn_GetInfo_CheckOut.PerformClick();
                foreach (Person P in persons)
                {
                    if (P.BraceletID == tb_BraceletID_CheckOut.Text)
                    {
                        foreach (string s in P.ListOfString())
                        {
                            listBox_CheckOut.Items.Add(s);
                        }
                    }
                }
            }

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

        private void btn_CheckOut_CheckOut_Click(object sender, EventArgs e)
        {
            listBox_CheckOut.Items.Clear();
            try
            {
                DateTime dt = DateTime.Now;
                string braceletid = tb_BraceletID_CheckOut.Text;
                if (dh.GetEquipmentForPersonDB(braceletid).Count == 0)
                {
                    if (MessageBox.Show("Proceed?", "Proceed?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        foreach (Person P in persons)
                        {
                            if (P.BraceletID == braceletid)
                            {
                                if (P.CheckInDateTime < P.CheckOutDateTime)
                                {
                                    if (dh.SetCheckInForDB(P))
                                    {
                                        P.SetCheckInDateTime(dt);
                                    }
                                }
                                else if (P.CheckInDateTime > P.CheckOutDateTime)
                                {

                                    if (dh.SetCheckOutForDB(P))
                                    {
                                        P.SetCheckOutDateTime(dt);
                                    }
                                }
                                foreach (string s in P.ListOfString())
                                {
                                    listBox_CheckOut.Items.Add(s);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Person P in persons)
                        {
                            if (P.BraceletID == braceletid)
                            {
                                foreach (string s in P.ListOfString())
                                {
                                    listBox_CheckOut.Items.Add(s);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Person P in persons)
                    {
                        if (P.BraceletID == braceletid)
                        {
                            foreach (string s in P.ListOfString())
                            {
                                listBox_CheckOut.Items.Add(s);
                            }
                        }
                    }
                    MessageBox.Show("Please, return the equipment first!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_GetInfo_CheckOut_Click(object sender, EventArgs e)
        {
            listBox_PendingProducts_Exit.Items.Clear();
            string braceletid = tb_BraceletID_CheckOut.Text;
            decimal total = 0;
            foreach (Equipment equip in dh.GetEquipmentForPersonDB(braceletid))
            {
                listBox_PendingProducts_Exit.Items.Add(equip.Name.PadRight(20 - equip.Name.Length) + "\tQuantity: " + equip.Quantity.ToString().PadRight(3) + "\t" + equip.Price + " \u20AC");
                total = total + equip.Price;

            }
            listBox_PendingProducts_Exit.Items.Add("*****************************************************************");
            listBox_PendingProducts_Exit.Items.Add("\t\t\tTOTAL: " + total + " \u20AC");
        }

        private void exitApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rfidexitApp.Attached == true)
            {
                rfidexitApp.LED = false;
                rfidexitApp.Antenna = false;
                rfidexitApp.close();
            }
        }

   
    }
}
