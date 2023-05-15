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
    public partial class tableUpdate : Form
    {

        private store1 str;
        private store1 ss1;
        public tableUpdate()
        {
            InitializeComponent();
        }
        public tableUpdate(store1 st)
        {
            InitializeComponent();
            str = st;
        }
        private void bunifuCustomTextbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string npin;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Student values(@RegNo,@Name,@AcademicYear,@pin)";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            //string pp = txboxRegNo.Text;
           /* OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            x.CommandText = "select Pin from Student where RegNo=@RegNo";
            x.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd1.Read())
            {
                // txboxRegNo.Text = rd1.GetValue(0).ToString();
                com.Parameters.AddWithValue("@Pin", rd1.GetValue(0).ToString());
            }*/

            com.Parameters.AddWithValue("@RegNo", sreg.Text);
            com.Parameters.AddWithValue("@Name", sname.Text);
            com.Parameters.AddWithValue("@AcademicYear", syear.Text);
            com.Parameters.AddWithValue("@pin", spin.Text);
            com.ExecuteNonQuery();
          /*  OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            st.DataSource = dt;*/
            connection.Close();
            sshows();
        }
        public void sshows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Student ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            st.DataSource = dt;
            connection.Close();
        }
        public void suhows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Subject ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sut.DataSource = dt;
            connection.Close();
        }
        public void lshows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Lectur ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lt.DataSource = dt;
            connection.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableUpdate_Load(object sender, EventArgs e)
        {
            sshows();
            suhows();
            lshows();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            string npin;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Subject values(@CourseCode,@SubjectName,@Days)";

            com.Parameters.AddWithValue("@CourseCode", succode.Text);
            com.Parameters.AddWithValue("@SubjectName", suname.Text);
            com.Parameters.AddWithValue("@Days", sudays.Text);
           // com.Parameters.AddWithValue("@pin", spin.Text);
            com.ExecuteNonQuery();
           /* OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sut.DataSource = dt;*/
            connection.Close();
            suhows();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
          //  string npin;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Lectur values(@LecturId,@Name,@CourseCode,@Lpin)";

            com.Parameters.AddWithValue("@LecturId", lid.Text);
            com.Parameters.AddWithValue("@Name", lname.Text);
            com.Parameters.AddWithValue("@CourseCode", lccode.Text);
            com.Parameters.AddWithValue("@Lpin", lpin.Text);
            com.ExecuteNonQuery();
            // com.Parameters.AddWithValue("@photo", "");

            /* OleDbDataAdapter da = new OleDbDataAdapter(com);
             DataTable dt = new DataTable();
             da.Fill(dt);
             sut.DataSource = dt;*/
            connection.Close();
            lshows();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Student where Pin=@pin ";
           // string pp = txboxRegNo.Text;
            com.Parameters.AddWithValue("@pin", spin.Text);
          /*  com.Parameters.AddWithValue("@year", comYear.Text);
            com.Parameters.AddWithValue("@sem", comSem.Text);*/
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            st.DataSource = dt;
            connection.Close();
            sshows();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Lectur where LPin=@pin ";
            // string pp = txboxRegNo.Text;
            com.Parameters.AddWithValue("@pin", lpin.Text);
            /*  com.Parameters.AddWithValue("@year", comYear.Text);
              com.Parameters.AddWithValue("@sem", comSem.Text);*/
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lt.DataSource = dt;
            connection.Close();
            lshows();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Subject where CourseCode=@CourseCode ";
            // string pp = txboxRegNo.Text;
            com.Parameters.AddWithValue("@CourseCode", succode.Text);
            /*  com.Parameters.AddWithValue("@year", comYear.Text);
              com.Parameters.AddWithValue("@sem", comSem.Text);*/
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sut.DataSource = dt;
            connection.Close();
            suhows();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lectureprofile lp = new lectureprofile(str);
            lp.Show();
            Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LogingChoosing lo = new LogingChoosing();
            lo.Show();
            Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
            Hide();
        }
    }
}
