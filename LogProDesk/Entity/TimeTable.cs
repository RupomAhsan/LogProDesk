namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeTable")]
    public partial class TimeTable
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public TimeSpan? OnDutyTime { get; set; }

        public TimeSpan? OffDutyTime { get; set; }

        public TimeSpan? BeginCheckInTime { get; set; }

        public TimeSpan? EndCheckInTime { get; set; }

        public TimeSpan? BeginCheckOutTime { get; set; }

        public TimeSpan? EndCheckOutTime { get; set; }

        public TimeSpan? MaximumLateCount { get; set; }

        public TimeSpan? MaximumEarlyCount { get; set; }

        public double? TotalWorkDays { get; set; }

        public double? TotalWorkTime { get; set; }

        public int? BranchID { get; set; }

        public bool? IsCheckInMandatory { get; set; }

        public bool? IsCheckOutMandatory { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }
    }
}
