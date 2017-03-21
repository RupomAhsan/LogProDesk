namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Branch")]
    public partial class Branch
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int CompanyID { get; set; }

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

        public bool? IsDeleted { get; set; }
    }
}
