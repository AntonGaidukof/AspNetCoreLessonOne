using AspNetCoreLessonOne.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreLessonOne.Controllers
{
    public class StudentController : Controller
    {
        private List<StudentViewModel> _students;

        public StudentController()
        {
            _students = new List<StudentViewModel>
            {
                new StudentViewModel
                {
                    Id = 1,
                    FirstName = "Иван ",
                    SurName = "Иванов",
                    MiddleName = "Иванович",
                    Specialty = "СПС",
                    Course = 1
                },
                new StudentViewModel
                                {
                    Id = 2,
                    FirstName = "Петр ",
                    SurName = "Петров",
                    MiddleName = "Петрович",
                    Specialty = "БИС",
                    Course = 2
                }
            };
        }
        public IActionResult Detailed(long id)
        {
            var result = _students.FirstOrDefault(e => e.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View("StudentDetails", result);
        }

        public IActionResult GetAll()
        {
            return View("StudentsTabel", _students);
        }
    }
}
