using System.Collections.Generic;

namespace SchoolSystem.Database.Entities.Users
{
    public class Teacher : User
    {
        //todo: add raiting here
        public ICollection<TeacherLesson> TeachersLessons { get; set; }
    }
}