using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Database.Entities.Users
{
    public class Teacher : UserBase
    {
        public ICollection<TeacherLesson> TeachersLessons { get; set; }
    }
}