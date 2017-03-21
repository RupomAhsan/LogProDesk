namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Leave")]
    public partial class Leave
    {
        public int Id { get; set; }

        public int? LeaveTypeID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool? CancelRemarks { get; set; }

        public bool? IsCancelled { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }
    }
}
