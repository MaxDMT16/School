using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Authorization.Services
{
    public interface IAccessTokenService
    {
        string CreateToken<TPayload>(TPayload payload, string key, Scope scope)
            where TPayload : Payload;

        void ValidateToken<TPayload>(string token, string key, Scope scope)
            where TPayload : Payload;

        TPayload GetPayload<TPayload>(string token)
            where TPayload : Payload;
    }
}