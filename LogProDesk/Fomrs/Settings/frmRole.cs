using LogProDesk.Entity;
using LogProDesk.Utility;
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
    public partial class frmRole : BaseForm
    {
        DBContext db;
        public frmRole()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "Role";
            BindListBox();            
        }

        private void BindListBox()
        {
            List<Role> roleList = new List<Role> { new Role { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Roles.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                roleList.Add(item);
            }
            ltbRoleList.DataSource = roleList;
            ltbRoleList.ValueMember = "id";
            ltbRoleList.DisplayMember = "name";
        }
        
        private void ltbRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // count ++;
           // if(count!=1)
              //  GetData((Role)ltbRoleList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            Role aRole = new Role();
            if (ID!=0)
                aRole = db.Roles.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aRole);
        }

        private void PopulateFormData(Role aRole)
        {
            lblID.Text = aRole.Id.ToString();
            txtName.Text= aRole.Name;
        }

        private void ltbRoleList_Click(object sender, EventArgs e)
        {
            GetData(ltbRoleList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new Role());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Role aRole = new Role();
                aRole = LoadRoleData(aRole);
                try
                {
                    aRole.CreatedBy = UserSessions.UserID;
                    aRole.CreatedDate = DateTime.Now;
                    aRole.IsDeleted = false;
                    db.Roles.Add(aRole);
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

        private Role LoadRoleData(Role aRole)
        {
            aRole.Name = txtName.Text;
            aRole.IsDeleted = false;          
            return aRole;
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
                        var result = from data in db.Roles
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Roles
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
                    Role aRole = db.Roles.Where(x => x.Id == id).FirstOrDefault();
                    aRole = LoadRoleData(aRole);
                    //aRole.UpdatedDate = DateTime.Now;
                    db.Roles.Attach(aRole);
                    db.Entry(aRole).State = EntityState.Modified;
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
                    Role aRole = db.Roles.Where(x => x.Id == id).FirstOrDefault();
                    //aRole = LoadRoleData(aRole);
                    //aRole.UpdatedDate = DateTime.Now;
                    aRole.IsDeleted = true;
                    db.Roles.Attach(aRole);
                    db.Entry(aRole).State = EntityState.Modified;
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
