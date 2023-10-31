using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using PracticeProjectLive.Empmodel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PracticeProjectLive.Models
{
    public class ViewModel
    {
        public  int  EmpId {  get; set; }
        public TblEmployee Employee { get; set; }
        public TblDepartment Department { get; set; }
        public TblCompany Company { get; set; }
        public string EmployeeName { get; set; }
        public int? Cid { get; set; }
        public int? DId { get; set; }
        public List<TblCompany> AllcompanyList { get; set; }
        public List<TblDepartment> AllDepartmentList { get; set; }
        public bool IsDeleted { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string Qualification { get; set; }
        public string QualificationYear { get; set; }
        public decimal? Percentage { get; set; }



    }
}
