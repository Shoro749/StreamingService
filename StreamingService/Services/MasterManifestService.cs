using System.Text;

namespace StreamingService.Service
{
    public class MasterManifestService
    {
        private VideoEpisodeRepository _repository;

        public MasterManifestService(VideoEpisodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> BuildMasterAsync(
            int episodeId,
            CancellationToken token)
        {
            var episode = await _repository.GetForStreamingAsync(episodeId, token);

            var sb = new StringBuilder();

            sb.AppendLine("#EXTM3U");
            sb.AppendLine("#EXT-X-VERSION:7");

            foreach (var a in episode.Audiotracks)
            {
                sb.AppendLine(
                    $"#EXT-X-MEDIA:TYPE=AUDIO," +
                    $"GROUP-ID=\"audio\"," +
                    $"NAME=\"{a.LocaleCode}\"," +
                    $"LANGUAGE=\"{a.LocaleCode}\"," +
                    $"AUTOSELECT=YES," +
                    $"URI=\"/stream/{episodeId}/audio/{a.Id}/playlist\"");
            }

            foreach (var s in episode.VideoSubtitles)
            {
                sb.AppendLine(
                    $"#EXT-X-MEDIA:TYPE=SUBTITLES," +
                    $"GROUP-ID=\"subs\"," +
                    $"NAME=\"{s.Title}\"," +
                    $"LANGUAGE=\"{s.LocaleCode}\"," +
                    $"AUTOSELECT=YES," +
                    $"URI=\"/stream/{episodeId}/subtitles/{s.Id}.vtt\"");
            }

            foreach (var v in episode.VideoFiles)
            {
                sb.AppendLine(
                    $"#EXT-X-STREAM-INF:" +
                    $"BANDWIDTH={v.BitrateKbps * 1000}," +
                    $"RESOLUTION={v.Resolution}," +
                    $"CODECS=\"avc1.640028\"," +
                    $"AUDIO=\"audio\"," +
                    $"SUBTITLES=\"subs\"");

                sb.AppendLine(
                    $"/stream/{episodeId}/video/{v.Id}/playlist");
            }

            return sb.ToString();
        }
    }
}
