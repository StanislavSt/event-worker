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
    public partial class hiredApp : Form
    {
        private TextBox tbHiredApp;
        private RFID rfidhiredApp;
        public List<Equipment> Order;
        DataHelper dh;
        List<Equipment> ListfromDB;
        List<Equipment> ReturnList;
        List<Equipment> PEquipList;
        public hiredApp()
        {
            InitializeComponent();
            rfidhiredApp = new RFID();
            rfidhiredApp.open();
            rfidhiredApp.Tag += new TagEventHandler(GetBraceletIDhiredApp);
            rfidhiredApp.Attach += myRFID_AttachHiredApp;
            Order = new List<Equipment>();
            dh = new DataHelper();
            ListfromDB = dh.GetEquipmentFromDB();
           
            LabelUpdate();
        }

        private void myRFID_AttachHiredApp(object sender, AttachEventArgs e)
        {
            ((RFID)sender).waitForAttachment(3000);
            ((RFID)sender).LED = true;
            ((RFID)sender).Antenna = true;
            
        }
        private void GetBraceletIDhiredApp(object sender, TagEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                if (tbHiredApp != null)
                {
                    tbHiredApp.Text = e.Tag;
                }

            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                tb_BraceletID_Return.Text = e.Tag;
                btn_GetProd_Return.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEqToList(1);
            LabelUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEqToList(2);
            LabelUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEqToList(7);
            LabelUpdate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddEqToList(6);
            LabelUpdate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddEqToList(3);
            LabelUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddEqToList(4);
            LabelUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddEqToList(5);
            LabelUpdate();
        }

        private void listBox_Hire_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_Hire.SelectedItem != null)
            {
                Equipment E = Order[listBox_Hire.SelectedIndex];


                foreach (Equipment eq in ListfromDB)
                {
                    if (eq.EquipmentID == E.EquipmentID)
                    {

                        eq.IncreaseQuantity(E.Quantity);

                    }

                }

                listBox_Hire.Items.Remove(listBox_Hire.SelectedItem);
                Order.Remove(E);
            }
            LabelUpdate();
        }
        public static int GetEquipment(List<Equipment> listpr, int searchvalue, int min, int max)
        {

            if (min > max)
            {
                return -1;
            }
            else
            {
                int mid = (min + max) / 2;
                if (searchvalue == listpr[mid].EquipmentID)
                {
                    return mid;
                }
                else if (searchvalue < listpr[mid].EquipmentID)
                {
                    return GetEquipment(listpr, searchvalue, min, mid - 1);
                }
                else
                {
                    return GetEquipment(listpr, searchvalue, mid + 1, max);
                }
            }
        }
        public void AddEqToList(int equipmentid)
        {
            listBox_Hire.Items.Clear();
            try
            {
                int quantity = Convert.ToInt32(numericUpDown_Quantity_Hire.Value);
                numericUpDown_Quantity_Hire.Value = 1;
                Equipment eq = ListfromDB[GetEquipment(ListfromDB, equipmentid,
                    ListfromDB.IndexOf(ListfromDB.First()), ListfromDB.IndexOf(ListfromDB.Last()))];


                if (quantity > eq.Quantity)
                {
                    MessageBox.Show("There are " + eq.Quantity + " in stock.");
                }

                else
                {
                    bool found = false;
                    Equipment eqtoadd = new Equipment(eq.EquipmentID, eq.Name, quantity,eq.Price);
                    foreach (Equipment e in Order)
                    {
                        if (eqtoadd.EquipmentID == e.EquipmentID)
                        {
                            e.IncreaseQuantity(quantity);
                            found = true;
                            eq.DecreaseQuantity(quantity);
                        }

                    }
                    if (!found)
                    {
                        Order.Add(eqtoadd);
                        eq.DecreaseQuantity(quantity);
                    }

                }
                AddToListBox();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                AddToListBox();
            }
        }
        private  DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.StartPosition = FormStartPosition.CenterParent;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter the bracelet ID";

            tbHiredApp= new TextBox();
            tbHiredApp.Size = new System.Drawing.Size(size.Width - 10, 23);
            tbHiredApp.Location = new System.Drawing.Point(5, 5);
            tbHiredApp.Text = input;
            inputBox.Controls.Add(tbHiredApp);

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
            input = tbHiredApp.Text;
            return result;
        }

        private void btn_Finish_Hire_Click(object sender, EventArgs e)
        {
            if (listBox_Hire.Items.Count != 0)
            {
                listBox_Hire.Items.Clear();

                string braceletid = "";
                if (ShowInputDialog(ref braceletid) == DialogResult.OK)
                {

                    if (dh.InsertEquipmentinHiredDB(Order, braceletid) == true)
                    {
                        dh.UpdateEquipmentList(ListfromDB);
                        Order = new List<Equipment>();
                    }
                    AddToListBox();
                }
                else
                {
                    AddToListBox();
                }
            }
        }
        public void AddToListBox()
        {
            foreach (Equipment equip in Order)
            {
                listBox_Hire.Items.Add(equip.Name.PadRight(20 - equip.Name.Length) + "\tQuantity: " + equip.Quantity.ToString().PadRight(3) + "\tPer day: " + equip.Price * equip.Quantity + " \u20AC");
            }
        
        }

        private void btn_GetProd_Return_Click(object sender, EventArgs e)
        {
            ReturnList = new List<Equipment>();
            listBox_AllProducts_Return.Items.Clear();
            listBox_ToBe_Return.Items.Clear();
            string braceletid = tb_BraceletID_Return.Text;
            decimal total = 0;
            foreach (Equipment equip in dh.GetEquipmentForPersonDB(braceletid))
            {
                listBox_AllProducts_Return.Items.Add(equip.Name.PadRight(20 - equip.Name.Length) + "\tQuantity: " + equip.Quantity.ToString().PadRight(3) + "\t" + equip.Price + " \u20AC");
                total = total + equip.Price;
            }
            listBox_AllProducts_Return.Items.Add("*****************************************************************");
            listBox_AllProducts_Return.Items.Add("\t\t\tTOTAL: " + total + " \u20AC");
            PEquipList = dh.GetEquipmentForPersonDB(braceletid);
        }

        private void listBox_AllProducts_Return_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (PEquipList.Count != 0)
            {
                if (listBox_AllProducts_Return.SelectedItem != null)
                {

                    Equipment eq = PEquipList[listBox_AllProducts_Return.SelectedIndex];
                    ReturnList.Add(eq);
                    PEquipList.Remove(eq);
                }
                listBox_AllProducts_Return.Items.Clear();
                listBox_ToBe_Return.Items.Clear();
                decimal total1 = 0;
                decimal total2 = 0;
                foreach (Equipment eq1 in PEquipList)
                {
                    listBox_AllProducts_Return.Items.Add(eq1.Name.PadRight(20 - eq1.Name.Length) + "\tQuantity: " + eq1.Quantity.ToString().PadRight(3) + "\t" + eq1.Price + " \u20AC");
                    total1 = total1 + eq1.Price;
                }
                foreach (Equipment eq2 in ReturnList)
                {
                    listBox_ToBe_Return.Items.Add(eq2.Name.PadRight(20 - eq2.Name.Length) + "\tQuantity: " + eq2.Quantity.ToString().PadRight(3) + "\t" + eq2.Price + " \u20AC");
                    total2 = total2 + eq2.Price;
                }

                listBox_AllProducts_Return.Items.Add("*****************************************************************");
                listBox_AllProducts_Return.Items.Add("\t\t\tTOTAL: " + total1 + " \u20AC");
                listBox_ToBe_Return.Items.Add("*****************************************************************");
                listBox_ToBe_Return.Items.Add("\t\t\tTOTAL: " + total2 + " \u20AC");
            }
        }

        private void btn_Finish_Return_Click(object sender, EventArgs e)
        {
            if (listBox_ToBe_Return.Items.Count != 0)
            {
                decimal amount = 0;
                foreach (Equipment eq in ReturnList)
                {
                    amount += eq.Price;
                }

                if (dh.UpdateBraceletMoney(tb_BraceletID_Return.Text, amount) == true)
                {
                    dh.ReturnEquipmentDB(tb_BraceletID_Return.Text, ReturnList);
                    MessageBox.Show("Successful payment");
                    listBox_ToBe_Return.Items.Clear();
                    listBox_AllProducts_Return.Items.Clear();
                    foreach (Equipment eq in ReturnList)
                    {
                        foreach (Equipment eqr in ListfromDB)
                        {
                            if (eq.EquipmentID == eqr.EquipmentID)
                            {
                                eqr.IncreaseQuantity(eq.Quantity);

                            }

                        }
                    }
                    dh.UpdateEquipmentList(ListfromDB);
                    LabelUpdate();
                }
                else
                {
                    MessageBox.Show("Insufficient amount!");
                }
            }
        }

        private void LabelUpdate()
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            if (ListfromDB[0].Quantity == 0)
            {
                label1.ForeColor = Color.Red;
            }
            label1.Text = ListfromDB[0].Quantity.ToString();

            if (ListfromDB[5].Quantity == 0)
            {
                label2.ForeColor = Color.Red;
            }
            label2.Text = ListfromDB[5].Quantity.ToString();

            if (ListfromDB[4].Quantity == 0)
            {
                label3.ForeColor = Color.Red;
            }
            label3.Text = ListfromDB[4].Quantity.ToString();

            if (ListfromDB[1].Quantity == 0)
            {
                label6.ForeColor = Color.Red;
            }
            label6.Text = ListfromDB[1].Quantity.ToString();

            if (ListfromDB[2].Quantity == 0)
            {
                label5.ForeColor = Color.Red;
            }
            label5.Text = ListfromDB[2].Quantity.ToString();

            if (ListfromDB[3].Quantity == 0)
            {
                label8.ForeColor = Color.Red;
            }
            label8.Text = ListfromDB[3].Quantity.ToString();

            if (ListfromDB[6].Quantity == 0)
            {
                label9.ForeColor = Color.Red;
            }
            label9.Text = ListfromDB[6].Quantity.ToString();
        }

        private void hiredApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            rfidhiredApp.LED = false;
            rfidhiredApp.Antenna = false;
            rfidhiredApp.close();
        }

        private void btn_Clear_Hire_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_Hire.Items.Count; i++)
            {


                Equipment E = Order[i];


                foreach (Equipment eq in ListfromDB)
                {
                    if (eq.EquipmentID == E.EquipmentID)
                    {

                        eq.IncreaseQuantity(E.Quantity);

                    }

                }


            }
            Order = new List<Equipment>();
            listBox_Hire.Items.Clear();
            LabelUpdate();
        }
    }

}
