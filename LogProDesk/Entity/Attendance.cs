namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance")]
    public partial class Attendance
    {
        public int Id { get; set; }

        public int? EmployeeID { get; set; }

        public int? ScheduleAssignID { get; set; }

        public int? AttendanceSateID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? Time { get; set; }

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

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool? UpdateReason { get; set; }

        public bool? IsUpdated { get; set; }

        public bool? IsUpdateApproved { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public bool? IsAbsent { get; set; }

        public bool? IsOnLeave { get; set; }

        public bool? IsLate { get; set; }

        public bool? IsOverTime { get; set; }

        public bool? IsEarlyLeave { get; set; }
    }
}
