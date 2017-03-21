using LogProDesk.Entity;
using LogProDesk.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogProDesk.Fomrs.Authentications
{
    public partial class frmLogin : Form
    {
        DBContext db;
        public frmLogin()
        {
            InitializeComponent();
            
            db = new DBContext();
            PupulateDorpDownData();
            txtPassword.PasswordChar = '*';
            int usrID = UserSessions.UserID;
        }
        private void PupulateDorpDownData()
        {
            PupulateCompanyDDL();
           
        }
        private void PupulateCompanyDDL()
        {
            List<Company> companyList = new List<Company> ();
            foreach (var item in db.Companies.ToList().OrderBy(o => o.Name).Where(x => x.IsDeleted == false))
            {
                companyList.Add(item);
            }
            cboCompany.DataSource = companyList;
            cboCompany.ValueMember = "id";
            cboCompany.DisplayMember = "name";
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                int compnayId = Convert.ToInt32(cboCompany.SelectedValue);
               // User aUser = new User();
                var result = from data in db.Users
                             where data.UserName == txtUserName.Text.Trim().ToString()  
                                 && data.Password == txtPassword.Text.Trim().ToString()
                                 && data.CompanyID== compnayId
                                 && data.IsDeleted != true 
                                 && data.IsActive == true
                             select data;

                if (result.Any())
                {
                    UserSessions.UserID = result.FirstOrDefault().Id;
                    UserSessions.RoleID = result.FirstOrDefault().RoleID;
                    UserSessions.CompanyID = compnayId;
                    UserSessions.IsSystemAdmin = result.FirstOrDefault().IsSystemAdmin;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid User Credential, please try again or contact with system administrator.", "Login Failed!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
        }

        private bool CheckValidation()
        {
            string errorMessage = "";

            //Check UserName Data
            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorMessage += "UserName Required. ";
            }
            
            //Check Company Data
            if (Convert.ToInt32(cboCompany.SelectedValue) == 0)
            {
                errorMessage += "Company Required. ";
            }
            

            if (!String.IsNullOrEmpty(errorMessage))
            {
                // lblErrorMessage.Text = errorMessage;
                MessageBox.Show(errorMessage, "Validation Failed!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show(errorMessage);
                return false;
            }
            else
            {
                //lblErrorMessage.Text = "";
                return true;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
