namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayDetail")]
    public partial class HolidayDetail
    {
        public int Id { get; set; }

        public int HolidayID { get; set; }

        [Column(TypeName = "date")]
        public DateTime HolidayDate { get; set; }

        public int FinancialYear { get; set; }

        [Required]
        [StringLength(50)]
        public string DayName { get; set; }

        [Required]
        [StringLength(50)]
        public string DaySequence { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Holiday Holiday { get; set; }

        public virtual User User_CreatedBy { get; set; }
    }
}
