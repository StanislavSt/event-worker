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
    public partial class inspectionApp : Form
    {
        DataHelper dh;
        private List<Person> persons;

        public inspectionApp()
        {
            InitializeComponent();
            Inspection_Timer.Enabled = true;
            dh = new DataHelper();
            persons = dh.GetAllPeople();
            tb_PeopleRegistered.Text = dh.GetAllPeople().Count.ToString();
            tb_PeopleYetToEnter.Text = dh.NOTEnteredPeopleDB().ToString();
            tb_PeopleEntered.Text = dh.EnteredPeopleDB().ToString();
            tb_CheckOutPeople.Text = dh.CheckOutPeopleDB().ToString();
            tb_PeopleInsideATM.Text= dh.PeopleInsideATMDB().ToString();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            listBox_Search.Items.Clear();
            bool bfound = false;

            try
            {
                if (tb_LastName.Text != "" && tb_FirstName.Text != "")
                {
                    string fname = tb_FirstName.Text;
                    string lname = tb_LastName.Text;

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
        }

        private void btn_PeopleRegistered_Click(object sender, EventArgs e)
        {
            tb_PeopleRegistered.Text = dh.GetAllPeople().Count.ToString();
        }

        private void btn_PeopleEntered_Click(object sender, EventArgs e)
        {
            tb_PeopleEntered.Text = dh.EnteredPeopleDB().ToString();
        }

        private void btn_PeopleYetToEnter_Click(object sender, EventArgs e)
        {
            tb_PeopleYetToEnter.Text = dh.NOTEnteredPeopleDB().ToString();
            
        }

        private void btn_CheckOutPeople_Click(object sender, EventArgs e)
        {
            tb_CheckOutPeople.Text = dh.CheckOutPeopleDB().ToString();
        }

        private void btn_PeopleInsideATM_Click(object sender, EventArgs e)
        {
            tb_PeopleInsideATM.Text = dh.PeopleInsideATMDB().ToString();
        }

        private void Inspection_Timer_Tick(object sender, EventArgs e)
        {
            persons = dh.GetAllPeople();
            tb_PeopleRegistered.Text = dh.GetAllPeople().Count.ToString();
            tb_PeopleYetToEnter.Text = dh.NOTEnteredPeopleDB().ToString();
            tb_PeopleEntered.Text = dh.EnteredPeopleDB().ToString();
            tb_CheckOutPeople.Text = dh.CheckOutPeopleDB().ToString();
            tb_PeopleInsideATM.Text = dh.PeopleInsideATMDB().ToString();
        }
    }
}
