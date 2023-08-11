using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.DataAccess.Migrations
{
    public partial class fixed_datetime_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GraduateDate",
                table: "Educations",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduateDate",
                table: "Educations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
