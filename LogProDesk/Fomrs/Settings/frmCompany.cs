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
    public partial class frmCompany : Form
    {
        DBContext db;
        string imagename;
        int count = 0;
        public frmCompany()
        {
            db = new DBContext();
            InitializeComponent();
            PupulateDorpDownData();
            BindListBox();

            
        }

        private void PupulateDorpDownData()
        {
            PupulateStatusDDL();
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
            List<Company> companyList = new List<Company> { new Company { Id = 0, Name = "--- Please Select ---" } };
            foreach (var item in db.Companies.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                companyList.Add(item);
            }
            ltbCompanyList.DataSource = companyList;
            ltbCompanyList.ValueMember = "id";
            ltbCompanyList.DisplayMember = "name";
        }

        private void ltbCompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbCompanyList.SelectedIndex > 0)
            {
                GetData(ltbCompanyList.SelectedValue);
            }
            else {
                GetData(0);
            }
        }

        private void GetData(object selectedValue)
        {
            int ID = Convert.ToInt32(selectedValue);
            Company aCompany = new Company();
            if (ID!=0)
                aCompany = db.Companies.OrderBy(o => o.Name).Where(x => x.IsDeleted == false&&x.Id== ID ).FirstOrDefault();

            PopulateFormData(aCompany);
        }

        private void PopulateFormData(Company aCompany)
        {
            lblID.Text = aCompany.Id.ToString();
            txtAddress1.Text= aCompany.Address1 ;
            txtAddress2.Text= aCompany.Address2 ;
            txtContactNumber.Text= aCompany.ContactNumber;
            txtEmail.Text= aCompany.Email;
            txtName.Text= aCompany.Name;
            txtSlogan.Text= aCompany.Slogan;
            txtWeb.Text= aCompany.Website;
            
            dtpExpiredDate.Text= aCompany.ExpiredDate.ToString()== "01/01/0001 12:00:00 AM"? "": aCompany.ExpiredDate.ToString();
            cboStatus.SelectedValue = aCompany.IsActive == null ? 0 : Convert.ToInt32(aCompany.IsActive);

            if (aCompany.Logo != null)
            {
                ptbPhoto.Image = (Bitmap)((new ImageConverter()).ConvertFrom(aCompany.Logo));
                ptbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
                ptbPhoto.Image = null;
        }
               

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateFormData(new Company());
            lblID.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Company aCompany = new Company();
                aCompany = LoadCompanyData(aCompany);
                try
                {
                    db.Companies.Add(aCompany);
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

        private Company LoadCompanyData(Company aCompany)
        {
            aCompany.Address1 = txtAddress1.Text;
            aCompany.Address2 = txtAddress2.Text;
            aCompany.ContactNumber = txtContactNumber.Text;
            aCompany.Email = txtEmail.Text;
            aCompany.Name = txtName.Text;
            aCompany.Slogan = txtSlogan.Text;
            aCompany.Website = txtWeb.Text;
            aCompany.IsDeleted = false;
            if (dtpExpiredDate.Value != null)
                aCompany.ExpiredDate = dtpExpiredDate.Value;
            aCompany.IsActive = Convert.ToBoolean(cboStatus.SelectedValue);
            if (!String.IsNullOrEmpty(imagename))
            {
                FileStream fs;
                fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read);

                //a byte array to read the image

                byte[] picbyte = new byte[fs.Length];

                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));

                fs.Close();
                aCompany.Logo = picbyte;
            }
            return aCompany;
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
                        var result = from data in db.Companies
                                    where data.Name == txtName.Text.Trim().ToString() && data.IsDeleted != true
                                    select data;

                        if (result.Any())
                        {
                            errorMessage += "Name already Exists. ";
                        }
                    }
                    else
                    {
                        var result = from data in db.Companies
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
                    Company aCompany = db.Companies.Where(x => x.Id == id).FirstOrDefault();
                    aCompany = LoadCompanyData(aCompany);
                    aCompany.UpdatedDate = DateTime.Now;
                    db.Companies.Attach(aCompany);
                    db.Entry(aCompany).State = EntityState.Modified;
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
                    Company aCompany = db.Companies.Where(x => x.Id == id).FirstOrDefault();
                    //aCompany = LoadCompanyData(aCompany);
                    aCompany.UpdatedDate = DateTime.Now;
                    aCompany.IsDeleted = true;
                    db.Companies.Attach(aCompany);
                    db.Entry(aCompany).State = EntityState.Modified;
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

                    ptbPhoto.Image = System.Drawing.Image.FromFile(imagename);

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
    }
}
