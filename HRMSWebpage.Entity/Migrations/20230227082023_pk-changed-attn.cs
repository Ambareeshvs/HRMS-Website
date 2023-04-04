using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMSWebpage.Entity.Migrations
{
    public partial class pkchangedattn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AttnId",
                table: "Attn",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AttnId",
                table: "Attn",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
