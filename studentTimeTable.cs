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
    public partial class studentTimeTable : Form
    {

        private store str;
        public studentTimeTable()
        {
            InitializeComponent();
        }
        public studentTimeTable(store st)
        {
            InitializeComponent();
            str = st;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentProfiles st = new StudentProfiles(str);
            st.Show();
            Hide();
        }

        private void studentTimeTable_Load(object sender, EventArgs e)
        {

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
    }
}
