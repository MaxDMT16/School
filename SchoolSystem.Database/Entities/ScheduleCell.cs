using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities
{
    public class ScheduleCell : EntityBase
    {
        [ForeignKey(nameof(Lesson))]
        public Guid LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public byte LessonNumber { get; set; }

        public DayOfWeek Day { get; set; }

        public int Room { get; set; }
    }
}