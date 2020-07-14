using Microsoft.EntityFrameworkCore.Migrations;

namespace brewjournal.Infrastructure.Migrations
{
    public partial class ChangeGravityTypeToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Gravity",
                table: "BatchSamples",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "OG",
                table: "Batches",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "FG",
                table: "Batches",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Gravity",
                table: "BatchSamples",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<long>(
                name: "OG",
                table: "Batches",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<long>(
                name: "FG",
                table: "Batches",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
