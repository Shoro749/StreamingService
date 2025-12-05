using Microsoft.EntityFrameworkCore;
using StreamingService.Models;
using System;

namespace StreamingService.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Audiotrack> Audiotracks { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<GenreTranslation> GenreTranslations { get; set; } = default!;
        public DbSet<GenreVideo> GenreVideos { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<PersonRole> PersonRoles { get; set; } = default!;
        public DbSet<PersonTranslation> PersonTranslations { get; set; } = default!;
        public DbSet<PersonVideo> PersonVideos { get; set; } = default!;
        public DbSet<SubscriptionLevel> SubscriptionLevels { get; set; } = default!;
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; } = default!;
        public DbSet<UserCommentLike> UserCommentLikes { get; set; } = default!;
        public DbSet<UserEpisodesHistory> UserEpisodesHistories { get; set; } = default!;
        public DbSet<UserProfile> UserProfiles { get; set; } = default!;
        public DbSet<UserSubscription> UserSubscriptions { get; set; } = default!;
        public DbSet<UserVideoFavorite> UserVideoFavorites { get; set; } = default!;
        public DbSet<UserVideoRating> UserVideoRatings { get; set; } = default!;
        public DbSet<Video> Videos { get; set; } = default!;
        public DbSet<VideoEpisode> VideoEpisodes { get; set; } = default!;
        public DbSet<VideoEpisodeDailyStats> VideoEpisodeDailyStats { get; set; } = default!;
        public DbSet<VideoEpisodeTranslation> VideoEpisodeTranslations { get; set; } = default!;
        public DbSet<VideoEpisodeViewTimedLog> VideoEpisodeViewTimedLogs { get; set; } = default!;
        public DbSet<VideoFile> VideoFiles { get; set; } = default!;
        public DbSet<VideoImage> VideoImages { get; set; } = default!;
        public DbSet<VideoSeason> VideoSeasons { get; set; } = default!;
        public DbSet<VideoSubtitle> VideoSubtitles { get; set; } = default!;
        public DbSet<VideoTranslation> VideoTranslations { get; set; } = default!;
    }
}
