using LogProDesk.Entity;
using LogProDesk.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogProDesk.Fomrs.Authentications
{
    public partial class frmChangePassword : BaseForm
    {
        DBContext db;
        public frmChangePassword()
        {
            InitializeComponent();
            db = new DBContext();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                User aUser = db.Users.Where(x => x.Id == UserSessions.UserID).FirstOrDefault();
                aUser.Password = txtConfirmPassword.Text;
                aUser.PasswordUpdateDate = DateTime.Now;
                aUser.PasswordUpdateBy = UserSessions.UserID;

                db.Users.Attach(aUser);
                db.Entry(aUser).State = EntityState.Modified;
                var result = db.SaveChanges();
                MessageBox.Show("Password Changed Successfully.");
            }
        }

        private bool CheckValidation()
        {
            string errorMessage = "";
            //Check Password Data
            if (String.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                errorMessage += "New Password Required. ";
            }


            //Check Password Matching Data
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
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
                return true;

            }
        }
    }
}
