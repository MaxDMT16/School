using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Pupils;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Pupils
{
    public class PupilsQueryHandler : QueryHandlerBase<PupilsQuery, PupilsResponse>
    {
        public PupilsQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PupilsResponse> Execute(PupilsQuery query)
        {
            var pupils = await DbContext.Pupils.Select(p => new PupilsResponse.Pupil
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                GroupId = p.GroupId
            }).ToListAsync();

            return new PupilsResponse
            {
                Pupils = pupils
            };
        }
    }
}