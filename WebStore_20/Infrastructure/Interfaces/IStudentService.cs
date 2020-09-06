using System.Collections.Generic;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс для работы со студентами
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Получение списка студентов
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudentViewModel> GetAll();

        /// <summary>
        /// Получение студента по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        StudentViewModel GetById(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить нового
        /// </summary>
        /// <param name="model"></param>
        void AddNew(StudentViewModel model);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
