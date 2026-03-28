using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingService.Migrations
{
    /// <inheritdoc />
    public partial class new_table_and_updated_videos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrailerDuration",
                table: "videos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "persons_image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blob_container = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    blob_path = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_image", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_image_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_CommentId",
                table: "comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_image_person_id",
                table: "persons_image",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_CommentId",
                table: "comments",
                column: "CommentId",
                principalTable: "comments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_CommentId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "persons_image");

            migrationBuilder.DropIndex(
                name: "IX_comments_CommentId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "videos");

            migrationBuilder.DropColumn(
                name: "TrailerDuration",
                table: "videos");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "comments");
        }
    }
}
