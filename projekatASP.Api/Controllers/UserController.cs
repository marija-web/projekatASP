using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UserController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UserController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        /// <summary>
        /// Search through users with pagination.
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
        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] MainPaginationSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Finds user through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/User/id
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull finding.</response>
        /// <response code="404">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IFindUserQuery findUser)
        {
            return Ok(_handler.HandleQuery(findUser, id));
        }


        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User
        ///     {
        ///        "Email:"string",
        ///        "Username:"string",
        ///        "FirstName:"string",
        ///        "LastName:"string",
        ///        "Password:"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        //REGISTRACIJA
        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] RegisterDTO dto, [FromServices] IRegisterUserCommand registerUserCommand)
        {
            _handler.HandleCommand(registerUserCommand, dto);
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        /// Changes user through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/User/id
        ///     {
        ///        "Email:"string",
        ///        "Username:"string",
        ///        "FirstName:"string",
        ///        "LastName:"string",
        ///        "Password:"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] RegisterDTO dto, [FromServices] IEditUserCommand userCommand)
        {
            dto.Id = id;
            _handler.HandleCommand(userCommand, dto);
            return StatusCode(201);
        }



        /// <summary>
        /// Deletes user through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/User
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull delete.</response>
        /// <response code="404">Delete failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand userCommand)
        {
            _handler.HandleCommand(userCommand, id);
            return NoContent();
        }
    }
}
