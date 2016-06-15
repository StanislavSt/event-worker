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
    public partial class shopApp : Form
    {
        private TextBox tbShopApp;
        private RFID rfidshopApp;
        DataHelper dh;
        List<Product> listOfProducts;
        List<Product> BoughtProducts;

        public shopApp()
        {
            InitializeComponent();
            dh = new DataHelper();
            listOfProducts = dh.GetAllProductsDB();
            BoughtProducts = new List<Product>();
            rfidshopApp = new RFID();
            rfidshopApp.open();
            rfidshopApp.Attach += myRFID_AttachshopApp;
            rfidshopApp.Tag += GetBraceletIDshopApp;
            UpdateList();
            
        }
        private void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Product prod in listOfProducts)
            {
                listBox1.Items.Add(prod.Name.PadRight(20 - prod.Name.Length) + "\tQuantity: " + prod.Quantity.ToString().PadRight(2) + "\tPrice: " + prod.Price + " \u20AC");

            } 
        }

        private void myRFID_AttachshopApp(object sender, AttachEventArgs e)
        {
            ((RFID)sender).waitForAttachment(3000);
            ((RFID)sender).LED = true;
            ((RFID)sender).Antenna = true;

        }

        private void GetBraceletIDshopApp(object sender, TagEventArgs e)
        {
            if (tbShopApp != null)
            {
                tbShopApp.Text = e.Tag;
            }
        }



        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            listBox_Products.Items.Clear();
            try
            {   
                int productid = Convert.ToInt32(tb_ProductID.Text);
                int quantity = Convert.ToInt32(numericUpDown_Quantity.Value);
                numericUpDown_Quantity.Value = 1;
                Product pr = listOfProducts[GetProduct(listOfProducts, productid,
                    listOfProducts.IndexOf(listOfProducts.First()), listOfProducts.IndexOf(listOfProducts.Last()))];


                if (quantity > pr.Quantity)
                {
                    MessageBox.Show("There are only " + pr.Quantity + " in stock.");
                }

                else
                {
                    bool found = false;
                    Product prtoadd = new Product(pr.ProductID, pr.Name, quantity, pr.Price);
                    foreach (Product p in BoughtProducts)
                    {
                        if (prtoadd.ProductID == p.ProductID)
                        {
                            p.IncreaseQuantity(quantity);
                            found = true;
                            pr.DecreaseQuantity(quantity);
                        }

                    }
                    if (!found)
                    {
                        BoughtProducts.Add(prtoadd);
                        pr.DecreaseQuantity(quantity);
                    }

                }
                foreach (Product p in BoughtProducts)
                {
                    listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                foreach (Product p in BoughtProducts)
                {
                    listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");

                }
            }
            UpdateList();
        }

        public static int GetProduct(List<Product> listpr, int searchvalue, int min, int max)
        {

            if (min > max)
            {
                return -1;
            }
            else
            {
                int mid = (min + max) / 2;
                if (searchvalue == listpr[mid].ProductID)
                {
                    return mid;
                }
                else if (searchvalue < listpr[mid].ProductID)
                {
                    return GetProduct(listpr, searchvalue, min, mid - 1);
                }
                else
                {
                    return GetProduct(listpr, searchvalue, mid + 1, max);
                }
            }
        }

        private void listBox_Products_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_Products.SelectedItem != null)
            {
                Product P = BoughtProducts[listBox_Products.SelectedIndex];
                foreach (Product Pr in listOfProducts)
                {
                    if (Pr.ProductID == P.ProductID)
                    {
                        Pr.IncreaseQuantity(P.Quantity);
                    }
                }
                listBox_Products.Items.Remove(listBox_Products.SelectedItem);
                BoughtProducts.Remove(P);
            }
        }

        private void btn_Finnish_Click(object sender, EventArgs e)
        {

            if (listBox_Products.Items.Count != 0)
            {
                listBox_Products.Items.Clear();
                decimal amount = 0;
                foreach (Product P in BoughtProducts)
                {
                    amount = amount + P.Price * P.Quantity;
                }
                string braceletid = "";
                if (ShowInputDialog(ref braceletid) == DialogResult.OK)
                {
                    if (dh.UpdateBraceletMoney(braceletid, amount))
                    {
                        if (dh.InsertProductsinPurchasedDB(BoughtProducts, braceletid) == true)
                        {
                            dh.UpdateProductList(listOfProducts);
                            BoughtProducts = new List<Product>();
                            MessageBox.Show("Payment was successful!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not enough money!Please refill!");
                        listBox_Products.Items.Clear();
                        foreach (Product p in BoughtProducts)
                        {
                            listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");
                        }
                    }
                }
                else
                {
                    foreach (Product p in BoughtProducts)
                    {
                        listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");

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

            tbShopApp = new TextBox();
            tbShopApp.Size = new System.Drawing.Size(size.Width - 10, 23);
            tbShopApp.Location = new System.Drawing.Point(5, 5);
            tbShopApp.Text = input;
            inputBox.Controls.Add(tbShopApp);

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
            input = tbShopApp.Text;
            return result;
        }

        private void shopApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rfidshopApp.Attached == true)
            {
                rfidshopApp.LED = false;
                rfidshopApp.Antenna = false;
                rfidshopApp.close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_Products.Items.Count; i++)
			{
                Product P = BoughtProducts[i];
                foreach (Product Pr in listOfProducts)
                {
                    if (Pr.ProductID == P.ProductID)
                    {
                        Pr.IncreaseQuantity(P.Quantity);
                    }
                }
            }
            BoughtProducts = new List<Product>();
            listBox_Products.Items.Clear();
            UpdateList();
        }

        private void btn_RemoveProd_shop_Click(object sender, EventArgs e)
        {
            if (listBox_Products.SelectedItem != null)
            {
                Product P = BoughtProducts[listBox_Products.SelectedIndex];
                foreach (Product Pr in listOfProducts)
                {
                    if (Pr.ProductID == P.ProductID)
                    {
                        Pr.IncreaseQuantity(P.Quantity);
                    }
                }
                listBox_Products.Items.Remove(listBox_Products.SelectedItem);
                BoughtProducts.Remove(P);
            }
            UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox_Products.Items.Clear();
            int index = 0;
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    int quantity = Convert.ToInt32(numericUpDown_Quantity.Value);
                    numericUpDown_Quantity.Value = 1;
                    index = listBox1.SelectedIndex;
                    Product pr = listOfProducts[index];
                    if (quantity > pr.Quantity)
                    {
                        MessageBox.Show("There are  " + pr.Quantity + " left in stock!");
                    }
                    else
                    {
                        bool found = false;
                        Product prtoadd = new Product(pr.ProductID, pr.Name, quantity, pr.Price);
                        foreach (Product p in BoughtProducts)
                        {
                            if (prtoadd.ProductID == p.ProductID)
                            {
                                p.IncreaseQuantity(quantity);
                                found = true;
                                pr.DecreaseQuantity(quantity);
                            }
                        }
                        if (!found)
                        {
                            BoughtProducts.Add(prtoadd);
                            pr.DecreaseQuantity(quantity);
                        }
                    }
                    foreach (Product p in BoughtProducts)
                    {
                        listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");
                    }               
                }
                else
                {
                    foreach (Product p in BoughtProducts)
                    {
                        listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                foreach (Product p in BoughtProducts)
                {
                    listBox_Products.Items.Add(p.Name.PadRight(20 - p.Name.Length) + "\tQuantity: " + p.Quantity.ToString().PadRight(2) + "\tPrice: " + p.Price * p.Quantity + " \u20AC");
                }
            }
            UpdateList();
            listBox1.SelectedIndex = index;
        }
    }
}
