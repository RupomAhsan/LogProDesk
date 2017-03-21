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
    public partial class frmUser : Form
    {
        DBContext db;
        string imagename;
        int count = 0;
        public frmUser()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "User";
            PupulateDorpDownData();
            BindListBox();

            
        }

        private void PupulateDorpDownData()
        {
            PupulateStatusDDL();
            PupulateCompanyDDL();
            PupulateRoleDDL();
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

        private void BindListBox()
        {
            List<User> userList = new List<User> { new User { Id = 0, UserName = "--Please Select--" } };
            foreach (var item in db.Users.ToList().OrderBy(o => o.UserName).Where(x => x.IsDeleted == false))
            {
                userList.Add(item);
            }
            ltbUserList.DataSource = userList;
            ltbUserList.ValueMember = "id";
            ltbUserList.DisplayMember = "username";
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
        private void ltbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            count ++;
           // if(count!=1)
              //  GetData((User)ltbUserList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            User aUser = new User();
            if (ID!=0)
                aUser = db.Users.OrderBy(o => o.UserName).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aUser);
        }

        private void PopulateFormData(User aUser)
        {
            lblID.Text = aUser.Id.ToString();
            txtUserName.Text= aUser.UserName;
            txtPassword.Text = aUser.UserName;

            cboCompany.SelectedValue = aUser.CompanyID;
            cboStatus.SelectedValue = aUser.IsActive;
            cboRole.SelectedValue = aUser.RoleID;
        }

        private void ltbUserList_Click(object sender, EventArgs e)
        {
            GetData(ltbUserList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new User());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                User aUser = new User();
                aUser = LoadUserData(aUser);
                try
                {
                    db.Users.Add(aUser);
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

        private User LoadUserData(User aUser)
        {
            aUser.UserName = txtUserName.Text;
            aUser.IsDeleted = false;
            aUser.CompanyID = Convert.ToInt32(cboCompany.SelectedValue);            
            return aUser;
        }

        private bool CheckValidation(bool isUpdate = false, int? ID = null)
        {
            string errorMessage = "";
            
            //Check UserName Data
            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorMessage += "UserName Required. ";
            }
            else
            {
                Regex rgx = new Regex("^[\\w ]+$");
                if (!rgx.IsMatch(txtUserName.Text.Trim()))
                {
                    errorMessage += "Invalid UserName. ";
                }
                else
                {
                    if (!isUpdate)
                    {
                        var result = from data in db.Users
                                    where data.UserName == txtUserName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "UserName already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Users
                                     where data.UserName == txtUserName.Text.Trim().ToString() && data.IsDeleted != true && data.Id != ID
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "UserName already Exists. ";
                        }
                    }
                }
            }

            //Check Company Data
            if (Convert.ToInt32(cboCompany.SelectedValue) == 0)
            {
                errorMessage += "Company Required. ";
            }

            //Check Role Data
            if (Convert.ToInt32(cboStatus.SelectedValue) == 0)
            {
                errorMessage += "Status Required. ";
            }

            //Check Password Data
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorMessage += "Password Required. ";
            }
           

            //Check Password Matching Data
            if (txtPassword.Text.Trim()!= txtConfirmPassword.Text.Trim())
            {
                errorMessage += "Password not matched. ";
            }

            if (!String.IsNullOrEmpty(errorMessage))
            {
                // lblErrorMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
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
                    User aUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
                    aUser = LoadUserData(aUser);
                    //aUser.UpdatedDate = DateTime.Now;
                    db.Users.Attach(aUser);
                    db.Entry(aUser).State = EntityState.Modified;
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
                    User aUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
                    //aUser = LoadUserData(aUser);
                    //aUser.UpdatedDate = DateTime.Now;
                    aUser.IsDeleted = true;
                    db.Users.Attach(aUser);
                    db.Entry(aUser).State = EntityState.Modified;
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
