namespace LogProDesk.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AttendanceState> AttendanceStates { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CycleUnit> CycleUnits { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<MaritialStatu> MaritialStatus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleAssign> ScheduleAssigns { get; set; }
        public virtual DbSet<ScheduleDetail> ScheduleDetails { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceState>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceState>()
                .HasMany(e => e.Attendances)
                .WithOptional(e => e.AttendanceState)
                .HasForeignKey(e => e.AttendanceSateID);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CycleUnit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Designation>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeNo)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Holiday>()
                .Property(e => e.Name)
                .IsUnicode(false);

           

            modelBuilder.Entity<Leave>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<LeaveType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MaritialStatu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Day)
                .IsUnicode(false);

            modelBuilder.Entity<Sex>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Shift>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TimeTable>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
