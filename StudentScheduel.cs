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
    public partial class StudentScheduel : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        public StudentScheduel()
        {
            InitializeComponent();
        }
        public StudentScheduel(store stro)
        {
            InitializeComponent();
            str = stro;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
           StudentProfiles sp = new StudentProfiles(str);

            sp.Show();
            Hide();
        }

        private void StudentScheduel_Load(object sender, EventArgs e)
        {

            shoo();
        }
        public void shoo()
        {

            lblFirst.Text = "x";
            lblSecond.Text = "x";
            lblThird.Text = "x";
            lblDate1.Text = "x";
            lbldate2.Text = "x";
            lblDate3.Text = "x";
        }

        private void butnshow_Click(object sender, EventArgs e)
        {
           /* OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Scheduled_ICA where Course_code=@cose ";
            com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();*/
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            shoo();
            string dd = comboBox1.Text;
           // lblFirst.Text = dd;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select ICANo,Date from Scheduled_ICA where CourseCode=@cc";
            
            com.Parameters.AddWithValue("@cc", dd);
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {

                /*  if(rd.GetValue(0).ToString()!=null)
                  {
                      lblFirst.Text = "YES";
                  }
                  else
                  {
                      lblFirst.Text = "NO";
                  }*/
                /* lblRegNo.Text = rd.GetValue(1).ToString();
                 lblAcademicYear.Text = rd.GetValue(2).ToString();*/
                string v = rd.GetValue(0).ToString();
                switch (v)
                {
                    case "1st":

                        lblFirst.Text = "YES";
                        lblDate1.Text= rd.GetValue(1).ToString();

                        break;


                    case "2nd":

                        lblSecond.Text = "YES";
                        lbldate2.Text = rd.GetValue(1).ToString();
                        break;


                    case "3rd":

                        lblThird.Text = "YES";
                        lblDate3.Text = rd.GetValue(1).ToString();
                        break;

                    default:
                        lblFirst.Text = "NO";
                       // lblDate1.Text = rd.GetValue(1).ToString();
                        break;
                }
            }
            //StudentScheduel_Load(object sender, EventArgs e);
           // shoo();
            connection.Close();
           
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
