using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.WebApi.Models.CmsUsers
{
    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public ScopeFlag Scope { get; set; }
    }
}