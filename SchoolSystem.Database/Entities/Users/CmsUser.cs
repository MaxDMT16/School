using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Database.Entities.Users
{
    public class CmsUser : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Scope Scope { get; set; }
    }
}