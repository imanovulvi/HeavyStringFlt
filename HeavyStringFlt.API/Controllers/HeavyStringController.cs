using HeavyStringFlt.API.Business.Concret;
using HeavyStringFlt.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeavyStringFlt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeavyStringController : ControllerBase
    {
        private readonly ChunkService _chunkService;
        private readonly BackgroundQueue _backgroundQueue;

        public HeavyStringController(ChunkService chunkService, BackgroundQueue backgroundQueue)
        {
            _chunkService = chunkService;
            _backgroundQueue = backgroundQueue;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(Chunk chunk)
        {
            
            _chunkService.Add(chunk);
            if (chunk.IsLastChunk)
            {
                string combine = _chunkService.Combine(chunk.UploadId);

                if (combine is not null)
                    _backgroundQueue.Enqueue(combine);
            }

            return Ok(new { Status = "Accepted" });
        }
    }

}

