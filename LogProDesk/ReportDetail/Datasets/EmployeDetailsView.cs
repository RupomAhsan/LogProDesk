using LogProDesk.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProDesk.ReportDetail.Datasets
{
   public class EmployeDetailsView
    {
        public int Id { get; set; }
        
        public string EmployeeNo { get; set; }
        
        public string FullName { get; set; }

        public string Designation { get; set; }

        public string Company { get; set; }

        public string Department { get; set; }

        public string Branch { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string Education { get; set; }
        
        public string MobileNumber { get; set; }
        
        public string EmailAddress { get; set; }

        public DateTime? JoinDate { get; set; }

        public string MaritualStatus { get; set; }
        
        public string Address { get; set; }

        public string Role { get; set; }

        public string IsDeleted { get; set; }

        public string Status { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string LastUpdatedBy { get; set; }
        
        private DateTime createdDate = DateTime.MinValue;
        //public DateTime CreatedOn;
        public DateTime CreatedDate
        {
            get
            {
                return (createdDate == DateTime.MinValue) ? DateTime.Now : createdDate;
            }
            set { createdDate = value; }
        }
        //  public DateTime CreatedDate { get; set; }

        public DateTime? PasswordLastUpdated { get; set; }

        public string CreatedBy { get; set; }
        
        public string Remarks { get; set; }
        
        public byte[] Photo { get; set; }
    }
}
