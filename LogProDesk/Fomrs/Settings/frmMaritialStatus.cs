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
    public partial class frmMaritalStatus : BaseForm
    {
        DBContext db;
        public frmMaritalStatus()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "MaritalStatus";
            BindListBox();            
        }

        private void BindListBox()
        {
            List<MaritalStatu> departmentList = new List<MaritalStatu> { new MaritalStatu { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.MaritalStatus.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                departmentList.Add(item);
            }
            ltbMaritalStatusList.DataSource = departmentList;
            ltbMaritalStatusList.ValueMember = "id";
            ltbMaritalStatusList.DisplayMember = "name";
        }
        
        private void ltbMaritalStatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //count ++;
           // if(count!=1)
              //  GetData((MaritalStatus)ltbMaritalStatusList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            MaritalStatu aMaritalStatus = new MaritalStatu();
            if (ID!=0)
                aMaritalStatus = db.MaritalStatus.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aMaritalStatus);
        }

        private void PopulateFormData(MaritalStatu aMaritalStatus)
        {
            lblID.Text = aMaritalStatus.Id.ToString();
            txtName.Text= aMaritalStatus.Name;
        }

        private void ltbMaritalStatusList_Click(object sender, EventArgs e)
        {
            GetData(ltbMaritalStatusList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new MaritalStatu());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                MaritalStatu aMaritalStatus = new MaritalStatu();
                aMaritalStatus = LoadMaritalStatusData(aMaritalStatus);
                try
                {
                    aMaritalStatus.CreatedBy = UserSessions.UserID;
                    aMaritalStatus.CreatedDate = DateTime.Now;
                    aMaritalStatus.IsDeleted = false;
                    db.MaritalStatus.Add(aMaritalStatus);
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

        private MaritalStatu LoadMaritalStatusData(MaritalStatu aMaritalStatus)
        {
            aMaritalStatus.Name = txtName.Text;
            aMaritalStatus.IsDeleted = false;          
            return aMaritalStatus;
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
                        var result = from data in db.MaritalStatus
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.MaritalStatus
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
                    MaritalStatu aMaritalStatus = db.MaritalStatus.Where(x => x.Id == id).FirstOrDefault();
                    aMaritalStatus = LoadMaritalStatusData(aMaritalStatus);
                    //aMaritalStatus.UpdatedDate = DateTime.Now;
                    db.MaritalStatus.Attach(aMaritalStatus);
                    db.Entry(aMaritalStatus).State = EntityState.Modified;
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
                    MaritalStatu aMaritalStatus = db.MaritalStatus.Where(x => x.Id == id).FirstOrDefault();
                    //aMaritalStatus = LoadMaritalStatusData(aMaritalStatus);
                    //aMaritalStatus.UpdatedDate = DateTime.Now;
                    aMaritalStatus.IsDeleted = true;
                    db.MaritalStatus.Attach(aMaritalStatus);
                    db.Entry(aMaritalStatus).State = EntityState.Modified;
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
