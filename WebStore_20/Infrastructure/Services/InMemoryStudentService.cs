using System.Collections.Generic;
using System.Linq;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryStudentService : IStudentService
    {
        private List<StudentViewModel> _students;

        public InMemoryStudentService()
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

        public void AddNew(StudentViewModel model)
        {
            model.Id = _students.Count > 0
               ? _students.Max(e => e.Id) + 1
               : 1;
            _students.Add(model);
        }

        public void Commit()
        {
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return;
            }

            _students.Remove(student);
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _students;
        }

        public StudentViewModel GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }
    }
}
