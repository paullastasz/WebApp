using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Requests;
using WebApp.Application.DTOs;
using WebApp.Application.Interfaces.Services;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        [HttpPost("FromLast3Months")]
        public async Task<IActionResult> GetFromLast3MonthsAsync([FromQuery]PageableRequest pageableRequest, 
                                                                 [FromServices]ITransactionsService transactionsService)
        {
            GetTransactionsRequestDTO request = new GetTransactionsRequestDTO 
            {
                P_TAKE  = pageableRequest.Take.HasValue ? pageableRequest.Take.Value.ToString() : "50",
                P_SKIP  = pageableRequest.Skip.HasValue ? pageableRequest.Skip.Value.ToString() : "0",
            };

            var result = await transactionsService.GetFromLast3Months(request);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(string.Join("; ", result.Errors.Select(e => e.Message)));
        }
    }
}
