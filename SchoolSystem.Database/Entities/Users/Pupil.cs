using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Database.Entities.Users
{
    public class Pupil : UserBase
    {
        [ForeignKey(nameof(Group))] public Guid GroupId { get; set; }

        public Group Group { get; set; }
    }
}