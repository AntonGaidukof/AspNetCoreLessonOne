namespace AspNetCoreLessonOne.Models
{
    public class StudentViewModel
    {
        public long Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Course { get; set; }
        public string Specialty { get; set; }
    }
}
