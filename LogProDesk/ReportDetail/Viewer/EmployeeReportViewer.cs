using LogProDesk.Entity;
using LogProDesk.ReportDetail.Datasets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogProDesk.ReportDetail.Viewer
{
    public partial class EmployeeReportViewer :Form
    {
        public EmployeeReportViewer()
        {
            InitializeComponent();
        }

        private void EmployeeReportViewer_Load(object sender, EventArgs e)
        {
            DBContext db = new DBContext();
            this.reportViewer1.RefreshReport();

            var results = (from employee in db.Employees
                           //join company in db.Companies on employee.CompanyID equals company.Id into ec
                           //from ec1 in ec.DefaultIfEmpty()
                           join branch in db.Branches on employee.BranchID equals branch.Id into eb
                           from eb1 in eb.DefaultIfEmpty()
                           join department in db.Departments on employee.DepartmentID equals department.Id into ed
                           from ed1 in ed.DefaultIfEmpty()
                           join designation in db.Designations on employee.DesignationID equals designation.Id into edg
                           from edg1 in edg.DefaultIfEmpty()
                           join education in db.Educations on employee.EducationID equals education.Id into ee
                           from ee1 in ee.DefaultIfEmpty()
                           join maritialStatus in db.MaritialStatus on employee.MaritualStatusID equals maritialStatus.Id into em
                           from em1 in em.DefaultIfEmpty()
                           join role in db.Roles on employee.RoleID equals role.Id into er
                           from er1 in er.DefaultIfEmpty()
                           join sex in db.Sexes on employee.SexID equals sex.Id into es
                           from es1 in es.DefaultIfEmpty()
                           where employee.IsDeleted == false

                           select new EmployeDetailsView
                           {
                               Id=employee.Id,
                               //Company = ec1.Name,
                               Branch = eb1.Name,
                               Department = ed1.Name,
                               EmployeeNo=employee.EmployeeNo,
                               FullName=employee.FullName,
                               UserName=employee.UserName,
                               Role = er1.Name,
                               JoinDate=employee.JoinDate,
                               Designation = edg1.Name,
                               Education = ee1.Name,
                               DOB=employee.DOB,
                               EmailAddress=employee.EmailAddress,
                               MobileNumber=employee.MobileNumber,
                               MaritualStatus = em1.Name,
                               Gender = es1.Name,
                               Status = employee.IsActive == true ? "Active" : "Inactive",
                               Photo = employee.Photo
                           }).ToList();
            
            reportViewer1.LocalReport.DataSources.Clear(); //clear report
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "LogProDesk.ReportDetail.Reports.rptEmployeeDetail.rdlc"; // bind reportviewer with .rdlc

            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("dtsEmployeeDetail", results); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = results;

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report
        }

        private void EmployeeReportViewer_ResizeEnd(object sender, EventArgs e)
        {
           // groupBox1.Width = Convert.ToInt32(this.Width * 0.9);
           // groupBox1.Height = Convert.ToInt32(this.Height * 0.9);
        }

        private void EmployeeReportViewer_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = Convert.ToInt32(this.Width * 0.97);
            groupBox1.Height = Convert.ToInt32(this.Height * 0.9);
        }
    }
}
