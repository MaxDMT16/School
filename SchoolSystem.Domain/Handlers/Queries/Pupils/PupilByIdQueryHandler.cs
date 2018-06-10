using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Pupils;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Pupils
{
    public class PupilByIdQueryHandler : QueryHandlerBase<PupilByIdQuery, PupilResponse>
    {
        public PupilByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PupilResponse> Execute(PupilByIdQuery query)
        {
            var fetchedPupil = await DbContext.Pupils
                .Include(pupil => pupil.Group)
                .FirstOrDefaultAsync(pupil => pupil.Id == query.Id);

            return new PupilResponse
            {
                Id = fetchedPupil.Id,
                FirstName = fetchedPupil.FirstName,
                LastName = fetchedPupil.LastName,
                Group = new PupilResponse.PupilGroup
                {
                    Id = fetchedPupil.GroupId,
                    Name = fetchedPupil.Group.Name
                }
            };
        }
    }
}