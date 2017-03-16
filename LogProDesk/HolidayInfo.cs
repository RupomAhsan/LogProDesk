using LogProDesk.Entity;
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

namespace LogProDesk
{
    public partial class HolidayInfo : Form
    {
        DBContext db;
        public HolidayInfo()
        {
            InitializeComponent();
            db = new DBContext();
            PupulateDorpDownData();
            PopulateHolidayGrid();
            this.dgvHolidayDetail.DataBindingComplete +=
            new DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
        }
        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Loops through each row in the DataGridView, and adds the
            // row number to the header
            foreach (DataGridViewRow dGVRow in this.dgvHolidayDetail.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }

            // This resizes the width of the row headers to fit the numbers
            this.dgvHolidayDetail.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        private void PopulateHolidayGrid()
        {
            var results = (from holiday in db.Holidays
                           join company in db.Companies on holiday.CompanyID equals company.Id into ec
                           from ec1 in ec.DefaultIfEmpty()
                           join branch in db.Branches on holiday.BranchID equals branch.Id into eb
                           from eb1 in eb.DefaultIfEmpty()
                           join department in db.Departments on holiday.DepartmentID equals department.Id into ed
                           from ed1 in ed.DefaultIfEmpty()
                           where holiday.IsDeleted == false

                           select new
                           {
                               holiday.Id,
                               Company = ec1.Name,
                               Branch = eb1.Name,
                               DepartmentName = ed1.Name,
                               holiday.Name,
                               holiday.StartDate,
                               holiday.EndDate,
                               holiday.TotalDays,
                               holiday.FinancialYear,
                               Status = holiday.IsActive == true ? "Active" : "Inactive"
                           }).ToList();
            dgvHolidayDetail.DataSource = results;

        }

        private void PupulateDorpDownData()
        {
            PupulateCompanyDDL();
            PupulateBranchDDL();
            PupulateDepartmentDDL();           
            PupulateStatusDDL();
        }

        private void PupulateCompanyDDL()
        {
            List<Company> companyList = new List<Company> { new Company { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Companies.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                companyList.Add(item);
            }
            cboCompany.DataSource = companyList;
            cboCompany.ValueMember = "id";
            cboCompany.DisplayMember = "name";
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
        private void PupulateDepartmentDDL()
        {
            List<Department> departmentList = new List<Department> { new Department { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Departments.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                departmentList.Add(item);
            }
            cboDepartment.DataSource = departmentList;
            cboDepartment.ValueMember = "id";
            cboDepartment.DisplayMember = "name";
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
            if (CheckValidation())
            {
                Holiday anHoliday = new Holiday();
                anHoliday = LoadHolidayData(anHoliday);
                try
                {
                    db.Holidays.Add(anHoliday);
                    var result = db.SaveChanges();
                    PopulateHolidayGrid();
                    MessageBox.Show("Record Inserted Successfully");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }


        }

        private bool CheckValidation(bool isUpdate = false, int? holidayID = null)
        {
            string errorMessage = "";
            //Check Company Data
            if (Convert.ToInt32(cboCompany.SelectedValue) == 0)
            {
                errorMessage += "Company Required. ";
            }
            //Check Branch Data
            if (Convert.ToInt32(cboBranch.SelectedValue) == 0)
            {
                errorMessage += "Branch Required. ";
            }
            //Check Department Data
            if (Convert.ToInt32(cboDepartment.SelectedValue) == 0)
            {
                errorMessage += "Department Required. ";
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

            }

            //Check UserName Data
            if (String.IsNullOrEmpty(dtpStartingDate.Text.Trim()))
            {
                errorMessage += "Starting Date Required. ";
            }
            
            if (!String.IsNullOrEmpty(errorMessage))
            {
                lblErrorMessage.Text = errorMessage;
                return false;
            }
            else
            {
                lblErrorMessage.Text = "";
                return true;

            }

        }

        private Holiday LoadHolidayData(Holiday anHoliday)
        {
            // Holiday anHoliday=new Holiday ();
            anHoliday.CompanyID = Convert.ToInt32(cboCompany.SelectedValue);
            anHoliday.BranchID = Convert.ToInt32(cboBranch.SelectedValue);
            anHoliday.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
            anHoliday.Name = txtName.Text.Trim();
            anHoliday.TotalDays = Convert.ToInt32(nmrTotalDays.Value);
            if (dtpStartingDate.Value != null)
            {
                anHoliday.StartDate = dtpStartingDate.Value;
                anHoliday.EndDate = dtpStartingDate.Value.AddDays(Convert.ToDouble(nmrTotalDays.Value)-1);
                anHoliday.FinancialYear = dtpStartingDate.Value.Year;
            }            
            anHoliday.IsActive = Convert.ToBoolean(cboStatus.SelectedValue);
            anHoliday.IsDeleted = false;
            return anHoliday;
        }

        private void dgvHolidayDetail_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHolidayDetail.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                LoadHolidayDetail(id);
            }
        }

        private void LoadHolidayDetail(int id)
        {
            var hldy = from data in db.Holidays
                        where data.Id == id
                        select data;

            if (hldy.Any())
            {
                PopulateHolidayInfo(hldy.FirstOrDefault());
                lblHolidayID.Text = id.ToString();
            }
        }

        private void PopulateHolidayInfo(Holiday holiday)
        {
            cboCompany.SelectedValue = holiday.CompanyID == null ? 0 : holiday.CompanyID;
            cboBranch.SelectedValue = holiday.BranchID == null ? 0 : holiday.BranchID;
            cboDepartment.SelectedValue = holiday.DepartmentID == null ? 0 : holiday.DepartmentID;

            txtName.Text = holiday.Name;
            if(holiday.TotalDays == null || holiday.TotalDays<1)
                nmrTotalDays.Value = 1;
            else
                nmrTotalDays.Value = Convert.ToDecimal(holiday.TotalDays);

            dtpStartingDate.Text = holiday.StartDate.ToString();
            cboStatus.SelectedValue = holiday.IsActive == null ? 0 : Convert.ToInt32(holiday.IsActive);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value==null)
            {
                PopulateHolidayGrid();
                return;
            }
            var results = (from holiday in db.Holidays
                           join company in db.Companies on holiday.CompanyID equals company.Id into ec
                           from ec1 in ec.DefaultIfEmpty()
                           join branch in db.Branches on holiday.BranchID equals branch.Id into eb
                           from eb1 in eb.DefaultIfEmpty()
                           join department in db.Departments on holiday.DepartmentID equals department.Id into ed
                           from ed1 in ed.DefaultIfEmpty()
                           where holiday.IsDeleted == false && (holiday.StartDate >= dtpFrom.Value && holiday.StartDate <= dtpFrom.Value)

                           select new
                           {
                               holiday.Id,
                               Company = ec1.Name,
                               Branch = eb1.Name,
                               DepartmentName = ed1.Name,
                               holiday.Name,
                               holiday.StartDate,
                               holiday.EndDate,
                               holiday.TotalDays,
                               holiday.FinancialYear,
                               Status = holiday.IsActive == true ? "Active" : "Inactive"
                           }).ToList();
            dgvHolidayDetail.DataSource = results;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateHolidayInfo(new Holiday());
            lblHolidayID.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(lblHolidayID.Text.ToString()))
                id = Convert.ToInt32(lblHolidayID.Text.ToString());
            if (id == 0)
                return;
            if (CheckValidation(true, id))
            {

                try
                {
                    Holiday anHoliday = db.Holidays.Where(x => x.Id == id).FirstOrDefault();
                    anHoliday = LoadHolidayData(anHoliday);
                    anHoliday.UpdatedDate = DateTime.Now;
                    db.Holidays.Attach(anHoliday);
                    db.Entry(anHoliday).State = EntityState.Modified;
                    // db.Holidays.Add(anHoliday);
                    var result = db.SaveChanges();
                    PopulateHolidayGrid();
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
            if (!String.IsNullOrEmpty(lblHolidayID.Text.ToString()))
                id = Convert.ToInt32(lblHolidayID.Text.ToString());
            if (id == 0)
                return;
            try
            {
                Holiday anHoliday = db.Holidays.Where(x => x.Id == id).FirstOrDefault();
                // anHoliday = LoadHolidayData(anHoliday);
                anHoliday.IsDeleted = true;
                anHoliday.IsActive = false;
                anHoliday.UpdatedDate = DateTime.Now;
                db.Holidays.Attach(anHoliday);
                db.Entry(anHoliday).State = EntityState.Modified;
                // db.Holidays.Add(anHoliday);
                var result = db.SaveChanges();
                PopulateHolidayGrid();
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
