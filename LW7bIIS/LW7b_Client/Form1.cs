using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LW7b_Client
{
    public partial class Form1 : Form
    {
        TSService.TSServiceSoapClient soapClient;
        List<TSService.TelephoneNumber> telephoneNumbers;
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Data(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            soapClient = new TSService.TSServiceSoapClient();
            telephoneNumbers = soapClient.GetDict().ToList();

            int count = 0;
            if ((count = telephoneNumbers.Count) > 0)
            {
                dataGridView1.Rows.Add(count);
                count = 0;
                foreach (TSService.TelephoneNumber telephoneNumber in telephoneNumbers)
                {
                    dataGridView1.Rows[count].Cells[0].Value = telephoneNumber.Id.ToString();
                    dataGridView1.Rows[count].Cells[1].Value = telephoneNumber.Name.ToString();
                    dataGridView1.Rows[count].Cells[2].Value = telephoneNumber.PhoneNumber.ToString();
                    count++;

                }
            }

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            string phoneNumber = phoneNumberTB.Text;
            bool wrongData = name == null || name == "" || phoneNumber == null || phoneNumber == "";

            if (wrongData)
                return;
            TSService.TelephoneNumber telephoneNumber = new TSService.TelephoneNumber();
            telephoneNumber.Name = name;
            telephoneNumber.PhoneNumber = phoneNumber;
            soapClient.AddDict(telephoneNumber);

            telephoneNumbers = soapClient.GetDict().ToList();
            Load_Data(null, null);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            string phoneNumber = phoneNumberTB.Text;
            string id_text = idTB.Text;
            int id=-1;
            bool wrongData = name == null || name == "" ||
                 phoneNumber == null || phoneNumber == "" ||
                 !int.TryParse(id_text, out id);

            if (wrongData)
                return;
            TSService.TelephoneNumber telephoneNumber = new TSService.TelephoneNumber();
            telephoneNumber.Name = name;
            telephoneNumber.PhoneNumber = phoneNumber;
            telephoneNumber.Id = id;
            soapClient.UpdDict(telephoneNumber);

            telephoneNumbers = soapClient.GetDict().ToList();
            Load_Data(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id_text = idTB.Text;
            int id=-1;
            bool wrongData = !int.TryParse(id_text, out id);

            if (wrongData)
                return;
            soapClient.DelDict(id_text);

            telephoneNumbers = soapClient.GetDict().ToList();
            Load_Data(null, null);
        }
    }
}
