using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoFileSeeder
    {
        public static async Task<List<VideoFile>?> SeedAsync(AppDbContext context, List<VideoEpisode>? videoEpisodes)
        {
            if (videoEpisodes == null)
                return null;

            if (context.VideoFiles.Any())
                return null;

            var videoFiles = new List<VideoFile>
            {
                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 2100000000L, BitrateKbps = 8000, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[0] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 1400000000L, BitrateKbps = 5000, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[0] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 900000000L,  BitrateKbps = 3000, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[0] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 2800000000L, BitrateKbps = 9000, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[1] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 1800000000L, BitrateKbps = 5500, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[1] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 1100000000L, BitrateKbps = 3500, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[1] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 1900000000L, BitrateKbps = 7500, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[2] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 1200000000L, BitrateKbps = 4800, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[2] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 800000000L,  BitrateKbps = 3000, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[2] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 950000000L,  BitrateKbps = 6500, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[3] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 600000000L,  BitrateKbps = 4000, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[3] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 400000000L,  BitrateKbps = 2500, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[3] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 970000000L,  BitrateKbps = 6600, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[4] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 620000000L,  BitrateKbps = 4200, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[4] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 410000000L,  BitrateKbps = 2600, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[4] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 1000000000L, BitrateKbps = 6800, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[5] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 650000000L,  BitrateKbps = 4200, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[5] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 420000000L,  BitrateKbps = 2600, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[5] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 1020000000L, BitrateKbps = 6900, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[6] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 670000000L,  BitrateKbps = 4300, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[6] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 430000000L,  BitrateKbps = 2700, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[6] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 1000000000L, BitrateKbps = 6800, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[7] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 650000000L,  BitrateKbps = 4200, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[7] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 420000000L,  BitrateKbps = 2600, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[7] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 1020000000L, BitrateKbps = 6900, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[8] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 670000000L,  BitrateKbps = 4300, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[8] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 430000000L,  BitrateKbps = 2700, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://placeholdervideo.dev/3840x2160", VideoEpisode = videoEpisodes[8] },

                new VideoFile { Resolution = "1920x1080", VideoCodec = "H.264", SizeBytes = 1000000000L, BitrateKbps = 6800, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[9] },
                new VideoFile { Resolution = "1280x720",  VideoCodec = "H.264", SizeBytes = 650000000L,  BitrateKbps = 4200, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[9] },
                new VideoFile { Resolution = "854x480",   VideoCodec = "H.264", SizeBytes = 420000000L,  BitrateKbps = 2600, ContentType = "video/mp4", BlobContainer = "video", BlobPath = "https://interactive-examples.mdn.mozilla.net/media/cc0-videos/flower.mp4", VideoEpisode = videoEpisodes[9] },
            };

            await context.VideoFiles.AddRangeAsync(videoFiles);
            await context.SaveChangesAsync();

            return videoFiles;
        }
    }
}