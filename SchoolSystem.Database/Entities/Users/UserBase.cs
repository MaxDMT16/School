using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Database.Entities.Users
{
    public abstract class UserBase : EntityBase
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}