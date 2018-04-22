using System;

namespace SchoolSystem.Abstractions.Authorization.Services
{
    public abstract class Payload
    {
        public DateTime CreationDate { get; set; }
        public long LifeTimeTicks { get; set; }
    }
}