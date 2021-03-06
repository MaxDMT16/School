﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Teachers
{
    public class DeleteTeacherCommandHandler : CommandHandlerBase<DeleteTeacherCommand>
    {
        public DeleteTeacherCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteTeacherCommand command)
        {
            var teacher = await DbContext.Teachers.Where(t => t.Id == command.Id).FirstOrDefaultAsync();

            if (teacher == null)
            {
                throw new EntityNotFoundException<Teacher, DeleteTeacherCommand>(command);
            }

            DbContext.Teachers.Remove(teacher);

            await DbContext.SaveChangesAsync();
        }
    }
}