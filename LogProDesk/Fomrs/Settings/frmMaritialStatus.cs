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
    public partial class frmMaritialStatus : Form
    {
        DBContext db;
        string imagename;
        int count = 0;
        public frmMaritialStatus()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "MaritialStatus";
            BindListBox();            
        }

        private void BindListBox()
        {
            List<MaritialStatu> departmentList = new List<MaritialStatu> { new MaritialStatu { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.MaritialStatus.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                departmentList.Add(item);
            }
            ltbMaritialStatusList.DataSource = departmentList;
            ltbMaritialStatusList.ValueMember = "id";
            ltbMaritialStatusList.DisplayMember = "name";
        }
        
        private void ltbMaritialStatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            count ++;
           // if(count!=1)
              //  GetData((MaritialStatus)ltbMaritialStatusList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            MaritialStatu aMaritialStatus = new MaritialStatu();
            if (ID!=0)
                aMaritialStatus = db.MaritialStatus.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aMaritialStatus);
        }

        private void PopulateFormData(MaritialStatu aMaritialStatus)
        {
            lblID.Text = aMaritialStatus.Id.ToString();
            txtName.Text= aMaritialStatus.Name;
        }

        private void ltbMaritialStatusList_Click(object sender, EventArgs e)
        {
            GetData(ltbMaritialStatusList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new MaritialStatu());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                MaritialStatu aMaritialStatus = new MaritialStatu();
                aMaritialStatus = LoadMaritialStatusData(aMaritialStatus);
                try
                {
                    db.MaritialStatus.Add(aMaritialStatus);
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

        private MaritialStatu LoadMaritialStatusData(MaritialStatu aMaritialStatus)
        {
            aMaritialStatus.Name = txtName.Text;
            aMaritialStatus.IsDeleted = false;          
            return aMaritialStatus;
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
                        var result = from data in db.MaritialStatus
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.MaritialStatus
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
                    MaritialStatu aMaritialStatus = db.MaritialStatus.Where(x => x.Id == id).FirstOrDefault();
                    aMaritialStatus = LoadMaritialStatusData(aMaritialStatus);
                    //aMaritialStatus.UpdatedDate = DateTime.Now;
                    db.MaritialStatus.Attach(aMaritialStatus);
                    db.Entry(aMaritialStatus).State = EntityState.Modified;
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
                    MaritialStatu aMaritialStatus = db.MaritialStatus.Where(x => x.Id == id).FirstOrDefault();
                    //aMaritialStatus = LoadMaritialStatusData(aMaritialStatus);
                    //aMaritialStatus.UpdatedDate = DateTime.Now;
                    aMaritialStatus.IsDeleted = true;
                    db.MaritialStatus.Attach(aMaritialStatus);
                    db.Entry(aMaritialStatus).State = EntityState.Modified;
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
