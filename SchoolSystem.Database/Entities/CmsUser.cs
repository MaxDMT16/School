using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Database.Entities
{
    public class CmsUser : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public ScopeFlag Scope { get; set; }
    }
}