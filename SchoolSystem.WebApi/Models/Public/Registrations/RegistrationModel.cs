using System;

namespace SchoolSystem.WebApi.Models.Registrations
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RegistrationCode { get; set; }
    }
}