using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogProDesk
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
           // var abcd = System.IO.File.ReadAllText("demo.html");
        }

        private void searchAddEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeInfo anEmployeeInfo = new EmployeeInfo();
            anEmployeeInfo.ShowDialog();
        }

        private void holidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HolidayInfo aHolidayInfo = new HolidayInfo();
            aHolidayInfo.ShowDialog();
        }
    }
}
