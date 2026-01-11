namespace StreamingService.DTO
{
    public class StreamFileViewModel
    {
        public Stream Stream { get; init; } = default!;
        public string ContentType { get; init; } = default!;
        public bool EnableRange { get; init; }
    }
}
