namespace StreamingService.DTO.ViewModels
{
    public class PlayerViewModel
    {
        public EpisodeViewModel CurrentEpisode { get; set; }
        public VideoPlayerVideoViewModel CurrentQualities { get; set; }
        public VideoPlayerAudioViewModel CurrentVoiceAction { get; set; }
        public VideoPlayerSubtitlesViewModel CurrentSubtitles { get; set; }

        public List<EpisodeViewModel> Episodes { get; set; }
        public List<VideoPlayerVideoViewModel> Qualities { get; set; }
        public List<VideoPlayerAudioViewModel> VoiceAction { get; set; }
        public List<VideoPlayerSubtitlesViewModel> Subtitles { get; set; }
    }
}
