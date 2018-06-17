using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities
{
    public class Lesson : EntityBase
    {
        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        [ForeignKey(nameof(Subject))]
        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }

        public ICollection<TeacherLesson> TeachersLessons { get; set; }

        public ICollection<ScheduleCell> ScheduleCells { get; set; }
    }
}