using BatchAPI.AppLog;
using BatchAPI.DataContext;
using BatchAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BatchAPI.Services
{
    public class BatchServices : IBatchServices
    {
        private readonly BatchContext _context;
        private Files _objFile;
        private Batch _objBatch;// Rename wirth a better nomencltuew

        public BatchServices(BatchContext context, ILog logger, Batch objBatch,Files objfiles)
        {
            _context = context;
            _objBatch = objBatch;
            _objFile = objfiles;
        }
        public async Task<Batch> GetBatch([FromRoute] Guid id)
        {
            //_objBatch = await _context.BatchDetails.FindAsync(Convert.ToString(id));
            _objBatch = await _context.BatchDetails.Include(a => a.Files)
                .Where(x => x.BatchId == Convert.ToString(id)).FirstOrDefaultAsync();
            return _objBatch;
        }

        public async Task<Batch> PostBatch(BatchRequest objBatchRequest, IFormFile file)
        {
            Guid objGuid = Guid.NewGuid();
            _objBatch.BatchId = objGuid.ToString();
            _objBatch.BusinessUnit = objBatchRequest.BusinessUnit;
            _objBatch.ExpiryDate = objBatchRequest.ExpiryDate;
            _objBatch.ReadGroups = objBatchRequest.ReadGroups;
            _objBatch.ReadUsers = objBatchRequest.ReadUsers;
            _objBatch.Status = objBatchRequest.Status;
            _objBatch.KeyAttribute = objBatchRequest.KeyAttribute;
            _objBatch.ValueAttribute = objBatchRequest.ValueAttribute;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    _objFile.Filedata = fileBytes;
                    _objFile.FileName = file.FileName;
                    _objFile.FileType = file.ContentType;
                }
            }
            _objBatch.Files = _objFile;
            _context.BatchDetails.Add(_objBatch);
            await _context.SaveChangesAsync();
            return _objBatch;
        }
    }
}
