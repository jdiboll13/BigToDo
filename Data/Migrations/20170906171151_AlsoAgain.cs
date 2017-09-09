using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BigToDo.Data.Migrations
{
    public partial class AlsoAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "BigToDoModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BigToDoModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "BigToDoModel",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BigToDoModel",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "BigToDoModel");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BigToDoModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BigToDoModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "BigToDoModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
