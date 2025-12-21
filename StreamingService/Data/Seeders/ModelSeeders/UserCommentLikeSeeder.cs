using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserCommentLikeSeeder
    {
        public static async Task<List<UserCommentLike>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<Comment>? comments)
        {
            if (users == null || comments == null)
                return null;

            if (context.UserCommentLikes.Any())
                return null;

            var userCommentLikes = new List<UserCommentLike>
            {
                new UserCommentLike { UserProfile = users[1], Comment = comments[0] },
                new UserCommentLike { UserProfile = users[2], Comment = comments[0] },

                new UserCommentLike { UserProfile = users[0], Comment = comments[1] },

                new UserCommentLike { UserProfile = users[4], Comment = comments[3] },
                new UserCommentLike { UserProfile = users[2], Comment = comments[3] }
            };


            await context.UserCommentLikes.AddRangeAsync(userCommentLikes);
            await context.SaveChangesAsync();

            return userCommentLikes;
        }
    }
}