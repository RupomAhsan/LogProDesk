using LogProDesk.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LogProDesk
{
    public partial class EmployeeInfo : Form
    {
        DBContext db;
        string imagename;
        public EmployeeInfo()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            db = new DBContext();
            PupulateDorpDownData();
            PopulateEmployeeGrid();
            this.dgvEmployeeDetail.DataBindingComplete +=
            new DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
        }
        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Loops through each row in the DataGridView, and adds the
            // row number to the header
            foreach (DataGridViewRow dGVRow in this.dgvEmployeeDetail.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }

            // This resizes the width of the row headers to fit the numbers
            this.dgvEmployeeDetail.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        private void PopulateEmployeeGrid()
        {

            var results= (from employee in db.Employees
                          join company in db.Companies on employee.CompanyID equals company.Id into ec
                          from ec1 in ec.DefaultIfEmpty()
                          join branch in db.Branches on employee.BranchID equals branch.Id into eb
                          from eb1 in eb.DefaultIfEmpty()
                          join department in db.Departments on employee.DepartmentID equals department.Id into ed
                          from ed1 in ed.DefaultIfEmpty()
                          join designation in db.Designations on employee.DesignationID equals designation.Id into edg
                          from edg1 in edg.DefaultIfEmpty()
                          join education in db.Educations on employee.EducationID equals education.Id into ee
                          from ee1 in ee.DefaultIfEmpty()
                          join maritialStatus in db.MaritialStatus on employee.MaritualStatusID equals maritialStatus.Id into em
                          from em1 in em.DefaultIfEmpty()
                          join role in db.Roles on employee.RoleID equals role.Id into er
                          from er1 in er.DefaultIfEmpty()
                          join sex in db.Sexes on employee.SexID equals sex.Id into es
                          from es1 in es.DefaultIfEmpty()
                          where employee.IsDeleted==false 

                          select new
                          {
                              employee.Id,
                              Company = ec1.Name,
                              Branch=eb1.Name,
                              DepartmentName=ed1.Name,
                              employee.EmployeeNo,
                              employee.FullName,
                              employee.UserName,
                              Role = er1.Name,
                              employee.JoinDate,
                              Designation =edg1.Name,
                              Education= ee1.Name,
                              employee.DOB,
                              employee.EmailAddress,
                              employee.MobileNumber,
                              MaritialStatus = em1.Name,
                              Gender= es1.Name,
                              Status = employee.IsActive == true ? "Active" : "Inactive",
                              Photo=employee.Photo
                          }).ToList();
            dgvEmployeeDetail.DataSource = results;
            
        }

        private void PupulateDorpDownData()
        {
            PupulateCompanyDDL();
            PupulateBranchDDL();
            PupulateDepartmentDDL();
            PupulateRoleDDL();
            PupulateDesignationDDL();
            PupulateEducationDDL();
            PupulateMaritialStatusDDL();
            PupulateSexDDL();
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
        private void PupulateRoleDDL()
        {
            List<Role> roleList = new List<Role> { new Role { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Roles.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                roleList.Add(item);
            }
            cboRole.DataSource = roleList;
            cboRole.ValueMember = "id";
            cboRole.DisplayMember = "name";
        }
        private void PupulateDesignationDDL()
        {
            List<Designation> designationList = new List<Designation> { new Designation { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Designations.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                designationList.Add(item);
            }
            cboDesignation.DataSource = designationList;
            cboDesignation.ValueMember = "id";
            cboDesignation.DisplayMember = "name";
        }
        private void PupulateEducationDDL()
        {
            List<Education> educationList = new List<Education> { new Education { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Educations.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                educationList.Add(item);
            }
            cboEducation.DataSource = educationList;
            cboEducation.ValueMember = "id";
            cboEducation.DisplayMember = "name";
        }
        private void PupulateMaritialStatusDDL()
        {
            List<MaritialStatu> maritialStatusList = new List<MaritialStatu> { new MaritialStatu { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.MaritialStatus.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                maritialStatusList.Add(item);
            }
            cboMaritialStatus.DataSource = maritialStatusList;
            cboMaritialStatus.ValueMember = "id";
            cboMaritialStatus.DisplayMember = "name";
        }
        private void PupulateSexDDL()
        {
            List<Sex> sexList = new List<Sex> { new Sex { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Sexes.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                sexList.Add(item);
            }
            cboSex.DataSource = sexList;
            cboSex.ValueMember = "id";
            cboSex.DisplayMember = "name";
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();

                //specify your own initial directory

                fldlg.InitialDirectory = @"C:\";

                //this will allow only those file extensions to be added

                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";

                if (fldlg.ShowDialog() == DialogResult.OK)
                {

                    imagename = fldlg.FileName;

                    //Bitmap newimg = new Bitmap(imagename);

                    ptbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                    ptbPhoto.Image = Image.FromFile(imagename);

                }

                fldlg = null;

            }

            catch (System.ArgumentException ae)
            {

                imagename = " ";

                MessageBox.Show(ae.Message.ToString());

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Employee anEmployee = new Employee();
                anEmployee = LoadEmployeeData(anEmployee);
                try
                {
                    db.Employees.Add(anEmployee);
                    var result = db.SaveChanges();
                    PopulateEmployeeGrid();
                    MessageBox.Show("Record Inserted Successfully");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }                
                
                
            }


        }


        private bool CheckValidation(bool isUpdate=false,int? employeeID=null)
        {
            string errorMessage = "";
            //Check Company Data
            if(Convert.ToInt32(cboCompany.SelectedValue)==0)
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
            if (String.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                errorMessage += "Full Name Required. ";
            }
            else
            {
                Regex rgx = new Regex("^[\\w ]+$");
                if (!rgx.IsMatch(txtFullName.Text.Trim()))
                {
                    errorMessage += "Invalid Full Name. ";
                }
                
            }

            //Check UserName Data
            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorMessage += "User Name Required. ";
            }
            else
            {
                Regex rgx = new Regex("^[a-zA-Z0-9]+$");
                if (!rgx.IsMatch(txtUserName.Text.Trim()))
                {
                    errorMessage += "Invalid User Name. ";
                }
                else
                {
                    if (!isUpdate)
                    {
                        var empNo = from data in db.Employees
                                    where data.UserName == txtEmployeeNo.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (empNo.Any())
                        {
                            errorMessage += "User Name already Exists. ";
                        }
                    }
                    else
                    {
                        var empNo = from data in db.Employees
                                    where data.UserName == txtEmployeeNo.Text.Trim().ToString() && data.IsDeleted != true && data.Id != employeeID
                                    select data;

                        if (empNo.Any())
                        {
                            errorMessage += "User Name already Exists. ";
                        }
                    }
                }
            }
            
            //Check Password Data
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorMessage += "Password Required. ";
            }
            //Check Role Data
            if (Convert.ToInt32(cboRole.SelectedValue) == 0)
            {
                errorMessage += "Role Required. ";
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

        private Employee LoadEmployeeData(Employee anEmployee)
        {
           // Employee anEmployee=new Employee ();
            anEmployee.CompanyID = Convert.ToInt32(cboCompany.SelectedValue);
            anEmployee.BranchID = Convert.ToInt32(cboBranch.SelectedValue);
            anEmployee.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
            anEmployee.EmployeeNo = txtEmployeeNo.Text.Trim();
            anEmployee.FullName = txtFullName.Text.Trim();
            anEmployee.UserName = txtUserName.Text.Trim();
            anEmployee.Password = txtPassword.Text.Trim();
            anEmployee.RoleID = Convert.ToInt32(cboRole.SelectedValue);
            if (dtpJoinDate.Value != null)
                anEmployee.JoinDate = dtpJoinDate.Value;
            if (dtpDoB.Value != null)
                anEmployee.DOB = dtpDoB.Value;
            anEmployee.MobileNumber = txtMobileNumber.Text.Trim();
            anEmployee.EmailAddress = txtEmailAddress.Text.Trim();
            anEmployee.DesignationID = Convert.ToInt32(cboDesignation.SelectedValue);
            anEmployee.EducationID = Convert.ToInt32(cboEducation.SelectedValue);
            anEmployee.MaritualStatusID = Convert.ToInt32(cboMaritialStatus.SelectedValue);
            anEmployee.SexID = Convert.ToInt32(cboSex.SelectedValue);
            anEmployee.IsActive = Convert.ToBoolean(cboStatus.SelectedValue);
            if (!String.IsNullOrEmpty(imagename))
            {
                FileStream fs;
                fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read);

                //a byte array to read the image

                byte[] picbyte = new byte[fs.Length];

                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));

                fs.Close();
                anEmployee.Photo = picbyte;
            }
            return anEmployee;
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'logProDeskDBDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.logProDeskDBDataSet.Employee);

        }

        private void dgvEmployeeDetail_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployeeDetail.SelectedRows)
            {
                int id =Convert.ToInt32( row.Cells[0].Value);
                LoadEmployeeDetail(id);
               // string value1 = row.Cells[0].Value.ToString();
               // string value2 = row.Cells[1].Value.ToString();
                //...
            }
        }

        private void LoadEmployeeDetail(int id)
        {
            var empNo = from data in db.Employees
                        where data.Id == id
                        select data;

            if (empNo.Any())
            {
                PopulateEmployeeInfo(empNo.FirstOrDefault());
                lblEmployeeID.Text = id.ToString();
            }
        }

        private void PopulateEmployeeInfo(Employee employee)
        {
            cboCompany.SelectedValue = employee.CompanyID == null ? 0 : employee.CompanyID;
            cboBranch.SelectedValue = employee.BranchID == null ? 0 : employee.BranchID;
            cboDepartment.SelectedValue= employee.DepartmentID == null ? 0 : employee.DepartmentID;

            txtEmployeeNo.Text = employee.EmployeeNo;
            txtFullName.Text = employee.FullName;
            txtUserName.Text = employee.UserName;
            txtPassword.Text = employee.Password;
            txtEmailAddress.Text = employee.EmailAddress;
            dtpDoB.Text = employee.DOB.ToString();
            dtpJoinDate.Text = employee.JoinDate.ToString(); 
            cboRole.SelectedValue = employee.RoleID == null ? 0 : employee.RoleID;
            cboDesignation.SelectedValue  = employee.DesignationID == null ? 0 : employee.DesignationID;
            cboEducation.SelectedValue = employee.EducationID == null ? 0 : employee.EducationID;
            cboMaritialStatus.SelectedValue = employee.MaritualStatusID == null ? 0 : employee.MaritualStatusID;
            cboSex.SelectedValue = employee.SexID == null ? 0 : employee.SexID;
            cboStatus.SelectedValue = employee.IsActive == null ? 0 : Convert.ToInt32(employee.IsActive);

            if (employee.Photo != null)
            {
                ptbPhoto.Image = (Bitmap)((new ImageConverter()).ConvertFrom(employee.Photo));
                ptbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
                ptbPhoto.Image = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearchText.Text.Trim()))
            {
                PopulateEmployeeGrid();
                return;
            }
            var results = (from employee in db.Employees
                           join company in db.Companies on employee.CompanyID equals company.Id into ec
                           from ec1 in ec.DefaultIfEmpty()
                           join branch in db.Branches on employee.BranchID equals branch.Id into eb
                           from eb1 in eb.DefaultIfEmpty()
                           join department in db.Departments on employee.DepartmentID equals department.Id into ed
                           from ed1 in ed.DefaultIfEmpty()
                           join designation in db.Designations on employee.DesignationID equals designation.Id into edg
                           from edg1 in edg.DefaultIfEmpty()
                           join education in db.Educations on employee.EducationID equals education.Id into ee
                           from ee1 in ee.DefaultIfEmpty()
                           join maritialStatus in db.MaritialStatus on employee.MaritualStatusID equals maritialStatus.Id into em
                           from em1 in em.DefaultIfEmpty()
                           join role in db.Roles on employee.RoleID equals role.Id into er
                           from er1 in er.DefaultIfEmpty()
                           join sex in db.Sexes on employee.SexID equals sex.Id into es
                           from es1 in es.DefaultIfEmpty()
                           where employee.IsDeleted == false && (employee.FullName.Contains(txtSearchText.Text.Trim()) || employee.FullName.Contains(txtSearchText.Text.Trim()))

                           select new
                           {
                               employee.Id,
                               Company = ec1.Name,
                               Branch = eb1.Name,
                               DepartmentName = ed1.Name,
                               employee.EmployeeNo,
                               employee.FullName,
                               employee.UserName,
                               Role = er1.Name,
                               employee.JoinDate,
                               Designation = edg1.Name,
                               Education = ee1.Name,
                               employee.DOB,
                               employee.EmailAddress,
                               employee.MobileNumber,
                               MaritialStatus = em1.Name,
                               Gender = es1.Name,
                               Status = employee.IsActive == true ? "Active" : "Inactive",
                               Photo = employee.Photo
                           }).ToList();
            dgvEmployeeDetail.DataSource = results;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateEmployeeInfo(new Employee());
            lblEmployeeID.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(lblEmployeeID.Text.ToString()))
                id = Convert.ToInt32(lblEmployeeID.Text.ToString());
            if (id == 0)
                return;
            if (CheckValidation(true, id))
            {
                
                try
                {
                    Employee anEmployee = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                    anEmployee = LoadEmployeeData(anEmployee);
                    anEmployee.LastUpdateDate = DateTime.Now;
                    db.Employees.Attach(anEmployee);
                    db.Entry(anEmployee).State = EntityState.Modified;
                    // db.Employees.Add(anEmployee);
                    var result = db.SaveChanges();
                    PopulateEmployeeGrid();
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
            if (!String.IsNullOrEmpty(lblEmployeeID.Text.ToString()))
                id = Convert.ToInt32(lblEmployeeID.Text.ToString());
            if (id == 0)
                return;
            try
            {
                Employee anEmployee = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                // anEmployee = LoadEmployeeData(anEmployee);
                anEmployee.IsDeleted = true;
                anEmployee.IsActive = false;
                anEmployee.LastUpdateDate = DateTime.Now;
                db.Employees.Attach(anEmployee);
                db.Entry(anEmployee).State = EntityState.Modified;
                // db.Employees.Add(anEmployee);
                var result = db.SaveChanges();
                PopulateEmployeeGrid();
                MessageBox.Show("Record Deleted Successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvEmployeeDetail, sfd.FileName); 
            }
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count - 1; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count-1; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }
    }
}
