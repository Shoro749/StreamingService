using StreamingService.DTO;

namespace StreamingService.Service
{
    public interface IStreamStorage
    {
        //Task<string> Get

        Task<StreamFileViewModel?> GetVideoManifestAsync(
            int episodeId,
            int videoFileId,
            CancellationToken token);
        Task<StreamFileViewModel?> GetVideoSegmentAsync(
            int episodeId,
            int videoFileId,
            string file,
            CancellationToken token);
        Task<StreamFileViewModel?> GetAudioManifestAsync(
            int episodeId,
            int audioId,
            CancellationToken token);
        Task<StreamFileViewModel?> GetAudioSegmentAsync(
            int episodeId,
            int audioId,
            string file,
            CancellationToken token);
        Task<StreamFileViewModel?> GetSubtitleAsync(
            int episodeId,
            int subtitleId,
            CancellationToken token);
    }

}
