﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities
{
    public class ScheduleCell : EntityBase
    {
        [ForeignKey(nameof(Lesson))]
        public Guid LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public int LessonNumber { get; set; }

        public DayOfWeek Day { get; set; }

        public string Room { get; set; }
    }
}