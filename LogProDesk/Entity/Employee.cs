namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string EmployeeNo { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        public int? DesignationID { get; set; }

        public int? CompanyID { get; set; }

        public int? DepartmentID { get; set; }

        public int? BranchID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Password { get; set; }

        public int? SexID { get; set; }

        public DateTime? DOB { get; set; }

        public int? EducationID { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        public DateTime? JoinDate { get; set; }

        public int? MaritualStatusID { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public int? RoleID { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int? LastUpdatedBy { get; set; }

        [DataType(DataType.DateTime)]
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

        public int? CreatedBy { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
    }
}
