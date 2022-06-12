using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.Api.DTO;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.DTO.Searches;
using projekatASP.Application.UseCases.Queries;
using projekatASP.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private UseCaseHandler _handler;

        public PostController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        public static IEnumerable<string> AllowedExtensions =>
            new List<string> { ".jpg", ".png", ".jpeg", ".gif" };



        /// <summary>
        /// Search through posts with pagination.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Post?keyword=
        ///     {
        ///        "keyword":"string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull seraching.</response>
        /// <response code="400">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET: api/<PostController>
        [HttpGet]
        public IActionResult Get([FromQuery] MainPaginationSearch search, [FromServices] IGetPostsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Finds post through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Post/id
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Successfull finding.</response>
        /// <response code="404">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindPostQuery findPost)
        {
            return Ok(_handler.HandleQuery(findPost, id));
        }

        /// <summary>
        /// Creates new post.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Post
        ///     {
        ///        "FileImage":"New image",
        ///        "Title":"string",
        ///        "Caption":"string",
        ///        "CategoryId":"null",
        ///        "UserId":"null",
        ///        "TagId":"null",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<PostController>
        [HttpPost]
        public IActionResult Post([FromForm] UploadFileDTO dto, [FromServices] ICreatePostCommand postCommand)
        {
            if (dto.FileImage != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.FileImage.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("This file type is not eligible, try another one(ex. .gif, .png, .jpg...)");
                } 

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);

                dto.FileImage.CopyTo(stream);
                    
                dto.FileImageName = fileName;
            }

            _handler.HandleCommand(postCommand, dto);
            return StatusCode(201);
        }



        /// <summary>
        /// Changes post through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Post/id
        ///     {
        ///        "FileImage":"New image",
        ///        "Title":"string",
        ///        "Caption":"string",
        ///        "CategoryId":"null",
        ///        "UserId":"null",
        ///        "TagId":"null",
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull modification.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UploadFileDTO dto, [FromServices] IEditPostCommand postCommand)
        {
            if (dto.FileImage != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.FileImage.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("This file type is not eligible, try another one(ex. .gif, .png, .jpg...)");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);

                dto.FileImage.CopyTo(stream);

                dto.FileImageName = fileName;
            }


            dto.Id = id;
            _handler.HandleCommand(postCommand, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes post through requested id.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Post
        ///     {
        ///        "id:"int"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull delete.</response>
        /// <response code="404">Delete failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand postCommand)
        {
            _handler.HandleCommand(postCommand, id);
            return NoContent();
        }
    }
}
