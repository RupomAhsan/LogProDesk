﻿using LogProDesk.Fomrs.Attendances;
using LogProDesk.Fomrs.Authentications;
using LogProDesk.Fomrs.Settings;
using LogProDesk.ReportDetail.Viewer;
using LogProDesk.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogProDesk
{
    public partial class Home : BaseForm
    {
        public Home()
        {
            InitializeComponent();
           // var abcd = System.IO.File.ReadAllText("demo.html");
        }

        private void searchAddEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee anEmployeeInfo = new frmEmployee();
            anEmployeeInfo.ShowDialog();
        }

        private void holidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoliday afrmHoliday = new frmHoliday();
            afrmHoliday.ShowDialog();
        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReportViewer aEmployeeReportViewer = new EmployeeReportViewer();
            aEmployeeReportViewer.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany afrmCompany = new frmCompany();
            afrmCompany.ShowDialog();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranch afrmBranch = new frmBranch();
            afrmBranch.ShowDialog();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment afrmDepartment = new frmDepartment();
            afrmDepartment.ShowDialog();
        }

        private void educationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEducation afrmEducation = new frmEducation();
            afrmEducation.ShowDialog();
        }

        private void designationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignation afrmDesignation = new frmDesignation();
            afrmDesignation.ShowDialog();
        }

       
        private void maritialStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaritalStatus afrmMaritalStatus = new frmMaritalStatus();
            afrmMaritalStatus.ShowDialog();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRole afrmRole = new frmRole();
            afrmRole.ShowDialog();
        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimetable afrmTimetable = new frmTimetable();
            afrmTimetable.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser anfrmUser = new frmUser();
            anfrmUser.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]

        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_NCPAINT = 0x85;
            base.WndProc(ref m);

            if (m.Msg == WM_NCPAINT)
            {

                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    g.DrawLine(Pens.Green, 10, 10, 100, 10);
                    g.Flush();
                    ReleaseDC(m.HWnd, hdc);
                }

            }

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword afrmChangePassword = new frmChangePassword();
            afrmChangePassword.ShowDialog();
        }
    }
}
