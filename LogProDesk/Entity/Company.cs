namespace LogProDesk.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Slogan { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Website { get; set; }

        [StringLength(250)]
        public string Address1 { get; set; }

        [StringLength(250)]
        public string Address2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? ExpiredDate { get; set; }

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

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
