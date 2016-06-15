using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EventApp
{
    class Person
    {
        public int TicketID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfRegistration { get; private set; }
        public DateTime CheckOutDateTime { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CheckInDateTime { get; private set; }
        public string BraceletID { get; private set; }
        public string Email { get; private set; }

        public Person(int ticket, string fname, string lname, DateTime dob, string email,DateTime dt)
        {
            TicketID = ticket;
            FirstName = fname;
            LastName = lname;
            DateOfRegistration = dt;
            DateOfBirth = dob;
            Email = email;
        }

        public void SetBraceletID(string bracelet)
        { BraceletID = bracelet; }

        public void SetCheckOutDateTime(DateTime dt)
        { CheckOutDateTime = dt; }

        public void SetCheckInDateTime(DateTime ck)
        { CheckInDateTime = ck; }

        public List<string> ListOfString()
        {
            string checkin = "";
            string checkout = "";
            string status = "";
            DateTime checkoutcheck = new DateTime(0001, 01, 01, 00, 00, 00);
            DateTime checkincheck = new DateTime(0001, 01, 01, 00, 00, 00);
            List<string> temp = new List<string>();
            if (CheckInDateTime == checkincheck && CheckOutDateTime == checkoutcheck)
            {
                checkin = "...";
                checkout = "...";
                status = "HAS NOT ENTERED THE EVENT";
            
            
            }
            else if (CheckOutDateTime == checkoutcheck && CheckInDateTime != checkincheck)
            {
                checkout = "HAS NOT LEFT THE EVENT YET";
                checkin = CheckInDateTime.ToString();
                status = "INSIDE THE EVENT";
            
            
            
            }
            else if (CheckInDateTime > CheckOutDateTime)
            {

                checkout = CheckOutDateTime.ToString();
                checkin = CheckInDateTime.ToString();
                status = "INSIDE THE EVENT";
            }
            else if (CheckOutDateTime > CheckInDateTime)
            {

                checkout = CheckOutDateTime.ToString();
                checkin = CheckInDateTime.ToString();
                status = "HAS LEFT THE EVENT";
            
            }
          
            temp.Add("Ticket ID: " + this.TicketID);
            temp.Add("Name: " + this.FirstName + " " + this.LastName);
            temp.Add("Date of registration: " + this.DateOfRegistration.ToString("D"));
            temp.Add("Date of birth: " + this.DateOfBirth.ToString("D"));
            temp.Add("Bracelet ID: " + this.BraceletID);
            temp.Add("Email: " + this.Email);
            temp.Add("Last checkin: " + checkin);
            temp.Add("Last checkout: " + checkout);
            temp.Add("Status: " + status);

            return temp;
        }

        public List<String> ListOfStringDataGrid()
        {
            string checkin;
            string checkout;
            DateTime checkoutcheck = new DateTime(0001, 01, 01, 00, 00, 00);
            DateTime checkincheck = new DateTime(0001, 01, 01, 00, 00, 00);
            List<string> temp = new List<string>();

            if (CheckInDateTime == checkincheck)
            {
                checkin = "Has not entered yet!";
            }

            else
            {
                checkin = CheckInDateTime.ToString();
            }

            if (CheckOutDateTime == checkoutcheck)
            {
                checkout = "Has not left the event yet!";
            }

            else
            {
                checkout = CheckOutDateTime.ToString();
            }

            temp.Add(checkin);
            temp.Add(checkout);

            return temp;
        }

        public override string ToString()
        {
            return "Ticket ID: " + this.TicketID + " -\t"+ this.FirstName + " " + this.LastName;
        }
    }
}
