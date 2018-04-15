using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells
{
    public class CreateScheduleCellCommand : ICommand
    {
        public Guid LessonId { get; set; }
        public byte LessonNumber { get; set; }
        public DayOfWeek Day { get; set; }
        public int Room { get; set; }
    }
}