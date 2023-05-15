using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BSIS_Project
{
   
    public partial class StudentLogin : Form
    {
      
        public string stuPIN;
     
        public StudentLogin()
        {
            InitializeComponent();
           
        }
      
        public void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            store str = new store();
            str.pin = txbxStudentPin.Text;
            stuPIN = txbxStudentPin.Text;

         

            com.CommandText = "select * from Student where pin='" +txbxStudentPin.Text + "' ";


           


            OleDbDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                StudentProfiles a = new StudentProfiles(str);
               
                a.Show();
                Hide();
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate PIN", "Wiarning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Not Currect Your PIN ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            txbxStudentPin.Text = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LogingChoosing lg = new LogingChoosing();
            lg.Show();
            Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            WElcom w = new WElcom();
            w.Show();
            Hide();
        }

        private void StudentLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
