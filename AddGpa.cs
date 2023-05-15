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
    public partial class AddGpa : Form
    {
        double p1,p2,p3,p4,p5,p6,p7,p8,p9,p10;
        string x1, x2, x3, x4, x5, x6, x7, x8, x9, x10;

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

        private store1 str;
        private void btnBack_Click(object sender, EventArgs e)
        {
            lectureprofile lp = new lectureprofile(str);
            lp.Show();
            Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from GPA where Pin=@pin AND Year=@year AND Semester=@sem ";
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
            com.Parameters.AddWithValue("@year", comYear.Text);
            com.Parameters.AddWithValue("@sem", comSem.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            shows();
        }

        private void AddGpa_Load(object sender, EventArgs e)
        {
            shows();
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
            com.CommandText = "insert into GPA values(@Pin,@Year,@Semester,@GPA)";
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
            com.Parameters.AddWithValue("@Year", comYear.Text);
            com.Parameters.AddWithValue("@Semester", comSem.Text);
            com.Parameters.AddWithValue("@GPA", lblGPA.Text);
            com.ExecuteNonQuery();
            /*OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
            connection.Close();
            shows();
        }
        public void shows()
        {

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from GPA ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        string code1, code2, code3, code4, code5, code6, code7, code8, code9, code10;
        double credit1, credit2, credit3, credit4, credit5, credit6, credit7, credit8, credit9, credit10;
        double gpa, sumCredit,sumcp;
        //double point1, point2, point3, point4, point5, point6, point7, point8, point9, point10;
        double mutcp1, mutcp2, mutcp3, mutcp4, mutcp5,mutcp6, mutcp7, mutcp8, mutcp9, mutcp10;

        public AddGpa()
        {
            InitializeComponent();
        }
        public AddGpa(store1 st)
        {
            InitializeComponent();
            str = st;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void bunifuCustomTextbox9_TextChanged(object sender, EventArgs e)
        {

        }
        public double getvalu(string x, string code, double point)
        {

            if (x == "A+")
            {
                point = 4.0;
            }
            else if (x == "A")
            {
                point = 4.0;
            }
            else if (x == "A-")
            {
                point = 3.7;
            }
            else if (x == "B+")
            {
                point = 3.3;
            }
            else if (x == "B")
            {
                point = 3.0;
            }
            else if (x == "B-")
            {
                point = 2.7;
            }
            else if (x == "C+")
            {
                point = 2.3;
            }
            else if (x == "C")
            {
                point = 2.0;
            }
            else if (x == "C-")
            {
                point = 1.7;
            }
            else if (x == "D+")
            {
                point = 1.3;
            }
            else if (x == "D")
            {
                point = 1.0;
            }
            else if (x == "E")
            {
                point = 0.0;
            }
            else
            {
                point = 0.0;
            }
            return point;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (c1.Text != "" && g1.Text != "")
            {
                // 1 row

                x1 = g1.Text;
                code1 = c1.Text;

                double d= getvalu(x1, code1, p1);
               
                cr1.Text = code1.Substring(code1.Length - 1);
              
                credit1 = Convert.ToDouble(cr1.Text);
                mutcp1 = d * credit1;

            }
            //2 ROW
            if (c2.Text != "" && g2.Text != "")
            {
                x2 = g2.Text;
                code2 = c2.Text;

                double d = getvalu(x2, code2, p2);

                cr2.Text = code2.Substring(code2.Length - 1);
                credit2 = Convert.ToDouble(cr2.Text);
                mutcp2 = d * credit2;
            }
            //3 ROW
            if (c3.Text != "" && g3.Text != "")
            {
                x3 = g3.Text;
                code3 = c3.Text;

                double d = getvalu(x3, code3, p3);
                cr3.Text = code3.Substring(code3.Length - 1);
                credit3 = Convert.ToDouble(cr3.Text);
                mutcp3 = d * credit3;
            }
          

         
            //4 ROW
            if (c4.Text != "" && g4.Text != "")
            {
                x4 = g4.Text;
                code4 = c4.Text;

                double d = getvalu(x4, code4, p4);

                cr4.Text = code4.Substring(code4.Length - 1);
                credit4 = Convert.ToDouble(cr4.Text);
                mutcp4 = d * credit4;
            }
            
            //5 ROW
            if (c5.Text != "" && g5.Text != "")
            {
            
                x5 = g5.Text;
                code5 = c5.Text;

                double d = getvalu(x5, code5, p5);

                cr5.Text = code5.Substring(code5.Length - 1);
                credit5 = Convert.ToDouble(cr5.Text);
                mutcp5 = d * credit5;
            }
           
            //6 ROW
            if (c6.Text != "" && g6.Text != "")
            {
                x6 = g6.Text;
                code6 = c6.Text;

                double d = getvalu(x6, code6, p6);

                cr6.Text = code6.Substring(code6.Length - 1);
                credit6 = Convert.ToDouble(cr6.Text);
                mutcp6 = d * credit6;
            }
           
            //7 ROW
            if (c7.Text != "" && g7.Text != "")
            {
                x7 = g7.Text;
                code7 = c7.Text;

                double d = getvalu(x7, code7, p7);

                cr7.Text = code7.Substring(code7.Length - 1);
                credit7 = Convert.ToDouble(cr7.Text);
                mutcp7 = d * credit7;
            }
           
            //8 ROW
            if (c8.Text != "" && g8.Text != "")
            {
                x8 = g8.Text;
                code8 = c8.Text;

                double d = getvalu(x8, code8, p8);

                cr8.Text = code8.Substring(code8.Length - 1);
                credit8 = Convert.ToDouble(cr8.Text);
                mutcp8 = d * credit8;
            }
           
            //9 ROW
            if (c9.Text != "" && g9.Text != "")
            {
                x9 = g9.Text;
                code9 = c9.Text;

                double d = getvalu(x9, code9, p9);

                cr9.Text = code9.Substring(code9.Length - 1);
                credit9 = Convert.ToDouble(cr9.Text);
                mutcp9 = d * credit9;
            }
           
            //10 ROW
            if (c10.Text != "" && g10.Text != "")
            {
                x10 = g10.Text;
                code10 = c10.Text;

                double d = getvalu(x10, code10, p10);

                cr10.Text = code10.Substring(code10.Length - 1);
                credit10 = Convert.ToDouble(cr10.Text);
                mutcp10 = d * credit10;
            }
           
            sumCredit= credit1+ credit2+credit3+credit4+ credit5+ credit6+ credit7+ credit8+credit9+credit10;
            //lblGPA.Text = sumCredit.ToString();
           sumcp= mutcp1+ mutcp2+ mutcp3+ mutcp4+ mutcp5+mutcp6+ mutcp7+ mutcp8+ mutcp9+ mutcp10;
            // lblGPA.Text = sumcp.ToString();
            gpa = sumcp / sumCredit;
            gpa = Math.Round(gpa, 2);

            lblGPA.Text = gpa.ToString();

        }







    }
}
