using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities.Users
{
    public class UserRefreshToken : RefreshToken
    {
        [ForeignKey(nameof(UserBase))]
        public Guid UserId { get; set; }

        public UserBase UserBase { get; set; }
    }
}