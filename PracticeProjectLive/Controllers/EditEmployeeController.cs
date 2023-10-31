using Microsoft.AspNetCore.Mvc;
using PracticeProjectLive.Empmodel;
using PracticeProjectLive.Models;
using System.Linq;

namespace PracticeProjectLive.Controllers
{
    public class EditEmployeeController : Controller
    {

        DemoLiveContext _db;
        public EditEmployeeController()
        {
            _db = new DemoLiveContext();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditEmployee(ViewModel viewModel)
        {
            var Empl = _db.TblEmployee.Where(x => x.Eid == viewModel.EmpId).FirstOrDefault();
            _db.Remove(Empl);
            _db.Add(viewModel);
            return RedirectToAction("EmpIndex");
        }

    }
}
