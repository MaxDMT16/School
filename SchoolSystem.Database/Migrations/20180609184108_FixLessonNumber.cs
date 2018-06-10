using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Database.Migrations
{
    public partial class FixLessonNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LessonNumber",
                table: "ScheduleCells",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "LessonNumber",
                table: "ScheduleCells",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
