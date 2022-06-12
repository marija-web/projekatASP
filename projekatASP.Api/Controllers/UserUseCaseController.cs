using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.Application.UseCases;
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
    public class UserUseCaseController : ControllerBase
    {

        private UseCaseHandler _handler;

        public UserUseCaseController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        /// <summary>
        /// Search through use cases logs with pagination.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/User?keyword=
        ///     {
        ///        "keyword":"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull seraching.</response>
        /// <response code="400">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET: api/<UserUseCaseController>
        [HttpGet]
        public IActionResult Get([FromQuery] MainPaginationSearch search, [FromServices] IGetUseCaseLogsQuery useCaseLogsQuery)
        {
            return Ok(_handler.HandleQuery(useCaseLogsQuery, search));
        }

        /// <summary>
        /// Inserting new use cases for a user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/User/id
        ///     {
        ///        "UserId:"int",
        ///        "UseCaseIds:"array",
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<UserUseCaseController>
        [HttpPut]
        public IActionResult Put([FromBody] EditUseCasesDTO dto, [FromServices] IEditUserCaseCommand userCaseCommand)
        {
            _handler.HandleCommand(userCaseCommand, dto);
            return StatusCode(201);
        }



    }
}
