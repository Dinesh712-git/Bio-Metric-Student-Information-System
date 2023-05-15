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
    public partial class Results : Form
    {
      
        OleDbConnection connection = new OleDbConnection();
        private store str;
        string p;
        public string re;
        
        public Results()
        {
            InitializeComponent();
           
        }
        public Results(store stro)
        {
            InitializeComponent();
            str = stro;
            
            lblkkk.Text = str.pin;
            p = lblkkk.Text;
        }

        private void Results_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            StudentProfiles sp = new StudentProfiles(str);
            sp.Show();
            Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string va = comboBox1.Text;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Result from Result where CourseCode=@cc AND Pin=@pin";

            com.Parameters.AddWithValue("@cc", va);
            showresult.Text = "No";
            com.Parameters.AddWithValue("@pin",p);
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                //showresult.Text = rd.GetValue(0).ToString();
                if(rd.GetValue(0).ToString()!=null)
                {
                    showresult.Text = rd.GetValue(0).ToString();
                    break;
                }
                else 
                {
                    showresult.Text = "No";
                    break;
                }
            }
            connection.Close();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            StudentProfiles sp = new StudentProfiles(str);
            sp.Show();
            Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
            Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LogingChoosing lo = new LogingChoosing();
            lo.Show();
            Hide();
        }
    }
}
