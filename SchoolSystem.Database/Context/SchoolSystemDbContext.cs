using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Entities.Users;

namespace SchoolSystem.Database.Context
{
    public class SchoolSystemDbContext : DbContext, ISchoolSystemDbContext
    {
        public SchoolSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public IDbConnection Connection => Database.GetDbConnection();

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmsUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Group>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Teacher>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Pupil>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Lesson>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<ScheduleCell>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Subject>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TeacherLesson>()
                .HasKey(tl => new {tl.TeacherId, tl.LessonId});

            modelBuilder.Entity<UserRefreshToken>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CmsUserRefreshToken>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<CmsUser> CmsUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ScheduleCell> ScheduleCells { get; set; }
        public DbSet<TeacherLesson> TeachersLessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<CmsUserRefreshToken> CmsUserRefreshTokens { get; set; }
    }
}