using CleanArchitecture.Common.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Common.ApiHelper.Controller
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult ApiResult(Response response)
        {
            if (response != null)
            {
                if (response.IsSuccess == true)
                {
                    return Ok(response);
                }
                else if (response.Type == ResponseType.NotFound)
                {
                    if (response.Message != null)
                    {
                        return NotFound(response.Message);
                    }
                    return NotFound();
                }
                else if (response.Type == ResponseType.BadRequest)
                {
                    return BadRequest(ModelState);
                }
                else if (response.Type == ResponseType.Conflict)
                {
                    return Conflict(response);
                }
                else if (response.Type == ResponseType.NotAllowed)
                {
                    return StatusCode(405, response.Message);
                }
                else if (response.Type == ResponseType.Unknown)
                {
                    return StatusCode(500, response.Message);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return NoContent();
            }
        }
    }

}