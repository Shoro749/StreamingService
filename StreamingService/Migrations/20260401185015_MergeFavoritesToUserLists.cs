using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingService.Migrations
{
    /// <inheritdoc />
    public partial class MergeFavoritesToUserLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_video_lists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_id = table.Column<int>(type: "int", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    list_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_video_lists", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_video_lists_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_video_lists_videos_video_id",
                        column: x => x.video_id,
                        principalTable: "videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql(@"
                INSERT INTO user_video_lists (video_id, user_profile_id, list_type)
                SELECT video_id, user_profile_id, 1
                FROM user_video_favorite
            ");

            migrationBuilder.DropTable(
                name: "user_video_favorite");

            migrationBuilder.CreateIndex(
                name: "IX_user_video_lists_unique",
                table: "user_video_lists",
                columns: new[] { "user_profile_id", "video_id", "list_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_video_lists_video_id",
                table: "user_video_lists",
                column: "video_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_video_lists");

            migrationBuilder.CreateTable(
                name: "user_video_favorite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    video_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_video_favorite", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_video_favorite_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_video_favorite_videos_video_id",
                        column: x => x.video_id,
                        principalTable: "videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_video_favorite_user_profile_id_video_id",
                table: "user_video_favorite",
                columns: new[] { "user_profile_id", "video_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_video_favorite_video_id",
                table: "user_video_favorite",
                column: "video_id");
        }
    }
}
