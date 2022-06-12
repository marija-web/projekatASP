using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikeDislikeController : ControllerBase
    {

        private UseCaseHandler _handler;

        public LikeDislikeController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Creates new like or dislike for given post and user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/LikeDislike
        ///     {
        ///        "Like:"bool",
        ///        "PostId":"null",
        ///        "UserId:"null"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<LikeDislikeController>
        [HttpPost]
        public IActionResult Post([FromBody] LikeDTO dto, [FromServices] ICreateLikeDislikeCommand likeDislikeCommand)
        {
            _handler.HandleCommand(likeDislikeCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Changes like or dislike for given post and user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/LikeDislike
        ///     {
        ///        "Like:"bool",
        ///        "PostId":"null",
        ///        "UserId:"null"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<LikeDislikeController>/5
        [HttpPut]
        public IActionResult Put([FromBody] LikeDTO dto, [FromServices] IEditLikeDislikeCommand likeDislikeCommand)
        {
            _handler.HandleCommand(likeDislikeCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes like or dislike for given post and user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/LikeDislike
        ///     {
        ///        "Like:"bool",
        ///        "PostId":"null",
        ///        "UserId:"null"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull delete.</response>
        /// <response code="404">Delete failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // DELETE api/<LikeDislikeController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] LikeDTO dto, [FromServices] IDeleteLikeDislikeCommand likeDislikeCommand)
        {
            _handler.HandleCommand(likeDislikeCommand, dto);
            return NoContent();
        }
    }
}
