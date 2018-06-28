using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.User;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Users
{
    public class
        UserIdAndScopeByCredentialsQueryHandler : QueryHandlerBase<UserIdAndScopeByCredentialsQuery,
            UserIdAndScopeResponse>
    {
        public UserIdAndScopeByCredentialsQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<UserIdAndScopeResponse> Execute(UserIdAndScopeByCredentialsQuery query)
        {
            var teacher = await DbContext.Teachers
                .FirstOrDefaultAsync(t => t.Email == query.Email && t.Password == query.Password);

            if (teacher == null)
            {
                var pupil = await DbContext.Pupils
                    .FirstOrDefaultAsync(p => p.Email == query.Email && p.Password == query.Password);

                if (pupil == null)
                {
                    throw new EntityNotFoundException<UserBase, UserIdAndScopeByCredentialsQuery, UserIdAndScopeResponse>(query);
                }

                return new UserIdAndScopeResponse
                {
                    Id = pupil.Id,
                    Scope = Scope.Pupil
                };
            }
            else
            {
                return new UserIdAndScopeResponse
                {
                    Id = teacher.Id,
                    Scope = Scope.Teacher
                };
            }
        }
    }
}