using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServiceClient.TS_Service;


namespace WebServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<TelephoneNumber> telephoneNumbers;
        TSClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new TSClient();
            telephoneNumbers = client.GetDict().ToList();
            dataGridView1.Rows.Clear();

            int count = 0;
            if ((count = telephoneNumbers.Count) > 0)
            {
                dataGridView1.Rows.Add(count);
                count = 0;
                foreach (TelephoneNumber telephoneNumber in telephoneNumbers)
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
            TelephoneNumber telephoneNumber = new TelephoneNumber();
            telephoneNumber.Name = name;
            telephoneNumber.PhoneNumber = phoneNumber;
            client.AddDict(telephoneNumber);

            telephoneNumbers = client.GetDict().ToList();
            Form1_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idTB.Text);
            string name = nameTB.Text;
            string phoneNumber = phoneNumberTB.Text;
            bool wrongData = name == null || name == "" || phoneNumber == null || phoneNumber == "";

            if (wrongData)
                return;
            TelephoneNumber telephoneNumber = new TelephoneNumber();
            telephoneNumber.Name = name;
            telephoneNumber.Id = id;
            telephoneNumber.PhoneNumber = phoneNumber;
            client.UpdDict(telephoneNumber);

            telephoneNumbers = client.GetDict().ToList();
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
            client.DelDict(idTB.Text);

            telephoneNumbers = client.GetDict().ToList();
            Form1_Load(null, null);
        }
    }
}
