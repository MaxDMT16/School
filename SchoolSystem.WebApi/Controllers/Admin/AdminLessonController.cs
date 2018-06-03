using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/lesson")]
    [OAuth(ScopeFlag.Admin)]
    public class AdminLessonController : SchoolSystemController
    {
        public AdminLessonController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateLesson([FromBody] CreateLessonCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateLesson([FromBody] UpdateLessonCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeleteLesson(Guid id)
        {
            var command = new DeleteLessonCommand
            {
                Id = id
            };

            await CommandBus.Execute(command);
        }

        [HttpGet]
        public async Task<LessonsResponse> GetAllLessons()
        {
            var lessonsResponse = await QueryBus.Execute<LessonsQuery, LessonsResponse>(new LessonsQuery());

            return lessonsResponse;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<LessonResponse> GetLessongById(Guid id)
        {
            var lessonResponse = await QueryBus.Execute<LessonByIdQuery, LessonResponse>(new LessonByIdQuery
            {
                Id = id
            });

            return lessonResponse;
        }
    }
}