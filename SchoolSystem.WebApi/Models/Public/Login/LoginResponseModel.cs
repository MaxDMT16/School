using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.WebApi.Models.Public.Login
{
    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Scope Scope { get; set; }
    }
}