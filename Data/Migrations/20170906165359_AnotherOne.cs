using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BigToDo.Data.Migrations
{
    public partial class AnotherOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "BigToDoModel",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BigToDoModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BigToDoModel",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.CreateIndex(
                name: "IX_BigToDoModel_ApplicationUserId",
                table: "BigToDoModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BigToDoModel_AspNetUsers_ApplicationUserId",
                table: "BigToDoModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BigToDoModel_AspNetUsers_ApplicationUserId",
                table: "BigToDoModel");

            migrationBuilder.DropIndex(
                name: "IX_BigToDoModel_ApplicationUserId",
                table: "BigToDoModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BigToDoModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BigToDoModel");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "BigToDoModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
