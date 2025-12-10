using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StreamingService.Models;

namespace StreamingService.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audiotrack> Audiotracks { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GenreTranslation> GenresTranslations { get; set; }

    public virtual DbSet<GenreVideo> GenresVideos { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonRole> PersonRoles { get; set; }

    public virtual DbSet<PersonTranslation> PersonsTranslations { get; set; }

    public virtual DbSet<PersonVideo> PersonsVideos { get; set; }

    public virtual DbSet<SubscriptionLevel> SubscriptionLevels { get; set; }

    public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

    public virtual DbSet<UserCommentLike> UserCommentLikes { get; set; }

    public virtual DbSet<UserEpisodesHistory> UserEpisodesHistories { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserVideoFavorite> UserVideoFavorites { get; set; }

    public virtual DbSet<UserVideoRating> UserVideoRatings { get; set; }

    public virtual DbSet<UserSubscription> UsersSubscriptions { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    public virtual DbSet<VideoEpisode> VideoEpisode { get; set; }

    public virtual DbSet<VideoEpisodeDailyStats> VideoEpisodeDailyStats { get; set; }

    public virtual DbSet<VideoEpisodeTranslation> VideoEpisodeTranslations { get; set; }

    public virtual DbSet<VideoEpisodeViewTimedLog> VideoEpisodeViewTimedLogs { get; set; }

    public virtual DbSet<VideoFile> VideoFiles { get; set; }

    public virtual DbSet<VideoImage> VideoImages { get; set; }

    public virtual DbSet<VideoSeason> VideoSeasons { get; set; }

    public virtual DbSet<VideoSubtitle> VideoSubtitles { get; set; }

    public virtual DbSet<VideoTranslation> VideoTranslations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audiotrack>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.VideoEpisode)
                .WithMany(p => p.Audiotracks)
                .HasForeignKey(d => d.VideoEpisodesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id);

             entity.HasOne(e => e.Parent)
                .WithMany()
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.UserProfile)
                .WithMany()
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Video)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<GenreTranslation>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Genre)
                .WithMany(p => p.GenreTranslations)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


        modelBuilder.Entity<GenreVideo>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Genre)
                .WithMany(p => p.GenreVideos)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Video)
                .WithMany(p => p.GenreVideos)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<PersonRole>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<PersonTranslation>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Person)
                .WithMany(p => p.PersonTranslations)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonVideo>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Person)
                .WithMany(p => p.PersonsVideos)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PersonRole)
                .WithMany(p => p.PersonsVideos)
                .HasForeignKey(d => d.PersonRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Video)
                .WithMany(p => p.PersonVideos)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


        modelBuilder.Entity<SubscriptionLevel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserCommentLike>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.UserProfile)
                .WithMany()
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Comment)
                .WithMany()
                .HasForeignKey(e => e.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new { e.UserProfileId, e.CommentId }).IsUnique();
        });



        modelBuilder.Entity<UserEpisodesHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<UserVideoFavorite>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(u => new { u.UserProfileId, u.VideoId }).IsUnique();
        });

        modelBuilder.Entity<UserVideoRating>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(u => new { u.UserProfileId, u.VideoId }).IsUnique();
        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.AutoRenew).HasDefaultValue(true);
        });


        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<VideoEpisode>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.VideoSeason)
                .WithMany(p => p.Episodes)
                .HasForeignKey(d => d.VideoSeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VideoEpisodeDailyStats>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<VideoEpisodeTranslation>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.VideoEpisode)
                .WithMany(p => p.VideoEpisodeTranslations)
                .HasForeignKey(d => d.VideoEpisodesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VideoEpisodeViewTimedLog>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<VideoFile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.VideoEpisode)
                .WithMany(p => p.VideoFiles)
                .HasForeignKey(d => d.VideoEpisodesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VideoImage>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Video)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VideoSeason>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Video)
                .WithMany(p => p.Seasons)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VideoSubtitle>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.VideoEpisodes)
                .WithMany(p => p.VideoSubtitles)
                .HasForeignKey(d => d.VideoEpisodesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VideoTranslation>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Video)
                .WithMany(p => p.Translations)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
