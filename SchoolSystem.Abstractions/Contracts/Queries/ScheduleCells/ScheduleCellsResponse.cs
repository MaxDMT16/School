﻿using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells
{
    public class ScheduleCellsResponse : IQueryResult
    {
        public IEnumerable<ScheduleCell> ScheduleCells { get; set; }

        public class ScheduleCell
        {
            public Guid Id { get; set; }
            public Guid LessonId { get; set; }
            public byte LessonNumber { get; set; }
            public DayOfWeek Day { get; set; }
            public int Room { get; set; }
        }
    }
}