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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            Leaves = new HashSet<Leave>();
            ScheduleAssigns = new HashSet<ScheduleAssign>();
        }

        public int Id { get; set; }

        public int BranchID { get; set; }

        [StringLength(50)]
        public string EmployeeNo { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        public int? DesignationID { get; set; }

        public int? DepartmentID { get; set; }

        public int? SexID { get; set; }

        public DateTime? DOB { get; set; }

        public int? EducationID { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        public DateTime? JoinDate { get; set; }

        public int? MaritalStatusID { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Department Department { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual Education Education { get; set; }

        public virtual MaritalStatu MaritalStatu { get; set; }

        public virtual Sex Sex { get; set; }

        public virtual User User_CreatedBy { get; set; }

        public virtual User User_UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leave> Leaves { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleAssign> ScheduleAssigns { get; set; }
    }
}
