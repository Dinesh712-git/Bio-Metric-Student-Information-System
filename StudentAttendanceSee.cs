﻿using System;
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
    public partial class StudentAttendanceSee : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        
       // private store str;
        public StudentAttendanceSee()
        {
            InitializeComponent();
        }
        public StudentAttendanceSee(store stro)
        {
            InitializeComponent();
            str = stro;
            lblTRegNo.Text = str.pin;
            lblRegNo.Text = str.pin;
        }


        private void btnResults_Click(object sender, EventArgs e)
        {
            lblCourseCode.Text = comcourecode.Text;
         //   lblRegNo.Text = txboxRegNo.Text;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Days from Subject where CourseCode=@pin";

            com.Parameters.AddWithValue("@pin", lblCourseCode.Text);

            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblday.Text = rd.GetValue(0).ToString();

            }


            double attstu, avg, allday;


            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "SELECT COUNT(RegNo)FROM Attendance where CourseCode=@code AND RegNo=@regno";

            com1.Parameters.AddWithValue("@code", comcourecode.Text);
            com1.Parameters.AddWithValue("@regno", lblTRegNo.Text);
            allday = Convert.ToDouble(lblday.Text);
            OleDbDataReader rd1 = com1.ExecuteReader();
            while (rd1.Read())
            {
                // attstu =Convert.ToDouble( rd1.GetValue(0).ToString());
                lblPresent.Text = rd1.GetValue(0).ToString();
                /* avg = attstu / allday;
                 avg = Math.Round(avg, 2);
                 lblAttendance.Text = avg.ToString() + "%";*/

            }
            attstu = Convert.ToDouble(lblPresent.Text);
            avg = (attstu / allday)*100;
            avg = Math.Round(avg, 2);
            lblAttendance.Text = avg.ToString() + "%";


            connection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            store stt = new store();
            // stt.coursecode = cc.Text;
            StudentProfiles at = new StudentProfiles(str);
            at.Show();
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
    }
}
