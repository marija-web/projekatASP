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
    public class CommentController : ControllerBase
    {

        private UseCaseHandler _handler;

        public CommentController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Creates new comment for a given post and user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Comment
        ///     {
        ///        "Comment:"string",
        ///        "PostId:"null",
        ///        "UserId":"null"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentForPostDTO dto, [FromServices] ICreateCommentCommand commentCommand)
        {
            _handler.HandleCommand(commentCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Changes comment through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Comment/id
        ///     {
        ///        "Comment:"string",
        ///        "PostId:"null",
        ///        "UserId":"null"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateCommentForPostDTO dto, [FromServices] IEditCommentCommand commentCommand)
        {
            dto.Id = id;
            _handler.HandleCommand(commentCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes comment through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Comment
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull delete.</response>
        /// <response code="404">Delete failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand commentCommand)
        {
            _handler.HandleCommand(commentCommand, id);
            return NoContent();
        }
    }
}
