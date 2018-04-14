using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Database.Entities.Users;

namespace SchoolSystem.Database.Entities
{
    public class Lesson : EntityBase
    {
        [ForeignKey(nameof(Teacher))]
        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public Subject Subject { get; set; }
    }
}