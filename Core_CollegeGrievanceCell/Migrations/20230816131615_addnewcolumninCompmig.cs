using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_CollegeGrievanceCell.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumninCompmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dept",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dept",
                table: "Complaints");
        }
    }
}
