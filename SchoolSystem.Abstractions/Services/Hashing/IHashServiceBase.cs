namespace SchoolSystem.Abstractions.Services.Hashing
{
    public interface IHashServiceBase
    {
        string GetHashBase64(string textToHash);
        string GetHashHex(string textToHash, string format = "X2");
    }
}