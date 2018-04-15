using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Groups;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Groups
{
    public class GroupsQueryHandler : QueryHandlerBase<GroupsQuery, GroupsResponse>
    {
        public GroupsQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<GroupsResponse> Execute(GroupsQuery query)
        {
            var groups = await DbContext.Groups.Select(g => new GroupsResponse.Group
            {
                Id = g.Id,
                Name = g.Name
            }).ToListAsync();

            return new GroupsResponse
            {
                Groups = groups
            };
        }
    }
}