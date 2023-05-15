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
    public partial class LectureScheduleICA : Form
    {
        private store1 str;
        private store1 ss1;
        public LectureScheduleICA()
        {
            InitializeComponent();
        }
        public LectureScheduleICA(store1 st)
        {
            InitializeComponent();
            str = st;
        }
        private void LectureScheduleICA_Load(object sender, EventArgs e)
        {
            shoo();
        }
        public void shoo()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Scheduled_ICA ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Scheduled_ICA values(@CourseCode,@ICANo,@Date)";
           
            com.Parameters.AddWithValue("@CourseCode", comCourseCode.Text);
            com.Parameters.AddWithValue("@ICA_No", comICANO.Text);
            com.Parameters.AddWithValue("@Date", date.Text);
            com.ExecuteNonQuery();
            connection.Close();
            shoo();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Scheduled_ICA where CourseCode=@pin AND ICANo=@ICANO";
           
           
            com.Parameters.AddWithValue("@pin", comCourseCode.Text);
            com.Parameters.AddWithValue("@ICANO", comICANO.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            shoo();

        }

        private void btn_back_Click(object sender, EventArgs e)
        {

            lectureprofile lp = new lectureprofile(str);
            lp.Show();
            Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
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
