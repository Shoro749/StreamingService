using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingService.Migrations
{
    /// <inheritdoc />
    public partial class UserProfileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_episode_view_timed_log_video_episodes_video_episodes _id ",
                table: "video_episode_view_timed_log");

            migrationBuilder.RenameColumn(
                name: "video_episodes _id ",
                table: "video_episode_view_timed_log",
                newName: "video_episodes_id ");

            migrationBuilder.RenameIndex(
                name: "IX_video_episode_view_timed_log_video_episodes _id ",
                table: "video_episode_view_timed_log",
                newName: "IX_video_episode_view_timed_log_video_episodes_id ");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "google_id",
                table: "user_profile",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "user_profile",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_video_episode_view_timed_log_video_episodes_video_episodes_id ",
                table: "video_episode_view_timed_log",
                column: "video_episodes_id ",
                principalTable: "video_episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_episode_view_timed_log_video_episodes_video_episodes_id ",
                table: "video_episode_view_timed_log");

            migrationBuilder.DropColumn(
                name: "email",
                table: "user_profile");

            migrationBuilder.DropColumn(
                name: "google_id",
                table: "user_profile");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "user_profile");

            migrationBuilder.RenameColumn(
                name: "video_episodes_id ",
                table: "video_episode_view_timed_log",
                newName: "video_episodes _id ");

            migrationBuilder.RenameIndex(
                name: "IX_video_episode_view_timed_log_video_episodes_id ",
                table: "video_episode_view_timed_log",
                newName: "IX_video_episode_view_timed_log_video_episodes _id ");

            migrationBuilder.AddForeignKey(
                name: "FK_video_episode_view_timed_log_video_episodes_video_episodes _id ",
                table: "video_episode_view_timed_log",
                column: "video_episodes _id ",
                principalTable: "video_episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
