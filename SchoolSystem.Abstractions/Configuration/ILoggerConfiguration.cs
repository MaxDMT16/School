namespace SchoolSystem.Abstractions.Configuration
{
    public interface ILoggerConfiguration
    {
        string LogLevel { get; set; }
        string Path { get; set; }
    }
}