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
    public partial class frmDesignation : BaseForm
    {
        DBContext db;
        string imagename;
        int count = 0;
        public frmDesignation()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "Designation";
            BindListBox();            
        }

        private void BindListBox()
        {
            List<Designation> designationList = new List<Designation> { new Designation { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Designations.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                designationList.Add(item);
            }
            ltbDesignationList.DataSource = designationList;
            ltbDesignationList.ValueMember = "id";
            ltbDesignationList.DisplayMember = "name";
        }
        
        private void ltbDesignationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            count ++;
           // if(count!=1)
              //  GetData((Designation)ltbDesignationList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            Designation aDesignation = new Designation();
            if (ID!=0)
                aDesignation = db.Designations.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aDesignation);
        }

        private void PopulateFormData(Designation aDesignation)
        {
            lblID.Text = aDesignation.Id.ToString();
            txtName.Text= aDesignation.Name;
        }

        private void ltbDesignationList_Click(object sender, EventArgs e)
        {
            GetData(ltbDesignationList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new Designation());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Designation aDesignation = new Designation();
                aDesignation = LoadDesignationData(aDesignation);
                try
                {
                    aDesignation.CreatedBy = UserSessions.UserID;
                    aDesignation.CreatedDate = DateTime.Now;
                    aDesignation.IsDeleted = false;
                    db.Designations.Add(aDesignation);
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

        private Designation LoadDesignationData(Designation aDesignation)
        {
            aDesignation.Name = txtName.Text;
            aDesignation.IsDeleted = false;          
            return aDesignation;
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
                        var result = from data in db.Designations
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Designations
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
                    Designation aDesignation = db.Designations.Where(x => x.Id == id).FirstOrDefault();
                    aDesignation = LoadDesignationData(aDesignation);
                    //aDesignation.UpdatedDate = DateTime.Now;
                    db.Designations.Attach(aDesignation);
                    db.Entry(aDesignation).State = EntityState.Modified;
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
                    Designation aDesignation = db.Designations.Where(x => x.Id == id).FirstOrDefault();
                    //aDesignation = LoadDesignationData(aDesignation);
                    //aDesignation.UpdatedDate = DateTime.Now;
                    aDesignation.IsDeleted = true;
                    db.Designations.Attach(aDesignation);
                    db.Entry(aDesignation).State = EntityState.Modified;
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
