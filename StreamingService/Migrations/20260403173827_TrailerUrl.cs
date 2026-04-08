using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingService.Migrations
{
    /// <inheritdoc />
    public partial class TrailerUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_user_video_lists_user_profile_id_video_id",
            //    table: "user_video_lists");

            migrationBuilder.AddColumn<string>(
                name: "Trailerurl",
                table: "videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_video_lists_user_profile_id_video_id_list_type",
                table: "user_video_lists",
                columns: new[] { "user_profile_id", "video_id", "list_type" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_video_lists_user_profile_id_video_id_list_type",
                table: "user_video_lists");

            migrationBuilder.DropColumn(
                name: "Trailerurl",
                table: "videos");

            migrationBuilder.CreateIndex(
                name: "IX_user_video_lists_user_profile_id_video_id",
                table: "user_video_lists",
                columns: new[] { "user_profile_id", "video_id" },
                unique: true);
        }
    }
}
