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
    public partial class StudentICAMark : Form
    {
        OleDbConnection connection = new OleDbConnection();
       
        private store str;
        string p;
        public StudentICAMark()
        {
            InitializeComponent();
        }
        public StudentICAMark(store stro)
        {
            InitializeComponent();
            str = stro;
            p = str.pin;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentProfiles sp = new StudentProfiles(str);
            sp.Show();
            Hide();
        }

        private void StudentICAMark_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            com.Connection = connection;
            com.CommandText = "select Name from student  where Pin=@pin";
            x.CommandText = "select CourseCode from ICA_Marks where pin=@pin";
           /* com.Parameters.AddWithValue("@cc", va);
            showresult.Text = "No";*/
            com.Parameters.AddWithValue("@pin", p);
            x.Parameters.AddWithValue("@pin", p);
            OleDbDataReader rd = com.ExecuteReader();
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd.Read())
            {
                sql.Text = rd.GetValue(0).ToString();
                
              /*  if (rd.GetValue(0).ToString() != null)
                {
                    showresult.Text = rd.GetValue(0).ToString();
                    break;
                }
                else
                {
                    showresult.Text = "No";
                    break;
                }*/
            }
            while(rd1.Read())
            {
               // lblother.Text = rd1.GetValue(0).ToString();
            }
            connection.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string s = comsub.Text;
            string n = comICANo.Text;

             lblMark.Text = s;
             lblno.Text = n;
             lblpin.Text = p;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Mark from ICA_Marks  where CourseCode=@code AND ICA_No=@no AND Pin=@pin";
            com.Parameters.AddWithValue("@code", s);
            com.Parameters.AddWithValue("@no", n);
            com.Parameters.AddWithValue("@pin", p);
            lblMark.Text = "--";
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblMark.Text = rd.GetValue(0).ToString();
            }
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
