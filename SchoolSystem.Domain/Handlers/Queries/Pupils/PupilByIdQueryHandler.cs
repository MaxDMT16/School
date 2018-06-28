using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Pupils;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Pupils
{
    public class PupilByIdQueryHandler : QueryHandlerBase<PupilByIdQuery, PupilWithGroupResponse>
    {
        public PupilByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PupilWithGroupResponse> Execute(PupilByIdQuery query)
        {
            var fetchedPupil = await DbContext.Pupils
                .Include(pupil => pupil.Group)
                .FirstOrDefaultAsync(pupil => pupil.Id == query.Id);

            return new PupilWithGroupResponse
            {
                Id = fetchedPupil.Id,
                FirstName = fetchedPupil.FirstName,
                LastName = fetchedPupil.LastName,
                Email = fetchedPupil.Email,
                Group = new PupilWithGroupResponse.PupilGroup
                {
                    Id = fetchedPupil.GroupId,
                    Name = fetchedPupil.Group.Name
                }
            };
        }
    }
}