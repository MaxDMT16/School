﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSystem.Database.Migrations
{
    public partial class ReplaceLoginWithEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "UserBase",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserBase",
                newName: "Login");
        }
    }
}
