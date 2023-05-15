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
    public partial class StudentProfiles : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        string p;
        public StudentProfiles()
        {
            InitializeComponent();
        }
        public StudentProfiles(store stro)
        {
            InitializeComponent();
            str = stro;
            p = str.pin;
           pinnnn.Text = p;


        }


        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            studentTimeTable t = new studentTimeTable(st);
            t.Show();
            Hide();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            Results re = new Results(st);
            re.Show();
            Hide();
        }

        private void btnGPA_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            GPA G = new GPA(st);
            G.Show();
            Hide();
        }

        private void btnScheduledICA_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            StudentScheduel Sc = new StudentScheduel(st);
            Sc.Show();
            Hide();
        }

        private void btnICAMarks_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            StudentICAMark im = new StudentICAMark(st);
            im.Show();
            Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            store st =new store();
            st.pin = lblRegNo.Text;
            StudentAttendanceSee At = new StudentAttendanceSee(st);
            At.Show();
            Hide();
        }

        private void StudentProfiles_Load(object sender, EventArgs e)
        {
            //lblName.Text = str.pin;
           
          connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Name,RegNo,AcademicYear,Pin from Student where Pin=@pin";
            
           com.Parameters.AddWithValue("@pin", str.pin);
           
            OleDbDataReader rd = com.ExecuteReader();
            while(rd.Read())
            {
                lblName.Text = rd.GetValue(0).ToString();
                str.name = lblName.Text;
                lblRegNo.Text = rd.GetValue(1).ToString();
                str.regno = lblRegNo.Text;
                lblAcademicYear.Text = rd.GetValue(2).ToString();
                str.accdmicyear = lblAcademicYear.Text;
                kkk.Text = rd.GetValue(3).ToString();
                
            }


         /*   OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                string picLoc = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc;
                
            }*/



           /* connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();*/
            OleDbCommand com1= new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "select Name,RegNo,AcademicYear,Pin from Student where RegNo=@pin";

            com1.Parameters.AddWithValue("@pin", pinnnn.Text);

            OleDbDataReader rd1 = com1.ExecuteReader();
            while (rd1.Read())
            {
                lblName.Text = rd1.GetValue(0).ToString();
               // str.name = lblName.Text;
                lblRegNo.Text = rd1.GetValue(1).ToString();
               // str.regno = lblRegNo.Text;
                lblAcademicYear.Text = rd1.GetValue(2).ToString();
               // str.accdmicyear = lblAcademicYear.Text;
                kkk.Text = rd1.GetValue(3).ToString();
            }




            /*  OleDbDataAdapter da = new OleDbDataAdapter(com);
              DataTable dt = new DataTable();
              da.Fill(dt);
              CashiarDataView.DataSource = dt;*/
            connection.Close();
        }
      /*  public void ff()
        {
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "select Name,RegNo,AcademicYear,Pin from Student where RegNo=@pin";

            com1.Parameters.AddWithValue("@pin", pinnnn.Text);

            OleDbDataReader rd1 = com1.ExecuteReader();
            while (rd1.Read())
            {
                lblName.Text = rd1.GetValue(0).ToString();
                // str.name = lblName.Text;
                lblRegNo.Text = rd1.GetValue(1).ToString();
                // str.regno = lblRegNo.Text;
                lblAcademicYear.Text = rd1.GetValue(2).ToString();
                // str.accdmicyear = lblAcademicYear.Text;
                kkk.Text = rd1.GetValue(3).ToString();
            }

        }*/

        private void btnLogout_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
            Hide();
        }

        private void btnGPA_Click_1(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            GPA G = new GPA(st);
            G.Show();
            Hide();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
