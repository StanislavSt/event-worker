using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventApp
{
    public partial class PayPalApp : Form
    {
        DataHelper dh;
        PayPal pp;

        public PayPalApp()
        {
            InitializeComponent();
            dh = new DataHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> bracelets = new List<string>();
            List<decimal> amounts = new List<decimal>();
            List<string> names = new List<string>();
            int bnr;
            int nrofppl;
            DateTime dtstart;
            DateTime dtend;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                pp = new PayPal(ofd.FileName);
                if (pp.AddDeposits(out bnr, out dtstart, out dtend, out nrofppl, ref amounts, ref bracelets))
                {
                    if (dh.AddMoneyToBracelet(bracelets, amounts))
                    {
                        foreach (string bracelet in bracelets)
                        {
                            names.Add(dh.GetNames(bracelet));
                        }
                        for (int i = 0; i < bracelets.Count; i++)
                        {
                            listBox1.Items.Add("Name: " + names[i].PadRight(28 - names[i].Length) + "\tBracelet ID: " + bracelets[i].PadRight(26 - bracelets[i].Length) + "\tAmount deposited: " + amounts[i] + " \u20AC");
                        }
                        textBox1.Text = nrofppl.ToString();
                        textBox2.Text = dtstart.ToString();
                        textBox3.Text = dtend.ToString();
                        label4.ForeColor = Color.Green;
                        label4.Text = "Transactions were made successfully!";

                    }
                    else
                    {
                        label4.ForeColor = Color.Red;
                        label4.Text = "Please try again!";
                    }
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "Please try again!";
                }
            }
            else
            {
                label4.Text = "";
            }
        }
    }
}
