using AspNetCoreLessonOne.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreLessonOne.Controllers
{
    public class EmployeeController : Controller
    {
        private List<EmployeeViewModel> _employees;

        public EmployeeController()
        {
            _employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    FirstName = "Иван ",
                    SurName = "Иванов",
                    MiddleName = "Иванович",
                    Age = 18
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    FirstName = "Петр ",
                    SurName = "Петров",
                    MiddleName = "Петрович",
                    Age = 22
                }
            };
        }

        public IActionResult Detailed(long id)
        {
            var result = _employees.FirstOrDefault(e => e.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View("EmployeeDetails", result);
        }

        public IActionResult GetAll()
        {
            return View("EmployeesTabel", _employees);
        }
    }
}
