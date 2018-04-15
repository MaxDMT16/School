﻿using System.Threading.Tasks;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Lessons
{
    public class CreateLessonCommandHandler : CommandHandlerBase<CreateLessonCommand>
    {
        public CreateLessonCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateLessonCommand command)
        {
            var lesson = new Lesson
            {
                GroupId = command.GroupId,
                TeacherId = command.TeacherId,
                Subject = command.Subject
            };

            DbContext.Lessons.Add(lesson);

            await DbContext.SaveChangesAsync();
        }
    }
}