using System.Collections.Generic;
using SchoolSystem.Database.Entities.Users;

namespace SchoolSystem.Database.Entities
{
    public class Group : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Pupil> Pupils { get; set; }
    }
}