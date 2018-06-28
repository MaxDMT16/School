using System;

namespace SchoolSystem.Database.Entities.Users
{
    public abstract class UserBase : EntityBase
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid RegistrationCode { get; set; }
    }
}