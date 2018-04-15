using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/lesson")]
    public class AdminLessonController : SchoolSystemController
    {
        public AdminLessonController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateLesson(CreateLessonCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateLesson(UpdateLessonCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeleteLesson(DeleteLessonCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpGet]
        public async Task<LessonsResponse> GetAllLessons()
        {
            var lessonsResponse = await QueryBus.Execute<LessonsQuery, LessonsResponse>(new LessonsQuery());

            return lessonsResponse;
        }
    }
}