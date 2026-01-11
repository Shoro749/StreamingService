using StreamingService.Data;
using StreamingService.DTO.ViewModels;

namespace StreamingService.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PlayerViewModel> GetPlayerDataAsync(int episodeId, string locale)
        {
            var episode = await _context.VideoEpisode.FindAsync(episodeId);

            var episodeTranslation = episode.VideoEpisodeTranslations
                .Where(vet => vet.IsOriginal.Value)
                .FirstOrDefault();

            var qualities = episode.VideoFiles.Select(vf => new VideoPlayerVideoViewModel
            {
                Id = vf.Id,
                Label = vf.Resolution
            }).ToList();

            var subtitles = episode.VideoSubtitles.Select(s => new VideoPlayerSubtitlesViewModel
            {
                Id = s.Id,
                Label = s.Title,
            }).ToList();

            var voiceActions = episode.Audiotracks.Select(a => new VideoPlayerAudioViewModel
            {
                Id = a.Id,
            }).ToList();

            var episodes = episode.VideoSeason.Episodes.Select(e => new EpisodeViewModel
            {
                Id = e.Id,
                Title = e.VideoEpisodeTranslations
                        .Where(vet => vet.LocaleCode == locale)
                        .Select(vet => vet.Title)
                        .FirstOrDefault(),
                Number = e.EpisodeNumber
            }).ToList();

            return new PlayerViewModel
            {
                CurrentEpisode = episodes.Find(e => e.Id == episodeId),
                CurrentQualities = qualities.First(),
                CurrentSubtitles = subtitles.First(),
                CurrentVoiceAction = voiceActions.First(),

                Episodes = episodes,
                Qualities = qualities,
                Subtitles = subtitles,
                VoiceAction = voiceActions
            };
        }
    }
}
