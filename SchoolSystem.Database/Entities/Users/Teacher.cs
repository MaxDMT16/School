using System.Collections.Generic;

namespace SchoolSystem.Database.Entities.Users
{
    public class Teacher : UserBase
    {
        public ICollection<TeacherLesson> TeachersLessons { get; set; }
    }
}