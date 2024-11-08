using Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HuquqApi.Controllers
{
    [Authorize(Roles = "MasterAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogsController : ControllerBase
    {
        private readonly HuquqDbContext _dbContext;

        public ErrorLogsController(HuquqDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("failed-requests")]
        public async Task<IActionResult> GetFailedRequestLogs()
        {
            var failedRequests = await _dbContext.RequestLogs
                .Where(log => !log.IsSuccessful)
                .Select(log => new
                {
                    log.IpAddress,
                    log.Path,
                    log.Timestamp,
                    log.ErrorMessage,
                    log.StackTrace
                })
                .ToListAsync();

            return Ok(failedRequests);
        }
    }



}
