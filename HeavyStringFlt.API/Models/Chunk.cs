namespace HeavyStringFlt.API.Models
{
    public sealed record class Chunk
    {
        public string UploadId { get; set; }
        public int ChunkIndex { get; set; }
        public string Data { get; set; }
        public bool IsLastChunk { get; set; }
    }
}
