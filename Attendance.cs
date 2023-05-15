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
    public partial class Attendance : Form
    {
        OleDbConnection connection = new OleDbConnection();

        private store1 str;
        string p,c,d;
        public Attendance()
        {
            InitializeComponent();
        }
        public Attendance(store1 stro)
        {
            InitializeComponent();
            str = stro;
            c = str.coursecode;
            // code.Text = c;
           lblSubject.Text = c;
            d = str.date;
            p = str.pinL;
            
            lll.Text=p;
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            shoo();
           
            
        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
           // com.Parameters.AddWithValue(lblSubject.Text,c);
            /*  com.CommandText = "select SubjectName from Subject  where CourseCode=@code";

              com.Parameters.AddWithValue("@code",code.Text);
              OleDbDataReader rd = com.ExecuteReader();
              while (rd.Read())
              {
                  lblSubject.Text = rd.GetValue(0).ToString();
                  // lblSubject.Text = rd.GetValue(1).ToString();
                  //lpi.Text = rd.GetValue(2).ToString();
              }

      */


            connection.Close();
            
        }

        private void btn_timetble_Click(object sender, EventArgs e)
        {
            double allStu, todaystu, avg;

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "SELECT COUNT(*)FROM Student";
            OleDbDataReader rd1 = com.ExecuteReader();
            while (rd1.Read())
            {
                lblTotalbatch.Text = rd1.GetValue(0).ToString();
              //  allStu = Convert.ToDouble(lblTotalbatch.Text);
            }
            allStu = Convert.ToDouble(lblTotalbatch.Text);


            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "SELECT COUNT(RegNo)FROM Attendance where Date=@date ";
            com1.Parameters.AddWithValue("@date", date.Text);

            OleDbDataReader rd2 = com1.ExecuteReader();
            while (rd2.Read())
            {
                lbltoday.Text = rd2.GetValue(0).ToString();
               
            }
            todaystu = Convert.ToDouble(lbltoday.Text);
            avg = (todaystu / allStu)*100;
            avg = Math.Round(avg, 2);
            lblAvg.Text = avg.ToString()+"%";
            
            connection.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            store1 stt = new store1();
            stt.coursecode = lbltoday.Text;
            StudentAttendes sat = new StudentAttendes(str);
            sat.Show();
            Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
          
            lectureprofile lp = new lectureprofile( str);
            lp.Show();
            Hide();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            store1 str = new store1();
            str.date = date.Text;
            str.atten ="Yes" ;
            str.coursecode = c;
            studentAttendanceMark sam = new studentAttendanceMark(str);
            sam.Show();
            Hide();
            
        }

        public void shoo()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Attendance";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
