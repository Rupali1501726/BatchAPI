using BatchAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BatchAPI.Services
{
    public interface IBatchServices
    {
        Task<Batch> GetBatch(Guid id);
        Task<Batch> PostBatch(BatchRequest objBatchRequest, IFormFile file);
    }
}
