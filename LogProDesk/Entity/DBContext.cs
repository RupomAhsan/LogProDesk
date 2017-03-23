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
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<HolidayDetail> HolidayDetails { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<MaritalStatu> MaritalStatus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleAssign> ScheduleAssigns { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftDetail> ShiftDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                .WithRequired(e => e.AttendanceState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Holidays)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Shifts)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.TimeTables)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Slogan)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Branches)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Leaves)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ScheduleAssigns)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Holiday>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Holiday>()
                .HasMany(e => e.HolidayDetails)
                .WithRequired(e => e.Holiday)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HolidayDetail>()
                .Property(e => e.DayName)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayDetail>()
                .Property(e => e.DaySequence)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<LeaveType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<LeaveType>()
                .HasMany(e => e.Leaves)
                .WithRequired(e => e.LeaveType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaritalStatu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MaritalStatu>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.MaritalStatu)
                .HasForeignKey(e => e.MaritalStatusID);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .HasMany(e => e.ScheduleAssigns)
                .WithRequired(e => e.Schedule)
                .HasForeignKey(e => e.SheduleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScheduleAssign>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.ScheduleAssign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sex>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Shift>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Shift>()
                .HasMany(e => e.ShiftDetails)
                .WithRequired(e => e.Shift)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShiftDetail>()
                .Property(e => e.Day)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftDetail>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.ShiftDetail)
                .HasForeignKey(e => e.ShifDetailID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TimeTable>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TimeTable>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.TimeTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Attendances_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Attendances_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AttendanceStates_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Branches_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Companies_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Companies_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Departments_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Designations_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Educations_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employees_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employees_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Holidays_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Holidays_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HolidayDetails_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Leaves_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Leaves_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LeaveTypes_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MaritalStatus_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Schedules_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Schedules_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ScheduleAssigns_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ScheduleAssigns_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Sexes_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Shifts_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Shifts_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ShiftDetails_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ShiftDetails_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TimeTables_CreatedBy)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TimeTables_UpdatedBy)
                .WithOptional(e => e.User_UpdatedBy)
                .HasForeignKey(e => e.UpdatedBy);
        }
    }
}
