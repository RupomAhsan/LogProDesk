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
    public partial class frmBranch : BaseForm
    {
        DBContext db;
        public frmBranch()
        {
            db = new DBContext();
            InitializeComponent();
            lblTitle.Text = "Branch";
            PupulateDorpDownData();
            BindListBox();

            
        }

        private void PupulateDorpDownData()
        {
            PupulateStatusDDL();
            PupulateCompanyDDL();
        }

        private void PupulateStatusDDL()
        {
            SortedDictionary<string, int> statusData = new SortedDictionary<string, int>
            {
              {"Active", 1},
              {"Inctive", 0}
            };
            cboCompany.DataSource = new BindingSource(statusData, null);
            cboCompany.DisplayMember = "Key";
            cboCompany.ValueMember = "Value";
        }

        private void BindListBox()
        {
            List<Branch> branchList = new List<Branch> { new Branch { Id = 0, Name = "--Please Select--" } };
            foreach (var item in db.Branches.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                branchList.Add(item);
            }
            ltbBranchList.DataSource = branchList;
            ltbBranchList.ValueMember = "id";
            ltbBranchList.DisplayMember = "name";
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
        private void ltbBranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // count ++;
           // if(count!=1)
              //  GetData((Branch)ltbBranchList.SelectedValue);
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            Branch aBranch = new Branch();
            if (ID!=0)
                aBranch = db.Branches.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aBranch);
        }

        private void PopulateFormData(Branch aBranch)
        {
            lblID.Text = aBranch.Id.ToString();
            txtName.Text= aBranch.Name;
            cboCompany.SelectedValue = aBranch.CompanyID;
        }

        private void ltbBranchList_Click(object sender, EventArgs e)
        {
            GetData(ltbBranchList.SelectedValue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new Branch());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Branch aBranch = new Branch();
                aBranch = LoadBranchData(aBranch);
                try
                {
                    aBranch.CreatedBy = UserSessions.UserID;
                    aBranch.CreatedDate = DateTime.Now;
                    aBranch.IsDeleted = false;
                    db.Branches.Add(aBranch);
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

        private Branch LoadBranchData(Branch aBranch)
        {
            aBranch.Name = txtName.Text;
            aBranch.IsDeleted = false;
            aBranch.CompanyID = Convert.ToInt32(cboCompany.SelectedValue);            
            return aBranch;
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
                        var result = from data in db.Branches
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Branches
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
                    Branch aBranch = db.Branches.Where(x => x.Id == id).FirstOrDefault();
                    aBranch = LoadBranchData(aBranch);
                    //aBranch.UpdatedDate = DateTime.Now;
                    db.Branches.Attach(aBranch);
                    db.Entry(aBranch).State = EntityState.Modified;
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
                    Branch aBranch = db.Branches.Where(x => x.Id == id).FirstOrDefault();
                    //aBranch = LoadBranchData(aBranch);
                    //aBranch.UpdatedDate = DateTime.Now;
                    aBranch.IsDeleted = true;
                    db.Branches.Attach(aBranch);
                    db.Entry(aBranch).State = EntityState.Modified;
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
