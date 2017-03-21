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
    public partial class frmEducation : Form
    {
        DBContext db;
        string imagename;
        int count = 0;
        public frmEducation()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "Education";
            BindListBox();            
        }

        private void BindListBox()
        {
            List<Education> educationList = new List<Education> { new Education { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Educations.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                educationList.Add(item);
            }
            ltbEducationList.DataSource = educationList;
            ltbEducationList.ValueMember = "id";
            ltbEducationList.DisplayMember = "name";
        }
        
        private void ltbEducationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            count ++;
           // if(count!=1)
              //  GetData((Education)ltbEducationList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            Education aEducation = new Education();
            if (ID!=0)
                aEducation = db.Educations.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aEducation);
        }

        private void PopulateFormData(Education aEducation)
        {
            lblID.Text = aEducation.Id.ToString();
            txtName.Text= aEducation.Name;
        }

        private void ltbEducationList_Click(object sender, EventArgs e)
        {
            GetData(ltbEducationList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new Education());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Education aEducation = new Education();
                aEducation = LoadEducationData(aEducation);
                try
                {
                    db.Educations.Add(aEducation);
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

        private Education LoadEducationData(Education aEducation)
        {
            aEducation.Name = txtName.Text;
            aEducation.IsDeleted = false;          
            return aEducation;
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
                        var result = from data in db.Educations
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Educations
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
                    Education aEducation = db.Educations.Where(x => x.Id == id).FirstOrDefault();
                    aEducation = LoadEducationData(aEducation);
                    //aEducation.UpdatedDate = DateTime.Now;
                    db.Educations.Attach(aEducation);
                    db.Entry(aEducation).State = EntityState.Modified;
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
                    Education aEducation = db.Educations.Where(x => x.Id == id).FirstOrDefault();
                    //aEducation = LoadEducationData(aEducation);
                    //aEducation.UpdatedDate = DateTime.Now;
                    aEducation.IsDeleted = true;
                    db.Educations.Attach(aEducation);
                    db.Entry(aEducation).State = EntityState.Modified;
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
