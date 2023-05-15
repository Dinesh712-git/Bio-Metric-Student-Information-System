using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSIS_Project
{
    public partial class LogingChoosing : Form
    {
        public LogingChoosing()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            lectureprofile l = new lectureprofile();
            l.Show();
            Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            StudentLogin sl = new StudentLogin();
            sl.Show();
            Hide();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            LectureLogin lg = new LectureLogin();
            lg.Show();
            Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            WElcom we = new WElcom();
            we.Show();
            Hide();
        }
    }
}
