using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonResponse : IQueryResult
    {
        public Guid Id { get; set; }

        public ICollection<Guid> TeacherIds { get; set; }
        
        public Guid GroupId { get; set; }

        public SubjectInfo Subject { get; set; }

        public class SubjectInfo
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }

}