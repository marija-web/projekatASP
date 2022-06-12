using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekatASP.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JWTManager _manager;

        public TokenController(JWTManager manager)
        {
            _manager = manager;
        }


        /// <summary>
        /// Creates new token for a user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Token
        ///     {
        ///        "email:"string",
        ///        "password":string
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Token Successfully made.</response>
        /// <response code="422">Unprocessable Entity.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<TokenController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] TokenRequest request)
        {
            try
            {
                var token = _manager.MakeToken(request.Email, request.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

    public class TokenRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
