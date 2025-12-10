using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genres_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    provider = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    method = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    transaction_id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    avatar_url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_profile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genre_translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocaleCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genre_translations_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "person_translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocaleCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_translations_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "subscription_plans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    period_days = table.Column<int>(type: "int", nullable: false),
                    trial_days = table.Column<int>(type: "int", nullable: false),
                    features = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    is_enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    subscription_level_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_plans", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscription_plans_subscription_levels_subscription_level_id",
                        column: x => x.subscription_level_id,
                        principalTable: "subscription_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingCount = table.Column<long>(type: "bigint", nullable: false),
                    RatingSum = table.Column<long>(type: "bigint", nullable: false),
                    MinAccess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videos_subscription_levels_MinAccess",
                        column: x => x.MinAccess,
                        principalTable: "subscription_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users_subscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    auto_renew = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    subscription_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subscription_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    payment_id = table.Column<int>(type: "int", nullable: false),
                    subscription_plan_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_subscriptions_payments_payment_id",
                        column: x => x.payment_id,
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_subscriptions_subscription_plans_subscription_plan_id",
                        column: x => x.subscription_plan_id,
                        principalTable: "subscription_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_subscriptions_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    video_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_comments_parent_id",
                        column: x => x.parent_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_videos_video_id",
                        column: x => x.video_id,
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "genre_videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genre_videos_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_genre_videos_videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "person_videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PersonRoleId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_videos_person_roles_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "person_roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_person_videos_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_person_videos_videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_video_favorite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_id = table.Column<int>(type: "int", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "user_video_rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_id = table.Column<int>(type: "int", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_video_rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_video_rating_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_video_rating_videos_video_id",
                        column: x => x.video_id,
                        principalTable: "videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    BlobContainer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BlobPath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_images_videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "video_seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSeason = table.Column<int>(type: "int", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_seasons_videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "video_translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocaleCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_translations_videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_comment_like",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    comment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_comment_like", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_comment_like_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_comment_like_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "video_episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true),
                    EpisodeType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    VideoSeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_episodes_video_seasons_VideoSeasonId",
                        column: x => x.VideoSeasonId,
                        principalTable: "video_seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "audiotracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocaleCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AudioCodec = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    BitrateKbps = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    BlobContainer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BlobPath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    VideoEpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audiotracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_audiotracks_video_episodes_VideoEpisodesId",
                        column: x => x.VideoEpisodesId,
                        principalTable: "video_episodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_episodes_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paused_watch_time = table.Column<int>(type: "int", nullable: false),
                    last_watched_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_fully_watched = table.Column<bool>(type: "bit", nullable: false),
                    video_episodes_id = table.Column<int>(type: "int", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_episodes_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_episodes_history_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_episodes_history_video_episodes_video_episodes_id",
                        column: x => x.video_episodes_id,
                        principalTable: "video_episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_episode_daily_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_user_views = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    video_episodes_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_episode_daily_stats", x => x.id);
                    table.ForeignKey(
                        name: "FK_video_episode_daily_stats_video_episodes_video_episodes_id",
                        column: x => x.video_episodes_id,
                        principalTable: "video_episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_episode_translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocaleCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    VideoEpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_episode_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_episode_translations_video_episodes_VideoEpisodesId",
                        column: x => x.VideoEpisodesId,
                        principalTable: "video_episodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "video_episode_view_timed_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    video_episodes_id = table.Column<int>(name: "video_episodes _id ", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_episode_view_timed_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_video_episode_view_timed_log_user_profile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_video_episode_view_timed_log_video_episodes_video_episodes _id ",
                        column: x => x.video_episodes_id,
                        principalTable: "video_episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resolution = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    VideoCodec = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    BitrateKbps = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    BlobContainer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BlobPath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    VideoEpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_files_video_episodes_VideoEpisodesId",
                        column: x => x.VideoEpisodesId,
                        principalTable: "video_episodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "video_subtitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LocaleCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    BlobContainer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BlobPath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    VideoEpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_subtitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_subtitles_video_episodes_VideoEpisodesId",
                        column: x => x.VideoEpisodesId,
                        principalTable: "video_episodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_audiotracks_VideoEpisodesId",
                table: "audiotracks",
                column: "VideoEpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_parent_id",
                table: "comments",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_profile_id",
                table: "comments",
                column: "user_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_video_id",
                table: "comments",
                column: "video_id");

            migrationBuilder.CreateIndex(
                name: "IX_genre_translations_GenreId",
                table: "genre_translations",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_videos_GenreId",
                table: "genre_videos",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_videos_VideoId",
                table: "genre_videos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_genres_GenreId",
                table: "genres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_person_translations_PersonId",
                table: "person_translations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_person_videos_PersonId",
                table: "person_videos",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_person_videos_PersonRoleId",
                table: "person_videos",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_person_videos_VideoId",
                table: "person_videos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_plans_subscription_level_id",
                table: "subscription_plans",
                column: "subscription_level_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_comment_like_comment_id",
                table: "user_comment_like",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_comment_like_user_profile_id_comment_id",
                table: "user_comment_like",
                columns: new[] { "user_profile_id", "comment_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_episodes_history_user_profile_id",
                table: "user_episodes_history",
                column: "user_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_episodes_history_video_episodes_id",
                table: "user_episodes_history",
                column: "video_episodes_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_video_favorite_user_profile_id_video_id",
                table: "user_video_favorite",
                columns: new[] { "user_profile_id", "video_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_video_favorite_video_id",
                table: "user_video_favorite",
                column: "video_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_video_rating_user_profile_id_video_id",
                table: "user_video_rating",
                columns: new[] { "user_profile_id", "video_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_video_rating_video_id",
                table: "user_video_rating",
                column: "video_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_subscriptions_payment_id",
                table: "users_subscriptions",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_subscriptions_subscription_plan_id",
                table: "users_subscriptions",
                column: "subscription_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_subscriptions_user_profile_id",
                table: "users_subscriptions",
                column: "user_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_video_episode_daily_stats_video_episodes_id",
                table: "video_episode_daily_stats",
                column: "video_episodes_id");

            migrationBuilder.CreateIndex(
                name: "IX_video_episode_translations_VideoEpisodesId",
                table: "video_episode_translations",
                column: "VideoEpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_video_episode_view_timed_log_user_profile_id",
                table: "video_episode_view_timed_log",
                column: "user_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_video_episode_view_timed_log_video_episodes _id ",
                table: "video_episode_view_timed_log",
                column: "video_episodes _id ");

            migrationBuilder.CreateIndex(
                name: "IX_video_episodes_VideoSeasonId",
                table: "video_episodes",
                column: "VideoSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_video_files_VideoEpisodesId",
                table: "video_files",
                column: "VideoEpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_video_images_VideoId",
                table: "video_images",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_video_seasons_VideoId",
                table: "video_seasons",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_video_subtitles_VideoEpisodesId",
                table: "video_subtitles",
                column: "VideoEpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_video_translations_VideoId",
                table: "video_translations",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_videos_MinAccess",
                table: "videos",
                column: "MinAccess");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audiotracks");

            migrationBuilder.DropTable(
                name: "genre_translations");

            migrationBuilder.DropTable(
                name: "genre_videos");

            migrationBuilder.DropTable(
                name: "person_translations");

            migrationBuilder.DropTable(
                name: "person_videos");

            migrationBuilder.DropTable(
                name: "user_comment_like");

            migrationBuilder.DropTable(
                name: "user_episodes_history");

            migrationBuilder.DropTable(
                name: "user_video_favorite");

            migrationBuilder.DropTable(
                name: "user_video_rating");

            migrationBuilder.DropTable(
                name: "users_subscriptions");

            migrationBuilder.DropTable(
                name: "video_episode_daily_stats");

            migrationBuilder.DropTable(
                name: "video_episode_translations");

            migrationBuilder.DropTable(
                name: "video_episode_view_timed_log");

            migrationBuilder.DropTable(
                name: "video_files");

            migrationBuilder.DropTable(
                name: "video_images");

            migrationBuilder.DropTable(
                name: "video_subtitles");

            migrationBuilder.DropTable(
                name: "video_translations");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "person_roles");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "subscription_plans");

            migrationBuilder.DropTable(
                name: "video_episodes");

            migrationBuilder.DropTable(
                name: "user_profile");

            migrationBuilder.DropTable(
                name: "video_seasons");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "subscription_levels");
        }
    }
}
