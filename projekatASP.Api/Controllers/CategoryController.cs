using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.DTO.Searches;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
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
    public class CategoryController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CategoryController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        /// <summary>
        /// Search through categories with pagination.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Category/keyword=
        ///     {
        ///        "keyword":"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull seraching.</response>
        /// <response code="400">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get ([FromQuery] MainPaginationSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Finds category through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Category/id
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull finding.</response>
        /// <response code="404">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCategoryQuery findCategory)
        {
            return Ok(_handler.HandleQuery(findCategory, id));
        }


        /// <summary>
        /// Creates new category.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Category
        ///     {
        ///        "name:"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDTO dto, [FromServices] ICreateCategoryCommand categoryCommand)
        {
            _handler.HandleCommand(categoryCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Changes category through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Category/id
        ///     {
        ///        "name:"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateCategoryDTO dto, [FromServices] IEditCategoryCommand categoryCommand)
        {
            dto.Id = id;
            _handler.HandleCommand(categoryCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes category through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Category
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull delete.</response>
        /// <response code="404">Delete failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand categoryCommand)
        {
            _handler.HandleCommand(categoryCommand, id);
            return NoContent();
        }
    }
}
