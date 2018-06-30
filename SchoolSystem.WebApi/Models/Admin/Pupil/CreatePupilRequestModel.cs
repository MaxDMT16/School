using System;

namespace SchoolSystem.WebApi.Models.Admin.Pupil
{
    public class CreatePupilRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid GroupId { get; set; }
    }
}