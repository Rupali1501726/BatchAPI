using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BatchAPI.DataContext;
using Newtonsoft.Json;
using BatchAPI.AppLog;
using Microsoft.OpenApi.Writers;
using BatchAPI.Entities;
using BatchAPI.Services;
using System.Net;

namespace BatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly ILog _logger;
        private Batch _objBatch;// Rename wirth a better nomencltuew
        private IBatchServices _objBatchService;
        private AddBatchResponse _objAddBatchResponse;

        public BatchController(ILog logger, Batch objBatch,IBatchServices objBatchService,AddBatchResponse objAddBatchResponse)
        {
            _logger = logger;
            _objBatch = objBatch; 
            _objBatchService = objBatchService;
            _objAddBatchResponse = objAddBatchResponse;
        }

        // GET: api/Batches
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Batch>>> GetBatchDetails()
        //{
        //  if (_context.BatchDetails == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.BatchDetails.ToListAsync();
        //}

        // GET: api/Batches/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Batch>> GetBatch([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.Information("400 : Bad request");
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                _objBatch = await _objBatchService.GetBatch(id);
                if (_objBatch == null)
                {
                    _logger.Information("data not found");
                    return NotFound();
                }
                return Ok(_objBatch);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return _objBatch;
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<string>> Get(int id)
        //{
        //    if (_context.BatchDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    var batch = await _context.BatchDetails.FindAsync(id);

        //    if (batch == null)
        //    {
        //        return NotFound();
        //    }

        //    return batch.BatchId == null ? "NA" : batch.BatchId;
        //}

        // PUT: api/Batches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBatch(int id, Batch batch)
        //{
        //    if (id != batch.BatchId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(batch).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BatchExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Batches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddBatchResponse>> PostBatch([FromForm]BatchRequest objBatchRequest, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.Information("400 : Bad request");
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                _objBatch = await _objBatchService.PostBatch(objBatchRequest, file);
                _objAddBatchResponse.BatchId = _objBatch.BatchId;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return Ok(_objAddBatchResponse);
        }

        // DELETE: api/Batches/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBatch(int id)
        //{
        //    if (_context.BatchDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    var batch = await _context.BatchDetails.FindAsync(id);
        //    if (batch == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.BatchDetails.Remove(batch);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BatchExists(int id)
        //{
        //    return (_context.BatchDetails?.Any(e => e.BatchId == id)).GetValueOrDefault();
        //}
    }
}
