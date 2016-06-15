using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EventApp
{
    class PayPal
    {
        public string FilePath { get; private set; }

        public PayPal(string fp)
        {

            FilePath = fp;
        }

        public bool AddDeposits(out int banknr, out DateTime dtstart, out DateTime dtend,out int nrpfppl,
            ref List<decimal> amountlist, ref List<string> braceletids)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                banknr = Convert.ToInt32(sr.ReadLine());
                string dtstarts = sr.ReadLine();
                dtstart = DateTime.ParseExact(dtstarts, "yyyy/MM/dd/HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                string dtends = sr.ReadLine();
                dtend = DateTime.ParseExact(dtends, "yyyy/MM/dd/HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                int count = Convert.ToInt32(sr.ReadLine());
                int counter = 0;
                while (counter < count)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    string braceletid = line[0];
                    decimal amount = decimal.Parse(line[1], System.Globalization.CultureInfo.InvariantCulture);
                    braceletids.Add(braceletid);
                    amountlist.Add(amount);
                    counter++;

                }
                nrpfppl = counter;
                return true;

            }
            //catch(Exception ex)
            // {

           // }

            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }

        }

    }
}