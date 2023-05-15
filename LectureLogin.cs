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
    public partial class LectureLogin : Form
    {
        
        public LectureLogin()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            store1 str = new store1();
            str.pinL = txbxLecturePin.Text;
          //  stuPIN = txbxStudentPin.Text;



            com.CommandText = "select * from Lectur where Lpin='" + txbxLecturePin.Text + "' ";





            OleDbDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                lectureprofile a = new lectureprofile(str);

                a.Show();
                Hide();
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate PIN", "Wiarning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Not Currect Your PIN ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            txbxLecturePin.Text = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LogingChoosing lg = new LogingChoosing();
            lg.Show();
            Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            WElcom w = new WElcom();
            w.Show();
            Hide();
        }

        private void LectureLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
