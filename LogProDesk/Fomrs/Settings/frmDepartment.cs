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

namespace LogProDesk.Fomrs.Settings
{
    public partial class frmDepartment : Form
    {
        DBContext db;
        string imagename;
        int count = 0;
        public frmDepartment()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "Department";
            BindListBox();            
        }

        private void BindListBox()
        {
            List<Department> departmentList = new List<Department> { new Department { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Departments.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                departmentList.Add(item);
            }
            ltbDepartmentList.DataSource = departmentList;
            ltbDepartmentList.ValueMember = "id";
            ltbDepartmentList.DisplayMember = "name";
        }
        
        private void ltbDepartmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            count ++;
           // if(count!=1)
              //  GetData((Department)ltbDepartmentList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            Department aDepartment = new Department();
            if (ID!=0)
                aDepartment = db.Departments.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aDepartment);
        }

        private void PopulateFormData(Department aDepartment)
        {
            lblID.Text = aDepartment.Id.ToString();
            txtName.Text= aDepartment.Name;
        }

        private void ltbDepartmentList_Click(object sender, EventArgs e)
        {
            GetData(ltbDepartmentList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new Department());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Department aDepartment = new Department();
                aDepartment = LoadDepartmentData(aDepartment);
                try
                {
                    db.Departments.Add(aDepartment);
                    var result = db.SaveChanges();
                    BindListBox();
                    MessageBox.Show("Record Inserted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Department LoadDepartmentData(Department aDepartment)
        {
            aDepartment.Name = txtName.Text;
            aDepartment.IsDeleted = false;          
            return aDepartment;
        }

        private bool CheckValidation(bool isUpdate = false, int? ID = null)
        {
            string errorMessage = "";
            
            //Check Name Data
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
                        var result = from data in db.Departments
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Departments
                                     where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true && data.Id != ID
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                }
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
                    Department aDepartment = db.Departments.Where(x => x.Id == id).FirstOrDefault();
                    aDepartment = LoadDepartmentData(aDepartment);
                    //aDepartment.UpdatedDate = DateTime.Now;
                    db.Departments.Attach(aDepartment);
                    db.Entry(aDepartment).State = EntityState.Modified;
                    // db.Employees.Add(anEmployee);
                    var result = db.SaveChanges();
                    BindListBox();
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
                    Department aDepartment = db.Departments.Where(x => x.Id == id).FirstOrDefault();
                    //aDepartment = LoadDepartmentData(aDepartment);
                    //aDepartment.UpdatedDate = DateTime.Now;
                    aDepartment.IsDeleted = true;
                    db.Departments.Attach(aDepartment);
                    db.Entry(aDepartment).State = EntityState.Modified;
                    // db.Employees.Add(anEmployee);
                    var result = db.SaveChanges();
                    BindListBox();
                    MessageBox.Show("Record Deleted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        
    }
}
