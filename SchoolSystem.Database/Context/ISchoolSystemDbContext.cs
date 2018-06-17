using Microsoft.EntityFrameworkCore;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Entities.Users;

namespace SchoolSystem.Database.Context
{
    public interface ISchoolSystemDbContext : IDbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<Pupil> Pupils { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<ScheduleCell> ScheduleCells { get; set; }
        DbSet<CmsUser> CmsUsers { get; set; }
        DbSet<TeacherLesson> TeachersLessons { get; set; }
        DbSet<Subject> Subjects { get; set; }
    }
}