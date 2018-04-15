using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Database.Migrations
{
    public partial class UpdateClassIdToGroupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Groups_ClassId",
                table: "Pupils");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Pupils",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Pupils_ClassId",
                table: "Pupils",
                newName: "IX_Pupils_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Groups_GroupId",
                table: "Pupils",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Groups_GroupId",
                table: "Pupils");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Pupils",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Pupils_GroupId",
                table: "Pupils",
                newName: "IX_Pupils_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Groups_ClassId",
                table: "Pupils",
                column: "ClassId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
