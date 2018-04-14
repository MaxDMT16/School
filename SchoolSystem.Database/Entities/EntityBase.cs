using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Database.Entities
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid Id { get; set; }
    }
}