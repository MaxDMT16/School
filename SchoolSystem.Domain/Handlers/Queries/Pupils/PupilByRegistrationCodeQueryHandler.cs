using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Pupils;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Pupils
{
    public class PupilByRegistrationCodeQueryHandler : QueryHandlerBase<PupilByRegistrationCodeQuery, PupilByRegistrationCodeResponse>
    {
        public PupilByRegistrationCodeQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PupilByRegistrationCodeResponse> Execute(PupilByRegistrationCodeQuery query)
        {
            var pupil = await DbContext.Pupils
                .Include(p => p.Group)
                .FirstOrDefaultAsync(p => p.RegistrationCode == query.RegistrationCode);

            if (pupil == null)
            {
                throw new EntityNotFoundException<Pupil, PupilByRegistrationCodeQuery, PupilByRegistrationCodeResponse>(query);
            }

            return new PupilByRegistrationCodeResponse
            {
                FirstName = pupil.FirstName,
                LastName = pupil.LastName,
                GroupName = pupil.Group.Name
            };
        }
    }
}