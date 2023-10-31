using Microsoft.AspNetCore.Mvc;
using PracticeProjectLive.Empmodel;
using PracticeProjectLive.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PracticeProjectLive.Controllers
{
    public class EmployeeController : Controller
    {
        DemoLiveContext _db;
        public EmployeeController()
        {

            _db = new DemoLiveContext();
        }
        public IActionResult EmpIndex()
        {
            using (DemoLiveContext context = new DemoLiveContext())
            {
                var EmployeeData = from employee in context.TblEmployee
                                   join department in context.TblDepartment on employee.Did equals department.Did
                                   join company in context.TblCompany on employee.Cid equals company.Cid
                                   join details in context.TblDetails on employee.Eid equals details.Eid
                                   where employee.IsDeleted == false
                                   select new ViewModel
                                   {
                                       EmpId = employee.Eid,
                                       Employee = employee,
                                       Department = department,
                                       Company = company,
                                       AllcompanyList = context.TblCompany.ToList(),
                                       AllDepartmentList = context.TblDepartment.ToList(),
                                       Address = details.Address,
                                       Education = details.Education,
                                       Qualification = details.Qualification,
                                       QualificationYear = details.QualificationYear,
                                       Percentage = details.Percentage
                                   };

        List<ViewModel> employeeDataModels = EmployeeData.ToList();

                return View(employeeDataModels);
            }
        }



        public string Education { get; set; }
        public string Qualification { get; set; }
        public string QualificationYear { get; set; }
        public decimal? Percentage { get; set; }


        [HttpPost]
        public IActionResult EditEmployee(int EID, string EName, int CID, int DID, string Address,
            string Education, string Qualification , string QualificationYear , decimal Percentage)
        {
            try
            {
                var employee = _db.TblEmployee.FirstOrDefault(e => e.Eid == EID);

                if (employee != null)
                {
                    employee.EmpName = EName;
                    employee.Cid = CID;
                    employee.Did = DID;
                    
                    var DetailData = _db.TblDetails.FirstOrDefault(a => a.Eid == EID);

                    if (DetailData != null)
                    {
                        DetailData.Address = Address;
                        DetailData.Education = Education;
                        DetailData.Qualification = Qualification;

                         DetailData.QualificationYear = QualificationYear;
                         DetailData.Percentage = Percentage;


                    }

                  
                    _db.SaveChanges();

                    return Json(new { success = true, message = "Employee and address updated successfully" });
                }

                return Json(new { success = false, message = "Employee not found" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while updating the employee and address" });
            }
        }






        [HttpGet]
        public IActionResult PostEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostEmployee(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (DemoLiveContext entities = new DemoLiveContext())
                {
                    TblEmployee tblEmployee = new TblEmployee
                    {
                        EmpName = model.EmployeeName,
                        Did = model.DId,
                        Cid = model.Cid,
                        IsDeleted = false
                    };

                    entities.TblEmployee.Add(tblEmployee);
                    entities.SaveChanges();

                    TblDetails tblDetails = new TblDetails
                    {
                        Address = model.Address,
                        Eid = tblEmployee.Eid ,
                        Education = model.Education,
                        Qualification= model.Qualification,
                        QualificationYear = model.QualificationYear,
                        Percentage= model.Percentage

                    };

                    entities.TblDetails.Add(tblDetails);
                    entities.SaveChanges();
                }

                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Validation failed." });
        }


        [HttpDelete]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            try
            {
                var employeeToDelete = _db.TblEmployee.SingleOrDefault(x => x.Eid == EmployeeId);

                if (employeeToDelete != null)
                {
                    employeeToDelete.IsDeleted = true;
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Employee deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Employee not found." });
                }
            }
            catch (Exception )
            {

                return Json(new { success = false, message = "An error occurred while deleting the employee." });
            }
        }



        public IActionResult EmpDetails(int EmpId)
        {
            using (DemoLiveContext context = new DemoLiveContext())
            {
                var employeeData = from employee in context.TblEmployee
                                   join department in context.TblDepartment on employee.Did equals department.Did
                                   join company in context.TblCompany on employee.Cid equals company.Cid
                                   join details in context.TblDetails on employee.Eid equals details.Eid
                                   where employee.IsDeleted == false && employee.Eid == EmpId
                                   select new ViewModel
                                   {

                                       EmployeeName = employee.EmpName,
                                       EmpId = employee.Eid,
                                       Address = details.Address,
                                       Education = details.Education,
                                       Qualification = details.Qualification,
                                       QualificationYear = details.QualificationYear,
                                       Percentage = details.Percentage,
                                       Employee = employee,
                                       Department = department,
                                       Company = company,
                                       AllcompanyList = context.TblCompany.ToList(),
                                       AllDepartmentList = context.TblDepartment.ToList(),
                                   };

                ViewModel employeeDetails = employeeData.FirstOrDefault();


                return View(employeeDetails);
            }
        }




    }
}

