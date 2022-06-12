using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.DTO.Searches;
using projekatASP.Application.UseCases.Queries;
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
    public class TagController : ControllerBase
    {
        private UseCaseHandler _handler;

        public TagController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Search through tags with pagination.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Tag?keyword=
        ///     {
        ///        "keyword":"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull seraching.</response>
        /// <response code="400">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get([FromQuery] MainPaginationSearch search, [FromServices] IGetTagsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Finds tag through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Tag/id
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull finding.</response>
        /// <response code="404">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindTagQuery findTag)
        {
            return Ok(_handler.HandleQuery(findTag, id));
        }


        /// <summary>
        /// Creates new tag.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Tag
        ///     {
        ///        "name":"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<TagController>
        [HttpPost]
        public IActionResult Post([FromBody] TagDTO dto, [FromServices] ICreateTagCommand tagCommand)
        {
            _handler.HandleCommand(tagCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Changes tag through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Tag/id
        ///     {
        ///        "name":"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TagDTO dto, [FromServices] IEditTagCommand tagCommand)
        {
            dto.Id = id;
            _handler.HandleCommand(tagCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes tag through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Tag
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull delete.</response>
        /// <response code="404">Delete failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand tagCommand)
        {
            _handler.HandleCommand(tagCommand, id);
            return NoContent();
        }
    }
}
