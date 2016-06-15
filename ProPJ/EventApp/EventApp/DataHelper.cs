using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MySql.Data;


namespace EventApp
{
    class DataHelper
    {

        public MySqlConnection connection;


        string connnectionstring = "Server=athena01.fhict.local;Database=dbi315379;Uid=dbi315379;Pwd=etV9hbpQZM;connect timeout=30;";

        public DataHelper()
        {


            connection = new MySqlConnection(connnectionstring);


        }

        public List<Person> GetAllPeople()
        {
            string sql = "SELECT * FROM person";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<Person> temp = new List<Person>();
            MySqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                Person P;
                string fname;
                string lname;
                int ticketid;
                DateTime dateofreg;
                DateTime dob;
                DateTime checkout;
                DateTime checkin;
                string braceletid;
                string email;


                while (reader.Read())
                {

                    fname = Convert.ToString(reader["First_name"]);
                    lname = Convert.ToString(reader["Last_name"]);
                    ticketid = Convert.ToInt32(reader["Ticket_ID"]);
                    dateofreg = Convert.ToDateTime(reader["DateOfRegistration"]);
                    dob = Convert.ToDateTime(reader["DateOfBirth"]);
                    email = Convert.ToString(reader["Email"]);


                    P = new Person(ticketid, fname, lname, dob, email, dateofreg);
                    if (reader["Bracelet_ID"].ToString() != "")
                    {
                        braceletid = Convert.ToString(reader["Bracelet_ID"]);
                        P.SetBraceletID(braceletid);
                    }

                    if (reader["CheckOutDateTime"].ToString() != "0001-01-01 00:00:00")
                    {
                        checkout = Convert.ToDateTime(reader["CheckOutDateTime"]);
                        P.SetCheckOutDateTime(checkout);
                    }
                    if (reader["CheckInDateTime"].ToString() != "0001-01-01 00:00:00")
                    {
                        checkin = Convert.ToDateTime(reader["CheckInDateTime"]);
                        P.SetCheckInDateTime(checkin);
                    }
                    temp.Add(P);
                }
            }

            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong!");
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return temp;
        }

        public bool AddAPersontoDB(Person p)
        {
            try
            {

                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "INSERT INTO `dbi315379`.`person` (`First_Name`, `Last_Name`, `DateOfRegistration`, `CheckOutDateTime`, `CheckInDateTime`, `DateOfBirth`, `Bracelet_ID`, `Email`)" +
                    "VALUES(@fname,@lname,@dateofreg,@checkoutdate,@checkindate,@dob,@braceletid,@email)";
                command.Parameters.AddWithValue("@fname", p.FirstName);
                command.Parameters.AddWithValue("@lname", p.LastName);
                command.Parameters.AddWithValue("@dateofreg", p.DateOfRegistration);
                command.Parameters.AddWithValue("@checkoutdate", p.CheckOutDateTime);
                command.Parameters.AddWithValue("@checkindate", p.CheckInDateTime);
                command.Parameters.AddWithValue("@dob", p.DateOfBirth.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@braceletid", p.BraceletID);
                command.Parameters.AddWithValue("@email", p.Email);
                command.Connection = connection;



                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException m)
            {
                MessageBox.Show(m.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return false;
        }

        public int GetLastIDfromDB()
        {
            try
            {

                connection.Open();

                string mysql = "SELECT MAX(Ticket_ID) FROM person";
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.ExecuteNonQuery();
                int lastid = Convert.ToInt32(command.ExecuteScalar());
                lastid++;
                return lastid;

            }
            catch (MySqlException m)
            {
                MessageBox.Show(m.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return -1;
        }






        public bool SetBraceletIDForPerson(Person P, string bracelet)
        {
            try
            {
                connection.Open();
                string mysql = "UPDATE `dbi315379`.`person` SET `Bracelet_ID` =" + "'" + bracelet + "'" + "WHERE `person`.`Ticket_ID` =" + P.TicketID;
                MySqlCommand command = new MySqlCommand(mysql, connection);

                command.ExecuteScalar();
                return true;
            }

            catch (MySqlException m)
            {
                MessageBox.Show(m.Message);
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return false;
        }

        public bool SetCheckOutForDB(Person P)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string thedate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                connection.Open();
                string mysql = "UPDATE `dbi315379`.`person` SET `CheckOutDateTime` =" + "'" + thedate + "'" + "WHERE `person`.`Ticket_ID` =" + P.TicketID;
                MySqlCommand command = new MySqlCommand(mysql, connection);

                command.ExecuteScalar();
                return true;
            }

            catch (MySqlException m)
            {
                MessageBox.Show(m.Message);
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return false;
        }

        public bool SetCheckInForDB(Person P)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string thedate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                connection.Open();
                string mysql = "UPDATE `dbi315379`.`person` SET `CheckInDateTime` =" + "'" + thedate + "'" + "WHERE `person`.`Ticket_ID` =" + P.TicketID;
                MySqlCommand command = new MySqlCommand(mysql, connection);

                command.ExecuteScalar();
                return true;
            }

            catch (MySqlException m)
            {
                MessageBox.Show(m.Message);
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return false;
        }


        public int EnteredPeopleDB()
        {
            string stmt = "SELECT COUNT(*) FROM dbi315379.person WHERE Bracelet_ID IS NOT NULL";
            int count = 0;
            try
            {
                using (MySqlConnection thisConnection = new MySqlConnection(connnectionstring))
                {
                    using (MySqlCommand cmdCount = new MySqlCommand(stmt, thisConnection))
                    {
                        thisConnection.Open();
                        count = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }
                }
                return count;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
            finally
            {
                if (connection != null)
                {

                    connection.Close();
                }

            }
            return -1;
        }

        public int PeopleInsideATMDB()
        {

            string stmt = "SELECT COUNT(*) FROM dbi315379.person WHERE Bracelet_ID IS NOT NULL AND CheckOutDateTime <CheckInDateTime";
            int count = 0;
            try
            {
                using (MySqlConnection thisConnection = new MySqlConnection(connnectionstring))
                {
                    using (MySqlCommand cmdCount = new MySqlCommand(stmt, thisConnection))
                    {
                        thisConnection.Open();
                        count = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }
                }
                return count;

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
            finally
            {
                if (connection != null)
                {

                    connection.Close();

                }

            }
            return -1;
        }





        public int NOTEnteredPeopleDB()
        {
            string stmt = "SELECT COUNT(*) FROM dbi315379.person WHERE Bracelet_ID IS NULL";
            int count = 0;
            try
            {

                using (MySqlConnection thisConnection = new MySqlConnection(connnectionstring))
                {
                    using (MySqlCommand cmdCount = new MySqlCommand(stmt, thisConnection))
                    {
                        thisConnection.Open();
                        count = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }
                }
                return count;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
            finally
            {
                if (connection != null)
                {

                    connection.Close();
                }

            }
            return -1;
        }

        public int CheckOutPeopleDB()
        {
            string stmt = "SELECT COUNT(*) FROM dbi315379.person WHERE CheckOutDateTime > CheckInDateTime";
            int count = 0;
            try
            {
                using (MySqlConnection thisConnection = new MySqlConnection(connnectionstring))
                {
                    using (MySqlCommand cmdCount = new MySqlCommand(stmt, thisConnection))
                    {
                        thisConnection.Open();
                        count = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }
                    return count;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
            finally
            {
                if (connection != null)
                {

                    connection.Close();
                }

            }
            return -1;

        }

        public List<Equipment> GetEquipmentFromDB()
        {
            string sql = "SELECT * FROM equipment";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<Equipment> temp = new List<Equipment>();
            MySqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                Equipment e = null;
                int eqid;
                string name;
                int quantity;
                decimal price;


                while (reader.Read())
                {

                    eqid = Convert.ToInt32(reader["Equipment_ID"]);
                    name = Convert.ToString(reader["Name"]);
                    quantity = Convert.ToInt32(reader["Quantity"]);
                    price = Convert.ToDecimal(reader["Price"]);


                    e = new Equipment(eqid, name, quantity, price);

                    temp.Add(e);
                }
            }

            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong!");
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return temp;
        }

        public Product GetProductFromDB(int pr)
        {
            Product Pr = null;
            int productid;
            string name;
            int quantity;
            decimal price;
            MySqlDataReader reader = null;

            try
            {
                string mysql = "SELECT * FROM dbi315379.products WHERE Product_ID =@ProductID";
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("ProductID", pr);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productid = Convert.ToInt32(reader["Product_ID"]);
                    name = Convert.ToString(reader["Name"]);
                    quantity = Convert.ToInt32(reader["Quantity"]);
                    price = Convert.ToDecimal(reader["Price"]);
                    Pr = new Product(productid, name, quantity, price);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return Pr;
        }

        public List<Product> GetAllProductsDB()
        {
            MySqlConnection connectionnew = new MySqlConnection(connnectionstring);
            string sql = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(sql, connectionnew);
            List<Product> pr = new List<Product>();
            Product P = null;
            MySqlDataReader reader = null;

            try
            {
                connectionnew.Open();
                reader = command.ExecuteReader();

                int productid;
                string name;
                int quantity;
                decimal price;


                while (reader.Read())
                {

                    productid = Convert.ToInt32(reader["Product_ID"]);
                    name = Convert.ToString(reader["Name"]);
                    quantity = Convert.ToInt32(reader["Quantity"]);
                    price = Convert.ToDecimal(reader["Price"]);


                    P = new Product(productid, name, quantity, price);

                    pr.Add(P);
                }
            }

            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong!");
            }

            finally
            {
                if (connectionnew != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return pr;
        }
        public void UpdateProductList(List<Product> products)
        {
            try
            {
                connection.Open();
                foreach (Product p in products)
                {
                    string sql = "UPDATE `dbi315379`.`products` SET `Quantity` = @quantity WHERE `products`.`Product_ID` = @productid;";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@quantity", p.Quantity);
                    command.Parameters.AddWithValue("@productid", p.ProductID);
                    command.ExecuteScalar();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong!");
            }
            finally
            {

                if (connection != null)
                {
                    connection.Close();

                }

            }
        }


        public bool InsertProductsinPurchasedDB(List<Product> products, string braceletid)
        {
            try
            {
                connection.Open();
                foreach (Product P in products)
                {
                    string mysql = "INSERT INTO `dbi315379`.`bought_products` (`Bracelet_ID`, `Product_ID`, `DateTimePurchase`, `QuantityBought`, `TotalPrice`) VALUES (@braceletid,@productid, @dtpurchased, @quantity, @price);";
                    MySqlCommand command = new MySqlCommand(mysql, connection);
                    command.Parameters.AddWithValue("@braceletid", braceletid);
                    command.Parameters.AddWithValue("@productid", P.ProductID);
                    command.Parameters.AddWithValue("dtpurchased", DateTime.Now);
                    command.Parameters.AddWithValue("@quantity", P.Quantity);
                    command.Parameters.AddWithValue("@price", P.Quantity * P.Price);
                    command.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false;

        }


        public bool UpdateBraceletMoney(string braceletid, decimal amount)
        {
            MySqlConnection connectionnew = new MySqlConnection(connnectionstring);
            decimal amountinbracelet = 0;
            MySqlDataReader reader = null;
            string mysqlread = "SELECT * FROM `bracelet` WHERE `Bracelet_ID` = @braceletid";
            try
            {
                connectionnew.Open();
                MySqlCommand command = new MySqlCommand(mysqlread, connectionnew);
                command.Parameters.AddWithValue("@braceletid", braceletid);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    amountinbracelet = Convert.ToDecimal(reader["AmountOfMoney"]);


                }
                reader.Close();

                if (amount > amountinbracelet)
                {
                    return false;
                }
                else
                {
                    string mysqlupdate = "UPDATE `dbi315379`.`bracelet` SET `AmountOfMoney` =@amount WHERE `bracelet`.`Bracelet_ID` =@braceletid;";
                    MySqlCommand updatecommand = new MySqlCommand(mysqlupdate, connectionnew);
                    decimal amountleft = amountinbracelet - amount;
                    updatecommand.Parameters.AddWithValue("@amount", amountleft);
                    updatecommand.Parameters.AddWithValue("@braceletid", braceletid);
                    updatecommand.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connectionnew != null)
                {

                    connectionnew.Close();
                }
                if (reader != null)
                {

                    reader.Close();
                }
            }
            return false;
        }

        public void ReturnEquipmentDB(string braceletid, List<Equipment> equipment)
        {
            MySqlConnection connectionnew = new MySqlConnection(connnectionstring);
            string mysql = "UPDATE `dbi315379`.`equipment_hired` SET `DateTimeOfReturn` = @DTOfReturn WHERE `equipment_hired`.`Bracelet_ID` = @BraceletID AND `equipment_hired`.`Equipment_ID` = @EquipmentID AND `equipment_hired`.`DateTimeOfHire`=@dtofhire";
            try
            {
                connectionnew.Open();
                foreach (Equipment eq in equipment)
                {
                    MySqlCommand command = new MySqlCommand(mysql, connectionnew);
                    command.Parameters.AddWithValue("@BraceletID", braceletid);
                    command.Parameters.AddWithValue("@EquipmentID", eq.EquipmentID);
                    command.Parameters.AddWithValue("@DTOfReturn", DateTime.Now);
                    command.Parameters.AddWithValue("@dtofhire", eq.DateHired);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connectionnew != null)
                {

                    connectionnew.Close();
                }


            }
        }

        public bool InsertBraceletID(string br)
        {
            string sql = "INSERT INTO `dbi315379`.`bracelet` (`Bracelet_ID`, `AmountOfMoney`, `ReplacedBy`) VALUES (@BraceletID, 0, NULL)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@BraceletID", br);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false;
        }
        public void UpdateEquipmentList(List<Equipment> equipments)
        {
            try
            {
                connection.Open();
                foreach (Equipment e in equipments)
                {
                    string sql = "UPDATE `dbi315379`.`equipment` SET `Quantity` = @quantity WHERE `equipment`.`Equipment_ID` = @equipmentid;";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@quantity", e.Quantity);
                    command.Parameters.AddWithValue("@equipmentid", e.EquipmentID);
                    command.ExecuteScalar();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong!");
            }
            finally
            {

                if (connection != null)
                {
                    connection.Close();

                }

            }
        }
        public bool InsertEquipmentinHiredDB(List<Equipment> equpments, string braceletid)
        {
            DateTime dtofreturn = new DateTime(0001, 01, 01, 00, 00, 00);
            try
            {
                connection.Open();
                foreach (Equipment e in equpments)
                {
                    string mysql = "INSERT INTO `dbi315379`.`equipment_hired` (`Bracelet_ID`, `Equipment_ID`, `Quantity`, `DateTimeOfHire`, `DateTimeOfReturn`, `TotalPrice`) VALUES (@braceletid, @equipmentid, @quantity, @dtofhire, @dtofreturn, @totalprice);";
                    MySqlCommand command = new MySqlCommand(mysql, connection);
                    command.Parameters.AddWithValue("@braceletid", braceletid);
                    command.Parameters.AddWithValue("@equipmentid", e.EquipmentID);
                    command.Parameters.AddWithValue("@quantity", e.Quantity);
                    command.Parameters.AddWithValue("@dtofhire", DateTime.Now);
                    command.Parameters.AddWithValue("@dtofreturn", dtofreturn);
                    command.Parameters.AddWithValue("@totalprice", e.Price * e.Quantity);
                    command.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false;
        }

        public List<Equipment> GetEquipmentForPersonDB(string braceletid)
        {
            string sql = "SELECT * FROM `equipment_hired` join `equipment` ON `equipment_hired`.`Equipment_ID`=`equipment`.`Equipment_ID` WHERE `equipment_hired`.`Bracelet_ID` =@braceletid AND `equipment_hired`.`DateTimeOfReturn` = '0001-01-01 00:00:00'";


            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@braceletid", braceletid);
            List<Equipment> temp = new List<Equipment>();
            MySqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                Equipment e = null;
                int eqid;
                string name;
                int quantity;
                decimal price;
                DateTime dtofhire;


                while (reader.Read())
                {

                    eqid = Convert.ToInt32(reader["Equipment_ID"]);
                    name = Convert.ToString(reader["Name"]);
                    quantity = Convert.ToInt32(reader["Quantity"]);
                    price = Convert.ToDecimal(reader["TotalPrice"]);
                    dtofhire = Convert.ToDateTime(reader["DateTimeOfHire"]);


                    int days = ((int)(DateTime.Now.Date - dtofhire.Date).TotalDays) + 1;


                    e = new Equipment(eqid, name, quantity, price * days);
                    e.SetDateTimeHired(dtofhire);
                    temp.Add(e);
                }

            }
            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong!");
            }
            finally
            {
                if (reader != null)
                {

                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }



            }
            return temp;
        }
        public bool AddMoneyToBracelet(List<string> bracelets, List<decimal> amounts)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE `dbi315379`.`bracelet` SET `AmountOfMoney` = AmountOfMoney + @amount  WHERE `bracelet`.`Bracelet_ID` = @braceletid;";
                for (int i = 0; i < bracelets.Count; i++)
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@amount", amounts[i]);
                    command.Parameters.AddWithValue("@braceletid", bracelets[i]);
                    command.ExecuteScalar();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false;
        }

        public bool SelectUserLoginDB(string uname, string pass, ref string eapp, ref string happ, ref string sapp, ref string iapp, ref string papp, ref string capp, ref string tapp)
        {
            string mysql = " SELECT COUNT(*) FROM `loginprop` WHERE `UserName` = @username AND `UserPassword` = @password";
            string mysqlgetdata = " SELECT * FROM `loginprop` WHERE `UserName` = @username AND `UserPassword` = @password";
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                MySqlCommand getdata = new MySqlCommand(mysqlgetdata, connection);
                command.Parameters.AddWithValue("@username", uname);
                command.Parameters.AddWithValue("@password", pass);
                int nrofrows = Convert.ToInt32(command.ExecuteScalar());
                if (nrofrows != 0)
                {
                    getdata.Parameters.AddWithValue("@username", uname);
                    getdata.Parameters.AddWithValue("@password", pass);
                    reader = getdata.ExecuteReader();
                    while (reader.Read())
                    {
                        eapp = reader["EntranceApp"].ToString();
                        sapp = reader["ShopApp"].ToString();
                        happ = reader["EquipmentApp"].ToString();
                        iapp = reader["InspectionApp"].ToString();
                        capp = reader["CheckInOutApp"].ToString();
                        papp = reader["PayPalApp"].ToString();
                        tapp = reader["TentApp"].ToString();

                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }

            }
            return false;
        }
        public int RegisterUserDB(string uname, string pass, string eapp, string happ, string iapp, string capp, string tapp, string papp, string sapp)
        {
            MySqlCommand command = null;
            MySqlCommand checkcommand = null;
            string mysqlcheck = "SELECT COUNT(*) FROM loginprop WHERE UserName=@username";
            string insertmysql = "INSERT INTO `dbi315379`.`loginprop` (`UserName`, `UserPassword`, `EntranceApp`, `InspectionApp`, `EquipmentApp`, `ShopApp`, `TentApp`, `CheckInOutApp`, `PayPalApp`) VALUES (@username,@password,@eapp,@iapp,@happ,@sapp,@tapp,@capp,@papp);";
            try
            {
                connection.Open();
                checkcommand = new MySqlCommand(mysqlcheck, connection);
                checkcommand.Parameters.AddWithValue("@username", uname);
                int nrofrows = Convert.ToInt32(checkcommand.ExecuteScalar());
                if (nrofrows == 0)
                {
                    command = new MySqlCommand(insertmysql, connection);
                    command.Parameters.AddWithValue("@username", uname);
                    command.Parameters.AddWithValue("@password", pass);
                    command.Parameters.AddWithValue("@eapp", eapp);
                    command.Parameters.AddWithValue("@iapp", iapp);
                    command.Parameters.AddWithValue("@happ", happ);
                    command.Parameters.AddWithValue("@sapp", sapp);
                    command.Parameters.AddWithValue("@tapp", tapp);
                    command.Parameters.AddWithValue("@capp", capp);
                    command.Parameters.AddWithValue("@papp", papp);
                    command.ExecuteNonQuery();
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception)
            { }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return 3;
        }

        public string GetNames(string braceletid)
        {
            string fullname = "";
            MySqlDataReader reader = null;
            string mysql = "SELECT First_Name,Last_Name FROM person JOIN bracelet on person.Bracelet_ID=bracelet.Bracelet_ID WHERE bracelet.Bracelet_ID=@braceletid";
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@braceletid", braceletid);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string fname = reader["First_Name"].ToString();
                    string lname = reader["Last_Name"].ToString();
                    fullname = fname + " " + lname;
                }
                return fullname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return "";
        }
        public List<int> ListofTentAreas()
        {
            List<int> templist = new List<int>();
            string mysql = "SELECT DISTINCT TentArea from tent WHERE Booked='no'";
            MySqlCommand command = new MySqlCommand(mysql, connection);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    templist.Add(Convert.ToInt32(reader["TentArea"]));
                }
                return templist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return null;
        }
        public bool GetEmails(string email)
        {


            string mysql = "SELECT * FROM person  WHERE Email=@email";
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@email", email);
                int nrofrows = Convert.ToInt32(command.ExecuteScalar());
                if (nrofrows == 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false;
        }
        public bool InsertPeopleInTentsDB(List<string> emails,int tentid,int nrppl)
        {
            string mysql = "INSERT INTO `dbi315379`.`persons_in_tents` (`Tent_ID`, `Email`, `NrOfPlacesBooked`, `Price`, `Paid`) VALUES (@tentid,@email,@nrofppl,@price,@paid);";
            try
            {
                connection.Open();
                foreach (string email in emails)
                {
                    MySqlCommand command = new MySqlCommand(mysql, connection);
                    command.Parameters.AddWithValue("@tentid", tentid);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@nrofppl", nrppl);
                    command.Parameters.AddWithValue("@price", 30 + ((nrppl - 1) * 20));
                    command.Parameters.AddWithValue("@paid", "yes");
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            
            }
            return false;
        }
        public int GetTentIdDB(int tentarea)
        {
            int tentid = 0;
            MySqlDataReader reader = null;
            string mysql = "SELECT * FROM Tent WHERE TentArea=@tentid LIMIT 1";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@tentid", tentarea);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tentid = Convert.ToInt32(reader["Tent_ID"]);
                }
                return tentid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return -1;
        }
        public bool UpdateTentDB(int tentid)
        {
            string mysql = "UPDATE `dbi315379`.`tent` SET `Booked` = 'yes' WHERE `tent`.`Tent_ID` =@tentid;";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@tentid", tentid);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false;
        }

        public int GetTentIDForBracelet(string braceletid,ref decimal amount)
        {
            int tentid = -1;
            MySqlDataReader reader = null;
            string mysql = "SELECT pt.tent_id AS TENTID,pt.price as PRICE FROM person p join persons_in_tents pt on p.email=pt.email join bracelet b on p.bracelet_id=b.bracelet_id where b.bracelet_id=@braceletid";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@braceletid", braceletid);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tentid = Convert.ToInt32(reader["TENTID"]);
                    amount = Convert.ToDecimal(reader["PRICE"]);
                }
                return tentid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return tentid;        
        }
        public bool UpdateTentsDB(int tentid)
        {

            string mysql = "UPDATE `dbi315379`.`persons_in_tents` SET `Paid` = 'yes' WHERE `persons_in_tents`.`Tent_ID` =@tentid;";
            try
            {

                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@tentid", tentid);
                command.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return false; 
        }
        public List<string> CheckTentsforEmail(string email,ref List<string> fullnamelist,ref string paid,ref decimal price,ref int tentid)
        {
            List<string> emails = new List<string>();
            MySqlDataReader reader = null;
            string mysql = "SELECT Tent_ID from persons_in_tents WHERE Email=@email";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@email", email);
                if (command.ExecuteScalar() != null)
                {
                    tentid = (int)command.ExecuteScalar();
                }
                string mysqlgetppl = "SELECT pt.price as PRICE,pt.paid as PAID, p.First_name AS FNAME,p.Last_Name AS LNAME,p.email as EMAIL FROM persons_in_tents pt join person p on pt.email=p.email WHERE pt.tent_id=@tentid";
                MySqlCommand emailcommand = new MySqlCommand(mysqlgetppl, connection);
                emailcommand.Parameters.AddWithValue("@tentid", tentid);
                reader = emailcommand.ExecuteReader();
                while (reader.Read())
                {
                    string fname = Convert.ToString(reader["FNAME"]);
                    string lname = Convert.ToString(reader["LNAME"]);
                    string fullname = fname + " " + lname;
                    fullnamelist.Add(fullname);
                    string emailtoadd = Convert.ToString(reader["EMAIL"]);
                    emails.Add(emailtoadd);
                    paid = Convert.ToString(reader["PAID"]);
                    price = Convert.ToDecimal(reader["PRICE"]);
                }
                return emails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return emails;
        
        
        
        
        }
    }
}   


