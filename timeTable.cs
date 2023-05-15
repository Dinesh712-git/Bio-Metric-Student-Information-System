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
    public partial class timeTable : Form
    {
        private store ss;
        private store str;
        string p;
        private store1 ss1;

        public timeTable()
        {
            InitializeComponent();
        }
        public timeTable(store ss)
        {
            InitializeComponent();
            this.ss = ss;
             p= ss.pin;
        }

        public timeTable(store1 ss1)
        {
            InitializeComponent();
            this.ss1 = ss1;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            lectureprofile lp = new lectureprofile(ss1);
            lp.Show();
            Hide();
        }

        private void timeTable_Load(object sender, EventArgs e)
        {

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
