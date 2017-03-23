using LogProDesk.Entity;
using LogProDesk.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogProDesk.Fomrs.Attendances
{
    public partial class frmShift : BaseForm
    {        
        DBContext db;
        public frmShift()
        {
            InitializeComponent();
            db = new DBContext();
            PupulateDorpDownData();
            PopulateGrid();
            this.dgvDetailData.DataBindingComplete +=
            new DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
        }
        private void PupulateDorpDownData()
        {
            PupulateStatusDDL();
            PupulateBranchDDL();
        }
        
        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Loops through each row in the DataGridView, and adds the
            // row number to the header
            foreach (DataGridViewRow dGVRow in this.dgvDetailData.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }

            // This resizes the width of the row headers to fit the numbers
            this.dgvDetailData.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        private void PopulateGrid()
        {
            var results = (from timetable in db.TimeTables
                           join branch in db.Branches on timetable.BranchID equals branch.Id into eb
                           from eb1 in eb.DefaultIfEmpty()
                           where timetable.IsDeleted == false && timetable.IsActive==true

                           select new
                           {
                               timetable.Id,
                               Branch = eb1.Name,
                               timetable.Name,
                               timetable.OnDutyTime,
                               timetable.OffDutyTime,
                               Status = timetable.IsActive == true ? "Active" : "Inactive"
                           }).ToList();
            dgvDetailData.DataSource = results;

        }

        private void PupulateBranchDDL()
        {
            List<Branch> branchList = new List<Branch> { new Branch { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Branches.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                branchList.Add(item);
            }
            cboBranch.DataSource = branchList;
            cboBranch.ValueMember = "id";
            cboBranch.DisplayMember = "name";
        }
        
        private void PupulateStatusDDL()
        {
            SortedDictionary<string, int> statusData = new SortedDictionary<string, int>
            {
              {"Active", 1},
              {"Inctive", 0}
            };
            cboStatus.DataSource = new BindingSource(statusData, null);
            cboStatus.DisplayMember = "Key";
            cboStatus.ValueMember = "Value";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    TimeTable anTimeTable = new TimeTable();
                    anTimeTable = LoadTimeTableData(anTimeTable);

                    anTimeTable.CreatedDate = DateTime.Now;
                    anTimeTable.CreatedBy = UserSessions.UserID;

                    db.TimeTables.Add(anTimeTable);
                    var result = db.SaveChanges();
                    PopulateGrid();
                    MessageBox.Show("Record Inserted Successfully");



                }
            }
                catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private bool CheckValidation(bool isUpdate = false, int? timetableID = null)
        {
            string errorMessage = "";

            //Check Branch Data
            if (Convert.ToInt32(cboBranch.SelectedValue) == 0)
            {
                errorMessage += "Branch Required. ";
            }
            
            //Check Fullname Data
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorMessage += "Name Required. ";
            }
            else
            {
                Regex rgx = new Regex("^[\\w ]+$");
                if (!rgx.IsMatch(txtName.Text.Trim()))
                {
                    errorMessage += "Invalid Name. ";
                }
                else
                {
                    if (!isUpdate)
                    {
                        var result = from data in db.TimeTables
                                     where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                     select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.TimeTables
                                     where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true && data.Id != timetableID
                                     select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                }

            }

            //Check OnDuty Data
            if (String.IsNullOrEmpty(mtbOnDuty.Text.Trim()))
            {
                errorMessage += " On Duty Required. ";
            }
            //Check OffDuty Data
            if (String.IsNullOrEmpty(mtbOffDuty.Text.Trim()))
            {
                errorMessage += "Off Duty Required. ";
            }
            //Check BeginCheckIn Data
            if (String.IsNullOrEmpty(mtbBeginCheckIn.Text.Trim()))
            {
                errorMessage += "Begin Check In Required. ";
            }
            //Check BeginCheckOut Data
            if (String.IsNullOrEmpty(mtbBeginCheckOut.Text.Trim()))
            {
                errorMessage += "Begin Check Out Required. ";
            }
            //Check EndCheckIn Data
            if (String.IsNullOrEmpty(mtbEndCheckIn.Text.Trim()))
            {
                errorMessage += "End Check In Required. ";
            }
            //Check EndCheckOut Data
            if (String.IsNullOrEmpty(mtbEndCheckOut.Text.Trim()))
            {
                errorMessage += "End Check Out Required. ";
            }


            if (!String.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            else
            {
                //lblErrorMessage.Text = "";
                return true;

            }

        }

        private TimeTable LoadTimeTableData(TimeTable anTimeTable)
        {
            anTimeTable.BranchID = Convert.ToInt32(cboBranch.SelectedValue);
            anTimeTable.Name = txtName.Text.Trim();
            anTimeTable.BeginCheckInTime =TimeSpan.Parse(mtbBeginCheckIn.Text.ToString());
            anTimeTable.BeginCheckOutTime = TimeSpan.Parse(mtbBeginCheckOut.Text.ToString());
            anTimeTable.EndCheckInTime = TimeSpan.Parse(mtbEndCheckIn.Text.ToString());
            anTimeTable.EndCheckOutTime = TimeSpan.Parse(mtbEndCheckOut.Text.ToString());
            anTimeTable.OffDutyTime = TimeSpan.Parse(mtbOffDuty.Text.ToString());
            anTimeTable.OnDutyTime = TimeSpan.Parse(mtbOnDuty.Text.ToString());
            anTimeTable.MaximumEarlyCount = TimeSpan.Parse(mtbEarlyAllowence.Text.ToString());
            anTimeTable.MaximumLateCount = TimeSpan.Parse(mtbLateAllowence.Text.ToString());
            anTimeTable.TotalWorkDays = double.Parse(nmrTotalWorkDays.Text.ToString());
            anTimeTable.TotalWorkTime = double.Parse(nmrTotalWorkTimes.Text.ToString());

            anTimeTable.IsCheckInMandatory = chkMustCheckIn.Checked;
            anTimeTable.IsCheckOutMandatory = chkMustCheckOut.Checked;

            anTimeTable.IsActive = Convert.ToBoolean(cboStatus.SelectedValue);
            anTimeTable.IsDeleted = false;
            
            return anTimeTable;
        }

        private void dgvDetailData_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetailData.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                LoadTimeTableDetail(id);
            }
        }

        private void LoadTimeTableDetail(int id)
        {
            var hldy = from data in db.TimeTables
                       where data.Id == id
                       select data;

            if (hldy.Any())
            {
                PopulateTimeTableInfo(hldy.FirstOrDefault());
                lblID.Text = id.ToString();
            }
        }

        private void PopulateTimeTableInfo(TimeTable anTimeTable)
        {
            cboBranch.SelectedValue = anTimeTable.BranchID == null ? 0 : anTimeTable.BranchID;
            txtName.Text = anTimeTable.Name;

            mtbBeginCheckIn.Text = anTimeTable.BeginCheckInTime.ToString();
            mtbBeginCheckOut.Text=anTimeTable.BeginCheckOutTime.ToString();
            mtbEndCheckIn.Text=anTimeTable.EndCheckInTime.ToString();
            mtbEndCheckOut.Text=anTimeTable.EndCheckOutTime.ToString();
            mtbOffDuty.Text=anTimeTable.OffDutyTime.ToString();
            mtbOnDuty.Text=anTimeTable.OnDutyTime.ToString();
            mtbEarlyAllowence.Text=anTimeTable.MaximumEarlyCount.ToString();
            mtbLateAllowence.Text=anTimeTable.MaximumLateCount.ToString();
            nmrTotalWorkDays.Text=anTimeTable.TotalWorkDays.ToString();
            nmrTotalWorkTimes.Text=anTimeTable.TotalWorkTime.ToString();

            chkMustCheckIn.Checked=(anTimeTable.IsCheckInMandatory ==null|| anTimeTable.IsCheckInMandatory==false) ?false: true;
            chkMustCheckOut.Checked= (anTimeTable.IsCheckOutMandatory == null || anTimeTable.IsCheckOutMandatory == false) ? false : true; 

            cboStatus.SelectedValue = anTimeTable.IsActive == null ? 0 : Convert.ToInt32(anTimeTable.IsActive);
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateTimeTableInfo(new TimeTable());
            lblID.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(lblID.Text.ToString()))
                id = Convert.ToInt32(lblID.Text.ToString());
            if (id == 0)
                return;
            if (CheckValidation(true, id))
            {

                try
                {
                    TimeTable anTimeTable = db.TimeTables.Where(x => x.Id == id).FirstOrDefault();
                    anTimeTable = LoadTimeTableData(anTimeTable);
                    anTimeTable.UpdatedBy = UserSessions.UserID;
                    anTimeTable.UpdatedDate = DateTime.Now;
                    db.TimeTables.Attach(anTimeTable);
                    db.Entry(anTimeTable).State = EntityState.Modified;
                    // db.TimeTables.Add(anTimeTable);
                    var result = db.SaveChanges();
                    PopulateGrid();
                    MessageBox.Show("Record Updated Successfully");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(lblID.Text.ToString()))
                id = Convert.ToInt32(lblID.Text.ToString());
            if (id == 0)
                return;
            try
            {
                TimeTable anTimeTable = db.TimeTables.Where(x => x.Id == id).FirstOrDefault();
                // anTimeTable = LoadTimeTableData(anTimeTable);
                anTimeTable.IsDeleted = true;
                anTimeTable.IsActive = false;
                anTimeTable.UpdatedBy = UserSessions.UserID;
                anTimeTable.UpdatedDate = DateTime.Now;
                db.TimeTables.Attach(anTimeTable);
                db.Entry(anTimeTable).State = EntityState.Modified;
                // db.TimeTables.Add(anTimeTable);
                var result = db.SaveChanges();
                PopulateGrid();
                MessageBox.Show("Record Deleted Successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        
    }
}
