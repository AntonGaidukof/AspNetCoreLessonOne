using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        public IActionResult Students()
        {
            return View("StudentsTabel", _studentService.GetAll());
        }

        public IActionResult StudentDetails(int id)
        {
            //Получаем студента по Id
            var student = _studentService.GetById(id);

            //Если такого не существует
            if (student == null)
                return NotFound(); // возвращаем результат 404 Not Found

            //Иначе возвращаем студента
            return View("StudentDetails", student);
        }

        /// <summary>
        /// Добавление или редактирование студента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new StudentViewModel());

            var model = _studentService.GetById(id.Value);
            if (model == null)
                return NotFound();// возвращаем результат 404 Not Found

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel model)
        {
            if (model.Id > 0) // если есть Id, то редактируем модель
            {
                var dbItem = _studentService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.MiddleName = model.MiddleName;
                dbItem.Specialty = model.Specialty;
                dbItem.Course = model.Course;
            }
            else // иначе добавляем модель в список
            {
                _studentService.AddNew(model);
            }
            _studentService.Commit(); // станет актуальным позднее (когда добавим БД)

            return RedirectToAction(nameof(Students));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction(nameof(Students));
        }
    }
}
