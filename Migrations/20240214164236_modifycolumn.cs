using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneatAPI.Migrations
{
    public partial class modifycolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "loginEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_loginEntities",
                table: "loginEntities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_loginEntities",
                table: "loginEntities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "loginEntities");
        }
    }
}
