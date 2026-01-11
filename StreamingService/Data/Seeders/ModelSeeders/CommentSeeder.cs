using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class CommentSeeder
    {
        public static async Task<List<Comment>?> SeedAsync(AppDbContext context, List<Video>? videos, List<UserProfile>? userProfiles)
        {

            if (videos == null || userProfiles == null)
                return null;

            if (context.Comments.Any())
                return null;

            var comment1 = new Comment
            {
                VideoId = videos[0].Id,
                UserProfileId = userProfiles[0].Id,
                Text = "Очень трогательный фильм, рекомендую!",
                CreateAt = DateTime.UtcNow.AddDays(-10),
                UpdateAt = DateTime.UtcNow.AddDays(-10),
            };
            var comment2 = new Comment
            {
                VideoId = videos[0].Id,
                UserProfileId = userProfiles[1].Id,
                Text = "Согласен, особенно понравилась сцена с музыкой.",
                CreateAt = DateTime.UtcNow.AddDays(-9),
                UpdateAt = DateTime.UtcNow.AddDays(-9),
                Parent = comment1
            };
            var comment3 = new Comment
            {
                VideoId = videos[0].Id,
                UserProfileId = userProfiles[2].Id,
                Text = "Для меня фильм оказался немного скучным, но концовка радует.",
                CreateAt = DateTime.UtcNow.AddDays(-8),
                UpdateAt = DateTime.UtcNow.AddDays(-8),
                Parent = comment1
            };
            var comment4 = new Comment
            {
                VideoId = videos[0].Id,
                UserProfileId = userProfiles[3].Id,
                Text = "Прекрасная актёрская игра!",
                CreateAt = DateTime.UtcNow.AddDays(-7),
                UpdateAt = DateTime.UtcNow.AddDays(-7),
            };
            var comment5 = new Comment
            {
                VideoId = videos[0].Id,
                UserProfileId = userProfiles[4].Id,
                Text = "Да, особенно главные герои.",
                CreateAt = DateTime.UtcNow.AddDays(-6),
                UpdateAt = DateTime.UtcNow.AddDays(-6),
                Parent = comment4
            };

            var comments = new List<Comment>
            {
                comment1,
                comment2,
                comment3,
                comment4,
                comment5
            };

            await context.Comments.AddRangeAsync(comments);
            await context.SaveChangesAsync();

            return comments;
        }
    }
}