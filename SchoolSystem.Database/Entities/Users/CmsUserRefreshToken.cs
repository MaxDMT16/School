using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities.Users
{
    public class CmsUserRefreshToken : RefreshToken
    {
        [ForeignKey(nameof(CmsUser))]
        public Guid CmsUserId { get; set; }

        public CmsUser CmsUser { get; set; }
    }
}