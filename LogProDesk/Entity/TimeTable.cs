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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeTable()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }

        public int BranchID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public TimeSpan OnDutyTime { get; set; }

        public TimeSpan OffDutyTime { get; set; }

        public TimeSpan? BeginCheckInTime { get; set; }

        public TimeSpan? EndCheckInTime { get; set; }

        public TimeSpan? BeginCheckOutTime { get; set; }

        public TimeSpan? EndCheckOutTime { get; set; }

        public TimeSpan? MaximumLateCount { get; set; }

        public TimeSpan? MaximumEarlyCount { get; set; }

        public double? TotalWorkDays { get; set; }

        public double? TotalWorkTime { get; set; }

        public bool? IsCheckInMandatory { get; set; }

        public bool? IsCheckOutMandatory { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual User User_CreatedBy { get; set; }

        public virtual User User_UpdatedBy { get; set; }
    }
}
