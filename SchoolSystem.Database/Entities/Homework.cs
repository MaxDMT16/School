﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolSystem.Database.Entities.Users;

namespace SchoolSystem.Database.Entities
{
    public class Homework : EntityBase
    {
        [ForeignKey(nameof(Teacher))]
        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(Lesson))]
        public Guid LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public string Info { get; set; }
    }
}