using Microsoft.IdentityModel.Tokens;
using StreamingService.Models;
using System.Collections.Generic;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class AudiotrackSeeder
    {
        public static async Task<List<Audiotrack>?> SeedAsync(AppDbContext context, List<VideoEpisode>? videoEpisodes)
        {
            if(videoEpisodes == null)
                return null;
            if (context.Audiotracks.Any())
                return null;

            var audiotracks = new List<Audiotrack>()
            {
                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 5000000L,
                    BitrateKbps = 192,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[0].Id,
                    VideoEpisode = videoEpisodes[0]
                },
                new Audiotrack
                {
                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 5100000L,
                    BitrateKbps = 192,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = 1,
                    VideoEpisode = videoEpisodes[0]
                },

                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 6500000L,
                    BitrateKbps = 256,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[1].Id,
                    VideoEpisode = videoEpisodes[1]
                },
                new Audiotrack
                {
                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 6600000L,
                    BitrateKbps = 256,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[1].Id,
                    VideoEpisode = videoEpisodes[1]
                },

                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 4800000L,
                    BitrateKbps = 160,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[2].Id,
                    VideoEpisode = videoEpisodes[2]
                },
                new Audiotrack
                {                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 4900000L,
                    BitrateKbps = 160,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[2].Id,
                    VideoEpisode = videoEpisodes[2]
                },

                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 3200000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[3].Id,
                    VideoEpisode = videoEpisodes[3]
                },
                new Audiotrack
                {
                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 3300000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[3].Id,
                    VideoEpisode = videoEpisodes[3]
                },

                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 3100000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[4].Id,
                    VideoEpisode = videoEpisodes[4]
                },
                new Audiotrack
                {
                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 3200000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[4].Id,
                    VideoEpisode = videoEpisodes[4]
                },

                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 3400000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[5].Id,
                    VideoEpisode = videoEpisodes[5]
                },
                new Audiotrack
                {
                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 3500000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[5].Id,
                    VideoEpisode = videoEpisodes[5]
                },

                new Audiotrack
                {
                    LocaleCode = "en",
                    AudioCodec = "AAC",
                    SizeBytes = 3450000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[6].Id,
                    VideoEpisode = videoEpisodes[6]
                },
                new Audiotrack
                {
                    LocaleCode = "uk",
                    AudioCodec = "AAC",
                    SizeBytes = 3550000L,
                    BitrateKbps = 128,
                    ContentType = "audio/mp3",
                    BlobContainer = "empty",
                    BlobPath = "empty",
                    VideoEpisodesId = videoEpisodes[6].Id,
                    VideoEpisode = videoEpisodes[6]
                }
            };


            await context.Audiotracks.AddRangeAsync(audiotracks);
            await context.SaveChangesAsync();

            return audiotracks;
        }
    }

}
