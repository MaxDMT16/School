using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities.Users
{
    public class Pupil : User
    {
        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }

        public Group Group { get; set; }
    }
}