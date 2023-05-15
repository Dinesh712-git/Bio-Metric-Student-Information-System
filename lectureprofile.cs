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
    public partial class lectureprofile : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store1 str1;
        string p;
        public lectureprofile()
        {
            InitializeComponent();
        }
        public lectureprofile(store1 stro)
        {
            InitializeComponent();
            str1 = stro;
            lpi.Text = str1.pinL;
        }
      /*  public lectureprofile(string p)
        {
            InitializeComponent();
            this.p = p;
            lpi.Text = p;
        }*/

        private void lectureprofile_Load(object sender, EventArgs e)
        {

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Name,Lpin from Lectur where LPin=@pin";

            com.Parameters.AddWithValue("@pin", str1.pinL);
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblName.Text = rd.GetValue(0).ToString();
                lpi.Text= rd.GetValue(1).ToString();
                // lblSubject.Text = rd.GetValue(1).ToString();
                //lpi.Text = rd.GetValue(2).ToString();
            }

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();
          
            ss.pinL = lpi.Text;
            timeTable t = new timeTable(ss);
            t.Show();
            Hide();
        }

        private void btn_atten_Click(object sender, EventArgs e)
        {
            store1 strr = new store1();
            strr.coursecode = comCourseCode.Text;
            strr.pinL = lpi.Text;
            
            Attendance at = new Attendance(strr);
            at.Show();
            Hide();
        }

        private void btn_schedul_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lpi.Text;
            LectureScheduleICA ls = new LectureScheduleICA(str1);
            ls.Show();
            Hide();
        }

        private void btn_IcaMa_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lpi.Text;
            ICAMark im = new ICAMark(str1);
            im.Show();
            Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
            Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            LogingChoosing lo = new LogingChoosing();
            lo.Show();
            Hide();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddGpa_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lpi.Text;
            AddGpa ad = new AddGpa(str1);
            ad.Show();
            Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lpi.Text;
            tableUpdate ad = new tableUpdate(str1);
            ad.Show();
            Hide();
        }
    }
}
