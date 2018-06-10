using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Pupil
{
    [Produces("application/json")]
    [Route("api/pupil")]
    public class PupilController : SecuredController
    {
        public PupilController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpGet]
        public async Task<LessonsWithCellsResponse> PupilSchedule(Guid id)
        {
            var lessonsWithCellsResponse = await QueryBus.Execute<LessonsByGroupIdQuery, LessonsWithCellsResponse>(
                new LessonsByGroupIdQuery
                {
                    Id = id
                });

            return lessonsWithCellsResponse;
        }
    }
}