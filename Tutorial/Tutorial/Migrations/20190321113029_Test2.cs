using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tutorial.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test2",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
            /*
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Test2",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test2",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blogs",
                nullable: true);
        }
    }
}
