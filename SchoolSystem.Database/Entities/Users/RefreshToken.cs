namespace SchoolSystem.Database.Entities.Users
{
    public abstract class RefreshToken : EntityBase
    {
        public string Token { get; set; }

        public string DeviceId { get; set; }
    }
}