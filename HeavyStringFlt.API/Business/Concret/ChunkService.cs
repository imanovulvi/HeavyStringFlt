using HeavyStringFlt.API.Models;
using System.Collections.Concurrent;

namespace HeavyStringFlt.API.Business.Concret
{
    public class ChunkService
    {
        private readonly ConcurrentDictionary<string, SortedDictionary<int, string>> heavyStrings = new();


        public void Add(Chunk chunk)
        {
            var sorted = heavyStrings.GetOrAdd(chunk.UploadId, _ => new SortedDictionary<int, string>());
            lock (sorted)
            {
                sorted.Add(chunk.ChunkIndex, chunk.Data+" ");
            }

        }

        public string Combine(string uploadId)
        {
            var lst = heavyStrings.FirstOrDefault(x => x.Key == uploadId);
            string textCombine = "";

            foreach (var hs in lst.Value)
            {
                textCombine += hs.Value;
            }
            return textCombine;
        }
    }
}
