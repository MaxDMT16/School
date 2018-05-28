using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Groups;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Groups
{
    public class GroupByIdQueryHandler : QueryHandlerBase<GroupByIdQuery, GroupResponse>
    {
        public GroupByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<GroupResponse> Execute(GroupByIdQuery query)
        {
            var group = await DbContext.Groups.FirstOrDefaultAsync(g => g.Id == query.Id);

            return new GroupResponse
            {
                Id = group.Id,
                Name = group.Name
            };
        }
    }
}