
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamingService.Data.Seeders.ModelSeeders;
using StreamingService.Models;

namespace StreamingService.Data.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedAllAsync(
            AppDbContext context
            //UserManager<UserProfile> userManager,
            //RoleManager<IdentityRole> roleManager
            )
        {

            var subscriptionLevels = await SubscriptionLevelSeeder.SeedAsync(context);
            var subscriptionPlans = await SubscriptionPlanSeeder.SeedAsync(context, subscriptionLevels);

            var personRoles = await PersonRoleSeeder.SeedAsync(context);

            var genres = await GenreSeeder.SeedAsync(context);
            var genreTranslations = await GenreTranslationSeeder.SeedAsync(context, genres);

            var videos = await VideoSeeder.SeedAsync(context, subscriptionLevels);
            var videoTranslations = await VideoTranslationSeeder.SeedAsync(context, videos);
            var videoSeasons = await VideoSeasonSeeder.SeedAsync(context, videos);
            var videoEpisodes = await VideoEpisodeSeeder.SeedAsync(context, videoSeasons);
            //var videoEpisodeTranslations = await VideoEpisodeTranslationSeeder.SeedAsync(context, videoEpisodes);
            var videoImages = await VideoImageSeeder.SeedAsync(context, videos);

            var videoFiles = await VideoFileSeeder.SeedAsync(context, videoEpisodes);
            var audiotracks = await AudiotrackSeeder.SeedAsync(context, videoEpisodes);
            var videoSubtitles = await VideoSubtitleSeeder.SeedAsync(context, videoEpisodes);

            await GenreVideoSeeder.SeedAsync(context, genres, videos);
            var persons = await PersonSeeder.SeedAsync(context);
            var personTranslations = await PersonTranslationSeeder.SeedAsync(context, persons);
            await PersonVideoSeeder.SeedAsync(context, videos, persons, personRoles);
            await PersonImageSeeder.SeedAsync(context, persons);

            var users = await UserProfileSeeder.SeedAsync(context); //(userManager, roleManager);
            var payments = await PaymentSeeder.SeedAsync(context);
            await UserSubscriptionSeeder.SeedAsync(context, users, payments, subscriptionPlans);

            //await UserVideoFavoriteSeeder.SeedAsync(context, users, videos);
            var ratings = await UserVideoRatingSeeder.SeedAsync(context, users, videos);
            await UserEpisodesHistorySeeder.SeedAsync(context, users, videoEpisodes);

            var comments = await CommentSeeder.SeedAsync(context, videos, users);
            await UserCommentLikeSeeder.SeedAsync(context, users, comments);

            await VideoEpisodeDailyStatsSeeder.SeedAsync(context, videoEpisodes);
            await VideoEpisodeViewTimedLogSeeder.SeedAsync(context, users, videoEpisodes);

            if (videos == null || ratings == null)
                return;

            foreach (var video in videos)
            {
                var videoRatings = ratings.Where(r => r.VideoId == video.Id);  
                video.RatingCount = videoRatings.Count();
                video.RatingSum = videoRatings.Sum(r => r.Rating);
            }

            await context.SaveChangesAsync();

        }
    }
}
