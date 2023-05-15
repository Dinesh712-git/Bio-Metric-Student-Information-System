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
    public partial class ICAMark : Form
    {
        private store1 str;
        private store1 ss1;
        public ICAMark()
        {
            InitializeComponent();
        }
        public ICAMark(store1 st)
        {
            InitializeComponent();
            str = st;
        }

        private void ICAMark_Load(object sender, EventArgs e)
        {
            shows();
        }
        public void shows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from ICA_Marks ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string npin;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into ICA_Marks values(@Pin,@CourseCode,@ICA_No,@Mark)";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            string pp = txboxRegNo.Text;
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            x.CommandText = "select Pin from Student where RegNo=@RegNo";
            x.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd1.Read())
            {
                // txboxRegNo.Text = rd1.GetValue(0).ToString();
                com.Parameters.AddWithValue("@Pin", rd1.GetValue(0).ToString());
            }

            //  com.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            com.Parameters.AddWithValue("@CourseCode", comCourseCode.Text);
            com.Parameters.AddWithValue("@ICA_No", comICANO.Text);
            com.Parameters.AddWithValue("@Mark", txboxGrade.Text);
            com.ExecuteNonQuery();
            /*OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
            connection.Close();
            shows();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from ICA_Marks where Pin=@pin AND CourseCode=@cc AND ICA_No=@icn ";
            string pp = txboxRegNo.Text;
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            x.CommandText = "select Pin from Student where RegNo=@RegNo";
            x.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd1.Read())
            {
                txboxRegNo.Text = rd1.GetValue(0).ToString();

            }
            com.Parameters.AddWithValue("@pin", txboxRegNo.Text);
            com.Parameters.AddWithValue("@cc", comCourseCode.Text);
            com.Parameters.AddWithValue("@icn", comICANO.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            shows();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            lectureprofile lp = new lectureprofile(str);
            lp.Show();
            Hide();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            LogingChoosing lo = new LogingChoosing();
            lo.Show();
            Hide();
        }
    }
}
